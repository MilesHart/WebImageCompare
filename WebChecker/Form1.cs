using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WebChecker
{
    public partial class Form1 : Form
    {
        int i = 0;
        public bool virgin;
        //List<Image> images = new List<Image>();

        List<KeyValuePair<int, Image>> dImages = new List<KeyValuePair<int, Image>>();
        List<KeyValuePair<int, Image>> diffImages = new List<KeyValuePair<int, Image>>();

        public Form1()
        {
            InitializeComponent();
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(128, 128);
            
            this.listView1.LargeImageList = this.imageList1;
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            this.listView1.Click += new EventHandler(listView1_Click);
            this.virgin = true;
        }

        void listView1_Click(object sender, EventArgs e)
        {

            Image ih = null;
            Image iDiff = null;
            foreach(KeyValuePair<int, Image> ii in this.dImages)
            {
                if (ii.Key == this.listView1.SelectedItems[0].Index)
                    ih = ii.Value;
            }
            
            this.pictureBox1.Image = ih;

            foreach (KeyValuePair<int, Image> id in this.diffImages)
            {
                if (id.Key == this.listView1.SelectedItems[0].Index)
                    iDiff = id.Value;
            }
            
            this.pictureBox2.Image = iDiff;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            this.webBrowser1.Width = 1024;
            this.webBrowser1.Height = 768;
            if (!this.textBox1.Text.StartsWith("http://"))
                this.textBox1.Text = "http://" + this.textBox1.Text;
            this.webBrowser1.Url = new Uri(this.textBox1.Text);
            
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(webBrowser1.ReadyState);
            //System.Threading.Thread.Sleep((int)numericUpDown1.Value);
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete);

            Bitmap bitmap = new Bitmap(1024, 768);
            Rectangle bitmapRect = new Rectangle(0, 0, 1024, 768);
            this.webBrowser1.DrawToBitmap(bitmap, bitmapRect);

            System.Drawing.Image origImage = bitmap;
            System.Drawing.Image origThumbnail = new Bitmap(1024, 768, origImage.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(origThumbnail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, 1024, 768);
            oGraphic.DrawImage(origImage, oRectangle);

            imageList1.Images.Add(origImage);
            
            dImages.Add(new KeyValuePair<int, Image>(i, origThumbnail));

            //if (images.Count > 10) images.RemoveAt(0)
            listView1.Items.Add(DateTime.Now.ToString("dd MMM yyyy hh:mm:ss"), i++);

            origThumbnail.Save("Screenshot.png", ImageFormat.Png);
            origImage.Dispose();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image i1 = this.dImages[this.dImages.Count-1].Value;
            Image i2 = this.dImages[this.dImages.Count-2].Value;
            double err = 0;
            Bitmap diff = new Bitmap(i1.Width, i1.Height);
            bitmapCompare.CompareResult r = bitmapCompare.Compare(false, new Bitmap(i1), new Bitmap(i2), out err, out diff);
            diffImages.Add(new KeyValuePair<int, Image>(i-1, diff));
            MessageBox.Show(err.ToString() + "%\r\n\r\n" + r.ToString());
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }


    }
}
