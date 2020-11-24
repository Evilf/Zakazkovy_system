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
    public partial class Form_Sprava_uctu : Form
    {

        string FileLocation = "Login_Values.xml"; 

        public Form_Sprava_uctu()
        {
            InitializeComponent();
            CenterToScreen();
            foreach (DataRow row in Form_Mainwindow.LoginData.Rows)
            {
                listView1.Items.Add(row[0].ToString());
                if(row[2].ToString() != "")
                comboBox_Rights.Items.Add(row[2].ToString());
            }

            if(Form_Mainwindow.CurrentUser[2].ToString() != "Admin")
            {
                panel_Controls.Enabled = false;
                label_NotAuthorized.Visible = true;
            }
            else
            {
                panel_Controls.Enabled = true;
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (DataRow row in Form_Mainwindow.LoginData.Rows)
                {
                    if (row[0].ToString() == listView1.SelectedItems[0].Text)
                    {
                        textBox_Jmeno.Text = row[0].ToString();
                        textBox_Heslo.Text = row[1].ToString();
                        comboBox_Rights.Text = row[2].ToString();
                    }
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach(DataRow row in Form_Mainwindow.LoginData.Rows)
            {
                if(row[0].ToString() == textBox_Jmeno.Text)
                {
                    row.BeginEdit();
                    row[0] = textBox_Jmeno.Text;
                    row[1] = textBox_Heslo.Text;
                    row[2] = comboBox_Rights.Text;
                    row.EndEdit();
                    found = true;
                    button_Save.ForeColor = Color.Green;
                }
            }

            if(!found)
            {
                if(MessageBox.Show("Účet nebyl nalezen, chcete ho přidat?", "Nenalezeno", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    button_Add_Click("", e);
                }
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataRow row in Form_Mainwindow.LoginData.Rows)
            {
                if (row[0].ToString() == textBox_Jmeno.Text)
                {
                    found = true;
                }
            }

            if (!found)
            {
                DataRow newrow = Form_Mainwindow.LoginData.NewRow();
                newrow[0] = textBox_Jmeno.Text;
                newrow[1] = textBox_Heslo.Text;
                newrow[2] = comboBox_Rights.Text;
                Form_Mainwindow.LoginData.Rows.Add(newrow);
                Form_Mainwindow.LoginData.AcceptChanges();
                button_Save.ForeColor = Color.Green;

            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in Form_Mainwindow.LoginData.Rows)
            {
                if (row[0].ToString() == textBox_Jmeno.Text)
                {
                    row.Delete();
                    Form_Mainwindow.LoginData.AcceptChanges();
                }
            }
        }

        private void Form_Sprava_uctu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                button_Save_Click("", e);
            }
        }

        int color;
        string colortochange;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button_Save.ForeColor == Color.Red)
            {
                colortochange = "Red";
                color = 254;
            }
            if (button_Save.ForeColor == Color.Green)
            {
                colortochange = "Green";
                color = 254;
            }

            if (colortochange == "Green")
            {
                if (button_Save.ForeColor != Color.FromArgb(0, 0, 0))
                {
                    button_Save.ForeColor = Color.FromArgb(0, color, 0);
                    color--;
                }
            }
            else if (colortochange == "Red")
            {
                if (button_Save.ForeColor != Color.FromArgb(0, 0, 0))
                {
                    button_Save.ForeColor = Color.FromArgb(color, 0, 0);
                    color--;
                }
            }
        }

        private void Form_Sprava_uctu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Chcete zachovat změny v účtech?", "Uložit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (System.IO.File.Exists(FileLocation))
                    Form_Mainwindow.LoginData.WriteXml(FileLocation, XmlWriteMode.WriteSchema);
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.ShowDialog();
                    FileLocation = saveFileDialog.FileName;
                    Form_Mainwindow.LoginData.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
                }
            }
        }
    }
}
