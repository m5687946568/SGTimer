using static SGTimer.INIFunction;
//using Microsoft.Toolkit.Uwp.Notifications;

namespace SGTimer
{
    public partial class Form1 : Form
    {
        private int Tseconds,
            P1seconds,
            P2seconds,
            P3seconds,
            P4seconds,
            P5seconds,
            P6seconds;

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists(ProfilePath))
            {
                iniSave();
            }
            else
            {
                iniRead();
            }
            reset();

        }

        #region INI存檔讀取
        private void iniSave()
        {
            WPPS("Time", "P1H", nud_P1_H.Value.ToString());
            WPPS("Time", "P1M", nud_P1_M.Value.ToString());
            WPPS("Time", "P1S", nud_P1_S.Value.ToString());
            WPPS("Time", "P2H", nud_P2_H.Value.ToString());
            WPPS("Time", "P2M", nud_P2_M.Value.ToString());
            WPPS("Time", "P2S", nud_P2_S.Value.ToString());
            WPPS("Time", "P3H", nud_P3_H.Value.ToString());
            WPPS("Time", "P3M", nud_P3_M.Value.ToString());
            WPPS("Time", "P3S", nud_P3_S.Value.ToString());
            WPPS("Time", "P4H", nud_P4_H.Value.ToString());
            WPPS("Time", "P4M", nud_P4_M.Value.ToString());
            WPPS("Time", "P4S", nud_P4_S.Value.ToString());
            WPPS("Time", "P5H", nud_P5_H.Value.ToString());
            WPPS("Time", "P5M", nud_P5_M.Value.ToString());
            WPPS("Time", "P5S", nud_P5_S.Value.ToString());
            WPPS("Time", "P6H", nud_P6_H.Value.ToString());
            WPPS("Time", "P6M", nud_P6_M.Value.ToString());
            WPPS("Time", "P6S", nud_P6_S.Value.ToString());

            WPPS("Time", "NotificationTime", numericUpDown1.Value.ToString());

            WPPS("Switch", "NotificationTime", checkBox1.Checked.ToString());
            WPPS("Switch", "OnTop", checkBox2.Checked.ToString());
        }

        private void iniRead()
        {
            SetNumericValue(nud_P1_H, GPPS("Time", "P1H"));
            SetNumericValue(nud_P1_M, GPPS("Time", "P1M"));
            SetNumericValue(nud_P1_S, GPPS("Time", "P1S"));
            SetNumericValue(nud_P2_H, GPPS("Time", "P2H"));
            SetNumericValue(nud_P2_M, GPPS("Time", "P2M"));
            SetNumericValue(nud_P2_S, GPPS("Time", "P2S"));
            SetNumericValue(nud_P3_H, GPPS("Time", "P3H"));
            SetNumericValue(nud_P3_M, GPPS("Time", "P3M"));
            SetNumericValue(nud_P3_S, GPPS("Time", "P3S"));
            SetNumericValue(nud_P4_H, GPPS("Time", "P4H"));
            SetNumericValue(nud_P4_M, GPPS("Time", "P4M"));
            SetNumericValue(nud_P4_S, GPPS("Time", "P4S"));
            SetNumericValue(nud_P5_H, GPPS("Time", "P5H"));
            SetNumericValue(nud_P5_M, GPPS("Time", "P5M"));
            SetNumericValue(nud_P5_S, GPPS("Time", "P5S"));
            SetNumericValue(nud_P6_H, GPPS("Time", "P6H"));
            SetNumericValue(nud_P6_M, GPPS("Time", "P6M"));
            SetNumericValue(nud_P6_S, GPPS("Time", "P6S"));

            SetNumericValue(numericUpDown1, GPPS("Time", "NotificationTime"));

            checkBox1.Checked = ParseBool(GPPS("Switch", "NotificationTime"));
            checkBox2.Checked = ParseBool(GPPS("Switch", "OnTop"));
        }

        void SetNumericValue(NumericUpDown nud, string valueStr)
        {
            if (int.TryParse(valueStr, out int value))
            {
                nud.Value = Math.Min(nud.Maximum, Math.Max(nud.Minimum, value));
            }
            else
            {
                nud.Value = nud.Minimum; // 或設定預設值
            }
        }

        bool ParseBool(string value)
        {
            return value?.Trim().ToLower() switch
            {
                "true" => true,
                "false" => false,
                _ => false // 預設為 false，可視需求調整
            };
        }
        #endregion

        private void reset()
        {
            timer1.Enabled = false;
            button1.Text = "開始";
            button2.Text = "重置";

            Tseconds = 0;
            P1seconds = (int)nud_P1_H.Value * 60 * 60 + (int)nud_P1_M.Value * 60 + (int)nud_P1_S.Value;
            P2seconds = (int)nud_P2_H.Value * 60 * 60 + (int)nud_P2_M.Value * 60 + (int)nud_P2_S.Value;
            P3seconds = (int)nud_P3_H.Value * 60 * 60 + (int)nud_P3_M.Value * 60 + (int)nud_P3_S.Value;
            P4seconds = (int)nud_P4_H.Value * 60 * 60 + (int)nud_P4_M.Value * 60 + (int)nud_P4_S.Value;
            P5seconds = (int)nud_P5_H.Value * 60 * 60 + (int)nud_P5_M.Value * 60 + (int)nud_P5_S.Value;
            P6seconds = (int)nud_P6_H.Value * 60 * 60 + (int)nud_P6_M.Value * 60 + (int)nud_P6_S.Value;

            groupBox1.Text = "時間：" + FSec(Tseconds);
            label2.Text = "P1：" + FSec(P1seconds);
            label3.Text = "P2：" + FSec(P2seconds);
            label4.Text = "P3：" + FSec(P3seconds);
            label5.Text = "P4：" + FSec(P4seconds);
            label6.Text = "P5：" + FSec(P5seconds);
            label7.Text = "P6：" + FSec(P6seconds);
        }

        private static string FSec(int sec)
        {
            if (sec < 60)
            {
                return $"{sec} 秒";
            }
            else if (sec < 3600)
            {
                int minutes = sec / 60;
                int seconds = sec % 60;
                return $"{minutes} 分 {seconds} 秒";
            }
            else
            {
                int hours = sec / 3600;
                int minutes = (sec % 3600) / 60;
                int seconds = sec % 60;
                return $"{hours} 小時 {minutes} 分 {seconds} 秒";
            }
        }
                
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            iniRead();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Wsec = (int)numericUpDown1.Value;

            Tseconds++;
            groupBox1.Text = "時間：" + FSec(Tseconds);

            P1seconds--;
            if (P1seconds >= 0) label2.Text = "P1：" + FSec(P1seconds);
            if (P1seconds == Wsec && checkBox1.Checked)
            {
                //new ToastContentBuilder()
                //    .AddText("P1")
                //    .AddButton(new ToastButton().SetContent("確定"))
                //    .SetToastScenario(ToastScenario.Reminder)
                //    .Show();
                 NotificationForm.ShowNotification("Ｐ1");
            }

            P2seconds--;
            if (P2seconds >= 0) label3.Text = "P2：" + FSec(P2seconds);
            if (P2seconds == Wsec && checkBox1.Checked)
            {
                //new ToastContentBuilder()
                //    .AddText("P2")
                //    .AddButton(new ToastButton().SetContent("確定"))
                //    .SetToastScenario(ToastScenario.Reminder)
                //    .Show();
                NotificationForm.ShowNotification("Ｐ2");
            }

            P3seconds--;
            if (P3seconds >= 0) label4.Text = "P3：" + FSec(P3seconds);
            if (P3seconds == Wsec && checkBox1.Checked)
            {
                //new ToastContentBuilder()
                //    .AddText("P3")
                //    .AddButton(new ToastButton().SetContent("確定"))
                //    .SetToastScenario(ToastScenario.Reminder)
                //    .Show();
                NotificationForm.ShowNotification("Ｐ3");
            }

            P4seconds--;
            if (P4seconds >= 0) label5.Text = "P4：" + FSec(P4seconds);
            if (P4seconds == Wsec && checkBox1.Checked)
            {
                //new ToastContentBuilder()
                //    .AddText("P4")
                //    .AddButton(new ToastButton().SetContent("確定"))
                //    .SetToastScenario(ToastScenario.Reminder)
                //    .Show();
                NotificationForm.ShowNotification("Ｐ4");
            }

            P5seconds--;
            if (P5seconds >= 0) label6.Text = "P5：" + FSec(P5seconds);
            if (P5seconds == Wsec && checkBox1.Checked)
            {
                //new ToastContentBuilder()
                //    .AddText("P5")
                //    .AddButton(new ToastButton().SetContent("確定"))
                //    .SetToastScenario(ToastScenario.Reminder)
                //    .Show();
                NotificationForm.ShowNotification("Ｐ5");
            }

            P6seconds--;
            if (P6seconds >= 0) label7.Text = "P6：" + FSec(P6seconds);
            if (P6seconds == Wsec && checkBox1.Checked)
            {
                //MessageBox.Show("P6", "P6", MessageBoxButtons.OK);
                //new ToastContentBuilder()
                //    .AddText("P6")
                //    .AddButton(new ToastButton().SetContent("確定"))
                //    .SetToastScenario(ToastScenario.Reminder)
                //    .Show();
                NotificationForm.ShowNotification("Ｐ6");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "繼續";
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "暫停";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iniSave();
            reset();
            tabControl1.SelectedIndex = 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
    }



}
