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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        String username = "admin", password = "12345";
        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
        static int count = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            count++;
            if(usernameText.Text != null && passwordText.Text != null)
            {
                if(usernameText.Text == username && passwordText.Text == password)
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                    this.Close();
                }
                else
                {
                    if(count <2)
                    {
                        attemptLabel.Text = "Attempt: " + count;
                    }
                    else if(count == 3)
                    {
                        this.Close();
                    }
                    else
                    {
                        attemptLabel.Text = "Attempt: " + count;
                        MessageBox.Show("You have one last attempt.\nAfter that, program will close itself automatically!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
