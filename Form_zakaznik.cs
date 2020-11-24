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
    public partial class Form_zakaznik : Form
    {
        public Form_zakaznik()
        {
            InitializeComponent();
        }

        public void ClearForm()
        {
            

            textBox_Spolecnost.Text = "";
            textBox_Jmeno.Text = "";
            textBox_Prijmeni.Text = "";
            textBox_Ulice.Text = "";
            textBox_Mesto.Text = "";
            textBox_PSC.Text = "";
            textBox_Tel.Text = "";
            textBox_email.Text = "";
            textBox_ICO.Text = "";
            textBox_DIC.Text = "";
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool canProceed = false;
            foreach (DataRow row in Form_Mainwindow.Data.Tables[1].Rows)
            {
                if (row[1].ToString() == textBox_Spolecnost.Text || row[9].ToString() == textBox_ICO.Text || (row[2].ToString() == textBox_Jmeno.Text && row[3].ToString() == textBox_Prijmeni.Text))
                {
                    MessageBox.Show("Pro přidání nového zákazníka se nesmí shodovat tyto pole: Společnost nebo IČO nebo Jméno a příjmení s jiným záznamem.", "Nesprávné údaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    canProceed = false;
                    break;
                }
                else
                {
                    canProceed = true;
                }
            }

            if (canProceed && textBox_Spolecnost.Text != "" && textBox_ICO.Text != "" && textBox_DIC.Text != "" && (textBox_email.Text != "" || textBox_Tel.Text != ""))
            {
                DataRow row = Form_Mainwindow.Data.Tables[1].NewRow();
                row[1] = textBox_Spolecnost.Text;
                row[2] = textBox_Jmeno.Text;
                row[3] = textBox_Prijmeni.Text;
                row[4] = textBox_Ulice.Text;
                row[5] = textBox_Mesto.Text;
                row[6] = textBox_PSC.Text;
                row[7] = textBox_Tel.Text;
                row[8] = textBox_email.Text;
                row[9] = textBox_ICO.Text;
                row[10] = textBox_DIC.Text;
                Form_Mainwindow.Data.Tables[1].Rows.Add(row);
                Form_Mainwindow.Update_to_database();
                MessageBox.Show("Přidáno.", "Přidáno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Pro přidání nového zákazníka musíte vyplnit tyto pole: Společnost, IČO, DIČ + telefon nebo email ", "Nedostatek údajů", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button_Find_Click(object sender, EventArgs e)
        {

            List<string> found = new List<string>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[1].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString().Contains(comboBox1.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString());
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox1.Items.Add(found[i]);
                }
                ClearForm();
            }
            else if (found.Count == 0)
            {
                MessageBox.Show("Zákazník: " + comboBox1.Text + " nebyl nalezen.", "Neexistuje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                foreach (DataRow row in Form_Mainwindow.Data.Tables[1].Rows)
                {
                    if (row[1].ToString().StartsWith(comboBox1.Text))
                    {
                        textBox_Spolecnost.Text = row[1].ToString();
                        textBox_Jmeno.Text = row[2].ToString();
                        textBox_Prijmeni.Text = row[3].ToString();
                        textBox_Ulice.Text = row[4].ToString();
                        textBox_Mesto.Text = row[5].ToString();
                        textBox_PSC.Text = row[6].ToString();
                        textBox_Tel.Text = row[7].ToString();
                        textBox_email.Text = row[8].ToString();
                        textBox_ICO.Text = row[9].ToString();
                        textBox_DIC.Text = row[10].ToString();
                        break;
                    }
                    
                }
                comboBox1.Items.Clear();
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (textBox_ICO.Text != "")
            {
                foreach (DataRow row in Form_Mainwindow.Data.Tables[1].Rows)
                {
                    if (row[9].ToString() == textBox_ICO.Text && row[2].ToString() == textBox_Jmeno.Text && row[3].ToString() == textBox_Prijmeni.Text)
                    {
                        row.Delete();
                        Form_Mainwindow.Data.Tables[1].AcceptChanges();
                        ClearForm();
                        comboBox1.Text = "";
                        break;
                    }
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (textBox_ICO.Text != "") 
            {
                foreach(DataRow row in Form_Mainwindow.Data.Tables[1].Rows)
                {
                    if(row[9].ToString() == textBox_ICO.Text && row[2].ToString() == textBox_Jmeno.Text && row[3].ToString() == textBox_Prijmeni.Text)
                    {
                        row.BeginEdit();
                        row[1] = textBox_Spolecnost.Text;
                        row[2] = textBox_Jmeno.Text;
                        row[3] = textBox_Prijmeni.Text;
                        row[4] = textBox_Ulice.Text;
                        row[5] = textBox_Mesto.Text;
                        row[6] = textBox_PSC.Text;
                        row[7] = textBox_Tel.Text;
                        row[8] = textBox_email.Text;
                        row[9] = textBox_ICO.Text;
                        row[10] = textBox_DIC.Text;
                        row.EndEdit();
                        break;
                    }
                }
            }
        }

        private void button_clear_fields_Click(object sender, EventArgs e)
        {
            ClearForm();
            comboBox1.Text = "";
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Find_Click("", e);
            }
        }

        private void Form_zakaznik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                foreach (DataRow row in Form_Mainwindow.Data.Tables[2].Rows)
                {
                    if (row[9].ToString() == textBox_ICO.Text && row[2].ToString() == textBox_Jmeno.Text && row[3].ToString() == textBox_Prijmeni.Text)
                    {
                        button_Save_Click("", e);
                    }
                    else
                    {
                        button_Add_Click("", e);
                    }
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
            List<string> found = new List<string>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[1].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString().Contains(comboBox1.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString());
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox1.Items.Add(found[i]);
                }
                ClearForm();
            }
            comboBox1.SelectionStart = comboBox1.Text.Length;
            Cursor.Current = Cursors.Default;
        }
    }
}
