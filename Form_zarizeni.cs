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
    public partial class Form_zarizeni : Form
    {
        public Form_zarizeni()
        {
            InitializeComponent();
        }

        private void Clear_form()
        {
            textBox_Model.Text = "";
            textBox_Typ_zarizeni.Text = "";
            textBox_Vyrobce.Text = "";
        }

        private void button_clear_fields_Click(object sender, EventArgs e)
        {
            Clear_form();
            comboBox1.Text = "";
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            //List<string> found = new List<string>();
            //int count = 0;
            //for (int i = 1; i <= Form_Mainwindow.Data.Tables[2].Rows.Count; i++)
            //{
            //    if (Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString().Contains(comboBox1.Text))
            //    {
            //        found.Add(Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString());
            //        count++;
            //    }
            //}
            //if (found.Count > 1)
            //{
            //    comboBox1.Items.Clear();
            //    for (int i = 0; i < found.Count; i++)
            //    {
            //        if (found[i] != null)
            //            comboBox1.Items.Add(found[i]);
            //    }
            //    Clear_form();
            //}
            //else if (found.Count == 0)
            //{
            //    MessageBox.Show("Zařízení číslo: " + comboBox1.Text + " nebylo nalezeno.", "Zařízení nebylo nalezeno.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //}
            //else
            //{
            //    foreach (DataRow row in Form_Mainwindow.Data.Tables[2].Rows) {
            //        if (row[2].ToString().Contains(comboBox1.Text)) {
            //            textBox_Vyrobce.Text = row[0].ToString();
            //            textBox_Typ_zarizeni.Text = row[1].ToString();
            //            textBox_Model.Text = row[2].ToString();
            //            break;
            //        }
            //    }
            //}     
            UpdatedSearch();

        }

        private void UpdatedSearch()
        {
            List<DataRow> found = new List<DataRow>();
            int count = 0;
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[2].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString().Contains(comboBox1.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[2].Rows[i - 1]);
                    count++;
                }
            }
            if (found.Count > 1)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < found.Count; i++)
                {
                    if (found[i] != null)
                        comboBox1.Items.Add(found[i][2].ToString());
                }
                Clear_form();
            }
            else if (found.Count == 0)
            {
                MessageBox.Show("Zařízení číslo: " + comboBox1.Text + " nebylo nalezeno.", "Zařízení nebylo nalezeno.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                textBox_Vyrobce.Text = found[0][0].ToString();
                textBox_Typ_zarizeni.Text = found[0][1].ToString();
                textBox_Model.Text = found[0][2].ToString();
                
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataRow row in Form_Mainwindow.Data.Tables[2].Rows)
            {
                if (row[2].ToString() == textBox_Model.Text)
                {
                    row.Delete();
                    Form_Mainwindow.Update_to_database();
                    Clear_form();
                    comboBox1.Text = "";
                    found = true;
                    break;
                }               
            }
            if(!found)
            {
                MessageBox.Show("Zařízení: " + textBox_Model.Text + " nebylo nalezeno.", "Zařízení nebylo nalezeno.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool canProceed = false;
            foreach (DataRow row in Form_Mainwindow.Data.Tables[2].Rows)
            {
                if (row[2].ToString() == textBox_Model.Text)
                {
                    MessageBox.Show("Pro přidání nového zařízení se nesmí shodovat Model s jiným záznamem.", "Nesprávné údaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    canProceed = false;
                    break;
                }
                else
                {
                    canProceed = true;
                }
            }
                
            if (canProceed && textBox_Model.Text != "" && textBox_Vyrobce.Text != "")
            {
                DataRow row = Form_Mainwindow.Data.Tables[2].NewRow();
                row[0] = textBox_Vyrobce.Text;
                row[1] = textBox_Typ_zarizeni.Text;
                row[2] = textBox_Model.Text;
                Form_Mainwindow.Data.Tables[2].Rows.Add(row);
                Form_Mainwindow.Update_to_database();
                MessageBox.Show("Přidáno.", "Přidáno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Pro přidání nového zařízení musíte vyplnit tyto pole: Model a Výrobce.", "Nedostatek údajů", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            bool completed = false;
            foreach(DataRow row in Form_Mainwindow.Data.Tables[2].Rows)
            {
                if(row[2].ToString() == textBox_Model.Text)
                {
                    row.BeginEdit();
                    row[0] = textBox_Vyrobce.Text;
                    row[1] = textBox_Typ_zarizeni.Text;
                    row[2] = textBox_Model.Text;
                    row.EndEdit();
                    completed = true;
                    break;
                }
            }
            if(!completed)
            {
                if(MessageBox.Show("Zařízení: " + textBox_Model.Text + " neexistuje. Chcete ho přidat?", "Nenalezené zařízení.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    button_Add_Click("", e);
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Find_Click("", e);
            }
        }

        private void Form_zarizeni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                foreach (DataRow row in Form_Mainwindow.Data.Tables[2].Rows)
                {
                    if (row[2].ToString() == textBox_Model.Text)
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
            for (int i = 1; i <= Form_Mainwindow.Data.Tables[2].Rows.Count; i++)
            {
                if (Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString().Contains(comboBox1.Text))
                {
                    found.Add(Form_Mainwindow.Data.Tables[2].Rows[i - 1][2].ToString());
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
                Clear_form();
            }
            comboBox1.SelectionStart = comboBox1.Text.Length;
            Cursor.Current = Cursors.Default;
        }
    }
}
