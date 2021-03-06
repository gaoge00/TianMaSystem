using System;
using System.Collections;
using System.Collections.Generic;

namespace Function
{
    public struct ComConst
    {
        #region 公共部分
        /// <summary>
        /// メッセージ表示ボタン
        /// <summary>
        public const int OK = 0;
        public const int OK_CANCEL = 1;

        /// <summary>
        /// 共通
        /// </summary>
        public const int WM_SYSCOMMAND = 0x0112;                                   　　//コマンド
        public const int SC_CLOSE = 0xF060;                                            //クローズ
        public const string MESSAGE_TITLE = "提示";                        //メッセージのタイトル
        public const string INPUTLANGUAGE_ZNNAME = "中国語（中国）";
        public const string INPUTLANGUAGE_JPNAME = "Microsoft IME Standard 2003";
        public const string INPUTLANGUAGE_JPNAME_2007 = "Microsoft Office IME 2007";
        /// <summary>

        //********   快捷鍵  ********
        public const string F1 = "F1";                                                       　　　 //F1
        public const string F2 = "F2";                                                        　　　//F2
        public const string F3 = "F3";                                                       　　　 //F3
        public const string F4 = "F4";                                                     　　　   //F4
        public const string F5 = "F5";                                                    　　　    //F5
        public const string F6 = "F6";                                                    　　　    //F6
        public const string F7 = "F7";                                                     　　　   //F7
        public const string F8 = "F8";                                                    　　　    //F8
        public const string F9 = "F9";                                                    　　　    //F9
        public const string F10 = "F10";                                                  　　　    //F10
        public const string F11 = "F11";                                                  　　　    //F11
        public const string F12 = "F12";                                                  　　　    //F12   

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




        #endregion

        
        #region hbh
        // 公司录入
        public const string FR = "法人";
        public const string zjl = "总经理";
        public const string zffzr = "中方负责人";
        public const string GSMC_CHINA = "公司名称(中文)";
        public const string zwsx = "中文(缩写)";
        public const string GSMC_ENGLISH = "公司名称(英文)";
        public const string ywsx = "英文(缩写)";
        public const string GSDZ2 = "公司地址(英文)";
        public const string GSDZ1 = "公司地址(中文)";
        public const string YB = "邮编";
        public const string DH1 = "电话";
        public const string EMAIL = "E_mail";
        public const string CZ = "传真";
        public const string jbyysj = "营业小时/月";
        public const string yyzz = "营业执照";
        public const string qydm = "组织机构代码";
        public const string sbdm = "社保代码";
        public const string sbzh = "社保账号";
        public const string GJJDM = "公积金代码";
        public const string GJJZH = "公积金账号";
        public const string SWSBDM = "税务识别代码";
        public const string DSJFDM = "地税缴费代码";
        public const string pfdfdm = "工资代发代码";
        public const string pfdfzh = "工资代发账号";
        public const string XXXX = "详细信息";


        // 个得税录入
        public const string GDSJFJS = "个得税缴费基数";
        public const string JS = "级数";
        public const string QYYNSSESX = "全月应纳税所得额上限";
        public const string QYYNSSEXX = "全月应纳税所得额下限";
        public const string SL = "税率";
        public const string SSKCS = "速算扣除数";
        public const string RQ = "日期";

        // 社保录入
        public const string SBQF = "社保区分";
        public const string GSXS = "公司系数";
        public const string ZGXS = "职工系数";

        // 公积金录入

        public const string SX = "上限";
        public const string XX = "下限";
        public const string GQT = "公司其他";
        public const string ZQT = "职工其他";
        public const string GJJCJS = "公积金超标准缴费基数";

        #endregion

        #region 所有画面

        /// <summary>
        ///  社员编号
        /// </summary>
        public const string CST_SYBH = "编号";

        /// <summary>
        ///  社员
        /// </summary>
        public const string CST_SY = "社员";

        /// <summary>
        ///  姓名
        /// </summary>
        public const string CST_XM = "姓名";

        /// <summary>
        ///  性别
        /// </summary>
        public const string CST_SEX = "性别";

