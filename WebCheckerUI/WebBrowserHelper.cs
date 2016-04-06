using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WebCheckerUI
{
    class WebBrowserHelper
    {
        public Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }
        public static Image getScreenshot(WebBrowser webBrowser)
        {
            return getScreenshot(webBrowser, 0);
        }
        public static Image getScreenshot(WebBrowser webBrowser, int delayCaptureTime)
        {
            
            System.Threading.Thread.Sleep(delayCaptureTime);

            int WW = webBrowser.Document.Body.ClientRectangle.Size.Width;
            int HH = webBrowser.Document.Body.ClientRectangle.Size.Height;

            Bitmap bitmap = new Bitmap(WW, HH);
            Rectangle bitmapRect = new Rectangle(0, 0, WW, HH);
            webBrowser.DrawToBitmap(bitmap, bitmapRect);

            System.Drawing.Image origImage = bitmap;
            System.Drawing.Image origThumbnail = new Bitmap(WW, HH, origImage.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(origThumbnail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, WW, HH);
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
