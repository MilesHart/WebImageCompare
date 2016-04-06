using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebChecker
{
    public partial class bigbrowser : Form
    {
        public bigbrowser()
        {
            InitializeComponent();
            WebBrowser webb = new WebBrowser();
            webb.AllowNavigation = true;
            webb.Width = 2000;
            webb.Height = 2000;
            webb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webb_DocumentCompleted);
            webb.Url = new Uri("");
            this.Controls.Add(webb);
        }

        void webb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;


            WebBrowser webb = sender as WebBrowser;
            do
            {
                System.Diagnostics.Debug.WriteLine(webb.ReadyState.ToString());

            } while (true);
            MessageBox.Show("finished");
        }
    }
}
