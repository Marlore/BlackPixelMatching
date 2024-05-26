namespace BlackPixelMatching
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            PathExplorer = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(273, 314);
            button1.Name = "button1";
            button1.Size = new Size(158, 60);
            button1.TabIndex = 0;
            button1.Text = "Посчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(2, 94);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(795, 214);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(187, 61);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 2;
            label1.Text = "Укажите путь:";
            // 
            // PathExplorer
            // 
            PathExplorer.BackColor = SystemColors.ControlLight;
            PathExplorer.Image = (Image)resources.GetObject("PathExplorer.Image");
            PathExplorer.Location = new Point(470, 51);
            PathExplorer.Name = "PathExplorer";
            PathExplorer.Size = new Size(39, 34);
            PathExplorer.TabIndex = 3;
            PathExplorer.UseVisualStyleBackColor = false;
            PathExplorer.Click += PathExplorer_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(282, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 23);
            textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(PathExplorer);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private Button PathExplorer;
        private TextBox textBox1;
    }
}
