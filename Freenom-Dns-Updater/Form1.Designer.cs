namespace Freenom_Dns_Updater
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_change = new System.Windows.Forms.Button();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_sub_domain0 = new System.Windows.Forms.Label();
            this.txt_sub_domain0 = new System.Windows.Forms.TextBox();
            this.lbl_domain_id = new System.Windows.Forms.Label();
            this.txt_domain_id = new System.Windows.Forms.TextBox();
            this.lbl_sub_domain1 = new System.Windows.Forms.Label();
            this.txt_sub_domain1 = new System.Windows.Forms.TextBox();
            this.lbl_target0 = new System.Windows.Forms.Label();
            this.txt_ip0 = new System.Windows.Forms.TextBox();
            this.txt_ip1 = new System.Windows.Forms.TextBox();
            this.lbl_target1 = new System.Windows.Forms.Label();
            this.cb_auto0 = new System.Windows.Forms.CheckBox();
            this.cb_auto1 = new System.Windows.Forms.CheckBox();
            this.lbl_logs = new System.Windows.Forms.Label();
            this.lst_logs = new System.Windows.Forms.ListBox();
            this.lbl_version = new System.Windows.Forms.Label();
            this.txt_domain = new System.Windows.Forms.TextBox();
            this.lbl_domain = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(11, 248);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(300, 50);
            this.btn_change.TabIndex = 0;
            this.btn_change.Text = "Change";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(12, 82);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(240, 20);
            this.txt_email.TabIndex = 1;
            this.txt_email.Text = "name@email.com";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(12, 66);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(63, 13);
            this.lbl_email.TabIndex = 2;
            this.lbl_email.Text = "Login/Email";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(258, 66);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(53, 13);
            this.lbl_password.TabIndex = 4;
            this.lbl_password.Text = "Password";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(258, 82);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(240, 20);
            this.txt_password.TabIndex = 3;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Black;
            this.btn_exit.Font = new System.Drawing.Font("Arial", 18F);
            this.btn_exit.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_exit.Location = new System.Drawing.Point(756, 12);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(32, 32);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "X";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_sub_domain0
            // 
            this.lbl_sub_domain0.AutoSize = true;
            this.lbl_sub_domain0.Location = new System.Drawing.Point(12, 137);
            this.lbl_sub_domain0.Name = "lbl_sub_domain0";
            this.lbl_sub_domain0.Size = new System.Drawing.Size(100, 13);
            this.lbl_sub_domain0.TabIndex = 7;
            this.lbl_sub_domain0.Text = "sub domain0/empty";
            // 
            // txt_sub_domain0
            // 
            this.txt_sub_domain0.Location = new System.Drawing.Point(12, 153);
            this.txt_sub_domain0.Name = "txt_sub_domain0";
            this.txt_sub_domain0.Size = new System.Drawing.Size(240, 20);
            this.txt_sub_domain0.TabIndex = 6;
            // 
            // lbl_domain_id
            // 
            this.lbl_domain_id.AutoSize = true;
            this.lbl_domain_id.Location = new System.Drawing.Point(271, 176);
            this.lbl_domain_id.Name = "lbl_domain_id";
            this.lbl_domain_id.Size = new System.Drawing.Size(51, 13);
            this.lbl_domain_id.TabIndex = 11;
            this.lbl_domain_id.Text = "Domainid";
            // 
            // txt_domain_id
            // 
            this.txt_domain_id.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_domain_id.Location = new System.Drawing.Point(274, 192);
            this.txt_domain_id.Name = "txt_domain_id";
            this.txt_domain_id.Size = new System.Drawing.Size(120, 26);
            this.txt_domain_id.TabIndex = 10;
            this.txt_domain_id.Text = "1234567890";
            // 
            // lbl_sub_domain1
            // 
            this.lbl_sub_domain1.AutoSize = true;
            this.lbl_sub_domain1.Location = new System.Drawing.Point(12, 176);
            this.lbl_sub_domain1.Name = "lbl_sub_domain1";
            this.lbl_sub_domain1.Size = new System.Drawing.Size(67, 13);
            this.lbl_sub_domain1.TabIndex = 12;
            this.lbl_sub_domain1.Text = "sub domain1";
            // 
            // txt_sub_domain1
            // 
            this.txt_sub_domain1.Location = new System.Drawing.Point(12, 192);
            this.txt_sub_domain1.Name = "txt_sub_domain1";
            this.txt_sub_domain1.Size = new System.Drawing.Size(240, 20);
            this.txt_sub_domain1.TabIndex = 13;
            this.txt_sub_domain1.Text = "www";
            // 
            // lbl_target0
            // 
            this.lbl_target0.AutoSize = true;
            this.lbl_target0.Location = new System.Drawing.Point(435, 137);
            this.lbl_target0.Name = "lbl_target0";
            this.lbl_target0.Size = new System.Drawing.Size(52, 13);
            this.lbl_target0.TabIndex = 14;
            this.lbl_target0.Text = "Target/Ip";
            // 
            // txt_ip0
            // 
            this.txt_ip0.Location = new System.Drawing.Point(438, 153);
            this.txt_ip0.Name = "txt_ip0";
            this.txt_ip0.Size = new System.Drawing.Size(240, 20);
            this.txt_ip0.TabIndex = 15;
            this.txt_ip0.Text = "127.0.0.1";
            // 
            // txt_ip1
            // 
            this.txt_ip1.Location = new System.Drawing.Point(438, 192);
            this.txt_ip1.Name = "txt_ip1";
            this.txt_ip1.Size = new System.Drawing.Size(240, 20);
            this.txt_ip1.TabIndex = 17;
            this.txt_ip1.Text = "127.0.0.1";
            // 
            // lbl_target1
            // 
            this.lbl_target1.AutoSize = true;
            this.lbl_target1.Location = new System.Drawing.Point(435, 176);
            this.lbl_target1.Name = "lbl_target1";
            this.lbl_target1.Size = new System.Drawing.Size(52, 13);
            this.lbl_target1.TabIndex = 16;
            this.lbl_target1.Text = "Target/Ip";
            // 
            // cb_auto0
            // 
            this.cb_auto0.AutoSize = true;
            this.cb_auto0.Location = new System.Drawing.Point(708, 155);
            this.cb_auto0.Name = "cb_auto0";
            this.cb_auto0.Size = new System.Drawing.Size(47, 17);
            this.cb_auto0.TabIndex = 18;
            this.cb_auto0.Text = "auto";
            this.cb_auto0.UseVisualStyleBackColor = true;
            // 
            // cb_auto1
            // 
            this.cb_auto1.AutoSize = true;
            this.cb_auto1.Location = new System.Drawing.Point(708, 194);
            this.cb_auto1.Name = "cb_auto1";
            this.cb_auto1.Size = new System.Drawing.Size(47, 17);
            this.cb_auto1.TabIndex = 19;
            this.cb_auto1.Text = "auto";
            this.cb_auto1.UseVisualStyleBackColor = true;
            // 
            // lbl_logs
            // 
            this.lbl_logs.AutoSize = true;
            this.lbl_logs.Location = new System.Drawing.Point(12, 301);
            this.lbl_logs.Name = "lbl_logs";
            this.lbl_logs.Size = new System.Drawing.Size(30, 13);
            this.lbl_logs.TabIndex = 21;
            this.lbl_logs.Text = "Logs";
            // 
            // lst_logs
            // 
            this.lst_logs.FormattingEnabled = true;
            this.lst_logs.HorizontalScrollbar = true;
            this.lst_logs.Location = new System.Drawing.Point(12, 317);
            this.lst_logs.Name = "lst_logs";
            this.lst_logs.Size = new System.Drawing.Size(776, 121);
            this.lst_logs.TabIndex = 22;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(748, 437);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(40, 13);
            this.lbl_version.TabIndex = 23;
            this.lbl_version.Text = "v.1.0.0";
            // 
            // txt_domain
            // 
            this.txt_domain.Location = new System.Drawing.Point(274, 152);
            this.txt_domain.Name = "txt_domain";
            this.txt_domain.Size = new System.Drawing.Size(120, 20);
            this.txt_domain.TabIndex = 24;
            this.txt_domain.Text = "ihateadmins.tk";
            // 
            // lbl_domain
            // 
            this.lbl_domain.AutoSize = true;
            this.lbl_domain.Location = new System.Drawing.Point(271, 136);
            this.lbl_domain.Name = "lbl_domain";
            this.lbl_domain.Size = new System.Drawing.Size(43, 13);
            this.lbl_domain.TabIndex = 25;
            this.lbl_domain.Text = "Domain";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(455, 248);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(300, 50);
            this.btn_save.TabIndex = 26;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_domain);
            this.Controls.Add(this.txt_domain);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.lst_logs);
            this.Controls.Add(this.lbl_logs);
            this.Controls.Add(this.cb_auto1);
            this.Controls.Add(this.cb_auto0);
            this.Controls.Add(this.txt_ip1);
            this.Controls.Add(this.lbl_target1);
            this.Controls.Add(this.txt_ip0);
            this.Controls.Add(this.lbl_target0);
            this.Controls.Add(this.txt_sub_domain1);
            this.Controls.Add(this.lbl_sub_domain1);
            this.Controls.Add(this.lbl_domain_id);
            this.Controls.Add(this.txt_domain_id);
            this.Controls.Add(this.lbl_sub_domain0);
            this.Controls.Add(this.txt_sub_domain0);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.btn_change);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Freenom-DNS-Updater by ihatedmins v.1.0.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_sub_domain0;
        private System.Windows.Forms.TextBox txt_sub_domain0;
        private System.Windows.Forms.Label lbl_domain_id;
        private System.Windows.Forms.TextBox txt_domain_id;
        private System.Windows.Forms.Label lbl_sub_domain1;
        private System.Windows.Forms.TextBox txt_sub_domain1;
        private System.Windows.Forms.Label lbl_target0;
        private System.Windows.Forms.TextBox txt_ip0;
        private System.Windows.Forms.TextBox txt_ip1;
        private System.Windows.Forms.Label lbl_target1;
        private System.Windows.Forms.CheckBox cb_auto0;
        private System.Windows.Forms.CheckBox cb_auto1;
        private System.Windows.Forms.Label lbl_logs;
        private System.Windows.Forms.ListBox lst_logs;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.TextBox txt_domain;
        private System.Windows.Forms.Label lbl_domain;
        private System.Windows.Forms.Button btn_save;
    }
}