        /// <summary>
        ///  年龄
        /// </summary>
        public const string CST_NL = "年龄";

        /// <summary>
        ///  身份证号
        /// </summary>
        public const string CST_SFID = "身份证号";

        /// <summary>
        ///  出生日期
        /// </summary>
        public const string CST_CSNYR = "出生日期";

        /// <summary>
        ///  婚否
        /// </summary>
        public const string CST_HFQF = "婚否";

        /// <summary>
        ///  合同区分	
        /// </summary>
        public const string CST_HTQF = "合同区分 ";

        /// <summary>
        ///  户口区分	
        /// </summary>
        public const string CST_HKQF = "户口区分 ";

        /// <summary>
        ///  户口区分	
        /// </summary>
        public const string CST_YGXZ = "用工性质 ";


        /// <summary>
        ///  年薪区分	
        /// </summary>
        public const string CST_NXQF = "年薪区分 ";

        /// <summary>
        ///  补助区分	
        /// </summary>
        public const string CST_BTQF = "补助区分 ";


        /// <summary>
        ///  住宿/通勤区分	
        /// </summary>
        public const string CST_TQQF = "住宿/通勤区分 ";

        /// <summary>
        ///  保险	
        /// </summary>
        public const string CST_BX = "保险 ";

        /// <summary>
        ///  入社日期	
        /// </summary>
        public const string CST_RSRQ = "入社日期 ";


        /// <summary>
        ///  入社时间	
        /// </summary>
        public const string CST_RSSJ = "入社时间 ";


        /// <summary>
        ///  退社日期	
        /// </summary>
        public const string CST_TSRQ = "退社日期 ";


        /// <summary>
        ///  试用期日期	
        /// </summary>
        public const string CST_SYRQ = "试用期日期 ";

        /// <summary>
        ///  试用期时间	
        /// </summary>
        public const string CST_SYSJ = "试用期时间 ";

        /// <summary>
        ///  合同期限	
        /// </summary>
        public const string CST_HTQX = "合同期限 ";

        /// <summary>
        ///  退休日期	
        /// </summary>
        public const string CST_TXRQ = "退休日期 ";

        /// <summary>
        ///  前职工龄	
        /// </summary>
        public const string CST_QZGL = "前职工龄 ";

        /// <summary>
        ///  入社工龄	
        /// </summary>
        public const string CST_RSGL = "入社工龄 ";

        /// <summary>
        ///  公积金帐号	
        /// </summary>
        public const string CST_GJJH = "公积金帐号 ";

        /// <summary>
        ///  工资卡号	
        /// </summary>
        public const string CST_GZKH = "工资卡号 ";

        /// <summary>
        ///  勤务名称	
        /// </summary>
        public const string CST_QWMC = "勤务名称 ";

        /// <summary>
        ///  短缩名	
        /// </summary>
        public const string CST_DSM = "短缩名 ";

        /// <summary>
        ///  勤务区分	
        /// </summary>
        public const string CST_QWQF = "勤务区分 ";

        /// <summary>
        ///  他加	
        /// </summary>
        public const string CST_TJIA = "他加 ";

        /// <summary>
        ///  他减	
        /// </summary>
        public const string CST_TJIAN = "他减 ";

        /// <summary>
        ///  他加金额,他减金额	
        /// </summary>
        public const string CST_TJJE = "他加金额,他减金额 ";

        /// <summary>
        ///  营业天数	
        /// </summary>
        public const string CST_YYTS = "营业天数 ";

        /// <summary>
        ///  公休天数	
        /// </summary>
        public const string CST_GXTS = "公休天数 ";

        /// <summary>
        ///  日期
        /// </summary>
        public const string CST_RQ = "日期";

        /// <summary>
        ///  金额
        /// </summary>
        public const string CST_JE = "金额";

        /// <summary>
        ///  部门
        /// </summary>
        public const string CST_BM = "部门";


        /// <summary>
        ///  供暖补助
        /// </summary>
        public const string CST_GNBZ = "供暖补助";

        /// <summary>
        ///  保健补助
        /// </summary>
        public const string CST_BJBZ = "保健补助";

