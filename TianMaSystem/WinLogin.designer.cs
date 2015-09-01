namespace TianMaSystem
{
    partial class WinLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinLogin));
            this.btnFromClosed = new System.Windows.Forms.Button();
            this.UserNameLab = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFromClosed
            // 
            this.btnFromClosed.BackColor = System.Drawing.Color.White;
            this.btnFromClosed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFromClosed.BackgroundImage")));
            this.btnFromClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFromClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromClosed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnFromClosed.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnFromClosed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFromClosed.Location = new System.Drawing.Point(511, 94);
            this.btnFromClosed.Name = "btnFromClosed";
            this.btnFromClosed.Size = new System.Drawing.Size(25, 25);
            this.btnFromClosed.TabIndex = 1366;
            this.btnFromClosed.UseVisualStyleBackColor = false;
            this.btnFromClosed.Click += new System.EventHandler(this.btnFromClosed_Click);
            // 
            // UserNameLab
            // 
            this.UserNameLab.AutoSize = true;
            this.UserNameLab.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLab.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.UserNameLab.Location = new System.Drawing.Point(459, 174);
            this.UserNameLab.Name = "UserNameLab";
            this.UserNameLab.Size = new System.Drawing.Size(0, 16);
            this.UserNameLab.TabIndex = 46;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.txtPass.Location = new System.Drawing.Point(210, 248);
            this.txtPass.MaxLength = 10;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.ShortcutsEnabled = false;
            this.txtPass.Size = new System.Drawing.Size(243, 26);
            this.txtPass.TabIndex = 37;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginPage_KeyDown);
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // btn_Login
            // 
            this.btn_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Login.BackgroundImage")));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Login.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Login.Location = new System.Drawing.Point(210, 308);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(243, 33);
            this.btn_Login.TabIndex = 48;
            this.btn_Login.Text = "登  录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.txtUserName.Location = new System.Drawing.Point(210, 168);
            this.txtUserName.MaxLength = 5;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ShortcutsEnabled = false;
            this.txtUserName.Size = new System.Drawing.Size(243, 26);
            this.txtUserName.TabIndex = 36;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginPage_KeyDown);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName1_KeyPress);
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // WinLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(651, 467);
            this.Controls.Add(this.btnFromClosed);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.UserNameLab);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WinLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLab;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnFromClosed;

    }
}