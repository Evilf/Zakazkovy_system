namespace Zakazkovy_system
{
    partial class Form_zarizeni
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
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Model = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Typ_zarizeni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Vyrobce = new System.Windows.Forms.TextBox();
            this.button_clear_fields = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Find = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.YellowGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(284, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 29);
            this.label6.TabIndex = 26;
            this.label6.Text = "Zařízení";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Location = new System.Drawing.Point(1, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 29);
            this.panel1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(87, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Model";
            // 
            // textBox_Model
            // 
            this.textBox_Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Model.Location = new System.Drawing.Point(145, 110);
            this.textBox_Model.Name = "textBox_Model";
            this.textBox_Model.Size = new System.Drawing.Size(388, 33);
            this.textBox_Model.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(47, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Typ zařízení";
            // 
            // textBox_Typ_zarizeni
            // 
            this.textBox_Typ_zarizeni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Typ_zarizeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Typ_zarizeni.Location = new System.Drawing.Point(145, 76);
            this.textBox_Typ_zarizeni.Name = "textBox_Typ_zarizeni";
            this.textBox_Typ_zarizeni.Size = new System.Drawing.Size(388, 33);
            this.textBox_Typ_zarizeni.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(72, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Výrobce";
            // 
            // textBox_Vyrobce
            // 
            this.textBox_Vyrobce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Vyrobce.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Vyrobce.Location = new System.Drawing.Point(145, 42);
            this.textBox_Vyrobce.Name = "textBox_Vyrobce";
            this.textBox_Vyrobce.Size = new System.Drawing.Size(388, 33);
            this.textBox_Vyrobce.TabIndex = 15;
            // 
            // button_clear_fields
            // 
            this.button_clear_fields.Location = new System.Drawing.Point(7, 169);
            this.button_clear_fields.Name = "button_clear_fields";
            this.button_clear_fields.Size = new System.Drawing.Size(104, 35);
            this.button_clear_fields.TabIndex = 91;
            this.button_clear_fields.Text = "Smaž všechny pole";
            this.button_clear_fields.UseVisualStyleBackColor = true;
            this.button_clear_fields.Click += new System.EventHandler(this.button_clear_fields_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(522, 207);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(104, 35);
            this.button_Save.TabIndex = 90;
            this.button_Save.Text = "Uložit změny";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(260, 164);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(356, 37);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(227, 210);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(104, 35);
            this.button_Delete.TabIndex = 88;
            this.button_Delete.Text = "Smaž zařízení";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(127, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 87;
            this.label7.Text = "Vyhledávací pole";
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(117, 210);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(104, 35);
            this.button_Find.TabIndex = 86;
            this.button_Find.Text = "Vyber zařízení";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(7, 210);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(104, 35);
            this.button_Add.TabIndex = 85;
            this.button_Add.Text = "Přidej zařízení";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // Form_zarizeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 263);
            this.Controls.Add(this.button_clear_fields);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_Find);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Model);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Typ_zarizeni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Vyrobce);
            this.Name = "Form_zarizeni";
            this.Text = "Form_zarizeni";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_zarizeni_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Model;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Typ_zarizeni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Vyrobce;
        private System.Windows.Forms.Button button_clear_fields;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Find;
        private System.Windows.Forms.Button button_Add;
    }
}