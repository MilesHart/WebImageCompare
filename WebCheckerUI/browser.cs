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

namespace WebCheckerUI
{
    public partial class browser : Form
    {
        public int loadTimer = 0;
        DateTime startDt;
        public Image screenShot { get; set; }
        public int bWidth { get; set; }
        public int bHeight { get; set; }
        public browser(string url)
        {
            InitializeComponent();
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigate(url);
            //this.webBrowser1.Url = new Uri(url);
            startDt = DateTime.Now;
            //this.webBrowser1.Width = 1024;
            //this.webBrowser1.Height = 768;

            this.button1.Enabled = false;
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.button1.Enabled = true;

            //System.Threading.Thread.Sleep(delayCaptureTime);
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            this.loadTimer = (int)DateTime.Now.Subtract(this.startDt).TotalMilliseconds;

            //this.bHeight = this.webBrowser1.Document.Body.ClientRectangle.Height;
            //this.bWidth = this.webBrowser1.Document.Body.ClientRectangle.Width;
            this.bHeight = this.webBrowser1.Document.Body.ScrollRectangle.Height + 100;
            this.bWidth = this.webBrowser1.Document.Body.ScrollRectangle.Width + 100;

            System.Diagnostics.Debug.WriteLine("Height:" + this.bHeight.ToString());
            System.Diagnostics.Debug.WriteLine("Weight:" + this.bWidth.ToString());

            //this.webBrowser1.Width = websitewidth;
            //this.webBrowser1.Height = websiteheight;

            //Bitmap bitmap = new Bitmap(websitewidth, websiteheight);
            //Rectangle bitmapRect = new Rectangle(0, 0, websitewidth, websitewidth);
            //this.webBrowser1.DrawToBitmap(bitmap, bitmapRect);

            //System.Drawing.Image origImage = bitmap;
            //System.Drawing.Image origThumbnail = new Bitmap(websitewidth, websitewidth, origImage.PixelFormat);
            //Graphics oGraphic = Graphics.FromImage(origThumbnail);
            //oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            //oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            //oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //Rectangle oRectangle = new Rectangle(0, 0, websitewidth, websitewidth);
            //oGraphic.DrawImage(origImage, oRectangle);

            //////imageList1.Images.Add(origImage);

            ////dImages.Add(new KeyValuePair<int, Image>(i, origThumbnail));

            //////if (images.Count > 10) images.RemoveAt(0)
            ////listView1.Items.Add(DateTime.Now.ToString("dd MMM yyyy hh:mm:ss"), i++);

            //origImage.Save("Screenshot.png", ImageFormat.Png);
            ////origImage.Dispose();
            //this.pictureBox1.Image = origImage;
            //this.screenShot = origImage;
            //return origImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //screenShot = getScreenshot();
            //this.pictureBox1.Image = screenShot;
            //this.Hide();
            WebBrowser wb = new WebBrowser();
            wb.Width = this.bWidth;
            wb.Height = this.bHeight;
            
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.Navigate(this.webBrowser1.Url);

            //wb.Url = this.webBrowser1.Url;
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete);

            System.Threading.Thread.Sleep(20000);

            this.screenShot = getScreenshot(sender as WebBrowser);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        public Image getScreenshot(WebBrowser wb)
        {
            // first one
            if (this.bHeight == 0 && this.bWidth == 0)
            {
                this.bHeight = wb.Document.Body.ClientRectangle.Height;
                this.bWidth = wb.Document.Body.ClientRectangle.Width;
            }


            Bitmap bitmap = new Bitmap(this.bWidth, this.bHeight);
            Rectangle bitmapRect = new Rectangle(0, 0, this.bWidth, this.bHeight);
            wb.DrawToBitmap(bitmap, bitmapRect);

            System.Drawing.Image origImage = bitmap;
            System.Drawing.Image origThumbnail = new Bitmap(this.bWidth, this.bHeight, origImage.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(origThumbnail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, this.bWidth, this.bHeight);
            oGraphic.DrawImage(origImage, oRectangle);

            ////imageList1.Images.Add(origImage);

            //dImages.Add(new KeyValuePair<int, Image>(i, origThumbnail));

            ////if (images.Count > 10) images.RemoveAt(0)
            //listView1.Items.Add(DateTime.Now.ToString("dd MMM yyyy hh:mm:ss"), i++);

            origThumbnail.Save("Screenshot.png", ImageFormat.Png);
            origImage.Dispose();
            return origThumbnail;

        }
        public Image getScreenshot()
        {
            // second one
            //System.Threading.Thread.Sleep(delayCaptureTime);
            //if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
            //    return;

            if (this.bHeight == 0 && this.bWidth == 0)
            {
                this.bHeight = this.webBrowser1.Document.Body.ClientRectangle.Height;
                this.bWidth = this.webBrowser1.Document.Body.ClientRectangle.Width;
            }
            System.Diagnostics.Debug.WriteLine("Width:" + this.bWidth);
            System.Diagnostics.Debug.WriteLine("Height:" + this.bHeight);


            Bitmap bitmap = new Bitmap(this.bWidth, this.bHeight);
            Rectangle bitmapRect = new Rectangle(0, 0, this.bWidth, this.bHeight);
            this.webBrowser1.DrawToBitmap(bitmap, bitmapRect);

            System.Drawing.Image origImage = bitmap;
            System.Drawing.Image origThumbnail = new Bitmap(this.bWidth, this.bHeight, origImage.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(origThumbnail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, this.bWidth, this.bHeight);
            oGraphic.DrawImage(origImage, oRectangle);

            ////imageList1.Images.Add(origImage);

            //dImages.Add(new KeyValuePair<int, Image>(i, origThumbnail));

            ////if (images.Count > 10) images.RemoveAt(0)
            //listView1.Items.Add(DateTime.Now.ToString("dd MMM yyyy hh:mm:ss"), i++);

            origThumbnail.Save("Screenshot.png", ImageFormat.Png);
            //origImage.Dispose();
            return origImage;

        }
    }
}
