using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Zakazkovy_system
{
    public partial class Form_tvorba_zakazky : Form
    {
        public Form_tvorba_zakazky()
        {
            InitializeComponent();
            textBox_Prijem.Text = DateTime.Now.ToString();
        }

        private void ClearForm_zakaznik()
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

        private void ClearForm_zarizeni()
        {
            textBox_Dalsi_identifikace.Text = "";
            textBox_Model.Text = "";
            textBox_SN.Text = "";
            textBox_Typ_zarizeni.Text = "";
            textBox_Vyrobce.Text = "";
        }

        private void button_SearchField_zarizeni_Click(object sender, EventArgs e)
        {
            List<string> found = new List<string>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[2].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString().Contains(comboBox_SearchField_zarizeni.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString());
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox_SearchField_zarizeni.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox_SearchField_zarizeni.Items.Add(found[i]);
                }
                ClearForm_zarizeni();
            }
            else if (found.Count == 0)
            {
                MessageBox.Show("Zařízení: " + comboBox_SearchField_zarizeni.Text + " nebylo nalezeno.", "Zařízení nebylo nalezeno.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                foreach (DataRow row in Form_Mainwindow.Data.Tables[2].Rows)
                {
                    if (row[2].ToString().Contains(comboBox_SearchField_zarizeni.Text))
                    {
                        textBox_Vyrobce.Text = row[0].ToString();
                        textBox_Typ_zarizeni.Text = row[1].ToString();
                        textBox_Model.Text = row[2].ToString();
                        break;
                    }
                }
            }
        }

        private void button_SearchField_zakaznik_Click(object sender, EventArgs e)
        {
            List<string> found = new List<string>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[1].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString().Contains(comboBox_SearchField_zakaznik.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString());
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox_SearchField_zakaznik.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox_SearchField_zakaznik.Items.Add(found[i]);
                }
                ClearForm_zakaznik();
            }
            else if (found.Count == 0)
            {
                MessageBox.Show("Zákazník: " + comboBox_SearchField_zakaznik.Text + " nebyl nalezen.", "Neexistuje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                foreach (DataRow row in Form_Mainwindow.Data.Tables[1].Rows)
                {
                    if (row[1].ToString().StartsWith(comboBox_SearchField_zakaznik.Text))
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
                comboBox_SearchField_zakaznik.Items.Clear();
            }
        }

        private void comboBox_SearchField_zakaznik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_SearchField_zakaznik_Click("", e);
        }

        private void comboBox_SearchField_zarizeni_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
               button_SearchField_zarizeni_Click("", e);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool canProceed = false;
            foreach (DataRow row in Form_Mainwindow.Data.Tables[0].Rows)
            {
                if (row[0].ToString() == comboBox_Search_field.Text)
                {
                    MessageBox.Show("Pro přidání nové zakázky se nesmí shodovat číslo zakázky s jiným záznamem.", "Nesprávné údaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

                int ID_zakaznik = 0;
                foreach (DataRow row1 in Form_Mainwindow.Data.Tables[1].Rows)
                {
                    if (row1[1].ToString() == textBox_Spolecnost.Text || row1[9].ToString() == textBox_ICO.Text || (row1[2].ToString() == textBox_Jmeno.Text && row1[3].ToString() == textBox_Prijmeni.Text))
                    {
                        ID_zakaznik = int.Parse(row1[0].ToString());
                        break;
                    }
                    
                }

                DataRow row = Form_Mainwindow.Data.Tables[0].NewRow();
                row[0] = comboBox_Search_field.Text;
                row[1] = textBox_Cizi_cislo_zakazky.Text;
                row[2] = comboBox_Status.Text;
                row[3] = textBox_Model.Text;
                row[4] = ID_zakaznik;
                row[5] = textBox_Vizualni_stav.Text;
                row[6] = textBox_Popis_zavady.Text;
                row[7] = textBox_Cenovy_limit.Text;

                if (textBox_Reklamace.Text != "")
                    row[8] = textBox_Reklamace.Text;
                else
                {
                    row[8] = DateTime.MinValue;
                }

                if (textBox_Prijem.Text != "")
                    row[9] = textBox_Prijem.Text;
                else
                {
                    row[9] = DateTime.MinValue;
                }

                row[10] = textBox_Diagnostika.Text;
                row[11] = textBox_Vyjadreni_k_oprave.Text;

                if (textBox_Ukonceni.Text != "")
                    row[12] = textBox_Ukonceni.Text;
                else
                {
                    row[12] = DateTime.MinValue;
                }

                if (textBox_Expedice.Text != "")
                    row[13] = textBox_Expedice.Text;
                else
                {
                    row[13] = DateTime.MinValue;
                }

                if (textBox_Oprava.Text != "")
                    row[14] = textBox_Oprava.Text;
                else
                {
                    row[14] = DateTime.MinValue;
                }

                if (textBox_Diagnostika_datum.Text != "")
                    row[15] = textBox_Diagnostika_datum.Text;
                else
                {
                    row[15] = DateTime.MinValue;
                }

                row[16] = textBox_Dalsi_identifikace.Text;
                row[17] = textBox_SN.Text;

                Form_Mainwindow.Data.Tables[0].Rows.Add(row);
                Form_Mainwindow.Update_to_database();
                MessageBox.Show("Přidáno.", "Přidáno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Pro přidání nové zakázky musí být splněny následující požadavky: Vybraný zákazník, vybrané zařízeni a vyplněné pole: příjem.", "Nedostatek údajů", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void Form_tvorba_zakazky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                button_Add_Click("", e);
            }
        }

        private void comboBox_SearchField_zarizeni_TextChanged(object sender, EventArgs e)
        {
            comboBox_SearchField_zarizeni.DroppedDown = true;
            List<string> found = new List<string>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[2].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString().Contains(comboBox_SearchField_zarizeni.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString());
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox_SearchField_zarizeni.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox_SearchField_zarizeni.Items.Add(found[i]);
                }
            }
            comboBox_SearchField_zarizeni.SelectionStart = comboBox_SearchField_zarizeni.Text.Length;
            Cursor.Current = Cursors.Default;
        }

        private void comboBox_SearchField_zakaznik_TextChanged(object sender, EventArgs e)
        {
            comboBox_SearchField_zakaznik.DroppedDown = true;
            List<string> found = new List<string>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[1].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString().Contains(comboBox_SearchField_zakaznik.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[1].Rows[i - 1][1].ToString());
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox_SearchField_zakaznik.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox_SearchField_zakaznik.Items.Add(found[i]);
                }
            }
            comboBox_SearchField_zakaznik.SelectionStart = comboBox_SearchField_zakaznik.Text.Length;
            Cursor.Current = Cursors.Default;
        }
    }
}
