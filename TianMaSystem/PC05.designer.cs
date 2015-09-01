namespace BSC_System
{
    partial class PC05
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC05));
            this.fspd = new FarPoint.Win.Spread.FpSpread();
            this.fspd_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSYName = new System.Windows.Forms.TextBox();
            this.txtSYBH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnADD = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).BeginInit();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // fspd
            // 
            this.fspd.AccessibleDescription = "fspd, Sheet1, Row 0, Column 0, ";
            this.fspd.BackColor = System.Drawing.Color.White;
            this.fspd.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse;
            this.fspd.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fspd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fspd.Location = new System.Drawing.Point(5, 149);
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
            this.fspd.Size = new System.Drawing.Size(1025, 631);
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
            this.fspd.TabIndex = 4447;
            this.fspd.TabStop = false;
            this.fspd.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.fspdMc_ColumnWidthChanged);
            this.fspd.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fspdMc_LeaveCell);
            this.fspd.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fspdMc_CellClick);
            this.fspd.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fspdMc_CellDoubleClick);
            // 
            // fspd_Sheet1
            // 
            this.fspd_Sheet1.Reset();
            this.fspd_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fspd_Sheet1.ColumnCount = 10;
            this.fspd_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), System.Drawing.Color.Black, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true, "ColumnHeaderEnhanced", "RowHeaderEnhanced", "DataAreaDefault", "CornerEnhanced");
            this.fspd_Sheet1.AllowNoteEdit = true;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "人员编号";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "人员名称";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "部门";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "职位";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "性别";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "人员生日";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "身份证";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 8).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "手机";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 9).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "家庭住址";
            this.fspd_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderEnhanced";
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.fspd_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Columns.Get(0).Label = " ";
            this.fspd_Sheet1.Columns.Get(0).Locked = true;
            this.fspd_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(0).Width = 28F;
            this.fspd_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.fspd_Sheet1.Columns.Get(1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(1).Label = "人员编号";
            this.fspd_Sheet1.Columns.Get(1).Locked = true;
            this.fspd_Sheet1.Columns.Get(1).Resizable = false;
            this.fspd_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(1).Width = 95F;
            this.fspd_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.fspd_Sheet1.Columns.Get(2).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(2).Label = "人员名称";
            this.fspd_Sheet1.Columns.Get(2).Locked = true;
            this.fspd_Sheet1.Columns.Get(2).Resizable = false;
            this.fspd_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(2).Width = 95F;
            this.fspd_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fspd_Sheet1.Columns.Get(3).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(3).Label = "部门";
            this.fspd_Sheet1.Columns.Get(3).Locked = true;
            this.fspd_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(3).Width = 95F;
            this.fspd_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.fspd_Sheet1.Columns.Get(4).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(4).Label = "职位";
            this.fspd_Sheet1.Columns.Get(4).Locked = true;
            this.fspd_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(4).Width = 110F;
            this.fspd_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(5).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(5).Label = "性别";
            this.fspd_Sheet1.Columns.Get(5).Locked = true;
            this.fspd_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(5).Width = 110F;
            this.fspd_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(6).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(6).Label = "人员生日";
            this.fspd_Sheet1.Columns.Get(6).Locked = true;
            this.fspd_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(6).Width = 95F;
            this.fspd_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(7).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(7).Label = "身份证";
            this.fspd_Sheet1.Columns.Get(7).Locked = true;
            this.fspd_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(7).Width = 95F;
            this.fspd_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(8).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(8).Label = "手机";
            this.fspd_Sheet1.Columns.Get(8).Locked = true;
            this.fspd_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(8).Width = 95F;
            this.fspd_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.Transparent;
            this.fspd_Sheet1.Columns.Get(9).ForeColor = System.Drawing.Color.Navy;
            this.fspd_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(9).Label = "家庭住址";
            this.fspd_Sheet1.Columns.Get(9).Locked = true;
            this.fspd_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(9).Width = 185F;
            this.fspd_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fspd_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderEnhanced";
            this.fspd_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.Rows.Get(0).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(0).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(1).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(2).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(3).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(3).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(4).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(4).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(5).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(5).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(6).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(6).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(7).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(7).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(8).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(8).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(9).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(9).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(10).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(10).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(11).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(11).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(12).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(12).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(13).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(13).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(14).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(14).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(15).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(15).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(16).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(16).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(17).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(17).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(18).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(18).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(19).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(19).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(20).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(20).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(21).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(21).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(22).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(22).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(23).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(23).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(24).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(24).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(25).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(25).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(26).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(26).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(27).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(27).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(28).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(28).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(29).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(29).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(30).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(30).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(31).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(31).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Rows.Get(32).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fspd_Sheet1.Rows.Get(32).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.SheetCornerStyle.Parent = "CornerEnhanced";
            this.fspd_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
            this.label1.TabIndex = 4448;
            this.label1.Text = "人 员 信 息 管 理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBox
            // 
            this.grpBox.BackColor = System.Drawing.Color.Transparent;
            this.grpBox.Controls.Add(this.btnSearch);
            this.grpBox.Controls.Add(this.txtSYName);
            this.grpBox.Controls.Add(this.txtSYBH);
            this.grpBox.Controls.Add(this.label4);
            this.grpBox.Controls.Add(this.label3);
            this.grpBox.ForeColor = System.Drawing.Color.Navy;
            this.grpBox.Location = new System.Drawing.Point(5, 37);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(1022, 64);
            this.grpBox.TabIndex = 1;
            this.grpBox.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSearch.Location = new System.Drawing.Point(843, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSYName
            // 
            this.txtSYName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSYName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSYName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSYName.ForeColor = System.Drawing.Color.Black;
            this.txtSYName.Location = new System.Drawing.Point(103, 28);
            this.txtSYName.MaxLength = 20;
            this.txtSYName.Name = "txtSYName";
            this.txtSYName.ShortcutsEnabled = false;
            this.txtSYName.Size = new System.Drawing.Size(163, 21);
            this.txtSYName.TabIndex = 1;
            this.txtSYName.TextChanged += new System.EventHandler(this.txtSYName_TextChanged);
            this.txtSYName.Enter += new System.EventHandler(this.txtSYName_Enter);
            this.txtSYName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMcKey_KeyPress);
            // 
            // txtSYBH
            // 
            this.txtSYBH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSYBH.ForeColor = System.Drawing.Color.Black;
            this.txtSYBH.Location = new System.Drawing.Point(354, 28);
            this.txtSYBH.MaxLength = 5;
            this.txtSYBH.Name = "txtSYBH";
            this.txtSYBH.ShortcutsEnabled = false;
            this.txtSYBH.Size = new System.Drawing.Size(188, 21);
            this.txtSYBH.TabIndex = 3;
            this.txtSYBH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZsMc_KeyPress);
            this.txtSYBH.Leave += new System.EventHandler(this.txtSYBH_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(283, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "人员编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(30, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "人员名称：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 118);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4450;
            this.pictureBox2.TabStop = false;
            // 
            // btnADD
            // 
            this.btnADD.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnADD.AutoSize = true;
            this.btnADD.BackColor = System.Drawing.Color.Transparent;
            this.btnADD.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnADD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADD.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnADD.Location = new System.Drawing.Point(41, 126);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(31, 12);
            this.btnADD.TabIndex = 4449;
            this.btnADD.TabStop = true;
            this.btnADD.Text = "新增";
            this.btnADD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnADD_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(98, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4452;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSave.Location = new System.Drawing.Point(126, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(31, 12);
            this.btnSave.TabIndex = 4451;
            this.btnSave.TabStop = true;
            this.btnSave.Text = "修正";
            this.btnSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSave_LinkClicked);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(187, 118);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4454;
            this.pictureBox3.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.DisabledLinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.LinkColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDelete.Location = new System.Drawing.Point(215, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 12);
            this.btnDelete.TabIndex = 4453;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "删除";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // PC05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 792);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.fspd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC05";
            this.Text = "人员信息管理-PC05";
            this.Load += new System.EventHandler(this.WinFMD010_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WinFMD010_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fspd;
        private FarPoint.Win.Spread.SheetView fspd_Sheet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.TextBox txtSYName;
        private System.Windows.Forms.TextBox txtSYBH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel btnADD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel btnSave;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel btnDelete;
    }
}