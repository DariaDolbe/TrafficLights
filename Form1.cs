using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class TrafficLights : Form
    {

        private Timer timerSwitch;
        private Timer timerBlink;
        private int timeCounter = 0;


        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLights();
            InitializeBoxForm();
            InitializeTimerSwitch();
            InitializeTimerBlink();
        }

        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }

        private void InitializeTimerBlink()
        {
            timerBlink = new Timer();
            timerBlink.Interval = 100;
            timerBlink.Tick += new EventHandler(TimerBlink_Tick);
        }

        private void TimerBlink_Tick (object sender, EventArgs e)
        {
            if (GreenLight.BackColor == Color.Green)
            {
                GreenLight.BackColor = Color.DarkGray;
            }
            else
            {
                GreenLight.BackColor = Color.Green;
            }
        }

        private void TimerSwitch_Tick (object sender, EventArgs e)
        {
            switch (timeCounter)
            {
                case 0:
                    RedLight.BackColor = Color.Red;
                    break;
                case 3:
                    YellowLight.BackColor = Color.Yellow;
                    RedLight.BackColor = Color.Gray;
                    break;
                case 5:
                    YellowLight.BackColor = Color.Gray;
                    GreenLight.BackColor = Color.Green;
                    break;
                case 7:
                    timerBlink.Start();
                    break;
                case 8:
                    timerBlink.Stop();
                    YellowLight.BackColor = Color.Yellow;
                    GreenLight.BackColor = Color.Gray;
                    break;
                case 10:
                    YellowLight.BackColor = Color.Gray;
                    RedLight.BackColor = Color.Red;
                    timeCounter = -1;
                    break;
            }
                timeCounter++;
        }

        private void InitializeBoxForm()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, RedLight.Width, RedLight.Height);
            RedLight.Region = new Region(path);

            System.Drawing.Drawing2D.GraphicsPath path2 = new System.Drawing.Drawing2D.GraphicsPath();
            path2.AddEllipse(0, 0, YellowLight.Width, YellowLight.Height);
            YellowLight.Region = new Region(path2);

            System.Drawing.Drawing2D.GraphicsPath path3 = new System.Drawing.Drawing2D.GraphicsPath();
            path3.AddEllipse(0, 0, GreenLight.Width, GreenLight.Height);
            GreenLight.Region = new Region(path3);
        }

        private void InitializeTrafficLights()
        {
            RedLight.BackColor = Color.DarkGray;
            YellowLight.BackColor = Color.DarkGray;
            GreenLight.BackColor = Color.DarkGray;
        }
    }
}
