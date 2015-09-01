namespace BSC_System
{
    partial class PC29_sub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC29_sub));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCLBH = new System.Windows.Forms.TextBox();
            this.txtPM = new System.Windows.Forms.TextBox();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFPSL = new System.Windows.Forms.TextBox();
            this.dateFPRq = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBZ = new System.Windows.Forms.TextBox();
            this.btnKHBH = new System.Windows.Forms.Button();
            this.txtKHMC = new System.Windows.Forms.TextBox();
            this.txtKHBH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFPZ = new System.Windows.Forms.TextBox();
            this.txtFPZMC = new System.Windows.Forms.TextBox();
            this.btnFPZ = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExit.Location = new System.Drawing.Point(322, 424);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 29);
            this.btnExit.TabIndex = 151;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "关闭(&Q)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSave.Location = new System.Drawing.Point(190, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 147;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label13.Location = new System.Drawing.Point(99, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 12);
            this.label13.TabIndex = 61;
            this.label13.Text = "材料：";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.BackColor = System.Drawing.Color.Transparent;
            this.ID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.ID.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.ID.Location = new System.Drawing.Point(99, 76);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(44, 12);
            this.ID.TabIndex = 2;
            this.ID.Text = "品名：";
            this.ID.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(102, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "品号：";
            // 
            // txtCLBH
            // 
            this.txtCLBH.BackColor = System.Drawing.SystemColors.Window;
            this.txtCLBH.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.txtCLBH.Location = new System.Drawing.Point(146, 149);
            this.txtCLBH.MaxLength = 15;
            this.txtCLBH.Name = "txtCLBH";
            this.txtCLBH.ShortcutsEnabled = false;
            this.txtCLBH.Size = new System.Drawing.Size(189, 20);
            this.txtCLBH.TabIndex = 10;
            this.txtCLBH.TextChanged += new System.EventHandler(this.txtSYBH_TextChanged);
            this.txtCLBH.Enter += new System.EventHandler(this.txt_Enter);
            this.txtCLBH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtCLBH.Validating += new System.ComponentModel.CancelEventHandler(this.txtSYBH_Validating);
            // 
            // txtPM
            // 
            this.txtPM.BackColor = System.Drawing.SystemColors.Window;
            this.txtPM.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.txtPM.Location = new System.Drawing.Point(146, 73);
            this.txtPM.MaxLength = 50;
            this.txtPM.Name = "txtPM";
            this.txtPM.ShortcutsEnabled = false;
            this.txtPM.Size = new System.Drawing.Size(189, 20);
            this.txtPM.TabIndex = 3;
            this.txtPM.TextChanged += new System.EventHandler(this.txtSYBH_TextChanged);
            this.txtPM.Enter += new System.EventHandler(this.txt_Enter);
            this.txtPM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtPM.Validating += new System.ComponentModel.CancelEventHandler(this.txtSYBH_Validating);
            // 
            // txtPH
            // 
            this.txtPH.BackColor = System.Drawing.SystemColors.Window;
            this.txtPH.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.txtPH.Location = new System.Drawing.Point(146, 110);
            this.txtPH.MaxLength = 50;
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(189, 20);
            this.txtPH.TabIndex = 8;
            this.txtPH.TextChanged += new System.EventHandler(this.txtPH_TextChanged);
            this.txtPH.Enter += new System.EventHandler(this.txt_Enter);
            this.txtPH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtPH.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.ForeColor = System.Drawing.Color.Red;
            this.label66.Location = new System.Drawing.Point(126, 152);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(11, 12);
            this.label66.TabIndex = 28;
            this.label66.Text = "*";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.ForeColor = System.Drawing.Color.Red;
            this.label65.Location = new System.Drawing.Point(85, 113);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(11, 12);
            this.label65.TabIndex = 7;
            this.label65.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(126, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 12);
            this.label23.TabIndex = 1;
            this.label23.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(73, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "返品数量：";
            this.label10.UseWaitCursor = true;
            // 
            // txtFPSL
            // 
            this.txtFPSL.Font = new System.Drawing.Font("宋体", 9.75F);
            this.txtFPSL.Location = new System.Drawing.Point(147, 235);
            this.txtFPSL.MaxLength = 8;
            this.txtFPSL.Name = "txtFPSL";
            this.txtFPSL.ShortcutsEnabled = false;
            this.txtFPSL.Size = new System.Drawing.Size(188, 22);
            this.txtFPSL.TabIndex = 16;
            this.txtFPSL.TextChanged += new System.EventHandler(this.txtSYBH_TextChanged);
            this.txtFPSL.Enter += new System.EventHandler(this.txt_Enter);
            this.txtFPSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtFPSL.Validating += new System.ComponentModel.CancelEventHandler(this.txtSYBH_Validating);
            // 
            // dateFPRq
            // 
            this.dateFPRq.Location = new System.Drawing.Point(146, 33);
            this.dateFPRq.Name = "dateFPRq";
            this.dateFPRq.Size = new System.Drawing.Size(143, 21);
            this.dateFPRq.TabIndex = 0;
            this.dateFPRq.Value = new System.DateTime(2014, 10, 9, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label5.Location = new System.Drawing.Point(73, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 70;
            this.label5.Text = "返品日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label6.Location = new System.Drawing.Point(72, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "详细描述：";
            // 
            // txtBZ
            // 
            this.txtBZ.Location = new System.Drawing.Point(147, 329);
            this.txtBZ.MaxLength = 100;
            this.txtBZ.Multiline = true;
            this.txtBZ.Name = "txtBZ";
            this.txtBZ.Size = new System.Drawing.Size(351, 59);
            this.txtBZ.TabIndex = 59;
            // 
            // btnKHBH
            // 
            this.btnKHBH.BackColor = System.Drawing.Color.Transparent;
            this.btnKHBH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKHBH.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnKHBH.Location = new System.Drawing.Point(341, 184);
            this.btnKHBH.Name = "btnKHBH";
            this.btnKHBH.Size = new System.Drawing.Size(39, 29);
            this.btnKHBH.TabIndex = 15;
            this.btnKHBH.Text = "选择";
            this.btnKHBH.UseVisualStyleBackColor = false;
            this.btnKHBH.Click += new System.EventHandler(this.btnKHBH_Click);
            // 
            // txtKHMC
            // 
            this.txtKHMC.BackColor = System.Drawing.Color.LightYellow;
            this.txtKHMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKHMC.ForeColor = System.Drawing.Color.Black;
            this.txtKHMC.Location = new System.Drawing.Point(201, 189);
            this.txtKHMC.MaxLength = 20;
            this.txtKHMC.Name = "txtKHMC";
            this.txtKHMC.ReadOnly = true;
            this.txtKHMC.ShortcutsEnabled = false;
            this.txtKHMC.Size = new System.Drawing.Size(134, 21);
            this.txtKHMC.TabIndex = 62;
            this.txtKHMC.TabStop = false;
            // 
            // txtKHBH
            // 
            this.txtKHBH.BackColor = System.Drawing.SystemColors.Window;
            this.txtKHBH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKHBH.ForeColor = System.Drawing.Color.Black;
            this.txtKHBH.Location = new System.Drawing.Point(147, 189);
            this.txtKHBH.MaxLength = 6;
            this.txtKHBH.Name = "txtKHBH";
            this.txtKHBH.ShortcutsEnabled = false;
            this.txtKHBH.Size = new System.Drawing.Size(53, 21);
            this.txtKHBH.TabIndex = 11;
            this.txtKHBH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtKHBH.Leave += new System.EventHandler(this.txtKHBH_Leave);
            this.txtKHBH.Validating += new System.ComponentModel.CancelEventHandler(this.txtFPZ_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(99, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "客户：";
            this.label1.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(86, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "返品者：";
            this.label3.UseWaitCursor = true;
            // 
            // txtFPZ
            // 
            this.txtFPZ.BackColor = System.Drawing.SystemColors.Window;
            this.txtFPZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFPZ.ForeColor = System.Drawing.Color.Black;
            this.txtFPZ.Location = new System.Drawing.Point(147, 282);
            this.txtFPZ.MaxLength = 5;
            this.txtFPZ.Name = "txtFPZ";
            this.txtFPZ.ShortcutsEnabled = false;
            this.txtFPZ.Size = new System.Drawing.Size(53, 21);
            this.txtFPZ.TabIndex = 17;
            this.txtFPZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtFPZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtFPZ_Validating);
            // 
            // txtFPZMC
            // 
            this.txtFPZMC.BackColor = System.Drawing.Color.LightYellow;
            this.txtFPZMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFPZMC.ForeColor = System.Drawing.Color.Black;
            this.txtFPZMC.Location = new System.Drawing.Point(201, 282);
            this.txtFPZMC.MaxLength = 20;
            this.txtFPZMC.Name = "txtFPZMC";
            this.txtFPZMC.ReadOnly = true;
            this.txtFPZMC.ShortcutsEnabled = false;
            this.txtFPZMC.Size = new System.Drawing.Size(134, 21);
            this.txtFPZMC.TabIndex = 62;
            this.txtFPZMC.TabStop = false;
            // 
            // btnFPZ
            // 
            this.btnFPZ.BackColor = System.Drawing.Color.Transparent;
            this.btnFPZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFPZ.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnFPZ.Location = new System.Drawing.Point(341, 277);
            this.btnFPZ.Name = "btnFPZ";
            this.btnFPZ.Size = new System.Drawing.Size(39, 29);
            this.btnFPZ.TabIndex = 20;
            this.btnFPZ.Text = "选择";
            this.btnFPZ.UseVisualStyleBackColor = false;
            this.btnFPZ.Click += new System.EventHandler(this.btnFPZ_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(82, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 154;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(83, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 155;
            this.label9.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(55, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 156;
            this.label11.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(82, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "*";
            // 
            // PC29_sub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(594, 467);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateFPRq);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFPZ);
            this.Controls.Add(this.btnKHBH);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.txtFPZMC);
            this.Controls.Add(this.txtKHMC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtFPZ);
            this.Controls.Add(this.txtKHBH);
            this.Controls.Add(this.txtCLBH);
            this.Controls.Add(this.txtPM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPH);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.txtBZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFPSL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC29_sub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Window_Loaded);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WinFMD310_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPM;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFPSL;
        private System.Windows.Forms.TextBox txtCLBH;
        private System.Windows.Forms.DateTimePicker dateFPRq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBZ;
        private System.Windows.Forms.Button btnKHBH;
        private System.Windows.Forms.TextBox txtKHMC;
        private System.Windows.Forms.TextBox txtKHBH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFPZ;
        private System.Windows.Forms.TextBox txtFPZMC;
        private System.Windows.Forms.Button btnFPZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
    }
}