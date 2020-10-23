using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.cb_minutes.Items.Add(i.ToString());
            }
            this.cb_minutes.SelectedItem = "30";
            this.btn_stop.Enabled = false;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            this.btn_start.Enabled = false;
            this.btn_stop.Enabled = true;

            totalSeconds = int.Parse(this.cb_minutes.SelectedItem.ToString()) * 60;

            System.Diagnostics.Process.Start("shutdown", "/s /t " + totalSeconds);

            this.t_timer.Enabled = true;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            this.btn_stop.Enabled = false;
            this.btn_start.Enabled = true;

            System.Diagnostics.Process.Start("shutdown", "/a");
        }

        private void t_timer_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0 && btn_stop.Enabled)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);
                this.lbl_timer.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                this.t_timer.Stop();
                MessageBox.Show("Time's up!");
            }
        }
    }
}
