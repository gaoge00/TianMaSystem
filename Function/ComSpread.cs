using System;

using System.Drawing;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Function
{
    public static class ComSpread
    {
        /////<summary>
        ///// 清除spd中文本 参数:表格对象
        /////</summary>
        public static void SpdTextClear(FpSpread ospd)
        {
            //其中,true是只清除文本,false是清除文本+sheet内部所有的格式.
            ospd.ActiveSheet.ClearRange(0, 0, ospd.ActiveSheet.RowCount, ospd.ActiveSheet.ColumnCount, true);
        }
 
        ///<summary> 
        /// 设定单元格的焦点  参数:表格对象,单元格行号,单元格列号
        ///</summary>
        public static void SpdSetFocus(FpSpread ospd, int orow, int ocol)
        {
            if (orow >= 0 && ocol >= 0)
            {
                ospd.Focus();
                //ospd.ActiveSheet.SetActiveCell(orow,ocol,false);
                ospd.ActiveSheet.ActiveRowIndex = orow;
                ospd.ActiveSheet.ActiveColumnIndex = ocol;
            }
        }

        ///<summary>
        /// 获取指定单元格内的值  参数:表格对象,单元格行号,单元格列号  返回:值(文本)
        ///</summary>
        public static string SpdGetValue(FpSpread ospd, int orow, int ocol)
        {
            string str = "";
            if (orow >= 0 && ocol >= 0)
            {
                if (ospd.ActiveSheet.GetValue(orow, ocol) != null)
                {
                    str = ospd.ActiveSheet.GetValue(orow, ocol).ToString().Trim();
                }
            }
            return str;
        }

        ///<summary>
        /// 设定指定单元格内的值   参数:表格对象,值,单元格行号,单元格列号
        ///</summary>
        public static void SpdSetValue(FpSpread ospd, object str, int orow, int ocol)
        {
            if (orow >= 0 && ocol >= 0)
            {
                ospd.ActiveSheet.SetValue(orow, ocol, str);
            }
        }

        ///<summary>
        /// 设定指定单元格内的值   参数:表格对象,值,单元格行号,单元格列号
        ///</summary>
        public static void SpdSetText(FpSpread ospd, string str, int orow, int ocol)
        {
            if (orow >= 0 && ocol >= 0)
            {
                ospd.ActiveSheet.SetText(orow, ocol, str);
            }
        }
        ///<summary>
        ///设定单元格的锁定(多行多列)   参数:表格对象,开始行号,开始列号,终止行号,终止列号
        ///</summary>

        public static void SpdLock(FpSpread ospd, int orow1, int ocol1, int orow2, int ocol2)
        {
            ospd.ActiveSheet.Cells[orow1, ocol1, orow2, ocol2].Locked = true;
            ospd.ActiveSheet.Cells[orow1, ocol1, orow2, ocol2].BackColor = Color.LightYellow;
        }

        ///<summary>
        ///设定单元格的锁定(多行多列,去掉附颜色)   参数:表格对象,开始行号,开始列号,终止行号,终止列号
        ///</summary>

        public static void SpdLockNoBC(FpSpread ospd, int orow1, int ocol1, int orow2, int ocol2)
        {
            ospd.ActiveSheet.Cells[orow1, ocol1, orow2, ocol2].Locked = true;
        }
        ///<summary>
        ///设定单元格的锁定(单个)   参数:表格对象,行号,列号
        ///</summary>
        public static void SpdLock(FpSpread ospd, int orow, int ocol)
        {
            ospd.ActiveSheet.Cells[orow, ocol].Locked = true;
            ospd.ActiveSheet.LockBackColor = Color.LightYellow;
        }

        #region 高歌
        ///<summary>
        ///设定单元格的锁定(单个)   参数:表格对象,行号,列号,是否锁定，背景颜色
        ///</summary>
        public static void SpdLock(FpSpread ospd, int orow, int ocol, bool blnLocked, Color backColor)
        {
            ospd.ActiveSheet.Cells[orow, ocol].Locked = blnLocked;
            ospd.ActiveSheet.Cells[orow, ocol].BackColor = backColor;
        }

        ///<summary>
        ///设定单元格的锁定(区域)   参数:表格对象,行号,列号,是否锁定，背景颜色
        ///</summary>
        public static void SpdLock(FpSpread ospd, int orow1, int ocol1, int orow2, int ocol2, bool blnLocked, Color backColor)
        {
            ospd.ActiveSheet.Cells[orow1, ocol1, orow2, ocol2].Locked = blnLocked;
            ospd.ActiveSheet.Cells[orow1, ocol1, orow2, ocol2].BackColor = backColor;
        }
        #endregion

        ///<summary>
        /// spd的初始属性设置.(回车跳格,清除split,锁定行高列宽.直接更改文本)
        ///</summary>
        public static void SpdLoad(FpSpread ospd)
        {
            //回车进行到下一个单元格
            InputMap im;
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F1, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Remove(new FarPoint.Win.Spread.Keystroke(Keys.C, Keys.Control));
            im.Remove(new FarPoint.Win.Spread.Keystroke(Keys.V, Keys.Control));
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.C, Keys.Control), SpreadActions.Redo);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.V, Keys.Control), SpreadActions.Redo);

            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F1, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Remove(new FarPoint.Win.Spread.Keystroke(Keys.C, Keys.Control));
            im.Remove(new FarPoint.Win.Spread.Keystroke(Keys.V, Keys.Control));
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.C, Keys.Control), SpreadActions.Redo);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.V, Keys.Control), SpreadActions.Redo);
            // 清除split按钮
            ospd.RowSplitBoxPolicy = SplitBoxPolicy.Never;
            ospd.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
            //锁定列宽和行高
            //ospd.ActiveSheet.Columns[0, ospd.ActiveSheet.ColumnCount - 1].Resizable = false;
            //ospd.ActiveSheet.Rows[0, ospd.ActiveSheet.RowCount - 1].Resizable = false;
            //单元格进入后文本全选.
            ospd.EditModeReplace = true;
        }
        ///<summary>
        /// spd的初始属性设置.(回车跳格,清除split,锁定行高列宽.直接更改文本)
        ///</summary>
        public static void SpdLoad_1(FpSpread ospd)
        {
            //回车进行到下一个单元格
            InputMap im;
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            // 清除split按钮
            ospd.RowSplitBoxPolicy = SplitBoxPolicy.Never;
            ospd.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
            //锁定列宽和行高
            //ospd.ActiveSheet.Columns[0, ospd.ActiveSheet.ColumnCount - 1].Resizable = false;
            //ospd.ActiveSheet.Rows[0, ospd.ActiveSheet.RowCount - 1].Resizable = false;
            //单元格进入后文本全选.
            ospd.EditModePermanent = true;
            ospd.EditModeReplace = true;
        }

        public static void SpdLoad_hbh(FpSpread ospd)
        {
            //回车进行到下一个单元格
            InputMap im;
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRowWrap);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRowWrap);
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRowWrap);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRowWrap);
            // 清除split按钮
            ospd.RowSplitBoxPolicy = SplitBoxPolicy.Never;
            ospd.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
            //锁定列宽和行高
            //ospd.ActiveSheet.Columns[0, ospd.ActiveSheet.ColumnCount - 1].Resizable = false;
            //ospd.ActiveSheet.Rows[0, ospd.ActiveSheet.RowCount - 1].Resizable = false;
            //单元格进入后文本全选.
            ospd.EditModePermanent = true;
            ospd.EditModeReplace = true;
        }
        ///<summary>
        /// spd 按回车光标横向移动,跳过lock的单元格.在spd的LeaveCell事件中使用.参数:sender,事件
        ///</summary>
        public static void SpdLockCheck(FpSpread ospd, object sender, LeaveCellEventArgs e)
        {
            if (ospd.ActiveSheet.Cells[e.NewRow, e.NewColumn].Locked == true)
            {
                System.Windows.Forms.SendKeys.Send("{ENTER}");
            }
        }

        ///<summary>
        /// 设置多行颜色
        ///<summary>
        public static void SpdBackColor(FpSpread ospd, int srow, int scol, int erow, int ecol, Color color)
        {
            ospd.ActiveSheet.Cells[srow, scol, erow, ecol].BackColor = color;
        }

        ///<summary>
        ///获得尾行(不空)行号
        ///</summary>
        public static int SpdFullRow(FpSpread ospd)
        {
            return ospd.ActiveSheet.NonEmptyRowCount;
        }


        //Spread 单击行变色
        public static void Spread_CellClickChangeBColor(FarPoint.Win.Spread.FpSpread Spd, FarPoint.Win.Spread.CellClickEventArgs e, Color bColor)
        {
            if (e.Row < Spd.ActiveSheet.RowCount)
            {
                Spd.ActiveSheet.Rows[0, Spd.ActiveSheet.Rows.Count - 1].BackColor = Color.Empty;
                Spd.ActiveSheet.Rows[e.Row].BackColor = bColor;
            }
        }

        //Spread 离开行变色
        public static void Spread_LeaveCellBColor(FarPoint.Win.Spread.FpSpread Spd, FarPoint.Win.Spread.LeaveCellEventArgs e, Color bColor)
        {
            if (e.NewRow < Spd.ActiveSheet.RowCount)
            {

                Spd.ActiveSheet.Rows[0, Spd.ActiveSheet.Rows.Count - 1].BackColor = Color.Empty;
                Spd.ActiveSheet.Rows[e.NewRow].BackColor = bColor;
            }
        }

        //Spread 离开Cells变色
        public static void Spread_LeaveCellBColor(FpSpread Spd, LeaveCellEventArgs e, Color bColor, int startColumn, int endColumn)
        {
            if (e.NewRow < Spd.ActiveSheet.RowCount)
            {
                //Spd.ActiveSheet.Cells[startRow,startColumn,endRow,endColumn].BackColor = Color.Empty;
                if (Spd.ActiveSheet.Cells[e.Row, startColumn, e.Row, endColumn].BackColor != Color.Pink)
                    Spd.ActiveSheet.Cells[e.Row, startColumn, e.Row, endColumn].BackColor = Color.Empty;
                Spd.ActiveSheet.Cells[e.NewRow, startColumn, e.NewRow, endColumn].BackColor = bColor;
            }
        }
    }

}

