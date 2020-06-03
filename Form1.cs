﻿using System;
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


        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLights();
            InitializeTimerSwitch();
        }

        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;]
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
        }

        private void TimerSwitch_Tick (object sender, EventArgs e)
        {
            if (RedLight.BackColor == Color.DarkGray)
            {
                RedLight.BackColor = Color.Red;
            }
            else
            {
                RedLight.BackColor = Color.DarkGray;
            }
        }

        private void InitializeTrafficLights()
        {
            RedLight.BackColor = Color.DarkGray;
            YellowLight.BackColor = Color.DarkGray;
            GreenLight.BackColor = Color.DarkGray;
        }
    }
}
