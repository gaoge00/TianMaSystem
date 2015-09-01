/**  版本信息模板在安装目录下，可自行修改。
* errlog.cs
*
* 功 能： N/A
* 类 名： errlog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:44   N/A    初版
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
	/// errlog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]  
	public partial class errlog
	{
		public errlog()
		{}
		#region Model
		private long _id;
		private string _log_msg;
		private string _cxmc;
		private string _rlzbh;
		private string _rlr;
		private string _rlsj;
		private string _rldmm;
		/// <summary>
		/// auto_increment
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LOG_MSG
		{
			set{ _log_msg=value;}
			get{return _log_msg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CXMC
		{
			set{ _cxmc=value;}
			get{return _cxmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RLZBH
		{
			set{ _rlzbh=value;}
			get{return _rlzbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RLR
		{
			set{ _rlr=value;}
			get{return _rlr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RLSJ
		{
			set{ _rlsj=value;}
			get{return _rlsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RLDMM
		{
			set{ _rldmm=value;}
			get{return _rldmm;}
		}
		#endregion Model

	}
}