        /// <summary>
        ///  交通补助
        /// </summary>
        public const string CST_JTBZ = "交通补助";

        /// <summary>
        ///  高温补助
        /// </summary>
        public const string CST_GWBZ = "高温补助";

        /// <summary>
        ///  技能工资
        /// </summary>
        public const string CST_JNGZ = "技能工资";

        /// <summary>
        ///  其他补助1
        /// </summary>
        public const string CST_QTBZ1 = "其他补助1";

        /// <summary>
        ///  其他补助2
        /// </summary>
        public const string CST_QTBZ2 = "其他补助2";

        /// <summary>
        ///  其他工资
        /// </summary>
        public const string CST_QTGZ = "其他工资";

        /// <summary>
        ///  试用期其他工资
        /// </summary>
        public const string CST_SYQQTGZ = "试用期其他工资";

        /// <summary>
        ///  夜班补助
        /// </summary>
        public const string CST_YBBZ = "夜班补助";

        /// <summary>
        ///  餐补
        /// </summary>
        public const string CST_WCBZ = "餐补";

        /// <summary>
        ///  卫生费
        /// </summary>
        public const string CST_WSF = "卫生费";

        /// <summary>
        ///  独生子女费
        /// </summary>
        public const string CST_DSZNF = "独生子女费";

        /// <summary>
        ///  试用期技能工资
        /// </summary>
        public const string CST_SYQJNGZ = "试用期技能工资";

        /// <summary>
        ///  用户名或者密码
        /// </summary>
        public const string CST_YONGHUMIMA = "用户名或密码";

        /// <summary>
        ///  申请日期
        /// </summary>
        public const string CST_SQRQ = "申请日期";

        #endregion

        #region  高歌

        #region  休假申请_AWSQ040
        /// <summary>
        ///  休假日期年
        /// </summary>
        public const string SQ040_XJRQY = "日期年";
        /// <summary>
        ///  休假日期月
        /// </summary>
        public const string SQ040_XJRQM = "日期月";
        /// <summary>
        ///  休假日期日
        /// </summary>
        public const string SQ040_XJRQD = "日期日";
        /// <summary>
        ///  休假区分
        /// </summary>
        public const string SQ040_XJQF = "休假区分";
        /// <summary>
        ///  合计小时
        /// </summary>
        public const string SQ040_GJXS = "共计小时";

        /// <summary>
        ///  社员编号
        /// </summary>
        public const string SQ040_SYBH = "社员编号";
        /// <summary>
        ///  开始时
        /// </summary>
        public const string SQ040_KSS = "开始时";
        /// <summary>
        ///  开始分
        /// </summary>
        public const string SQ040_KSF = "开始分";
        /// <summary>
        ///  结束时
        /// </summary>
        public const string SQ040_JSS = "结束时";
        /// <summary>
        ///  结束分
        /// </summary>
        public const string SQ040_JSF = "结束分";


        #endregion

        #region  考勤_AWMT100
        /// <summary>
        ///  开始年
        /// </summary>
        public const string MT100_KSY = "开始年";
        /// <summary>
        ///  开始月
        /// </summary>
        public const string MT100_KSM = "开始月";
        /// <summary>
        ///  开始日
        /// </summary>
        public const string MT100_KSD = "开始日";
        /// <summary>
        ///  结束年
        /// </summary>
        public const string MT100_JSY = "结束年";
        /// <summary>
        ///  结束月
        /// </summary>
        public const string MT100_JSM = "结束月";
        /// <summary>
        ///  结束日
        /// </summary>
        public const string MT100_JSD = "结束日";
        /// <summary>
        ///  社员编号
        /// </summary>
        public const string MT100_SYBH = "社员编号";
        /// <summary>
        /// 病假
        /// </summary>
        public const string MT070_BingJ = "病假";
        /// <summary>
        /// 事假
        /// </summary>
        public const string MT070_ShiJ = "事假";
        /// <summary>
        /// 迟到
        /// </summary>
        public const string MT070_ChiD = "迟到";
        /// <summary>
        /// 早退
        /// </summary>
        public const string MT070_ZaoT = "早退";
        /// <summary>
        /// 旷工
        /// </summary>
        public const string MT070_KuangG = "旷工";
        /// <summary>
        /// 息工
        /// </summary>
        public const string MT070_XiG = "息工";

