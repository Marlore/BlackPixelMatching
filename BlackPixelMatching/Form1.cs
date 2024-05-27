using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace BlackPixelMatching
{
    public partial class Form1 : Form
    {
        string FilePath;
        Dictionary<int,string> ConvertList;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            Convert();
            var dic =ConvertList.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in dic)
                listBox1.Items.Add(item.Value);

        }
        
        private async void Convert()
        {
            List<Thread> tasks = new List<Thread>();
            ConvertList = new Dictionary<int, string>();
            using (var rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.GraphicsAlphaBits = (int)GhostscriptImageDeviceAlphaBits.V_4;
                rasterizer.TextAlphaBits = (int)GhostscriptImageDeviceAlphaBits.V_4;
                rasterizer.Open(FilePath);
                int pageCount = rasterizer.PageCount;
                int PageToThread = 20;
                int taskCount = (int)Math.Ceiling((float)pageCount / PageToThread);
                
                for (int i = 0; i < taskCount; i++)
                {

                    if ((i + 1) * PageToThread > pageCount && i * PageToThread < pageCount)
                    {
                        int startPage = (i * PageToThread) + 1;
                        var thread = new Thread(()=> RenderCounter(startPage, pageCount, rasterizer));
                        thread.Start();
                        tasks.Add(thread);
                    }

                    else if((i + 1) * PageToThread <= pageCount)
                    {
                        int startPage = (i * PageToThread) + 1;
                        int endPage = (i + 1) * PageToThread;
                        var thread = new Thread(() => RenderCounter(startPage, endPage, rasterizer));
                        thread.Start();
                        tasks.Add(thread);
                    }
                }
                foreach (var task in tasks)
                {
                    task.Join();
                }

                rasterizer.Close();
                rasterizer.Dispose();
            }
           
        }
        private async void RenderCounter(int from,int to, GhostscriptRasterizer rasterizer)
        {
            for (int pageNumber = from; pageNumber <= to; pageNumber++)
            {
                var outputFormat = ImageFormat.Png;
                var image = rasterizer.GetPage(300, pageNumber);
                var bitmap = new Bitmap(image);
                var count = BlackPixelCount(bitmap);
                ConvertList.Add(pageNumber, Path.GetFileName(FilePath) + " Page:" + pageNumber + " Black pixel percent: " + (count * 100) + "%");
            }
        }

        private float BlackPixelCount(Bitmap bmp)
        {
            int blackColor = 0;
            int count = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    count++;
                    if (color.ToArgb() != Color.White.ToArgb())
                        blackColor++;
                }
            }
            return (float)blackColor/count;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){}

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e){}

        private void PathExplorer_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1.Filter = "Pdf Files|*.pdf";
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.ShowDialog();
            var fileName = this.openFileDialog1.FileName;
            textBox1.Text = fileName;
            FilePath =fileName;

        }
    }
}
