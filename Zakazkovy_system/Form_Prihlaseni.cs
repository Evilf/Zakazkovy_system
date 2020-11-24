using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zakazkovy_system
{
    public partial class Form_Prihlaseni : Form
    {

        public static bool SuccessfullLogin = false;
        public Form_Prihlaseni()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataRow row in Form_Mainwindow.LoginData.Rows)
            {
                if(row[0].ToString().ToLower() == textBox_UserName.Text.ToLower())
                {
                    if(row[1].ToString() == textBox_Password.Text)
                    {
                        SuccessfullLogin = true;
                        Form_Mainwindow.CurrentUser = row;
                        Close();
                        break;
                    }
                }
            }
            if(SuccessfullLogin == false)
                label3.Visible = true;
        }

        private void Form_Prihlaseni_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!SuccessfullLogin)
                Application.Exit();
        }

        private void Form_Prihlaseni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click("", e);
            }
        }

        private void textBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click("", e);
            }
        }

        private void textBox_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click("", e);
            }
        }
    }
}
