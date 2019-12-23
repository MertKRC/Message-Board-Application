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
            btnSettingsImage();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }






        //SETTINGS BUTTON START
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
        //SETTINGS BUTTON END
    }
}
