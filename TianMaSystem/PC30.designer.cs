namespace BSC_System
{
    partial class PC30
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC30));
            this.label1 = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.cobKhmc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fspd = new FarPoint.Win.Spread.FpSpread();
            this.fspd_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.llaXz = new System.Windows.Forms.LinkLabel();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1034, 24);
            this.label1.TabIndex = 4449;
            this.label1.Text = "客 户 别 成 品 信 息 管 理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBox
            // 
            this.grpBox.BackColor = System.Drawing.Color.Transparent;
            this.grpBox.Controls.Add(this.cobKhmc);
            this.grpBox.Controls.Add(this.label6);
            this.grpBox.ForeColor = System.Drawing.Color.Navy;
            this.grpBox.Location = new System.Drawing.Point(6, 27);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(1022, 66);
            this.grpBox.TabIndex = 4450;
            this.grpBox.TabStop = false;
            // 
            // cobKhmc
            // 
            this.cobKhmc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobKhmc.FormattingEnabled = true;
            this.cobKhmc.Location = new System.Drawing.Point(103, 27);
            this.cobKhmc.Name = "cobKhmc";
            this.cobKhmc.Size = new System.Drawing.Size(188, 20);
            this.cobKhmc.TabIndex = 1;
            this.cobKhmc.SelectedIndexChanged += new System.EventHandler(this.cobKhmc_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label6.Location = new System.Drawing.Point(56, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "客户：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fspd
            // 
            this.fspd.AccessibleDescription = "fspd, Sheet1, Row 0, Column 0, ";
            this.fspd.BackColor = System.Drawing.Color.White;
            this.fspd.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse;
            this.fspd.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fspd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fspd.Location = new System.Drawing.Point(4, 133);
            this.fspd.Name = "fspd";
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
            this.fspd.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.fspd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fspd.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fspd.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fspd_Sheet1});
            this.fspd.Size = new System.Drawing.Size(1028, 647);
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
            this.fspd.Skin = spreadSkin1;
            this.fspd.TabIndex = 4451;
            this.fspd.TabStop = false;
            this.fspd.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fspd_CellClick);
            // 
            // fspd_Sheet1
            // 
            this.fspd_Sheet1.Reset();
            this.fspd_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fspd_Sheet1.ColumnCount = 9;
            this.fspd_Sheet1.RowCount = 2;
            this.fspd_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), System.Drawing.Color.Black, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true, "ColumnHeaderEnhanced", "RowHeaderEnhanced", "DataAreaDefault", "CornerEnhanced");
            this.fspd_Sheet1.AllowNoteEdit = true;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "客户编号";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "客户名称";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "品名（工厂）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "品号（工厂）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "材料（工厂）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "品名（客户）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "品号（客户）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "材料（客户）";
            this.fspd_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderEnhanced";
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.fspd_Sheet1.Columns.Get(0).Label = " ";
            this.fspd_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(0).Width = 23F;
            this.fspd_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.fspd_Sheet1.Columns.Get(1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(1).Label = "客户编号";
            this.fspd_Sheet1.Columns.Get(1).Locked = true;
            this.fspd_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(1).Width = 63F;
            this.fspd_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.fspd_Sheet1.Columns.Get(2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(2).Label = "客户名称";
            this.fspd_Sheet1.Columns.Get(2).Locked = true;
            this.fspd_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(2).Width = 160F;
            this.fspd_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fspd_Sheet1.Columns.Get(3).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(3).Label = "品名（工厂）";
            this.fspd_Sheet1.Columns.Get(3).Locked = true;
            this.fspd_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(3).Width = 122F;
            this.fspd_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.fspd_Sheet1.Columns.Get(4).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(4).Label = "品号（工厂）";
            this.fspd_Sheet1.Columns.Get(4).Locked = true;
            this.fspd_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(4).Width = 122F;
            this.fspd_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(5).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(5).Label = "材料（工厂）";
            this.fspd_Sheet1.Columns.Get(5).Locked = true;
            this.fspd_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(5).Width = 122F;
            this.fspd_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(6).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(6).Label = "品名（客户）";
            this.fspd_Sheet1.Columns.Get(6).Locked = true;
            this.fspd_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(6).Width = 122F;
            this.fspd_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(7).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(7).Label = "品号（客户）";
            this.fspd_Sheet1.Columns.Get(7).Locked = true;
            this.fspd_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(7).Width = 122F;
            this.fspd_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(8).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(8).Label = "材料（客户）";
            this.fspd_Sheet1.Columns.Get(8).Locked = true;
            this.fspd_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(8).Width = 122F;
            this.fspd_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fspd_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.fspd_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderEnhanced";
            this.fspd_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.SheetCornerStyle.Parent = "CornerEnhanced";
            this.fspd_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(186, 103);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4466;
            this.pictureBox3.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.linkLabel1.Location = new System.Drawing.Point(214, 111);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(31, 12);
            this.linkLabel1.TabIndex = 4465;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "删除";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(97, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4464;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.linkLabel2.Location = new System.Drawing.Point(125, 111);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(31, 12);
            this.linkLabel2.TabIndex = 4463;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "修正";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 103);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4462;
            this.pictureBox2.TabStop = false;
            // 
            // llaXz
            // 
            this.llaXz.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.llaXz.AutoSize = true;
            this.llaXz.BackColor = System.Drawing.Color.Transparent;
            this.llaXz.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.llaXz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llaXz.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.llaXz.Location = new System.Drawing.Point(40, 111);
            this.llaXz.Name = "llaXz";
            this.llaXz.Size = new System.Drawing.Size(31, 12);
            this.llaXz.TabIndex = 4461;
            this.llaXz.TabStop = true;
            this.llaXz.Text = "新增";
            this.llaXz.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llaXz_LinkClicked);
            // 
            // PC30
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 792);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.llaXz);
            this.Controls.Add(this.fspd);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC30";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户别成品信息管理-PC30";
            this.Load += new System.EventHandler(this.PC30_Load);
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.ComboBox cobKhmc;
        private System.Windows.Forms.Label label6;
        private FarPoint.Win.Spread.FpSpread fspd;
        private FarPoint.Win.Spread.SheetView fspd_Sheet1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel llaXz;
    }
}