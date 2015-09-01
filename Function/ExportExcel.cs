using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Reflection;


namespace Function
{
    public class ExportBaseExcel
    {
        #region 私有成员
        private Microsoft.Office.Interop.Excel.Application m_objExcel;               //Excel应用程序对象
        private Microsoft.Office.Interop.Excel.Workbooks m_objBooks;                 //Excel的Books对象
        private Microsoft.Office.Interop.Excel.Workbook m_objBook;                   //当前Book对象
        private Microsoft.Office.Interop.Excel.Worksheet m_objSheet;                 //当前Sheet对象
        public Microsoft.Office.Interop.Excel.Range m_Range;                        //当前Range对象

        public Microsoft.Office.Interop.Excel.Range Range
        {
            get { return m_Range; }
            set { m_Range = value; }
        }
        private System.Reflection.Missing miss = System.Reflection.Missing.Value;    //空数据变量

        private Microsoft.Office.Interop.Excel.Font m_Font;                          //当前单元格的字体属性对象

        private Microsoft.Office.Interop.Excel.Borders m_Borders;                    //当前单元格或者区域的边框属性对象



        private Microsoft.Office.Interop.Excel.Border m_BorderTop;                   //单元格边框对象(上)
        private Microsoft.Office.Interop.Excel.Border m_BorderBottom;                //单元格边框对象(下)
        private Microsoft.Office.Interop.Excel.Border m_BorderLeft;                  //单元格边框对象(左)
        private Microsoft.Office.Interop.Excel.Border m_BorderRight;                 //单元格边框对象(右)
        private Microsoft.Office.Interop.Excel.Range m_cellRange;                    //单元格Range对象，用来取得对象的Rows和Columns属性对象


        //单元格列号数组

        private string[] m_colString = new string[52] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };

        public enum eHorizontal
        {
            eLeft = 0,
            eRight = 1,
            eCenter = 2
        }
        #endregion

        #region 构造函数

        public ExportBaseExcel()
        {
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            m_objExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            m_objBooks = (Microsoft.Office.Interop.Excel.Workbooks)m_objExcel.Workbooks;
            m_objBook = (Microsoft.Office.Interop.Excel.Workbook)(m_objBooks.Add(miss));
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.ActiveSheet;
        }
        #endregion
        public void GetPrint()
        {
            m_objSheet._PrintOut(miss, miss, 1, true, miss, miss, 1);
        }

        #region 释放对象函数
        ~ExportBaseExcel()
        {
            //释放所有Com对象
            //if (m_cellRange != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_cellRange); }
            //if (m_BorderTop != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderTop); }
            //if (m_BorderBottom != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderBottom); }
            //if (m_BorderLeft != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderLeft); }
            //if (m_BorderRight != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderRight); }
            //if (m_Borders != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Borders); }
            //if (m_Font != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Font); }
            //if (m_Range != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Range); }
            //if (m_objSheet != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet); }
            //if (m_objBook != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook); }
            //if (m_objBooks != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks); }
            //if (m_objExcel != null)
            //{
            //    m_objExcel.Quit();
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
            //}
            //GC.Collect();
        }
        #endregion

        #region 选定单元格

        public string GetCell(int ColNum, int RowNum)
        {
            int row = RowNum + 1;
            if (ColNum < 0 || ColNum > 255)
            {
                throw new Exception("行号错误");
            }
            int i0, i1 = 0;
            i0 = Math.DivRem(ColNum, 26, out i1);
            if (i0 == 0 && i1 == 0)
            {
                return "A" + row.ToString();
            }
            else if (i0 == 0 && i1 > 0)
            {
                return m_colString[i1] + row.ToString();
            }
            else
            {
                return m_colString[i0 - 1] + m_colString[i1] + row.ToString();
            }
        }

        /// 
        /// 选定相应单元格

