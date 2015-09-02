/**  版本信息模板在安装目录下，可自行修改。
* fmd030.cs
*
* 功 能： N/A
* 类 名： fmd030
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:51   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// fmd030:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fmd030
	{
		public fmd030()
		{}
		#region Model
        public int? ID { get; set; }
        public string GYSMC { get; set; }
        public string GYSSLMC { get; set; }
        public string DZ { get; set; }
        public string DH { get; set; }
        public string LXR { get; set; }
        public string SCQF { get; set; }
        public string RLZBH { get; set; }
        public string RLR { get; set; }
        public string RLSJ { get; set; }
        public string RLDMM { get; set; }
        public string GXZBH { get; set; }
        public string GXR { get; set; }
        public string GXSJ { get; set; }
        public string GXDMM { get; set; }
		
		#endregion Model

	}
}

