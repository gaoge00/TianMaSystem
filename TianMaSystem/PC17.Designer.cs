namespace BSC_System
{
    partial class PC17
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerEnhanced");
            FarPoint.Win.Spread.CellType.EnhancedCornerRenderer enhancedCornerRenderer1 = new FarPoint.Win.Spread.CellType.EnhancedCornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.SpreadSkin spreadSkin1 = new FarPoint.Win.Spread.SpreadSkin();
            FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer enhancedFocusIndicatorRenderer1 = new FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer();
            FarPoint.Win.Spread.EnhancedInterfaceRenderer enhancedInterfaceRenderer1 = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC17));
            this.Spd = new FarPoint.Win.Spread.FpSpread();
            this.Spd_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtYCLBH = new System.Windows.Forms.TextBox();
            this.cbbYCLLX = new System.Windows.Forms.ComboBox();
            this.cbbSYZT = new System.Windows.Forms.ComboBox();
            this.btnJs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEndRq = new System.Windows.Forms.DateTimePicker();
            this.dateStartRq = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_excel = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Spd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spd_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Spd
            // 
            this.Spd.AccessibleDescription = "Spd, Sheet1, Row 0, Column 0, ";
            this.Spd.AllowUserFormulas = true;
            this.Spd.BackColor = System.Drawing.Color.White;
            this.Spd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.Spd.Location = new System.Drawing.Point(8, 154);
            this.Spd.Name = "Spd";
            namedStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.Renderer = enhancedCornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.Renderer = generalCellType1;
            this.Spd.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.Spd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Spd.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.Spd.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.Spd_Sheet1});
            this.Spd.Size = new System.Drawing.Size(1021, 616);
            spreadSkin1.ColumnHeaderDefaultStyle = namedStyle1;
            spreadSkin1.CornerDefaultStyle = namedStyle3;
            spreadSkin1.DefaultStyle = namedStyle4;
            spreadSkin1.FocusRenderer = enhancedFocusIndicatorRenderer1;
            enhancedInterfaceRenderer1.GrayAreaColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(254)))), ((int)(((byte)(216)))));
            enhancedInterfaceRenderer1.ScrollBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(186)))), ((int)(((byte)(221)))));
            enhancedInterfaceRenderer1.SheetTabLowerActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(210)))), ((int)(((byte)(244)))));
            enhancedInterfaceRenderer1.SheetTabLowerNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            enhancedInterfaceRenderer1.SheetTabUpperActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            enhancedInterfaceRenderer1.SheetTabUpperNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            enhancedInterfaceRenderer1.TabStripBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(186)))), ((int)(((byte)(221)))));
            spreadSkin1.InterfaceRenderer = enhancedInterfaceRenderer1;
            spreadSkin1.Name = "CustomSkin2";
            spreadSkin1.RowHeaderDefaultStyle = namedStyle2;
            spreadSkin1.ScrollBarRenderer = enhancedScrollBarRenderer1;
            spreadSkin1.SelectionRenderer = new FarPoint.Win.Spread.DefaultSelectionRenderer();
            this.Spd.Skin = spreadSkin1;
            this.Spd.TabIndex = 26;
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
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "入库日期";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "原材料编号";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "原材料类型";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "入库单号LOTNO";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "单位";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "实际库存";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "使用期限";
            this.Spd_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "使用状态";
            this.Spd_Sheet1.ColumnHeader.Rows.Get(0).Height = 37F;
            this.Spd_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.Spd_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(0).Label = "入库日期";
            this.Spd_Sheet1.Columns.Get(0).Locked = true;
            this.Spd_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(0).Width = 103F;
            this.Spd_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.Spd_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(1).Label = "原材料编号";
            this.Spd_Sheet1.Columns.Get(1).Locked = true;
            this.Spd_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(1).Width = 145F;
            this.Spd_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.Spd_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(2).Label = "原材料类型";
            this.Spd_Sheet1.Columns.Get(2).Locked = true;
            this.Spd_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(2).Width = 80F;
            this.Spd_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.Spd_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.Spd_Sheet1.Columns.Get(3).Label = "入库单号LOTNO";
            this.Spd_Sheet1.Columns.Get(3).Locked = true;
            this.Spd_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(3).Width = 234F;
            this.Spd_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.Spd_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(4).Label = "单位";
            this.Spd_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(4).Width = 65F;
            this.Spd_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            numberCellType1.DecimalPlaces = 4;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.Spd_Sheet1.Columns.Get(5).CellType = numberCellType1;
            this.Spd_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.Spd_Sheet1.Columns.Get(5).Label = "实际库存";
            this.Spd_Sheet1.Columns.Get(5).Locked = true;
            this.Spd_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(5).Width = 124F;
            this.Spd_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(6).CellType = textCellType6;
            this.Spd_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(6).Label = "使用期限";
            this.Spd_Sheet1.Columns.Get(6).Locked = true;
            this.Spd_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(6).Width = 113F;
            this.Spd_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Spd_Sheet1.Columns.Get(7).CellType = textCellType7;
            this.Spd_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(7).Label = "使用状态";
            this.Spd_Sheet1.Columns.Get(7).Locked = true;
            this.Spd_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.Spd_Sheet1.Columns.Get(7).Width = 98F;
            this.Spd_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.Spd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.Spd.SetActiveViewport(0, -1, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtYCLBH);
            this.groupBox1.Controls.Add(this.cbbYCLLX);
            this.groupBox1.Controls.Add(this.cbbSYZT);
            this.groupBox1.Controls.Add(this.btnJs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateEndRq);
            this.groupBox1.Controls.Add(this.dateStartRq);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(8, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1021, 92);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // txtYCLBH
            // 
            this.txtYCLBH.Location = new System.Drawing.Point(142, 57);
            this.txtYCLBH.Name = "txtYCLBH";
            this.txtYCLBH.Size = new System.Drawing.Size(124, 21);
            this.txtYCLBH.TabIndex = 3;
            // 
            // cbbYCLLX
            // 
            this.cbbYCLLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbYCLLX.FormattingEnabled = true;
            this.cbbYCLLX.Location = new System.Drawing.Point(413, 56);
            this.cbbYCLLX.Name = "cbbYCLLX";
            this.cbbYCLLX.Size = new System.Drawing.Size(121, 20);
            this.cbbYCLLX.TabIndex = 4;
            // 
            // cbbSYZT
            // 
            this.cbbSYZT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSYZT.FormattingEnabled = true;
            this.cbbSYZT.Location = new System.Drawing.Point(681, 56);
            this.cbbSYZT.Name = "cbbSYZT";
            this.cbbSYZT.Size = new System.Drawing.Size(121, 20);
            this.cbbSYZT.TabIndex = 5;
            // 
            // btnJs
            // 
            this.btnJs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJs.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnJs.Location = new System.Drawing.Point(897, 49);
            this.btnJs.Name = "btnJs";
            this.btnJs.Size = new System.Drawing.Size(89, 29);
            this.btnJs.TabIndex = 6;
            this.btnJs.Text = "检索";
            this.btnJs.UseVisualStyleBackColor = true;
            this.btnJs.Click += new System.EventHandler(this.btnJs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(269, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "～";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateEndRq
            // 
            this.dateEndRq.Location = new System.Drawing.Point(289, 20);
            this.dateEndRq.Name = "dateEndRq";
            this.dateEndRq.Size = new System.Drawing.Size(124, 21);
            this.dateEndRq.TabIndex = 2;
            this.dateEndRq.Value = new System.DateTime(2014, 10, 9, 0, 0, 0, 0);
            // 
            // dateStartRq
            // 
            this.dateStartRq.Location = new System.Drawing.Point(142, 20);
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
            this.label1.Location = new System.Drawing.Point(69, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "入库日期：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(608, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "使用状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(56, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "原材料编号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label8.Location = new System.Drawing.Point(327, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "原材料类型：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_excel
            // 
            this.lbl_excel.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl_excel.AutoSize = true;
            this.lbl_excel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_excel.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl_excel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_excel.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl_excel.Location = new System.Drawing.Point(40, 132);
            this.lbl_excel.Name = "lbl_excel";
            this.lbl_excel.Size = new System.Drawing.Size(96, 12);
            this.lbl_excel.TabIndex = 28;
            this.lbl_excel.TabStop = true;
            this.lbl_excel.Text = "原材料在库一览";
            this.lbl_excel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_excel_LinkClicked);
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
            this.label4.TabIndex = 4450;
            this.label4.Text = "原 材 料 在 库 一 览";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PC17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 782);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Spd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_excel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC17";
            this.Text = "原材料在库一览-PC17";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PC17_FormClosing);
            this.Load += new System.EventHandler(this.PC17_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PC17_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Spd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spd_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread Spd;
        private FarPoint.Win.Spread.SheetView Spd_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnJs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEndRq;
        private System.Windows.Forms.DateTimePicker dateStartRq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel lbl_excel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYCLBH;
        private System.Windows.Forms.ComboBox cbbYCLLX;
        private System.Windows.Forms.ComboBox cbbSYZT;
        private System.Windows.Forms.Label label4;
    }
}