        /// 
        /// int 列号
        /// int 行号
        public void SetRange(int ColNum, int RowNum)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(ColNum, RowNum), miss);
            m_Font = m_Range.Font;
            m_Borders = m_Range.Borders;
            m_BorderTop = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop];
            m_BorderBottom = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom];
            m_BorderLeft = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft];
            m_BorderRight = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight];
            m_cellRange = m_Range;
            //m_Range.NumberFormatLocal = "@";

        }
        public void SetRange(int ColNum, int RowNum, object oFormat)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(ColNum, RowNum), miss);
            m_Font = m_Range.Font;
            m_Borders = m_Range.Borders;
            m_BorderTop = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop];
            m_BorderBottom = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom];
            m_BorderLeft = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft];
            m_BorderRight = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight];
            m_cellRange = m_Range;
            m_Range.Areas[0].NumberFormat = "[红色]-0.00";
        }

        public void SetRange(int startColNum, int startRowNum, int endColNum, int endRowNum)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(startColNum, startRowNum), (object)GetCell(endColNum, endRowNum));
            m_Font = m_Range.Font;
            m_Borders = m_Range.Borders;
            m_BorderTop = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop];
            m_BorderBottom = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom];
            m_BorderLeft = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft];
            m_BorderRight = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight];
            m_cellRange = m_Range;
        }


        public void SetRange_pc19(int startRowNum, int startColNum, string strFormula, string strNumberFormatLocal)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(startColNum, startRowNum), (object)GetCell(startColNum, startRowNum));
            m_Range.Formula = strFormula; //"= SUM(C6:C65500)";
            m_Range.NumberFormatLocal = strNumberFormatLocal;// "#,##0.00;-#,##0.00";
           // m_Range.NumberFormat = "-0.00";
        }

        public void SetRange(int startColNum, int startRowNum, int endColNum, int endRowNum, object oFormat)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(startColNum, startRowNum), (object)GetCell(endColNum, endRowNum));
            m_Font = m_Range.Font;
            m_Borders = m_Range.Borders;
            m_BorderTop = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop];
            m_BorderBottom = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom];
            m_BorderLeft = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft];
            m_BorderRight = m_Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight];
            m_cellRange = m_Range;
            if (oFormat == null)
            {
                m_cellRange.NumberFormat = "@";
            }
            else
            {
                m_cellRange.NumberFormat = oFormat.ToString();
            }
        }
        #endregion

        #region 给单元格附值

        /// 
        /// 给选定单元格附值

        /// 
        /// 值


        public void SetCellValue(string value)
        {
            if (m_Range == null) throw new System.Exception("没有设定单元格或者区域");
            m_Range.Value2 = value;
        }

        /// 
        /// 给选定单元格附值

        /// 
        /// 列号
        /// 行号
        /// 值


        public void SetCellValue(int row, int col, string value)
        {
            SetRange(col, row);
            m_Range.Value2 = value;
        }


        public void setvaluefor0010(int row, int col, string value)
        {
            m_objSheet.Cells[row, col] = value.ToString().Trim();
        }

        //宽度自适应 cpj
        public void setKD()
        {
            m_objSheet.Columns.AutoFit();
        }



        /// 
        /// 合并选定区域后给其附值

        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号
        /// 值


        public void SetCellValue(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);

            m_Range.Value2 = value;
        }

        /// 
        /// 合并选定区域后给其附值內容居右

        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号
        /// 值


        public void SetCellValueLH(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.Value2 = value;
        }

        /// 
        /// 合并选定区域后给其附值內容居右 数值型
        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号
        /// 值


        public void SetCellValueLH_1(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.NumberFormatLocal = "#,##0.00_ ";
            m_Range.Value2 = value;
        }
        public void SetCellValueLH2(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.NumberFormatLocal = "#,##0.0_ ";
            m_Range.Value2 = value;
        }
        public void SetCellValueLH3(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.NumberFormatLocal = "\\#,##0;\\-#,##0";
            m_Range.Value2 = value;
        }
        public void SetCellValueLH5(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.NumberFormatLocal = "#,##0 ";
            m_Range.Value2 = value;
        }
        public void SetCellValueLH4(int startRow, int startCol, int endRow, int endCol, string value)
        {
            Merge(startRow, startCol, endRow, endCol);
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.NumberFormatLocal = "#,##0.00;-#,##0.00";
            m_Range.Value2 = value;
        }


        #endregion

        #region 设定单元格对齐方式

        /// 
        /// 设定单元格中文字的对齐方式

        /// 
        /// 对齐方式

        public void SetHorizontal(eHorizontal eH)
        {
            if (m_Range == null) throw new System.Exception("没有设定单元格或者区域");
            switch (eH)
            {
                case eHorizontal.eLeft:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
                case eHorizontal.eRight:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
                case eHorizontal.eCenter:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                default:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
            }

        }

        /// 
        /// 设定单元格中文字的对齐方式

        /// 
        /// 单元格行号

        /// 单元格列号

        /// 对齐方式

        public void SetHorizontal(int rowIndex, int columnIndex, eHorizontal eH)
        {
            SetRange(columnIndex, rowIndex);
            switch (eH)
            {
                case eHorizontal.eLeft:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
                case eHorizontal.eRight:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
                case eHorizontal.eCenter:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                default:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;

            }

        }

        /// 

        /// 设定选定区域的对齐方式


        ///

        /// 起始行号

        /// 起始列号

        /// 结束行号

        /// 结束列号

        /// 对齐方式

        public void SetHorizontal(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, eHorizontal eH)
        {

            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            switch (eH)
            {
                case eHorizontal.eLeft:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
                case eHorizontal.eRight:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
                case eHorizontal.eCenter:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                default:
                    m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
            }
        }

        #endregion

        #region 设置行高和列宽


        /// 
        /// 设置列宽
        /// 
        /// 列宽度


        public void SetColumnWidth(float columnWidth)
        {
            m_Range.ColumnWidth = columnWidth;
        }

        /// 

        /// 设置列宽

        /// 

        /// 列号

        /// 列宽度


        public void SetColumnWidth(int columnIndex, float columnWidth)
        {
            SetRange(columnIndex, 0);
            m_Range.ColumnWidth = columnWidth;
        }
        public void SetColumnWidth2(int columnIndex, double width)
        {
            SetRange(columnIndex, 0);
            m_Range.ColumnWidth = width;
        }


        /// 

        /// 设置行高

        /// 

        /// 行宽度


        public void SetRowHeigh(float rowHeigh)
        {
            m_Range.RowHeight = rowHeigh;
        }

        public void SetautoWidth(int columnIndex)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(columnIndex, 0), miss);
            m_Range.EntireColumn.AutoFit();
        }

        /// 

        /// 设置行高

        /// 

        /// 行号

        /// 行宽度


        public void SetRowHeigh(int rowIndex, float rowHeigh)
        {
            SetRange(0, rowIndex);
            m_Range.RowHeight = rowHeigh;
        }

        public float GetRowHeigh(int rowIndex)
        {
            float rowHeigh = 0;
            SetRange(0, rowIndex);
             float.TryParse( m_Range.RowHeight.ToString(),out rowHeigh);
            return rowHeigh;
        }

        #endregion

        #region 合并单元格


        /// 
        /// 将选定区域中的单元格合并

        /// 

        public void Merge()
        {
            m_Range.Merge(null);
        }

        /// 
        /// 将选定区域中的单元格合并

        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号

        public void Merge(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex)
        {
            SetRange1(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_Range.Merge(null);
        }

        public void SetRange1(int startColNum, int startRowNum, int endColNum, int endRowNum)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(startColNum, startRowNum), (object)GetCell(endColNum, endRowNum));
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            m_Range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            m_cellRange = m_Range;
        }

        public void Merge1(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex)
        {
            SetRange11(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_Range.Merge(null);
        }

        public void SetRange11(int startColNum, int startRowNum, int endColNum, int endRowNum)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(startColNum, startRowNum), (object)GetCell(endColNum, endRowNum));
            m_Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            m_Range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            m_cellRange = m_Range;
        }

        #endregion

        #region 设置字体名称、大小

        /// 
        /// 设置区域内的字体
        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号
        /// 字体名称

        public void SetFont(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, string fontName)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_Font.Name = fontName;
        }

        /// 
        /// 设置区域内的字号（文字大小）
        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号
        /// 字号

        public void SetFont(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, int fontSize)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_Font.Size = fontSize;
        }

        /// 
        /// 设置区域内的字体以及字号
        /// 
        /// 起始行号
        /// 起始列号
        /// 结束行号
        /// 结束列号
        /// 字体名称
        /// 字号

        public void SetFont(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, string fontName, int fontSize)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_Font.Name = fontName;
            m_Font.Size = fontSize;
        }

        /// 
        /// 设置单元格的字体和字号

        /// 
        /// 行号
        /// 列号
        /// 字体
        /// 字号

        public void SetFont(int rowIndex, int columnIndex, string fontName, int fontSize)
        {
            SetRange(columnIndex, rowIndex);
            m_Font.Name = fontName;
            m_Font.Size = fontSize;

        }
        public void SetFont2(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, int fontSize)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex); ;
            m_Font.Size = fontSize;
            m_Font.Bold = true;
        }

        /// 
        /// 设置单元格的字体
        /// 
        /// 行号
        /// 列号
        /// 字体

        public void SetFont(int rowIndex, int columnIndex, string fontName)
        {
            SetRange(columnIndex, rowIndex);
            m_Font.Name = fontName;
        }

        /// 
        /// 设置单元格的字号
        /// 
        /// 行号
        /// 列号
        /// 字号

        public void SetFont(int rowIndex, int columnIndex, int fontSize)
        {
            SetRange(columnIndex, rowIndex);
            m_Font.Size = fontSize;
        }

        /// 

        /// 设定字体

        /// 

        /// 字体

        public void SetFont(string fontName)
        {
            m_Font.Name = fontName;
        }

        #endregion

        #region 具体操作
        public void UserControl(bool usercontrol)
        {
            if (m_objExcel == null) { return; }
            m_objExcel.UserControl = usercontrol;
            m_objExcel.DisplayAlerts = usercontrol;
            m_objExcel.Visible = usercontrol;
        }

        public void ExcelVisabl()
        {
            ((Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets.get_Item(1)).Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetHidden;//隐藏模板
        }


        public void SaveAs(string FileName)
        {
            m_objBook.SaveAs(FileName, miss, miss, miss, miss,
            miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges,
            miss, miss, miss, miss);
            //m_objBook.Close(false, miss, miss); 
        }

        public void ReleaseExcel()
        {

            if (m_cellRange != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_cellRange);
            if (m_BorderTop != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderTop);
            if (m_BorderBottom != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderBottom);
            if (m_BorderLeft != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderLeft);
            if (m_BorderRight != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_BorderRight);
            if (m_Borders != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Borders);
            if (m_Font != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Font);
            if (m_Range != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Range);
            if (m_objSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
            if (m_objBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
            if (m_objBooks != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
            if (m_objExcel != null)
            {
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                m_objExcel.Quit();
            }

            GC.Collect();
        }
        #endregion

        #region 读取Excel单元格的文本和值

        /// <summary>
        /// 读取Excel单元格的文本
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public object GetText(int row, int col)
        {
            if (m_objSheet != null)
            {
                return m_objSheet.get_Range((object)GetCell(col, row), miss).Text;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 读取Excel单元格的值

        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public object GetValue(int row, int col)
        {
            if (m_objSheet != null)
            {
                return m_objSheet.get_Range((object)GetCell(col, row), miss).Value2;
            }
            else
            {
                return "";
            }
        }

        //隐藏SHEET
        public void SetVisable()
        {
            m_objSheet.Visible = XlSheetVisibility.xlSheetHidden;

        }
        //显示SHEET
        public void SetVisable1()
        {
            m_objSheet.Visible = XlSheetVisibility.xlSheetVisible;

        }

        //设置Border
        public void SetBorderValue(string col, int row, string col1, int row1)
        {
            m_objSheet.get_Range(col + row, col1 + row1).Borders.LineStyle = 1;



        }
        //设置Border
        public void SetBorderValueMxs(int col, int row, int col1, int row1)
        {
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlHairline;
        }

        //设置Border
        public void SetBorderValue(string col, int row, string col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(col + row, col1 + row1).Borders.LineStyle = LineIndex;
        }

        public void SetBorderValueSingle(int col, int row, int col1, int row1)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders.LineStyle = 1;
        }
        #endregion

        #region //周應樂 OPEN FILE:OpenEFile

        #region 打开文件 系统原来写的有错误.
        public void OpenEFile(string filename)
        {
            if (m_objExcel == null)
            {
                //**************************************************************************
                m_objExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                //**************************************************************************
            }
            UserControl(false);
            m_objExcel.Workbooks.Open(
            filename,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss);
            m_objBooks = (Microsoft.Office.Interop.Excel.Workbooks)m_objExcel.Workbooks;
            m_objBook = m_objExcel.ActiveWorkbook;
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.ActiveSheet;

        }
        #endregion

        #region 设置SHEET名。

        public void SetSheetName(string Name)
        {
            m_objSheet.Name = Name;
        }
        #endregion

        #region 加新SHEET页

        public void SetNewSheet()
        {
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets.get_Item(1);
            m_objSheet.Copy(System.Reflection.Missing.Value, m_objBook.Sheets.get_Item(m_objBook.Sheets.Count));
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets[m_objBook.Sheets.Count];
        }

        public void SetNewSheet(int page)
        {
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets.get_Item(page);
            m_objSheet.Copy(System.Reflection.Missing.Value, m_objBook.Sheets.get_Item(m_objBook.Sheets.Count));
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets[m_objBook.Sheets.Count];
        }
        public void SetNewSpaceSheet()
        {
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets.get_Item(1);
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets[m_objBook.Sheets.Count];
        }
        #endregion

        #region 设置颜色
        public void SetBackColor(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, int intColor)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_cellRange.Interior.ColorIndex = intColor;
        }

        public void SetBackColorByInt(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, int intColor)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_cellRange.Interior.Color = intColor;
        }
        #endregion

        #region 设置自动填充
        public void SetAutoFit(int col, int row, int col1, int row1)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Columns.AutoFit();
        }
        #endregion

        #region 设置当前SHEET页对象

        public void SetActiveSheet(int intSheet)
        {
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets[intSheet];
        }
        #endregion

        #region 隐藏指定sheet
        public void SetModelSheetNoView(int intSheet)
        {
            m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets[intSheet];
            m_objSheet.Visible = XlSheetVisibility.xlSheetHidden;
        }
        #endregion

        #region 设置线


        public void SetBorderValueSingle(int col, int row, int col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders.LineStyle = LineIndex;
        }

        //设置区域边框
        public void SetRangeBorder(int col, int row, int col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeTop].LineStyle
                = LineIndex;
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeLeft].LineStyle
                = LineIndex;
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeBottom].LineStyle
                = LineIndex;
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeRight].LineStyle
               = LineIndex;
        }

        //边框变粗
        public void SetBorderWeight(int row, int col, int row1, int col1)
        {
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeTop].LineStyle
                = 1;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeLeft].LineStyle
                = 1;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeBottom].LineStyle
                = 1;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeRight].LineStyle
               = 1;

            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeTop].Weight
                = XlBorderWeight.xlMedium;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeLeft].Weight
                = XlBorderWeight.xlMedium;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeBottom].Weight
                = XlBorderWeight.xlMedium;
            m_objSheet.get_Range(m_objSheet.Cells[row, col], m_objSheet.Cells[row1, col1]).Borders[XlBordersIndex.xlEdgeRight].Weight
               = XlBorderWeight.xlMedium;
            //m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders.Weight = 3;

        }

        /// <summary>
        /// 已经有程序使用,所以不能更改代码,只好注释.
        /// </summary>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="col1">截止行</param>
        /// <param name="row1">截止列</param>
        /// <param name="LineIndex"></param>
        public void SetRangeTopBorder(int col, int row, int col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeTop].LineStyle
                = LineIndex;
        }

        /// <summary>
        /// 已经有程序使用,所以不能更改代码,只好注释.
        /// </summary>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="col1">截止行</param>
        /// <param name="row1">截止列</param>
        /// <param name="LineIndex"></param>
        public void SetRangeLeftBorder(int col, int row, int col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeLeft].LineStyle
                = LineIndex;
        }

        /// <summary>
        /// 已经有程序使用,所以不能更改代码,只好注释.
        /// </summary>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="col1">截止行</param>
        /// <param name="row1">截止列</param>
        /// <param name="LineIndex"></param>
        public void SetRangeBottomBorder(int col, int row, int col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeBottom].LineStyle
                = LineIndex;
        }

        /// <summary>
        /// 已经有程序使用,所以不能更改代码,只好注释.
        /// </summary>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="col1">截止行</param>
        /// <param name="row1">截止列</param>
        /// <param name="LineIndex"></param>
        public void SetRangeRightBorder(int col, int row, int col1, int row1, int LineIndex)
        {
            m_objSheet.get_Range(m_objSheet.Cells[col, row], m_objSheet.Cells[col1, row1]).Borders[XlBordersIndex.xlEdgeRight].LineStyle
               = LineIndex;
        }

        #endregion

        #region 给选定单元格附值

        /// 列号
        /// 行号
        /// 值

        public void SetCellValue(int row, int col, string value, string strFlg)
        {
            SetRangeZyl(col, row);
            m_Range.Value2 = value;
        }
        #endregion

        #region 选定相应单元格

        /// int 列号
        /// int 行号
        public void SetRangeZyl(int ColNum, int RowNum)
        {
            m_Range = m_objSheet.get_Range((object)GetCell(ColNum, RowNum), miss);
        }
        #endregion

        #region 关于直接赋值区域数据的方法.一次性写入.3500行数据,3分钟
        public void Write(System.Data.DataTable dt, int intRowStar, int intColStar)
        {

            long tbRoC = dt.Rows.Count;
            int tbCoC = dt.Columns.Count;

            try
            {

                for (int r = 0; r < tbRoC; r++)
                {
                    for (int i = 0; i < tbCoC; i++)
                    {
                        m_objSheet.Cells[intRowStar + r + 1, intColStar + i + 1] = dt.Rows[r][i];
                        m_Range = (Range)m_objSheet.Cells[r + 1, i + 1];
                    }

                    System.Windows.Forms.Application.DoEvents();
                }
                m_objBook.Saved = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        #region 设置页脚
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFooter"></param>
        /// <param name="intFlg">1:左,2:中,3:右</param>
        public void SetFoot(string strFooter, int intFlg)
        {
            switch (intFlg)
            {
                case 1:
                    m_objSheet.PageSetup.LeftFooter = strFooter;
                    break;
                case 2:
                    m_objSheet.PageSetup.CenterFooter = strFooter;
                    break;
                case 3:
                    m_objSheet.PageSetup.RightFooter = strFooter;
                    break;

            }
        }
        #endregion

        #region 区域复制
        public Range CopyArea(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex)
        {
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            return m_cellRange;

        }

        public Range CopyAreaSheet1(int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex)
        {
            Range TRange = ((Microsoft.Office.Interop.Excel.Worksheet)m_objBook.Sheets.get_Item(1)).
               get_Range((object)GetCell(startColumnIndex, startRowIndex), (object)GetCell(endColumnIndex, endRowIndex));
            return TRange;

        }

        #endregion

        #region 区域粘贴
        public void PasteArea(Range RangeSourse, int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex)
        {
            RangeSourse.Select();
            RangeSourse.Copy(Type.Missing);
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_cellRange.Select();
            m_objSheet.PasteSpecial(XlPasteType.xlPasteFormulasAndNumberFormats, false, false,
                                    Type.Missing, Type.Missing, Type.Missing, false);
        }

        //EXCEL2007粘帖
        public void PasteArea2007(Range RangeSourse, int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex)
        {
            RangeSourse.Copy(Type.Missing);
            SetRange(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
            m_cellRange.Select();
            m_objSheet.Paste(m_cellRange, false);
        }

        #endregion

        #region  设置焦点单元格

        public void SetCellFcous(int Row, int Col)
        {
            SetRange(Row, Col);
            m_Range.Select();
        }
        #endregion

        // 删除行

        public void DeleteRows(int rowIndex)
        {
            m_Range = (Range)m_objSheet.Rows[rowIndex, Type.Missing];
            m_Range.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);
        }

        // 插入列

        public void InsertColumn(int ColumnIndex)
        {
            m_Range = (Range)m_objSheet.Columns[ColumnIndex, Type.Missing];
            m_Range.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);


        }


        // 删除列

        public void DeleteColumn(int ColumnIndex)
        {
            m_Range = (Range)m_objSheet.Columns[ColumnIndex, Type.Missing];
            m_Range.Delete(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight);

        }

        /// <summary>
        ///  删除列 下标从0开始

        /// </summary>
        /// <param name="startCol">开始列</param>
        /// <param name="endCol">结束列</param>
        public void DeleteColumuns(int startCol, int  endCol)
        {
            string a = ToName(startCol);
            string b = ToName(endCol);
            //m_objSheet.get_Range((object)("A:D"), Type.Missing).Delete(XlDeleteShiftDirection.xlShiftToLeft);       
            m_Range = (Range)m_objSheet.Columns[(object)(a+":"+b), Type.Missing];
            m_Range.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftToLeft);
        }
        //数字转成字母 例 0=“A” 26="AA" 从0开始

        public  string ToName(int index)
        {
            if (index < 0) { throw new Exception("invalid parameter"); }

            List<string> chars = new List<string>();
            do
            {
                if (chars.Count > 0) index--;
                chars.Insert(0, ((char)(index % 26 + (int)'A')).ToString());
                index = (int)((index - index % 26) / 26);
            } while (index > 0);

            return String.Join(string.Empty, chars.ToArray());
        }
        //字母转成数字 例 A=“0” AA="26" 
        public  int ToIndex(string columnName)
        {
            if (!Regex.IsMatch(columnName.ToUpper(), @"[A-Z]+")) { throw new Exception("invalid parameter"); }

            int index = 0;
            char[] chars = columnName.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += ((int)chars[i] - (int)'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
            }
            return index - 1;
        }

        //设置文字颜色
        public void SetFontColor(int row, int col, int color)
        {
            SetRange(col, row, col, row);
            m_Font.ColorIndex = color;
        }
        public void SetFontColor(int srow, int scol,int erow,int ecol,int color)
        {
            SetRange(scol, srow, ecol, erow);
            //SetRange(col, row, col, row);
            m_Font.ColorIndex = color;
        }

        public void SetFontBold(int srow, int scol, int erow, int ecol)
        {
            SetRange(scol, srow, ecol, erow);
            //SetRange(col, row, col, row);
            m_Font.Bold = true;
        }
        //public void SetBackColor(int srow, int scol, int erow, int ecol, int color)
        //{
        //    SetRange(scol, srow, ecol, erow);
        //    //SetRange(col, row, col, row);
        //    m_Range.Interior.ColorIndex = color;
        //}

        #endregion

        public void setBK(int row, int p)
        {
            throw new NotImplementedException();
        }

        public void delSheet()
        {
            m_objSheet.Delete();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_row"></param>
        /// <param name="_col"></param>
        /// <param name="_dt"></param>
        public void TableToExcel(int _row, int _col, System.Data.DataTable _dt)
        {
            int RowCount = _dt.Rows.Count;
            int ColCount = _dt.Columns.Count;

            //定义一个2维数组用来存储DATATABLE里的数据
            object[,] dataArray = new object[RowCount, ColCount];

            //把DATATABLE里的数据导到2维数组中
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    if (_dt.Rows[i][j] == System.DBNull.Value)
                    {
                        dataArray[i, j] = "";
                    }
                    else
                    {
                        dataArray[i, j] = _dt.Rows[i][j];
                    }
                }
            }
            //把2维数组中的数据导到EXCEL中
            m_objSheet.get_Range(m_objSheet.Cells[_row, _col], m_objSheet.Cells[_row + RowCount - 1, _col + ColCount - 1]).Value2 =dataArray;
        }

        public void TableToExcelGZT(int _row, int _col, System.Data.DataTable _dt)
        {
            int RowCount = _dt.Rows.Count;
            int ColCount = _dt.Columns.Count;

            //定义一个2维数组用来存储DATATABLE里的数据
            object[,] dataArray = new object[RowCount*2, ColCount];
            int RowNo = 0;
            //把DATATABLE里的数据导到2维数组中
            for (int i = 0; i < RowCount; i++)
            {
                dataArray[RowNo, 0] = "月份";
                dataArray[RowNo, 1]= "社员编号";
                dataArray[RowNo, 2]= "姓名";
                dataArray[RowNo, 3]= "加班(平)";
                dataArray[RowNo, 4]= "加班(休)";
                dataArray[RowNo, 5]= "加班(节)";
                dataArray[RowNo, 6]= "欠勤(病)";
                dataArray[RowNo, 7]= "欠勤(事)";
                dataArray[RowNo, 8]= "基本工资";
                dataArray[RowNo, 9]= "职位工资";
                dataArray[RowNo, 10]= "职务津贴";
                dataArray[RowNo, 11]= "社内津贴";
                dataArray[RowNo, 12]= "工龄津贴";
                dataArray[RowNo, 13]= "满勤";
                dataArray[RowNo, 14]= "夜班费";
                dataArray[RowNo, 15]= "夜餐费";
                dataArray[RowNo, 16]= "加班费";
                dataArray[RowNo, 17]= "欠勤";
                dataArray[RowNo, 18]= "福利费";
                dataArray[RowNo, 19]= "应得工资";
                dataArray[RowNo, 20]= "取暖费";
                dataArray[RowNo, 21]= "医保费";
                dataArray[RowNo, 22]= "养老金";
                dataArray[RowNo, 23]= "住房基金";
                dataArray[RowNo, 24]= "所得税";
                dataArray[RowNo, 25]= "实得工资";
                RowNo++;
                for (int j = 0; j < ColCount; j++)
                {
                    if (_dt.Rows[i][j] == System.DBNull.Value)
                    {
                        dataArray[RowNo, j] = "";
                    }
                    else
                    {
                        dataArray[RowNo, j] = _dt.Rows[i][j];
                    }
                }
                RowNo++;
            }
            //把2维数组中的数据导到EXCEL中
            m_objSheet.get_Range(m_objSheet.Cells[_row, _col], m_objSheet.Cells[_row + RowCount*2 - 1, _col + ColCount - 1]).Value2 = dataArray;
        }

        public void SetDfont()
        {
            m_Font = m_objSheet.get_Range("C4", "C4").get_Characters(1, 2).Font;
            m_Font.Size = 12;
        }


       
     /// <summary>
     /// 执行宏
     /// </summary>
     /// <param name="MacroName"> 宏名称</param>
        public void RunMacro(string MacroName)
        { 
            object  missing = Missing.Value;
            m_objExcel.Run(MacroName, missing, missing,   
                        missing,missing,missing,missing,   
                        missing,missing,missing,   missing,   
                        missing,missing,missing,missing,   
                        missing,missing,   missing,missing,   
                        missing,missing,missing,missing,   
                        missing,missing,missing,missing,   
                        missing,   missing,missing,missing);             
        }
        /// <summary>
        /// 格式刷

        /// </summary>
        /// <param name="sheetIndex">sheet索引</param>
        /// <param name="newBeginCell">目标单元格</param>
        public void PasteSpecial(int sheetIndex, object beginCell, object endCell, object newBeginCell, object newEndCell)
        {
            //SetActiveSheet(sheetIndex);

            Excel.Range objCopySrc = (Excel.Range)m_objSheet.get_Range(beginCell, endCell);
            Excel.Range objCopyDESC = (Excel.Range)m_objSheet.get_Range(newBeginCell, newEndCell);

            objCopySrc.Select();
            objCopySrc.Copy(Type.Missing);

            objCopyDESC.Select();
            objCopyDESC.PasteSpecial(Excel.XlPasteType.xlPasteFormulasAndNumberFormats, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
           // objCopyDESC.PasteSpecial(Excel.XlPasteType.xlPasteColumnWidths, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


            
        }
        public void PasteSpecial(int sheetIndex, object beginCell, object endCell, object newBeginCell, object newEndCell,string QF)
        {
            SetActiveSheet(sheetIndex);

            Excel.Range objCopySrc = (Excel.Range)m_objSheet.get_Range(beginCell, endCell);
            Excel.Range objCopyDESC = (Excel.Range)m_objSheet.get_Range(newBeginCell, newEndCell);

            objCopySrc.Select();
            objCopySrc.Copy(Type.Missing);

            objCopyDESC.Select();
            objCopyDESC.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
           // objCopyDESC.PasteSpecial(Excel.XlPasteType.xlPasteColumnWidths, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


            
        }

        #region 杀Excel.exe进程，20120626 By CN
        //根据ID杀Excel.exe进程，20120626 By CN
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public void KillSpecialExcel()
        {
            try
            {
                if (m_objExcel != null)
                {
                    int lpdwProcessId;
                    GetWindowThreadProcessId(new IntPtr(m_objExcel.Hwnd), out lpdwProcessId);
                    System.Diagnostics.Process.GetProcessById(lpdwProcessId).Kill();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), "Delete Excel Process Error:" + ex.Message);
            }
        }
        #endregion

        #region 打开Excel文件
        public void ViewFile(string filename)
        {
            if (m_objExcel == null)
            {
                //**************************************************************************
                m_objExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                //**************************************************************************
            }
            //UserControl(false);
            m_objExcel.Workbooks.Open(
            filename,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss,
            miss);
            //m_objBooks = (Microsoft.Office.Interop.Excel.Workbooks)m_objExcel.Workbooks;
            //m_objBook = m_objExcel.ActiveWorkbook;
            //m_objSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objBook.ActiveSheet;
            UserControl(true);

        }
               public ExportBaseExcel(string excel)
        {

        }
        #endregion


        #region AddPic
               public void AddPic(int col,int row,string picPath ,float w ,float h)
               {
                   SetRange(col, row);
                   Excel.Range pic2 = this.Range;
                   pic2.Select();
                   float picleft, pictop;
                   picleft = Convert.ToSingle(pic2.Left)+1;
                   pictop = Convert.ToSingle(pic2.Top)+1;

                   this.m_objSheet.Shapes.AddPicture(picPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, picleft, pictop, w, h);
              
               }
 
        #endregion 

    }
}