        /// <summary>
        /// 通常勤务
        /// </summary>
        public const string FKD070_QWMC_TC = "004";
        /// <summary>
        /// 一班
        /// </summary>
        public const string FKD070_QWMC_YiB = "001";
        /// <summary>
        /// 二班
        /// </summary>
        public const string FKD070_QWMC_ErB = "002";
        /// <summary>
        /// 三班
        /// </summary>
        public const string FKD070_QWMC_SanB = "003";
        /// <summary>
        /// 息工
        /// </summary>
        public const string FKD070_QWMC_XiG = "009";



        #endregion

        #endregion

        #region 加班申请
        public const string SQ020_JBKSSJ = "加班开始时间";
        public const string SQ020_JBJSSJ = "加班结束时间";
        public const string SQ020_JBXSS = "加班小时数";

        public const string SQ020_JBRQY = "加班日期年";
        public const string SQ020_JBRQM = "加班日期月";
        public const string SQ020_JBRQD = "加班日期日";

        #endregion

        #region 工资计算
        public const string GZRQKSY = "工资日期开始年";
        public const string GZRQKSM = "工资日期开始月";
        public const string GZRQJZY = "工资日期截止年";
        public const string GZRQJZM = "工资日期截止月";
        #endregion

        #region lql
        ///  申请日期
        /// </summary>
        public const string ShenQingRQ = "申请日期";

        ///  休假开始日
        /// </summary>
        public const string VacationStarDay = "休假开始日";
        ///  休假终止日
        /// </summary>
        public const string VacationEndDay = "休假终止日";
        ///  生育假，折合连休时，哺乳假不可录入!
        /// </summary>
        public const string ShengZheBrNo = "生育假，折合连休时，哺乳假不可录入!";
        ///  产检假开始日期和终止日期不能小于生育假终止日期!
        /// </summary>
        public const string ChKsrXySyZhr = "产检假开始日期和终止日期不能小于生育假终止日期!";
        ///  区分
        /// </summary>
        public const string Distinguish = "区分";
        ///  请假时间必须是大于0～小于12小时之间
        /// </summary>
        public const string XjsjCheck = "请假时间必须是大于0～小于12小时之间";

        ///  哺乳小时数
        /// </summary>
        public const string CMbrxss = "哺乳小时数";

        #endregion

        #region  CN

        #region  出差申请_AWSQ050
        ///  出差日期
        /// </summary>
        public const string SQ050_RQ = "出差日期";
        ///  出差小时
        /// </summary>
        public const string SQ050_CCXSS = "出差小时";

        #endregion

        #region  病假系数录入_AWMT140
        ///  名称
        /// </summary>
        public const string MT140_BJMC = "名称";
        ///  小时数
        /// </summary>
        public const string MT140_XXS = "小时数";
        ///  扣缴比率
        /// </summary>
        public const string MT140_KJLATE = "扣缴比率";

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
        public const string MT160_XXXS = "休息小时";
        ///  出勤小时
        /// </summary>
        public const string MT160_CQXS = "出勤小时";

        #endregion

        #region  员工有薪年假申请一览_AWMT080

        ///  年度
        /// </summary>
        public const string MT080_ND = "年度";

        #endregion

        #region  员工有薪年假申请明细_AWMT080SUB

        ///  申请日
        /// </summary>
        public const string MT080SUB_SQR = "申请日";
        ///  天数
        /// </summary>
        public const string MT080SUB_TS = "天数";

        #endregion

        #region  年度上下限报表_AWBB040
        ///  开始年度
        /// </summary>
        public const string BB040_KSYEAR = "开始年度";
        ///  结束年度
        /// </summary>
        public const string BB040_JSYEAR = "结束年度";
        ///  上下限区分
        /// </summary>
        public const string BB040_SXXQF = "上下限区分";

        #endregion

        #endregion

        /// <summary>
        ///  工资项目	
        /// </summary>
        public const string CST_GZXM = "工资项目";//



    }
}

