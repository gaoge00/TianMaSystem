namespace BSC_System
{
    partial class PC22_Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC22_Dialog));
            this.dtp_rq = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_je = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_bz = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_status = new System.Windows.Forms.ComboBox();
            this.cobKh = new System.Windows.Forms.ComboBox();
            this.nud_dj = new System.Windows.Forms.NumericUpDown();
            this.nud_ckzssl = new System.Windows.Forms.NumericUpDown();
            this.txt_ckzlbh = new System.Windows.Forms.TextBox();
            this.txt_zksl = new System.Windows.Forms.TextBox();
            this.txtKHBH = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cobPM = new System.Windows.Forms.ComboBox();
            this.cobPH = new System.Windows.Forms.ComboBox();
            this.cobCL = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ckzssl)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_rq
            // 
            this.dtp_rq.Location = new System.Drawing.Point(121, 20);
            this.dtp_rq.Name = "dtp_rq";
            this.dtp_rq.Size = new System.Drawing.Size(124, 21);
            this.dtp_rq.TabIndex = 0;
            this.dtp_rq.Value = new System.DateTime(2014, 10, 9, 0, 0, 0, 0);
            this.dtp_rq.ValueChanged += new System.EventHandler(this.dtp_rq_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "出库日期：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(75, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "品名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label8.Location = new System.Drawing.Point(74, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "品号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(75, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "材料：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(23, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "出库指令编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(75, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "客户：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label5.Location = new System.Drawing.Point(49, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "在库数量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label6.Location = new System.Drawing.Point(23, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "出库指示数量：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label7.Location = new System.Drawing.Point(276, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "单价：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label9.Location = new System.Drawing.Point(75, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "金额：";
            // 
            // txt_je
            // 
            this.txt_je.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_je.Location = new System.Drawing.Point(121, 284);
            this.txt_je.MaxLength = 15;
            this.txt_je.Name = "txt_je";
            this.txt_je.ReadOnly = true;
            this.txt_je.Size = new System.Drawing.Size(149, 21);
            this.txt_je.TabIndex = 9;
            this.txt_je.TabStop = false;
            this.txt_je.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(75, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "备注：";
            // 
            // txt_bz
            // 
            this.txt_bz.Location = new System.Drawing.Point(121, 325);
            this.txt_bz.MaxLength = 65535;
            this.txt_bz.Multiline = true;
            this.txt_bz.Name = "txt_bz";
            this.txt_bz.Size = new System.Drawing.Size(329, 42);
            this.txt_bz.TabIndex = 20;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_save.Location = new System.Drawing.Point(143, 396);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(81, 35);
            this.btn_save.TabIndex = 22;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_close.Location = new System.Drawing.Point(317, 396);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(81, 35);
            this.btn_close.TabIndex = 24;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cobCL);
            this.groupBox1.Controls.Add(this.cobPH);
            this.groupBox1.Controls.Add(this.cobPM);
            this.groupBox1.Controls.Add(this.cbb_status);
            this.groupBox1.Controls.Add(this.cobKh);
            this.groupBox1.Controls.Add(this.nud_dj);
            this.groupBox1.Controls.Add(this.nud_ckzssl);
            this.groupBox1.Controls.Add(this.txt_ckzlbh);
            this.groupBox1.Controls.Add(this.txt_zksl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_rq);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_bz);
            this.groupBox1.Controls.Add(this.txt_je);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtKHBH);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 378);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cbb_status
            // 
            this.cbb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_status.FormattingEnabled = true;
            this.cbb_status.Location = new System.Drawing.Point(326, 285);
            this.cbb_status.Name = "cbb_status";
            this.cbb_status.Size = new System.Drawing.Size(124, 20);
            this.cbb_status.TabIndex = 17;
            // 
            // cobKh
            // 
            this.cobKh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobKh.FormattingEnabled = true;
            this.cobKh.Items.AddRange(new object[] {
            "正常入库",
            "返品入库"});
            this.cobKh.Location = new System.Drawing.Point(180, 180);
            this.cobKh.Name = "cobKh";
            this.cobKh.Size = new System.Drawing.Size(270, 20);
            this.cobKh.TabIndex = 9;
            this.cobKh.TextChanged += new System.EventHandler(this.cobKh_TextChanged);
            // 
            // nud_dj
            // 
            this.nud_dj.DecimalPlaces = 3;
            this.nud_dj.Location = new System.Drawing.Point(326, 251);
            this.nud_dj.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nud_dj.Name = "nud_dj";
            this.nud_dj.Size = new System.Drawing.Size(124, 21);
            this.nud_dj.TabIndex = 15;
            this.nud_dj.ValueChanged += new System.EventHandler(this.nud_dj_ValueChanged);
            this.nud_dj.Enter += new System.EventHandler(this.nud_dj_Enter);
            // 
            // nud_ckzssl
            // 
            this.nud_ckzssl.Location = new System.Drawing.Point(121, 250);
            this.nud_ckzssl.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nud_ckzssl.Name = "nud_ckzssl";
            this.nud_ckzssl.Size = new System.Drawing.Size(149, 21);
            this.nud_ckzssl.TabIndex = 11;
            this.nud_ckzssl.ValueChanged += new System.EventHandler(this.nud_ckzssl_ValueChanged);
            this.nud_ckzssl.Enter += new System.EventHandler(this.nud_ckzssl_Enter);
            this.nud_ckzssl.Leave += new System.EventHandler(this.nud_ckzssl_Leave);
            this.nud_ckzssl.Validating += new System.ComponentModel.CancelEventHandler(this.nud_ckzssl_Validating);
            // 
            // txt_ckzlbh
            // 
            this.txt_ckzlbh.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_ckzlbh.Location = new System.Drawing.Point(121, 144);
            this.txt_ckzlbh.MaxLength = 200;
            this.txt_ckzlbh.Name = "txt_ckzlbh";
            this.txt_ckzlbh.ReadOnly = true;
            this.txt_ckzlbh.Size = new System.Drawing.Size(329, 21);
            this.txt_ckzlbh.TabIndex = 4;
            this.txt_ckzlbh.TabStop = false;
            // 
            // txt_zksl
            // 
            this.txt_zksl.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_zksl.Location = new System.Drawing.Point(121, 217);
            this.txt_zksl.MaxLength = 15;
            this.txt_zksl.Name = "txt_zksl";
            this.txt_zksl.ReadOnly = true;
            this.txt_zksl.Size = new System.Drawing.Size(149, 21);
            this.txt_zksl.TabIndex = 6;
            this.txt_zksl.TabStop = false;
            this.txt_zksl.Text = "0";
            // 
            // txtKHBH
            // 
            this.txtKHBH.Location = new System.Drawing.Point(121, 179);
            this.txtKHBH.MaxLength = 15;
            this.txtKHBH.Name = "txtKHBH";
            this.txtKHBH.Size = new System.Drawing.Size(53, 21);
            this.txtKHBH.TabIndex = 7;
            this.txtKHBH.Text = "000000";
            this.txtKHBH.TextChanged += new System.EventHandler(this.txtKHBH_TextChanged);
            this.txtKHBH.Leave += new System.EventHandler(this.txtKHBH_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label13.Location = new System.Drawing.Point(276, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "状态：";
            // 
            // cobPM
            // 
            this.cobPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobPM.FormattingEnabled = true;
            this.cobPM.Location = new System.Drawing.Point(121, 53);
            this.cobPM.Name = "cobPM";
            this.cobPM.Size = new System.Drawing.Size(234, 20);
            this.cobPM.TabIndex = 1;
            this.cobPM.Leave += new System.EventHandler(this.cobPM_Leave);
            // 
            // cobPH
            // 
            this.cobPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobPH.FormattingEnabled = true;
            this.cobPH.Location = new System.Drawing.Point(121, 83);
            this.cobPH.Name = "cobPH";
            this.cobPH.Size = new System.Drawing.Size(234, 20);
            this.cobPH.TabIndex = 3;
            this.cobPH.Leave += new System.EventHandler(this.cobPH_Leave);
            // 
            // cobCL
            // 
            this.cobCL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCL.FormattingEnabled = true;
            this.cobCL.Location = new System.Drawing.Point(121, 112);
            this.cobCL.Name = "cobCL";
            this.cobCL.Size = new System.Drawing.Size(234, 20);
            this.cobCL.TabIndex = 5;
            this.cobCL.Leave += new System.EventHandler(this.cobCL_Leave);
            // 
            // PC22_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(538, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC22_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PC22_Dialog_FormClosing);
            this.Load += new System.EventHandler(this.PC22_Dialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PC22_Dialog_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ckzssl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_rq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_je;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_bz;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ckzlbh;
        private System.Windows.Forms.TextBox txt_zksl;
        private System.Windows.Forms.NumericUpDown nud_ckzssl;
        private System.Windows.Forms.NumericUpDown nud_dj;
        private System.Windows.Forms.ComboBox cobKh;
        private System.Windows.Forms.ComboBox cbb_status;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtKHBH;
        private System.Windows.Forms.ComboBox cobCL;
        private System.Windows.Forms.ComboBox cobPH;
        private System.Windows.Forms.ComboBox cobPM;
    }
}