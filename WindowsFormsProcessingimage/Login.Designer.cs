namespace WindowsFormsProcessingimage
{
    partial class Login
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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grLogin = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLogin = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserDangky = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassDangKy = new System.Windows.Forms.TextBox();
            this.txtComfirm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(237, 72);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(259, 37);
            this.txtUser.TabIndex = 0;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(237, 136);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(259, 37);
            this.txtPass.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(194, 212);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(176, 41);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grLogin
            // 
            this.grLogin.BackColor = System.Drawing.Color.Teal;
            this.grLogin.Controls.Add(this.linkRegister);
            this.grLogin.Controls.Add(this.label2);
            this.grLogin.Controls.Add(this.label1);
            this.grLogin.Controls.Add(this.txtUser);
            this.grLogin.Controls.Add(this.btnLogin);
            this.grLogin.Controls.Add(this.txtPass);
            this.grLogin.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grLogin.Location = new System.Drawing.Point(480, 247);
            this.grLogin.Name = "grLogin";
            this.grLogin.Size = new System.Drawing.Size(543, 320);
            this.grLogin.TabIndex = 3;
            this.grLogin.TabStop = false;
            this.grLogin.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tài khoản";
            // 
            // linkRegister
            // 
            this.linkRegister.AutoSize = true;
            this.linkRegister.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRegister.LinkColor = System.Drawing.Color.Black;
            this.linkRegister.Location = new System.Drawing.Point(426, 286);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(101, 31);
            this.linkRegister.TabIndex = 5;
            this.linkRegister.TabStop = true;
            this.linkRegister.Text = "Register";
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(615, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 41);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phần mềm xử lý ảnh";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Teal;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtComfirm);
            this.groupBox1.Controls.Add(this.linkLogin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUserDangky);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPassDangKy);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(480, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 368);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register";
            this.groupBox1.Visible = false;
            // 
            // linkLogin
            // 
            this.linkLogin.AutoSize = true;
            this.linkLogin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogin.LinkColor = System.Drawing.Color.Black;
            this.linkLogin.Location = new System.Drawing.Point(492, 337);
            this.linkLogin.Name = "linkLogin";
            this.linkLogin.Size = new System.Drawing.Size(75, 31);
            this.linkLogin.TabIndex = 5;
            this.linkLogin.TabStop = true;
            this.linkLogin.Text = "Login";
            this.linkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogin_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 31);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tài khoản";
            // 
            // txtUserDangky
            // 
            this.txtUserDangky.Location = new System.Drawing.Point(279, 69);
            this.txtUserDangky.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserDangky.Name = "txtUserDangky";
            this.txtUserDangky.Size = new System.Drawing.Size(259, 37);
            this.txtUserDangky.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 286);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Đăng ký";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPassDangKy
            // 
            this.txtPassDangKy.Location = new System.Drawing.Point(279, 138);
            this.txtPassDangKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassDangKy.Name = "txtPassDangKy";
            this.txtPassDangKy.PasswordChar = '*';
            this.txtPassDangKy.Size = new System.Drawing.Size(259, 37);
            this.txtPassDangKy.TabIndex = 1;
            // 
            // txtComfirm
            // 
            this.txtComfirm.Location = new System.Drawing.Point(279, 200);
            this.txtComfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtComfirm.Name = "txtComfirm";
            this.txtComfirm.PasswordChar = '*';
            this.txtComfirm.Size = new System.Drawing.Size(259, 37);
            this.txtComfirm.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 31);
            this.label6.TabIndex = 7;
            this.label6.Text = "Nhập lại mật khẩu";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 775);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.grLogin.ResumeLayout(false);
            this.grLogin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox grLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComfirm;
        private System.Windows.Forms.LinkLabel linkLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserDangky;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPassDangKy;
    }
}