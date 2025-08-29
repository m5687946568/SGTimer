namespace SGTimer
{
    partial class NotificationForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            lbl = new Label();
            closeTimer = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            fadeTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.BackColor = Color.LightBlue;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(50, 0);
            lbl.Margin = new Padding(0);
            lbl.Name = "lbl";
            lbl.Size = new Size(150, 50);
            lbl.TabIndex = 0;
            lbl.Text = "P1";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeTimer
            // 
            closeTimer.Interval = 3000;
            closeTimer.Tick += closeTimer_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightSkyBlue;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.Clock;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // fadeTimer
            // 
            fadeTimer.Interval = 50;
            fadeTimer.Tick += fadeTimer_Tick;
            // 
            // NotificationForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(200, 50);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(lbl);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "NotificationForm";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "NotificationForm";
            TopMost = true;
            Load += NotificationForm_Load;
            Shown += NotificationForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl;
        private System.Windows.Forms.Timer closeTimer;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer fadeTimer;
    }
}