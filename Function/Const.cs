using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function
{

    public class Const
    {
        public Const()
        { }
        public static string QX = string.Empty;         // 登录权限
        //public static string QXMC = string.Empty;       // 权限名称
        //public static string QXBH = string.Empty;       // 权限编号（00064）


        public static string BMBH = string.Empty;       // 部门编号
        public static string SYBH = string.Empty;       // 社员编号
        public static string XM = string.Empty;         // 姓名
        public static string GZQF = string.Empty;       // 工资全表区分
        public static string RQ = string.Empty;         // 公司信息中日期


        public static string SBRQ = string.Empty;      //社保查询日期
        public static string GYZL = string.Empty;         //雇佣种类
        public static string HTQF = string.Empty;         //合同区分
        public static string GJJRQ = string.Empty;     //公积金查询日期 
        public static string GDSRQ = string.Empty;     //个得税查询日期 


        public static string ZSTQQF = string.Empty;
        public static string NXQF = string.Empty;
        public static string HF = string.Empty;

        public static string BM = string.Empty;
        public static string ZW = string.Empty;

        public static string XB = string.Empty; //性别
        public static string SYQZ = string.Empty; //试用期止
        public static string GW = string.Empty; //岗位
        public static bool NLLastday = false; //判断农历最后一天

        public const string YEAR = "年";                                             　  　//年
        public const string MONTH = "月";                                          　  　  //月
        public const string DAY = "日";                                               　 　//日                       
        public const string LING = "0";
        public const string YI = "1";
        public const string ER = "2";
        public const string SAN = "3";
        public const string SI = "4";
        public const string WU = "5";
        public const string LIU = "6";
        public const string QI = "7";
        public const string BA = "8";
        public const string JIU = "9";
        public const string SHI = "10";
        public const string Date = "Date";
        public const string Time = "Time";
        public const string dateStyle_YMD = "yyyyMMdd";
        public const string dateStyle_Y_M_D = "yyyy/MM/dd";

        #region 冯璐
        /// <summary>
        ///  打卡编号       
        /// </summary>
        public const string CST_SYBHGLY = "打卡编号";
        /// <summary>
        ///  社员编号       
        /// </summary>
        public const string CST_SYBH = "社员编号";

        /// <summary>
        ///  身份证号
        /// </summary>
        public const string CST_SFID = "身份证号";

        /// <summary>
        ///  姓名
        /// </summary>
        public const string CST_XM = "姓名";

        /// <summary>
        ///  性别
        /// </summary>
        public const string CST_SEX = "性别";

        /// <summary>
        ///  出生日期
        /// </summary>
        public const string CST_CSNYR = "出生日期";

        /// <summary>
        ///  年龄
        /// </summary>
        public const string CST_NL = "年龄";

        /// <summary>
        ///  勤务名称	
        /// </summary>
        public const string CST_QWMC = "勤务名称 ";

        /// <summary>
        ///  住宿/通勤区分	
        /// </summary>
        public const string CST_TQQF = "住宿/通勤区分 ";

        /// <summary>
        ///  年薪区分	
        /// </summary>
        public const string CST_NXQF = "年薪区分 ";

        /// <summary>
        ///  人员类别	
        /// </summary>
        public const string CST_RYLB = "人员类别 ";

        /// <summary>
        ///  户口区分	
        /// </summary>
        public const string CST_YGXZ = "用工性质 ";

        /// <summary>
        ///  入社日期	
        /// </summary>
        public const string CST_RSRQ = "入社日期 ";

        /// <summary>
        ///  试用期日期	
        /// </summary>
        public const string CST_SYRQ = "试用期日期 ";

        /// <summary>
        ///  退社日期	
        /// </summary>
        public const string CST_TSRQ = "退社日期 ";

        /// <summary>
        ///  合同期限	
        /// </summary>
        public const string CST_HTQX = "合同期限 ";

        /// <summary>
        ///  作业者/管理者
        /// </summary>
        public const string ZYZGLZ = "作业者/管理者";

        /// <summary>
        ///  日期
        /// </summary>
        public const string CST_RQ = "日期";

        /// <summary>
        ///  入大柴日期	
        /// </summary>
        public const string CST_RDCRQ = "入大柴日期 ";

        /// <summary>
        ///  大柴解除日期	
        /// </summary>
        public const string CST_DCJCRQ = "大柴解除日期 ";



        // 社保录入
        public const string SBQF = "社保区分";
        public const string GSXS = "公司系数";
        public const string ZGXS = "职工系数";
        public const string RQ1 = "日期";
        public const string SQRQ1 = "申请日期";
        public const string CCRQ1 = "出差日期";

        // 公积金录入

        public const string SX = "上限";
        public const string XX = "下限";
        public const string GQT = "公司其他";
        public const string ZQT = "职工其他";
        public const string GJJCJS = "公积金超标准缴费基数";
        public const string GB1 = "国别";
        public const string GJXSS = "小时数";
        public const string Sybh202 = "社员编号";




        #endregion

        #region  勤务信息录入_AWMT160
        ///  出勤时间
        /// </summary>
        public const string MT160_CQSJ = "出勤时间";
        ///  退勤时间
        /// </summary>
        public const string MT160_TQSJ = "退勤时间";
        ///  休息小时
        /// </summary>
        public const string MT160_XXSJ = "休息时间";
        ///  出勤小时
        /// </summary>
        public const string MT160_CQXS = "出勤小时";

        #endregion

        #region  工龄病假系数
        public static string GBRQ = string.Empty;


        #endregion

        #region 加班申请
        public const string SQ020_JBKSSJ = "加班开始时间";
        public const string SQ020_JBJSSJ = "加班结束时间";
        public const string SQ020_JBXSS = "加班小时数";

        public const string SQ020_JBRQY = "加班日期年";
        public const string SQ020_JBRQM = "加班日期月";
        public const string SQ020_JBRQD = "加班日期日";

        #endregion

        #region 婚丧产工
        public static string FKD201_STRNUL = string.Empty;
        public const string FKD201_SQRQ = "申请日期";
        public const string FKD201_SYBH = "社员编号";
        public const string FKD201_QF = "区分";
        public const string FKD201_XJKSRQ = "休假开始日";
        public const string FKD201_XJJSRQ = "休假终止日";
        public const string FKD201_BRXSS = "哺乳小时数";
        public const string FKD201_XJZHLX = "生育假，折合连休时，哺乳假不可录入!";
        public const string FKD201_XSSZTOTW = "请假时间必须是大于0～小于12小时之间";
        #endregion


        #region 成品管理
        public const string PM = "品名";
        #endregion 

    }
}
