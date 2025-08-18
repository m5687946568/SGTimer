using SGTimer.Properties;
using System.Media;
using System.Runtime.InteropServices;

namespace SGTimer
{
    public partial class NotificationForm : Form
    {

        private static NotificationForm notificationForm;
        public static void ShowNotification(string message)
        {
            // 若已有通知視窗，則關閉
            if (notificationForm != null && !notificationForm.IsDisposed)
            {
                notificationForm.Invoke(new Action(() =>
                {
                    notificationForm.Close();
                }));
            }

            // 建立並顯示新通知
            notificationForm = new NotificationForm(message);
            notificationForm.Show();
        }

        public NotificationForm(string message)
        {
            InitializeComponent();

            //撥放音效
            SoundPlayer player = new SoundPlayer(Resources.WindowsNotifySystemGeneric);
            player.Play();

            //顯示內容
            lbl.Text = message;

            // 設定顯示位置（右下角）
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width - 10, screen.Bottom - this.Height - 10);
            //this.Location = new Point(
            //    screen.Left + (screen.Width - this.Width) / 2,
            //    screen.Top + (screen.Height - this.Height) / 10
            //    );

            // 設定自動關閉
            closeTimer.Interval = 5 * 1000;
            closeTimer.Start();
        }

        //點擊穿透
        private void EnableClickThrough()
        {
            int exStyle = GetWindowLong(this.Handle, -20);
            exStyle |= 0x80000 | 0x20;
            SetWindowLong(this.Handle, -20, exStyle);
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        private void NotificationForm_Load(object sender, EventArgs e)
        {
            EnableClickThrough();
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Close();
        }
    }

}
