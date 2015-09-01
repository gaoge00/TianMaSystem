namespace BSC_System
{
    partial class PC27
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
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerEnhanced");
            FarPoint.Win.Spread.CellType.EnhancedCornerRenderer enhancedCornerRenderer2 = new FarPoint.Win.Spread.CellType.EnhancedCornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.SpreadSkin spreadSkin2 = new FarPoint.Win.Spread.SpreadSkin();
            FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer enhancedFocusIndicatorRenderer2 = new FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer();
            FarPoint.Win.Spread.EnhancedInterfaceRenderer enhancedInterfaceRenderer2 = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC27));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnJs = new System.Windows.Forms.Button();
            this.txtClbh = new System.Windows.Forms.TextBox();
            this.txtPh = new System.Windows.Forms.TextBox();
            this.txtPm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEndRq = new System.Windows.Forms.DateTimePicker();
            this.dateStartRq = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Spd = new FarPoint.Win.Spread.FpSpread();
            this.Spd_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnExcel = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spd_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnJs);
            this.groupBox1.Controls.Add(this.txtClbh);
            this.groupBox1.Controls.Add(this.txtPh);
            this.groupBox1.Controls.Add(this.txtPm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateEndRq);
            this.groupBox1.Controls.Add(this.dateStartRq);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(7, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 83);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnJs
            // 
            this.btnJs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJs.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnJs.Location = new System.Drawing.Point(900, 33);
            this.btnJs.Name = "btnJs";
            this.btnJs.Size = new System.Drawing.Size(89, 29);
            this.btnJs.TabIndex = 20;
            this.btnJs.TabStop = false;
            this.btnJs.Text = "检索";
            this.btnJs.UseVisualStyleBackColor = true;
            this.btnJs.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // txtClbh
            // 
            this.txtClbh.Location = new System.Drawing.Point(101, 48);
            this.txtClbh.MaxLength = 15;
            this.txtClbh.Name = "txtClbh";
            this.txtClbh.Size = new System.Drawing.Size(149, 21);
            this.txtClbh.TabIndex = 4;
            // 
            // txtPh
            // 
            this.txtPh.Location = new System.Drawing.Point(711, 48);
            this.txtPh.MaxLength = 50;
            this.txtPh.Name = "txtPh";
            this.txtPh.Size = new System.Drawing.Size(149, 21);
            this.txtPh.TabIndex = 5;
            // 
            // txtPm
            // 
            this.txtPm.Location = new System.Drawing.Point(421, 48);
            this.txtPm.MaxLength = 50;
            this.txtPm.Name = "txtPm";
            this.txtPm.Size = new System.Drawing.Size(149, 21);
            this.txtPm.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(228, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "～";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateEndRq
            // 
            this.dateEndRq.Location = new System.Drawing.Point(248, 17);
            this.dateEndRq.Name = "dateEndRq";
            this.dateEndRq.Size = new System.Drawing.Size(124, 21);
            this.dateEndRq.TabIndex = 2;
            this.dateEndRq.Value = new System.DateTime(2014, 10, 9, 0, 0, 0, 0);
            // 
            // dateStartRq
            // 
            this.dateStartRq.Location = new System.Drawing.Point(101, 17);
            this.dateStartRq.Name = "dateStartRq";
            this.dateStartRq.Size = new System.Drawing.Size(124, 21);
            this.dateStartRq.TabIndex = 1;
            this.dateStartRq.Value = new System.DateTime(2014, 10, 9, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "硫化日期：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(374, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "品名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(28, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "材料编号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label8.Location = new System.Drawing.Point(664, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "品号：";
            // 
            // Spd
            // 
            this.Spd.AccessibleDescription = "Spd, Sheet1, Row 0, Column 0, ";
            this.Spd.AllowUserFormulas = true;
            this.Spd.BackColor = System.Drawing.Color.White;
            this.Spd.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.Spd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.Spd.Location = new System.Drawing.Point(10, 146);
            this.Spd.Name = "Spd";
            namedStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.Renderer = enhancedCornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.Renderer = generalCellType2;
            this.Spd.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.Spd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Spd.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.Spd.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.Spd_Sheet1});
            this.Spd.Size = new System.Drawing.Size(1015, 626);
            spreadSkin2.ColumnHeaderDefaultStyle = namedStyle5;
            spreadSkin2.CornerDefaultStyle = namedStyle7;
            spreadSkin2.DefaultStyle = namedStyle8;
            spreadSkin2.FocusRenderer = enhancedFocusIndicatorRenderer2;
            enhancedInterfaceRenderer2.GrayAreaColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(254)))), ((int)(((byte)(216)))));
            enhancedInterfaceRenderer2.ScrollBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(186)))), ((int)(((byte)(221)))));
            enhancedInterfaceRenderer2.SheetTabLowerActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(210)))), ((int)(((byte)(244)))));
            enhancedInterfaceRenderer2.SheetTabLowerNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            enhancedInterfaceRenderer2.SheetTabUpperActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            enhancedInterfaceRenderer2.SheetTabUpperNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            enhancedInterfaceRenderer2.TabStripBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(186)))), ((int)(((byte)(221)))));
            spreadSkin2.InterfaceRenderer = enhancedInterfaceRenderer2;
            spreadSkin2.Name = "CustomSkin2";
            spreadSkin2.RowHeaderDefaultStyle = namedStyle6;
            spreadSkin2.ScrollBarRenderer = enhancedScrollBarRenderer2;
            spreadSkin2.SelectionRenderer = new FarPoint.Win.Spread.DefaultSelectionRenderer();
            this.Spd.Skin = spreadSkin2;
            this.Spd.TabIndex = 15;
            this.Spd.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.Spd_CellClick);
            // 
            // Spd_Sheet1
            // 
            this.Spd_Sheet1.Reset();
            this.Spd_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.Spd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.Spd_Sheet1.ColumnCount = 8;
            this.Spd_Sheet1.RowCount = 0;
            this.Spd_Sheet1.ActiveRowIndex = -1;
            this.Spd_Sheet1.AllowNoteEdit = true;
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "前回-硫化日期";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "现在-硫化日期";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "材料编号";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "品名";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "品号";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "数量";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "变更者";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "变更日期";
            this.Spd_Sheet1.ColumnHeader.Rows.Get(0).Height = 37F;
            this.Spd_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(0).Label = "前回-硫化日期";
            this.Spd_Sheet1.Columns.Get(0).Locked = true;
            this.Spd_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(0).Width = 117F;
            this.Spd_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(1).Label = "现在-硫化日期";
            this.Spd_Sheet1.Columns.Get(1).Locked = true;
            this.Spd_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(1).Width = 117F;
            this.Spd_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(2).Label = "材料编号";
            this.Spd_Sheet1.Columns.Get(2).Locked = true;
            this.Spd_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(2).Width = 116F;
            this.Spd_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(3).Label = "品名";
            this.Spd_Sheet1.Columns.Get(3).Locked = true;
            this.Spd_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(3).Width = 149F;
            this.Spd_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(4).Label = "品号";
            this.Spd_Sheet1.Columns.Get(4).Locked = true;
            this.Spd_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(4).Width = 149F;
            this.Spd_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.DecimalSeparator = "，";
            numberCellType2.MaximumValue = 10000000D;
            numberCellType2.MinimumValue = -10000000D;
            numberCellType2.ShowSeparator = true;
            this.Spd_Sheet1.Columns.Get(5).CellType = numberCellType2;
            this.Spd_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.Spd_Sheet1.Columns.Get(5).Label = "数量";
            this.Spd_Sheet1.Columns.Get(5).Locked = true;
            this.Spd_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(5).Width = 106F;
            this.Spd_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(6).Label = "变更者";
            this.Spd_Sheet1.Columns.Get(6).Locked = true;
            this.Spd_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(6).Width = 101F;
            this.Spd_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(7).Label = "变更日期";
            this.Spd_Sheet1.Columns.Get(7).Locked = true;
            this.Spd_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.Spd_Sheet1.Columns.Get(7).Width = 101F;
            this.Spd_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.Spd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.Spd.SetActiveViewport(0, -1, 0);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 118);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExcel.AutoSize = true;
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExcel.Location = new System.Drawing.Point(44, 126);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(73, 12);
            this.btnExcel.TabIndex = 19;
            this.btnExcel.TabStop = true;
            this.btnExcel.Text = "EXCEL 报表";
            this.btnExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnExcel_LinkClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1034, 24);
            this.label4.TabIndex = 4456;
            this.label4.Text = "硫 化 日 变 更 日 志";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PC27
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 782);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.Spd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC27";
            this.Text = "硫化日变更日志-PC27";
            this.Load += new System.EventHandler(this.PC27_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spd_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnJs;
        private System.Windows.Forms.TextBox txtClbh;
        private System.Windows.Forms.TextBox txtPh;
        private System.Windows.Forms.TextBox txtPm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEndRq;
        private System.Windows.Forms.DateTimePicker dateStartRq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private FarPoint.Win.Spread.FpSpread Spd;
        private FarPoint.Win.Spread.SheetView Spd_Sheet1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel btnExcel;
        private System.Windows.Forms.Label label4;
    }
}