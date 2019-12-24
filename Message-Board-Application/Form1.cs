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

        public Form1()
        {
            InitializeComponent();     
        }

        public void getTempTexts()
        {
            text1Temp.Font = text1.Font;
            text2Temp.Font = text2.Font;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSettingsImage();
            getTempTexts();
            ledLabelsSelect();
            resetAll();
            this.MaximizeBox = false;
        }

        //Reset Methods

        public void t1Reset()
        {
            tbT1.Text = "";
            text1.Text = "Mert KARACA";
            text1.ForeColor = Color.Tomato;
            text1.Font = text1Temp.Font;
            btnColorT1.BackColor = Color.Tomato;
        }

        public void t2Reset()
        {
            tbT2.Text = "";
            text2.Text = "Work hard, stay humble";
            text2.ForeColor = Color.DodgerBlue;
            text2.Font = text2Temp.Font;
            btnColorT2.BackColor = Color.DodgerBlue;
        }

        public void resetAll()
        {
            t1Reset();
            t2Reset();
        }

        //Create ledLabels list from empty labels
        List<Label> ledLabels = new List<Label>();
        public void ledLabelsSelect()
        {
            foreach (Label lbl in this.panel1.Controls.OfType<Label>().Where(x => x.Text == ""))
            {
                ledLabels.Add(lbl);
            }
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

        //Left To Right
        //Right to Left
        //Up to Down
        //Down to Up
        int t1Direction, t2Direction;
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

        public void text1Move()
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
                text1.Top = 430 + text1.Size.Height;
            }
            else if(text1.Top >= 430 + text1.Size.Height)
            {
                text1.Top = 50 - text1.Size.Height;
            }
        }
        public void text2Move()
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
                text2.Top = 430 + text2.Size.Height;
            }
            else if (text2.Top >= 430 + text2.Size.Height)
            {
                text2.Top = 50 - text2.Size.Height;
            }
        }


        private void t1SpeedTimer_Tick(object sender, EventArgs e)
        {
            text1Move();
        }

        private void t2SpeedTimer_Tick(object sender, EventArgs e)
        {
            text2Move();
        }
        //Text Animation END

        //Led Timer
        int i = 0;
        private void ledTimer_Tick(object sender, EventArgs e)
        {
            //Led color changes
            if(i != 0)
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


        // *** BUTTONS START ***

        //RESET START
        //Reset All
        private void btnResetAll_Click(object sender, EventArgs e)
        {
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

        //FONT FAMILY END

        //SETTINGS START
        //btnSettings
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if(panel2.Visible == true)
            {
                panel2.Hide();
                this.Size = new Size(1280, 550);
            }
            else
            {
                panel2.Show();
                this.Size = new Size(1280, 720);
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






        //SETTINGS END

        // *** BUTTONS END ***
    }
}
