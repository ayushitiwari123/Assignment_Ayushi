using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarmClock
{
    public partial class Alarm_clock : Form
    {
        System.Timers.Timer timer;

        public Alarm_clock()
        {
            InitializeComponent();
        }

        private void A_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

                
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker.Value;
            if(currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                UpdateLable upd = UpdateDataLable;
                if (lblStatus.InvokeRequired)
                    Invoke(upd, lblStatus, "Stop");
                MessageBox.Show("Medicine Time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        delegate void UpdateLable(Label lbl, string value);
        void UpdateDataLable(Label lbl, string value)
        {
            lbl.Text = value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            lblStatus.Text = "Running....";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblStatus.Text = "Stop";
        }
    }
}
