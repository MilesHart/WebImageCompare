namespace WebCheckerUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbUrls = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrlAdd = new System.Windows.Forms.TextBox();
            this.cmdAddUrl = new System.Windows.Forms.Button();
            this.cmdDeleteUrl = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUrls
            // 
            this.lbUrls.DisplayMember = "displayName";
            this.lbUrls.FormattingEnabled = true;
            this.lbUrls.ItemHeight = 20;
            this.lbUrls.Location = new System.Drawing.Point(46, 120);
            this.lbUrls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbUrls.Name = "lbUrls";
            this.lbUrls.Size = new System.Drawing.Size(500, 144);
            this.lbUrls.TabIndex = 0;
            this.lbUrls.Click += new System.EventHandler(this.lbUrls_Click);
            this.lbUrls.SelectedIndexChanged += new System.EventHandler(this.lbUrls_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url";
            // 
            // txtUrlAdd
            // 
            this.txtUrlAdd.Location = new System.Drawing.Point(81, 40);
            this.txtUrlAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUrlAdd.Name = "txtUrlAdd";
            this.txtUrlAdd.Size = new System.Drawing.Size(382, 26);
            this.txtUrlAdd.TabIndex = 2;
            // 
            // cmdAddUrl
            // 
            this.cmdAddUrl.Location = new System.Drawing.Point(474, 37);
            this.cmdAddUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdAddUrl.Name = "cmdAddUrl";
            this.cmdAddUrl.Size = new System.Drawing.Size(75, 74);
            this.cmdAddUrl.TabIndex = 3;
            this.cmdAddUrl.Text = "&Add";
            this.cmdAddUrl.UseVisualStyleBackColor = true;
            this.cmdAddUrl.Click += new System.EventHandler(this.cmdAddUrl_Click);
            // 
            // cmdDeleteUrl
            // 
            this.cmdDeleteUrl.Location = new System.Drawing.Point(435, 277);
            this.cmdDeleteUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdDeleteUrl.Name = "cmdDeleteUrl";
            this.cmdDeleteUrl.Size = new System.Drawing.Size(112, 35);
            this.cmdDeleteUrl.TabIndex = 4;
            this.cmdDeleteUrl.Text = "&Delete";
            this.cmdDeleteUrl.UseVisualStyleBackColor = true;
            this.cmdDeleteUrl.Click += new System.EventHandler(this.cmdDeleteUrl_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 80);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(360, 26);
            this.txtName.TabIndex = 6;
            this.txtName.Text = "Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(46, 322);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 360);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutput);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Location = new System.Drawing.Point(588, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(856, 386);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(9, 63);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(500, 266);
            this.txtOutput.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Preview";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(548, 43);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 288);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1462, 30);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 52);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 714);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdDeleteUrl);
            this.Controls.Add(this.cmdAddUrl);
            this.Controls.Add(this.txtUrlAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUrls);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUrls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrlAdd;
        private System.Windows.Forms.Button cmdAddUrl;
        private System.Windows.Forms.Button cmdDeleteUrl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button button2;
    }
}

