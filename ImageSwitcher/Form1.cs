using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSwitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public byte[] GetPictureData(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }

        private void saveByteBtn_Click(object sender, EventArgs e)
        {
            string byteResult = "";
            string imgPath = "C:/Users/Public/Pictures/Sample Pictures/t.jpg";
            byte[] valByte = GetPictureData(imgPath);
            //byteResult = System.Text.Encoding.Default.GetString(valByte);
            byteResult = "{" + string.Join(",", valByte) + "}";
            valTbx.Text = byteResult;
        }
    }
}
