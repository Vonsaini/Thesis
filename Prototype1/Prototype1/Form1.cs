using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;
using System.IO;


namespace Prototype1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select File";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            { textBox2.Text = openFileDialog1.FileName; }
            else
            { textBox2.Text = "You didn't select the file!"; }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var Ocr = new IronTesseract(); // nothing to configure
            Ocr.Language = OcrLanguage.English;
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            using (var Input = new OcrInput())
            {
                Input.AddImage(textBox2.Text);
                var Result = Ocr.Read(Input);
                Console.WriteLine(Result.Text);
                Result.SaveAsTextFile("ocrtext.docx");
            }
        }

    }

      

       
        

    
}
