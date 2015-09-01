namespace BSC_System
{
    partial class PC30_sub2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC30_sub2));
            this.fspd = new FarPoint.Win.Spread.FpSpread();
            this.fspd_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fspd
            // 
            this.fspd.AccessibleDescription = "fspd, Sheet1, Row 0, Column 0, ";
            this.fspd.BackColor = System.Drawing.Color.White;
            this.fspd.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse;
            this.fspd.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fspd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fspd.Location = new System.Drawing.Point(2, 1);
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
            this.fspd.Size = new System.Drawing.Size(589, 375);
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
            this.fspd.TabIndex = 4452;
            this.fspd.TabStop = false;
            // 
            // fspd_Sheet1
            // 
            this.fspd_Sheet1.Reset();
            this.fspd_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fspd_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fspd_Sheet1.ColumnCount = 4;
            this.fspd_Sheet1.RowCount = 2;
            this.fspd_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), System.Drawing.Color.Black, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true, "ColumnHeaderEnhanced", "RowHeaderEnhanced", "DataAreaDefault", "CornerEnhanced");
            this.fspd_Sheet1.AllowNoteEdit = true;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "品名（工厂）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("宋体", 9F);
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "品号（工厂）";
            this.fspd_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "材料（工厂）";
            this.fspd_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderEnhanced";
            this.fspd_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fspd_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.fspd_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fspd_Sheet1.Columns.Get(0).Label = " ";
            this.fspd_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(0).Width = 23F;
            this.fspd_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.fspd_Sheet1.Columns.Get(1).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(1).Label = "品名（工厂）";
            this.fspd_Sheet1.Columns.Get(1).Locked = true;
            this.fspd_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(1).Width = 170F;
            this.fspd_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.fspd_Sheet1.Columns.Get(2).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(2).Label = "品号（工厂）";
            this.fspd_Sheet1.Columns.Get(2).Locked = true;
            this.fspd_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(2).Width = 170F;
            this.fspd_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.fspd_Sheet1.Columns.Get(3).ForeColor = System.Drawing.Color.Black;
            this.fspd_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fspd_Sheet1.Columns.Get(3).Label = "材料（工厂）";
            this.fspd_Sheet1.Columns.Get(3).Locked = true;
            this.fspd_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            this.fspd_Sheet1.Columns.Get(3).Width = 170F;
            this.fspd_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fspd_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
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
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSave.Location = new System.Drawing.Point(195, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 32);
            this.btnSave.TabIndex = 4453;
            this.btnSave.Text = "确   定";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PC30_sub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(590, 430);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.fspd);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PC30_sub2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成品信息（工厂）";
            this.Load += new System.EventHandler(this.PC30_sub2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fspd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fspd_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fspd;
        private FarPoint.Win.Spread.SheetView fspd_Sheet1;
        private System.Windows.Forms.Button btnSave;
    }
}