namespace BSC_System
{
    partial class PC28
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

     //   #region Windows Form Designer generated code

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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC28));
            this.btnDelete = new System.Windows.Forms.Button();
            this.fspd = new FarPoint.Win.Spread.FpSpread();
            this.fspd_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDelete.Location = new System.Drawing.Point(23, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 365;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // fspd
            // 
            this.fspd.AccessibleDescription = "fspd, Sheet1, Row 0, Column 0, ";
            this.fspd.BackColor = System.Drawing.Color.White;
            this.fspd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fspd.Location = new System.Drawing.Point(12, 51);
            this.fspd.Name = "fspd";
            //namedStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            //namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            //namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            //namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
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
            this.fspd.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fspd.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fspd_Sheet1});
            this.fspd.Size = new System.Drawing.Size(549, 326);
            this.fspd.TabIndex = 355;
            this.fspd.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fspd.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.Spd_ColumnWidthChanged);
            this.fspd.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.Spd_EnterCell);
            this.fspd.SubEditorOpening += new FarPoint.Win.Spread.SubEditorOpeningEventHandler(this.Spd_SubEditorOpening);
            // 
            // fspd_Sheet1
            // 
            this.fspd_Sheet1.Reset();
            this.fspd_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fspd_Sheet1.ColumnCount = 5;
            this.fspd_Sheet1.RowCount = 14;
            this.fspd_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true, "ColumnHeaderEnhanced", "RowHeaderEnhanced", "DataAreaDefault", "CornerEnhanced");
            this.fspd_Sheet1.AllowNoteEdit = true;
            this.fspd_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(0, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(0, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(0, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(0, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(1, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(1, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(1, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(1, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(1, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(1, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(1, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(2, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(2, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(2, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(2, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(2, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(2, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(2, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(2, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(2, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(3, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(3, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(3, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(3, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(3, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(3, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(3, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(3, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(3, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(3, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(4, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(4, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(4, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(4, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(4, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(4, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(4, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(4, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(4, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(4, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(4, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(5, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(5, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(5, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(5, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(5, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(5, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(5, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(5, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(5, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(5, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(6, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(6, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(6, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(6, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(6, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(6, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(6, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(6, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(6, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(6, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(6, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(6, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(6, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(6, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(6, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(7, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(7, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(7, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(7, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(7, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(7, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(7, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(7, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(7, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(7, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(7, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(8, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(8, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(8, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(8, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(8, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(8, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(8, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(8, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(8, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(8, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(8, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(8, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(8, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(9, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(9, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(9, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(9, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(9, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(9, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(9, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(9, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(9, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(9, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(9, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(10, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(10, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(10, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(10, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(10, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(10, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(10, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(10, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(10, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(10, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(10, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(10, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(11, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(11, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(11, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(11, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(11, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(11, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(11, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(11, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(11, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(11, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(11, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(11, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(12, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(12, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(12, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(12, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(12, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(12, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(12, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(12, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(12, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(12, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(12, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(12, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(12, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(12, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(12, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(13, 0).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(13, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(13, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(13, 1).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(13, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(13, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(13, 2).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(13, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(13, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(13, 3).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(13, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(13, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Cells.Get(13, 4).BackColor = System.Drawing.Color.White;
            this.fspd_Sheet1.Cells.Get(13, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Cells.Get(13, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).CellType = textCellType1;
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).Locked = false;
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).TabStop = false;
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "级数";
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).CellType = textCellType2;
            
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).CellType = textCellType3;
           
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).CellType = textCellType4;
          
            //this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 4).CellType = textCellType5;
         
            //this.fspd_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            ////this.fspd_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderEnhanced";
            //this.fspd_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            //this.fspd_Sheet1.ColumnHeader.Rows.Get(0).Height = 31F;
            this.fspd_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.White;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 1000D;
            numberCellType1.MinimumValue = 1D;
            this.fspd_Sheet1.Columns.Get(0).CellType = numberCellType1;
            this.fspd_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Columns.Get(0).Label = "级数";
            this.fspd_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(0).Width = 110F;
            this.fspd_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.White;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.FixedPoint = false;
            numberCellType2.MaximumValue = 99999999D;
            numberCellType2.MinimumValue = 0D;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            numberCellType2.SpinDecimalIncrement = 0F;
            numberCellType2.SpinIntegerIncrement = 0F;
            this.fspd_Sheet1.Columns.Get(1).CellType = numberCellType2;
            this.fspd_Sheet1.Columns.Get(1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fspd_Sheet1.Columns.Get(1).Label = "全月应纳税所得额上限";
            this.fspd_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(1).Width = 62F;
            this.fspd_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.White;
            numberCellType3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.FixedPoint = false;
            numberCellType3.MaximumValue = 99999999D;
            numberCellType3.MinimumValue = 0D;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this.fspd_Sheet1.Columns.Get(2).CellType = numberCellType3;
            this.fspd_Sheet1.Columns.Get(2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
       
            this.fspd_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(2).Width = 155F;
            this.fspd_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.White;
            numberCellType4.MaximumValue = 100D;
            numberCellType4.MinimumValue = 0D;
            numberCellType4.Separator = ",";
            numberCellType4.ShowSeparator = true;
            this.fspd_Sheet1.Columns.Get(3).CellType = numberCellType4;
            this.fspd_Sheet1.Columns.Get(3).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
           
            this.fspd_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(3).Width = 98F;
            this.fspd_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.White;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.FixedPoint = false;
            numberCellType5.MaximumValue = 99999999D;
            numberCellType5.MinimumValue = 0D;
            numberCellType5.Separator = ",";
            numberCellType5.ShowSeparator = true;
            this.fspd_Sheet1.Columns.Get(4).CellType = numberCellType5;
            this.fspd_Sheet1.Columns.Get(4).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
      
            this.fspd_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(4).Width = 98F;
            this.fspd_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fspd_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.fspd_Sheet1.RowHeader.Columns.Get(0).Width = 24F;
            this.fspd_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderEnhanced";
            this.fspd_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnClose.Location = new System.Drawing.Point(470, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 358;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "关闭(&Q)";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSave.Location = new System.Drawing.Point(389, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 366;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClear.Location = new System.Drawing.Point(29, 517);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 29);
            this.btnClear.TabIndex = 357;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "清空(&C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(573, 24);
            this.label4.TabIndex = 4457;
            this.label4.Text = "公 差 录 入";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PC28
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(573, 441);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.fspd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC28";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公差录入-PC28";
            this.Load += new System.EventHandler(this.WinFMD220_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LR_D010_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AWMT110_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

      

        private System.Windows.Forms.Button btnDelete;
        private FarPoint.Win.Spread.FpSpread fspd;
        private FarPoint.Win.Spread.SheetView fspd_Sheet1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
    }
}