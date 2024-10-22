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
            await Convert();
        }
        
        private async Task Convert()
        {
            using (var rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.GraphicsAlphaBits = (int)GhostscriptImageDeviceAlphaBits.V_4;
                rasterizer.TextAlphaBits = (int)GhostscriptImageDeviceAlphaBits.V_4;
                rasterizer.Open(FilePath);
                int pageCount = rasterizer.PageCount;
                for (int i = 1; i <= pageCount; i++)
                {
                    await RenderCounter(i, rasterizer);
                }
                rasterizer.Close();
                rasterizer.Dispose();
            }
           
        }
        private async Task RenderCounter(int page, GhostscriptRasterizer rasterizer)
        {
            var image = rasterizer.GetPage(300, page);
            var bitmap = new Bitmap(image);
            int blackColor = 0;
            int count = bitmap.Width* bitmap.Height;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.ToArgb() != Color.White.ToArgb())
                        blackColor++;
                }
            }
            float blackPixelPercent = blackColor / count;
            listBox1.Items.Add(Path.GetFileName(FilePath) + " Page:" + page + " Black pixel percent: " + (blackPixelPercent) + "%");           
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
