using System;
using System.Windows.Forms;

namespace ShutdownTimer
{
    public partial class Form1 : Form
    {
        private int totalSeconds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 30; i <= 180; i += 30)
            {
                cb_minutes.Items.Add(i.ToString());
            }
            cb_minutes.SelectedItem = "30";
            btn_stop.Enabled = false;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            btn_stop.Enabled = true;

            totalSeconds = int.Parse(cb_minutes.SelectedItem.ToString()) * 60;

            System.Diagnostics.Process.Start("shutdown", "/s /t " + totalSeconds);

            t_timer.Enabled = true;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_stop.Enabled = false;
            btn_start.Enabled = true;

            System.Diagnostics.Process.Start("shutdown", "/a");
        }

        private void t_timer_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0 && btn_stop.Enabled)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);
                string zero = seconds < 10 ? "0" : string.Empty;
                lbl_timer.Text = minutes.ToString() + ":" + zero + seconds.ToString();

                if (totalSeconds == 300)
                {
                    MessageBox.Show("Less than 5 minutes left");
                }
            }
            else
            {
                t_timer.Stop();
            }
        }
    }
}
