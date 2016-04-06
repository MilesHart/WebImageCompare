using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebCheckerUI
{
    public partial class Form1 : Form
    {

        bool isbusy;
        public Form1()
        {
         
            InitializeComponent();
            isbusy = false;
        }

        private void cmdAddUrl_Click(object sender, EventArgs e)
        {
            string turl = this.txtUrlAdd.Text;
            if (!turl.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase))
                turl = "http://" + turl;


            server s = new server
            {
                url = turl,
                name = this.txtName.Text
            };
            browser b = new browser(s.url);
            if (b.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            this.pictureBox1.Image = b.screenShot;
            s.delay = b.loadTimer;
            s.goodImage = b.screenShot;
            s.width = b.bWidth;
            s.height = b.bHeight;
            s.confirmed = true;
            this.lbUrls.Items.Add(s);

        }

        private void cmdDeleteUrl_Click(object sender, EventArgs e)
        {
            if (this.lbUrls.SelectedIndex == -1) return;
            this.lbUrls.Items.RemoveAt(this.lbUrls.SelectedIndex);

        }

        private void lbUrls_Click(object sender, EventArgs e)
        {

        }

        private void lbUrls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbUrls.SelectedIndex == -1) return;
            this.pictureBox1.Image = ((server)this.lbUrls.SelectedItem).goodImage;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser wbcomp = new WebBrowser();
            

            wbcomp.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbcomp_DocumentCompleted);
            // start schedule
            foreach (server s in this.lbUrls.Items)
            {
                wbcomp.Width = s.goodImage.Width;
                wbcomp.Height = s.goodImage.Height;
                ouput(s.url);
                
                // get the new thumbnail
                //wbcomp.Width = s.goodImage.Width;
                //wbcomp.Height = s.goodImage.Height;
                this.isbusy = true;
                wbcomp.Url = new Uri(s.url);

                while (this.isbusy)
                {
                    System.Threading.Thread.Sleep(2000);
                    Application.DoEvents();
                }
                this.toolStripStatusLabel1.Text = s.url + " Done";
                wbcomp.Width = s.goodImage.Width;// wbcomp.Document.Body.ClientRectangle.Width;
                wbcomp.Height = s.goodImage.Height;// wbcomp.Document.Body.ClientRectangle.Height;
                wbcomp.ScrollBarsEnabled = false;

                WebCheckerUI.browser bbb = new browser(s.url);
                bbb.bWidth = s.width;
                bbb.bHeight = s.height;
                ouput("Getting shot..");
                Image compImage = bbb.getScreenshot(wbcomp);
                ouput("Comparing...");
                //Image compImage = WebBrowserHelper.getScreenshot(wbcomp, s.delay);

                // compare
                double err= 0;
                Bitmap bitmapDiff = null;
                bitmapCompare.CompareResult res = bitmapCompare.Compare(false, new Bitmap(s.goodImage), new Bitmap(compImage), out err, out bitmapDiff);

                ouput(res.ToString());

                if (res == bitmapCompare.CompareResult.ciSizeMismatch)
                {
                    ouput(string.Format("{0} X {1} vs {2} X {3}",
                        s.goodImage.Size.Width,
                        s.goodImage.Size.Height,
                        compImage.Size.Width,
                        compImage.Size.Height));

                }

                this.pictureBox2.Image = bitmapDiff;

                string baseFile = Path.GetTempFileName();
                s.goodImage.Save(baseFile + "_original(" + s.goodImage.Width.ToString() + "x" + s.goodImage.Height.ToString() + ").png");
                compImage.Save(baseFile + "_compared(" + compImage.Width.ToString() + "x" + compImage.Height.ToString() + ").png");
                bitmapDiff.Save(baseFile + "_diff(" + bitmapDiff.Width.ToString() + "x" + bitmapDiff.Height.ToString() + ").png");
                string [] images = new string[3];
                images[0] = baseFile + "_original(" + s.goodImage.Width.ToString() + "x" + s.goodImage.Height.ToString() + ").png";
                images[1] = baseFile + "_compared(" + compImage.Width.ToString() + "x" + compImage.Height.ToString() + ").png";
                images[2] = baseFile + "_diff(" + bitmapDiff.Width.ToString() + "x" + bitmapDiff.Height.ToString() + ").png";



                if (res == bitmapCompare.CompareResult.ciCompareOk && err == 0)
                {
                    //email is required
                    ouput("sending email");
                    email em = new email();
                    em.send("mileshart@gmail.com", "test " + res + ":" + err.ToString() + "%", images);
                    ouput("sending email... done");
                }
            }

        }

        void wbcomp_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return; 
            this.isbusy = false;
        }
        void ouput(string m)
        {
            this.txtOutput.Text += m + "\r\n";
            this.toolStripStatusLabel1.Text = m;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SHA256Managed shaM = new SHA256Managed();
            ////namespace of the main program? 
            //byte[] hash1 = shaM.ComputeHash(btImage1);
            ////btImage1 = name of the imageBox1(emguCV) 
            //byte[] hash2 = shaM.ComputeHash(btImage2);
            ////btImage2 = name of the imageBox(emguCV)
        }
    }
    public class server
    {
        public string displayName { get { return string.Format("{0} ({1})", this.name, this.url); } }
        public string name { get; set; }
        public string url { get; set; }
        public bool confirmed { get; set; }
        public Image goodImage { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int delay { get; set; }
    }
}
