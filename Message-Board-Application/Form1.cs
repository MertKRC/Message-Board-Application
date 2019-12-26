using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Message_Board_Application
{
    public partial class Form1 : Form
    {
        String appPath;
        //Create ledLabels list from empty labels
        int t1Direction, t2Direction;
        //Color Map
        //Bootstrap Danger = 219, 53, 69
        //Bootstrap Success = 40, 167, 69
        //Bootstrap Warning
        //Bootstrap Dark


        List<Label> bottomLabels = new List<Label>();
        private void bottomLedsSelect()
        {
            foreach (Label lbl in this.bottomLedPanel.Controls.OfType<Label>()
                .Where(x => x.Text == ""))
            {
                bottomLabels.Add(lbl);
            }
        }

        List<Label> topLabels = new List<Label>();
        private void topLabelsSelect()
        {
            foreach (Label lbl in this.topLedPanel.Controls.OfType<Label>()
                .Where(x => x.Text == ""))
            {
                topLabels.Add(lbl);
            }
        }

        List<Label> ledLabels = new List<Label>();
        public void ledLabelsSelect()
        {
            foreach (Label lbl in this.topLedPanel.Controls.OfType<Label>())
            {
                ledLabels.Add(lbl);
            }
            foreach (Label lbl in this.bottomLedPanel.Controls.OfType<Label>())
            {
                ledLabels.Add(lbl);
            }
        }

        public Form1()
        {
            InitializeComponent();     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settingsPanel.BackColor = Color.FromArgb(52, 58, 64);
            bottomLedsSelect();
            btnSettingsImage();
            getTempTexts();
            ledLabelsSelect();
            resetAll();
            timerStartStop(false);
            resetComboBoxes();
            numUpDownBoundaries();
            numUpDownValue();
            //ulong value to cap it
            numTimerPeriod.Maximum = 18446744073709551614;
            this.MaximizeBox = false;
        }

        private void numUpDownBoundaries()
        {
            xPosT1.Maximum = 720;
            xPosT1.Minimum = 0;
            yPosT1.Maximum = 1280;
            yPosT1.Minimum = 0 - text1.Size.Width;

            xPosT2.Maximum = 720;
            xPosT2.Minimum = 0;
            yPosT2.Maximum = 1280;
            yPosT2.Minimum = 0 - text2.Size.Width;
        }

        private void numUpDownValue()
        {
            xPosT1.Value = text1.Top;
            yPosT1.Value = text1.Left;

            xPosT2.Value = text2.Top;
            yPosT2.Value = text2.Left;
        }
        
        // X - Y Positions
        private void xPosT1_ValueChanged(object sender, EventArgs e)
        {
            text1.Top = Convert.ToInt32(xPosT1.Value);
        }

        private void yPosT1_ValueChanged(object sender, EventArgs e)
        {
            text1.Left = Convert.ToInt32(yPosT1.Value);
        }

        private void xPosT2_ValueChanged(object sender, EventArgs e)
        {
            text2.Top = Convert.ToInt32(xPosT2.Value);
        }

        private void yPosT2_ValueChanged(object sender, EventArgs e)
        {
            text2.Left = Convert.ToInt32(yPosT2.Value);
        }

        //Temporary texts to reset main text to default value
        public void getTempTexts()
        {
            text1Temp.Font = text1.Font;
            text2Temp.Font = text2.Font;
        }

        //Reset Methods

        //Reset ComboBox
        private void t1ComboBoxes()
        {
            dirT1.SelectedIndex = 0;
            speedT1.SelectedIndex = 3;
        }

        private void t2ComboBoxes()
        {
            dirT2.SelectedIndex = 2;
            speedT2.SelectedIndex = 3;
        }
        private void resetComboBoxes()
        {
            t1ComboBoxes();
            t2ComboBoxes();
        }

        public void t1Reset()
        {
            tbT1.Text = "";
            text1.Text = "Mert KARACA";
            text1.ForeColor = Color.Tomato;
            text1.Font = text1Temp.Font;
            btnColorT1.BackColor = Color.Tomato;
            text1.Location = new Point(567, 162);
            xPosT1.Value = 162;
            yPosT1.Value = 567;
            t1ComboBoxes();
        }

        public void t2Reset()
        {
            tbT2.Text = "";
            text2.Text = "Work hard, stay humble.";
            text2.ForeColor = Color.DodgerBlue;
            text2.Font = text2Temp.Font;
            btnColorT2.BackColor = Color.DodgerBlue;
            text2.Location = new Point(506, 225);
            xPosT2.Value = 225;
            yPosT2.Value = 506;
            t2ComboBoxes();
        }

        public void mainReset()
        {
            this.BackColor = Color.FromArgb(52, 58, 64);
            btnDisplayColor.BackColor = this.BackColor;
            numTimerPeriod.Value = 0;
            cbLedStyle.SelectedIndex = 2;
        }

        public void resetAll()
        {
            t1Reset();
            t2Reset();
            ledColorReset();
            mainReset();
        }

        //Reset all LED colors to default value
        private void ledColorReset()
        {
            ledOnColorDialog.Color = Color.White;
            ledOffColorDialog.Color = Color.RoyalBlue;

            btnLedOnColor.BackColor = ledOnColorDialog.Color;
            btnLedOffColor.BackColor = ledOffColorDialog.Color;
        }

        //Led on/off Colors START
        private void btnLedOnColor_Click(object sender, EventArgs e)
        {
            ledOnColorDialog.ShowDialog();
            btnLedOnColor.BackColor = ledOnColorDialog.Color;
        }

        private void btnLedOffColor_Click(object sender, EventArgs e)
        {
            ledOffColorDialog.ShowDialog();
            btnLedOffColor.BackColor = ledOffColorDialog.Color;
        }
        //Led on/off Colors END

        //Text Animation START

        private void speedT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speedT1.Text == "Stop")
            {
                t1SpeedTimer.Enabled = false;
            }
            else if (speedT1.Text == "Slow")
            {
                t1SpeedTimer.Enabled = true;
                t1SpeedTimer.Interval = 1000;
            }
            else if (speedT1.Text == "Medium")
            {
                t1SpeedTimer.Enabled = true;
                t1SpeedTimer.Interval = 500;
            }
            else if (speedT1.Text == "Fast")
            {
                t1SpeedTimer.Enabled = true;
                t1SpeedTimer.Interval = 100;
            }
        }

        private void speedT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speedT2.Text == "Stop")
            {
                t2SpeedTimer.Enabled = false;
            }
            else if (speedT2.Text == "Slow")
            {
                t2SpeedTimer.Enabled = true;
                t2SpeedTimer.Interval = 1000;
            }
            else if (speedT2.Text == "Medium")
            {
                t2SpeedTimer.Enabled = true;
                t2SpeedTimer.Interval = 500;
            }
            else if (speedT2.Text == "Fast")
            {
                t2SpeedTimer.Enabled = true;
                t2SpeedTimer.Interval = 100;
            }
        }

        private void dirT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dirT1.Text == "Left To Right")
            {
                t1Direction = 1;
            }
            else if (dirT1.Text == "Right to Left")
            {
                t1Direction = 2;
            }
            else if (dirT1.Text == "Up to Down")
            {
                t1Direction = 3;
            }
            else if (dirT1.Text == "Down to Up")
            {
                t1Direction = 4;
            }
        }

        private void dirT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dirT2.Text == "Left To Right")
            {
                t2Direction = 1;
            }
            else if (dirT2.Text == "Right to Left")
            {
                t2Direction = 2;
            }
            else if (dirT2.Text == "Up to Down")
            {
                t2Direction = 3;
            }
            else if (dirT2.Text == "Down to Up")
            {
                t2Direction = 4;
            }
        }

        private void text1Move()
        {
            //t1 direction check
            if (t1Direction == 1)
            {
                text1.Left += 10;
            }
            else if (t1Direction == 2)
            {
                text1.Left -= 10;
            }
            else if (t1Direction == 3)
            {
                text1.Top += 10;
            }
            else if (t1Direction == 4)
            {
                text1.Top -= 10;
            }

            //t1 width boundary
            if (text1.Left >= 1280)
            {
                text1.Left = 0-text1.Size.Width;
            }
            else if(text1.Left <= 0-text1.Size.Width)
            {
                text1.Left = 1280;
            }

            //t1 height boundary
            if (text1.Top+text1.Size.Height <= 50)
            {
                text1.Top = bottomLedPanel.Top + text1.Size.Height;
            }
            else if(text1.Top >= bottomLedPanel.Top + text1.Size.Height)
            {
                text1.Top = 50 - text1.Size.Height;
            }
        }
        private void text2Move()
        {
            //t2 direction check
            if (t2Direction == 1)
            {
                text2.Left += 10;
            }
            else if (t2Direction == 2)
            {
                text2.Left -= 10;
            }
            else if (t2Direction == 3)
            {
                text2.Top += 10;
            }
            else if (t2Direction == 4)
            {
                text2.Top -= 10;
            }

            //t2 width boundary
            if (text2.Left >= 1280)
            {
                text2.Left = 0 - text2.Size.Width;
            }
            else if (text2.Left <= 0 - text2.Size.Width)
            {
                text2.Left = 1280;
            }

            //t2 height boundary
            if (text2.Top + text2.Size.Height <= 50)
            {
                text2.Top = bottomLedPanel.Top + text2.Size.Height;
            }
            else if (text2.Top >= bottomLedPanel.Top + text2.Size.Height)
            {
                text2.Top = 50 - text2.Size.Height;
            }
        }


        private void t1SpeedTimer_Tick(object sender, EventArgs e)
        {
            if(btnControl.Text != "START")
            {
                text1Move();
            }
            numUpDownValue();
        }

        private void t2SpeedTimer_Tick(object sender, EventArgs e)
        {
            if(btnControl.Text != "START")
            {
                text2Move();
            }
            numUpDownValue();
        }
        //Text Animation END

        //Led Timer
        int i = 0;
        private void ledTimer_Tick(object sender, EventArgs e)
        {
            //Led color changes
            if (i != 0)
            {
                foreach (Label lbl in ledLabels)
                {
                    lbl.BackColor = ledOnColorDialog.Color;
                }
                i = 0;
            }
            else
            {
                foreach (Label lbl in ledLabels)
                {
                    lbl.BackColor = ledOffColorDialog.Color;
                }
                i++;
            }
        }

        //TextBoxes
        private void tbT1_TextChanged(object sender, EventArgs e)
        {
            text1.Text = tbT1.Text;
        }

        private void tbT2_TextChanged(object sender, EventArgs e)
        {
            text2.Text = tbT2.Text;
        }


        private void cbLedStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLedStyle.SelectedIndex == 0)
            {
                foreach (Label lbl in ledLabels)
                {
                    lbl.Size = new Size(28, 15);
                }
            }
            else if(cbLedStyle.SelectedIndex == 1)
            {
                foreach (Label lbl in ledLabels)
                {
                    lbl.Size = new Size(56, 15);
                }
            }
            else if (cbLedStyle.SelectedIndex == 2)
            {
                foreach (Label lbl in ledLabels)
                {
                    lbl.Size = new Size(78, 15);
                }
            }
        }

        // *** GENERAL METHODS START ***

        //timerStartStop Method
        private void timerStartStop(bool startAll)
        {
            if (startAll == true)
            {
                ledTimer.Enabled = true;
                t1SpeedTimer.Enabled = true;
                t2SpeedTimer.Enabled = true;
            }
            else if (startAll == false)
            {
                ledTimer.Enabled = false;
                t1SpeedTimer.Enabled = false;
                t2SpeedTimer.Enabled = false;
            }
        }

        ulong generalTimerValue;
        private void numTimerPeriod_ValueChanged(object sender, EventArgs e)
        {
            generalTimerValue = Convert.ToUInt64(numTimerPeriod.Value);
        }

        private void generalTimer_Tick(object sender, EventArgs e)
        {
            if (generalTimerValue > 0)
            {
                generalTimerValue--;
            }
            if(generalTimerValue == 0)
            {
                btnControlMethod();
            }
            numTimerPeriod.Value = generalTimerValue;
        }

        //Start/Stop Button Method
        private void btnControlMethod()
        {
            if (btnControl.Text == "START")
            {
                btnControl.Text = "STOP";
                btnControl.BackColor = Color.FromArgb(219, 53, 69);
                timerStartStop(true);
                if(generalTimerValue > 0)
                {
                    generalTimer.Enabled = true;
                }
            }
            else
            {
                btnControl.Text = "START";
                btnControl.BackColor = Color.FromArgb(40, 167, 69);
                timerStartStop(false);
                generalTimer.Enabled = false;
            }
        }

        //btnSettings's background image - change it if you want
        private void btnSettingsImage()
        {
            appPath = Application.StartupPath.ToString();
            try
            {
                Image btnSettingsImg = new Bitmap(appPath + @"\Images\settingsImg.png");
                btnSettings.BackgroundImage = btnSettingsImg;
            }
            catch
            {
            }
        }

        // *** GENERAL METHODS END ***

        // *** BUTTONS START ***

        //Start/Stop Button
        private void btnControl_Click(object sender, EventArgs e)
        {
            btnControlMethod();
        }

        //RESET START
        //Reset All
        private void btnResetAll_Click(object sender, EventArgs e)
        {
            if(btnControl.Text != "START")
            {
                btnControlMethod();
            }
            resetAll();
        }

        //Text 1 Reset
        private void btnResetT1_Click(object sender, EventArgs e)
        {
            t1Reset();
        }

        //Text 2 Reset
        private void btnResetT2_Click(object sender, EventArgs e)
        {
            t2Reset();
        }
        //RESET END

        //TEXT COLOR START
        private void btnColorT1_Click(object sender, EventArgs e)
        {
            t1ColorDialog.ShowDialog();
            btnColorT1.BackColor = t1ColorDialog.Color;
            text1.ForeColor = t1ColorDialog.Color;
        }

        private void btnColorT2_Click(object sender, EventArgs e)
        {
            t2ColorDialog.ShowDialog();
            btnColorT2.BackColor = t2ColorDialog.Color;
            text2.ForeColor = t2ColorDialog.Color;
        }
        //TEXT COLOR END

        //FONT FAMILY START

        private void btnFontT1_Click(object sender, EventArgs e)
        {
            t1fontDialog.ShowDialog();
            text1.Font = t1fontDialog.Font;
        }

        private void btnFontT2_Click(object sender, EventArgs e)
        {
            t2fontDialog.ShowDialog();
            text2.Font = t2fontDialog.Font;
        }

        private void btnDisplayColor_Click(object sender, EventArgs e)
        {
            displayColorDialog.ShowDialog();
            this.BackColor = displayColorDialog.Color;
            btnDisplayColor.BackColor = this.BackColor;
        }

        //FONT FAMILY END

        //SETTINGS START
        //btnSettings

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if(settingsPanel.Visible == true)
            {
                settingsPanel.Visible = false;
                bottomLedPanel.Location = new Point(3, 635);

            }
            else
            {
                settingsPanel.Visible = true;
                bottomLedPanel.Location = new Point(3, 441);
            }
        }
        //SETTINGS END

        // *** BUTTONS END ***
    }
}
