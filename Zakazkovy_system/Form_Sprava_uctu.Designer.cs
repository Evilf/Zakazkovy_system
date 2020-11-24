namespace Zakazkovy_system
{
    partial class Form_Sprava_uctu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_CurrentUser = new System.Windows.Forms.Label();
            this.textBox_Jmeno = new System.Windows.Forms.TextBox();
            this.textBox_Heslo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Controls = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Rights = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_NotAuthorized = new System.Windows.Forms.Label();
            this.panel_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(10, 107);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(100, 30);
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "Uložit změny";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_CurrentUser
            // 
            this.label_CurrentUser.AutoSize = true;
            this.label_CurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_CurrentUser.Location = new System.Drawing.Point(326, 5);
            this.label_CurrentUser.Name = "label_CurrentUser";
            this.label_CurrentUser.Size = new System.Drawing.Size(104, 17);
            this.label_CurrentUser.TabIndex = 1;
            this.label_CurrentUser.Text = "Výběrové Pole:";
            // 
            // textBox_Jmeno
            // 
            this.textBox_Jmeno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Jmeno.Location = new System.Drawing.Point(151, 3);
            this.textBox_Jmeno.Name = "textBox_Jmeno";
            this.textBox_Jmeno.Size = new System.Drawing.Size(150, 26);
            this.textBox_Jmeno.TabIndex = 2;
            // 
            // textBox_Heslo
            // 
            this.textBox_Heslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Heslo.Location = new System.Drawing.Point(151, 35);
            this.textBox_Heslo.Name = "textBox_Heslo";
            this.textBox_Heslo.Size = new System.Drawing.Size(150, 26);
            this.textBox_Heslo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jméno uživatele:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(37, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Heslo uživatele:";
            // 
            // panel_Controls
            // 
            this.panel_Controls.Controls.Add(this.button_Remove);
            this.panel_Controls.Controls.Add(this.button_Add);
            this.panel_Controls.Controls.Add(this.listView1);
            this.panel_Controls.Controls.Add(this.comboBox_Rights);
            this.panel_Controls.Controls.Add(this.label_CurrentUser);
            this.panel_Controls.Controls.Add(this.label3);
            this.panel_Controls.Controls.Add(this.label2);
            this.panel_Controls.Controls.Add(this.label1);
            this.panel_Controls.Controls.Add(this.textBox_Heslo);
            this.panel_Controls.Controls.Add(this.textBox_Jmeno);
            this.panel_Controls.Controls.Add(this.button_Save);
            this.panel_Controls.Location = new System.Drawing.Point(8, 4);
            this.panel_Controls.Name = "panel_Controls";
            this.panel_Controls.Size = new System.Drawing.Size(481, 246);
            this.panel_Controls.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Oprávnění uživatele:";
            // 
            // comboBox_Rights
            // 
            this.comboBox_Rights.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_Rights.FormattingEnabled = true;
            this.comboBox_Rights.Location = new System.Drawing.Point(151, 67);
            this.comboBox_Rights.Name = "comboBox_Rights";
            this.comboBox_Rights.Size = new System.Drawing.Size(150, 28);
            this.comboBox_Rights.TabIndex = 4;
            this.comboBox_Rights.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.Location = new System.Drawing.Point(329, 25);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(134, 216);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(116, 107);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(100, 30);
            this.button_Add.TabIndex = 9;
            this.button_Add.Text = "Přidat uživatele";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(222, 107);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(100, 30);
            this.button_Remove.TabIndex = 10;
            this.button_Remove.Text = "Odebrat uživatele";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_NotAuthorized
            // 
            this.label_NotAuthorized.AutoSize = true;
            this.label_NotAuthorized.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_NotAuthorized.ForeColor = System.Drawing.Color.Red;
            this.label_NotAuthorized.Location = new System.Drawing.Point(93, 253);
            this.label_NotAuthorized.Name = "label_NotAuthorized";
            this.label_NotAuthorized.Size = new System.Drawing.Size(319, 22);
            this.label_NotAuthorized.TabIndex = 11;
            this.label_NotAuthorized.Text = "Pro změny v účtech nemáte oprávnění.";
            this.label_NotAuthorized.Visible = false;
            // 
            // Form_Sprava_uctu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 297);
            this.Controls.Add(this.label_NotAuthorized);
            this.Controls.Add(this.panel_Controls);
            this.KeyPreview = true;
            this.Name = "Form_Sprava_uctu";
            this.Text = "Form_Sprava_uctu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Sprava_uctu_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Sprava_uctu_KeyDown);
            this.panel_Controls.ResumeLayout(false);
            this.panel_Controls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_CurrentUser;
        private System.Windows.Forms.TextBox textBox_Jmeno;
        private System.Windows.Forms.TextBox textBox_Heslo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_Controls;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox_Rights;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_NotAuthorized;
    }
}