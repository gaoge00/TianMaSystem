/**  版本信息模板在安装目录下，可自行修改。
* message.cs
*
* 功 能： N/A
* 类 名： message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:55   N/A    初版
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
	/// message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class message
	{
		public message()
		{}
		#region Model
		private string _msgcd;
		private string _msg;
		private string _rlzbh;
		private string _rlr;
		private string _rlsj;
		private string _rldmm;
		/// <summary>
		/// 
		/// </summary>
		public string MSGCD
		{
			set{ _msgcd=value;}
			get{return _msgcd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MSG
		{
			set{ _msg=value;}
			get{return _msg;}
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

