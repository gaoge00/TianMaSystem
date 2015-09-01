namespace BSC_System
{
    partial class PC26
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC26));
            this.cobCpjcz = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStartJprq = new System.Windows.Forms.TextBox();
            this.txtEndJprq = new System.Windows.Forms.TextBox();
            this.txtEndLhrq = new System.Windows.Forms.TextBox();
            this.txtStartLhrq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLotno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cobCpjcz
            // 
            this.cobCpjcz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCpjcz.FormattingEnabled = true;
            this.cobCpjcz.Items.AddRange(new object[] {
            "正常入库",
            "返品入库"});
            this.cobCpjcz.Location = new System.Drawing.Point(151, 196);
            this.cobCpjcz.Name = "cobCpjcz";
            this.cobCpjcz.Size = new System.Drawing.Size(121, 20);
            this.cobCpjcz.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(278, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "～";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(79, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检品日期：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label9.Location = new System.Drawing.Point(66, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "成品检查者：";
            // 
            // txtStartJprq
            // 
            this.txtStartJprq.Location = new System.Drawing.Point(151, 161);
            this.txtStartJprq.MaxLength = 10;
            this.txtStartJprq.Name = "txtStartJprq";
            this.txtStartJprq.Size = new System.Drawing.Size(121, 21);
            this.txtStartJprq.TabIndex = 4;
            this.txtStartJprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtStartJprq.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartJprq_Validating);
            // 
            // txtEndJprq
            // 
            this.txtEndJprq.Location = new System.Drawing.Point(300, 161);
            this.txtEndJprq.MaxLength = 10;
            this.txtEndJprq.Name = "txtEndJprq";
            this.txtEndJprq.Size = new System.Drawing.Size(121, 21);
            this.txtEndJprq.TabIndex = 5;
            this.txtEndJprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtEndJprq.Validating += new System.ComponentModel.CancelEventHandler(this.txtEndJprq_Validating);
            // 
            // txtEndLhrq
            // 
            this.txtEndLhrq.Location = new System.Drawing.Point(300, 125);
            this.txtEndLhrq.MaxLength = 10;
            this.txtEndLhrq.Name = "txtEndLhrq";
            this.txtEndLhrq.Size = new System.Drawing.Size(121, 21);
            this.txtEndLhrq.TabIndex = 3;
            this.txtEndLhrq.TextChanged += new System.EventHandler(this.txtEndLhrq_TextChanged);
            this.txtEndLhrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtEndLhrq.Validating += new System.ComponentModel.CancelEventHandler(this.txtEndLhrq_Validating);
            // 
            // txtStartLhrq
            // 
            this.txtStartLhrq.Location = new System.Drawing.Point(151, 125);
            this.txtStartLhrq.MaxLength = 10;
            this.txtStartLhrq.Name = "txtStartLhrq";
            this.txtStartLhrq.Size = new System.Drawing.Size(121, 21);
            this.txtStartLhrq.TabIndex = 2;
            this.txtStartLhrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtStartLhrq.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartLhrq_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(79, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "硫化日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(278, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "～";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLotno
            // 
            this.txtLotno.Location = new System.Drawing.Point(151, 86);
            this.txtLotno.MaxLength = 50;
            this.txtLotno.Name = "txtLotno";
            this.txtLotno.Size = new System.Drawing.Size(270, 21);
            this.txtLotno.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label5.Location = new System.Drawing.Point(18, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "LOTNO（混炼批次）：";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(465, 30);
            this.label6.TabIndex = 35;
            this.label6.Text = "全 部 工 序 一 览";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.Location = new System.Drawing.Point(258, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 40;
            this.button1.TabStop = false;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExcel.Location = new System.Drawing.Point(117, 292);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(89, 29);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // PC26
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(465, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLotno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndLhrq);
            this.Controls.Add(this.txtStartLhrq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEndJprq);
            this.Controls.Add(this.txtStartJprq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobCpjcz);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC26";
            this.Text = "全部工序一览-PC26";
            this.Load += new System.EventHandler(this.PC26_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PC26_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cobCpjcz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndJprq;
        private System.Windows.Forms.TextBox txtStartJprq;
        private System.Windows.Forms.TextBox txtEndLhrq;
        private System.Windows.Forms.TextBox txtStartLhrq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLotno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExcel;
    }
}