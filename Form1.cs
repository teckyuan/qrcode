using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IMAGE_PATH = ConfigurationManager.AppSettings["IMAGE_PATH"];
            string file_name = textBox2.Text;

            int width =Convert.ToInt16( ConfigurationManager.AppSettings["WIDTH"]);
            int height = Convert.ToInt16(ConfigurationManager.AppSettings["HEIGHT"]);
            // instantiate a writer object
            var barcodeWriter = new BarcodeWriter();
            
            // set the barcode format
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new EncodingOptions
            {
                Height = height,
                Width = width,
                Margin = 1
            };
            // write text and generate a 2-D barcode as a bitmap
            barcodeWriter
                .Write(textBox1.Text)
                .Save($"{IMAGE_PATH}{file_name}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string OUTPUT_PATH = ConfigurationManager.AppSettings["OUTPUT_PATH"];//OUTPUT_PATH

            Byte[] bytes = File.ReadAllBytes(textBox3.Text);
            String output_string = Convert.ToBase64String(bytes);

            File.WriteAllText(OUTPUT_PATH, output_string);

        }
    }
}
