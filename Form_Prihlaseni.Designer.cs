namespace Zakazkovy_system
{
    partial class Form_Prihlaseni
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heslo:";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Password.Location = new System.Drawing.Point(78, 46);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(208, 27);
            this.textBox_Password.TabIndex = 2;
            this.textBox_Password.UseSystemPasswordChar = true;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jméno:";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_UserName.Location = new System.Drawing.Point(78, 12);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(208, 27);
            this.textBox_UserName.TabIndex = 1;
            this.textBox_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_UserName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(30, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nesprávné Jméno nebo Heslo.";
            this.label3.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(58, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Přihlásit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Prihlaseni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 147);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label1);
            this.Name = "Form_Prihlaseni";
            this.Text = "Form_Prihlaseni";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Prihlaseni_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Prihlaseni_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}