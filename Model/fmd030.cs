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
		private string _khbh;
		private string _khmc;
		private string _khsxm;
		private string _zt;
		private string _rlzbh;
		private string _rlr;
		private string _rlsj;
		private string _rldmm;
		private string _gxzbh;
		private string _gxr;
		private string _gxsj;
		private string _gxdmm;
		/// <summary>
		/// 
		/// </summary>
		public string KHBH
		{
			set{ _khbh=value;}
			get{return _khbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KHMC
		{
			set{ _khmc=value;}
			get{return _khmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KHSXM
		{
			set{ _khsxm=value;}
			get{return _khsxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZT
		{
			set{ _zt=value;}
			get{return _zt;}
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
		/// <summary>
		/// 
		/// </summary>
		public string GXZBH
		{
			set{ _gxzbh=value;}
			get{return _gxzbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GXR
		{
			set{ _gxr=value;}
			get{return _gxr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GXSJ
		{
			set{ _gxsj=value;}
			get{return _gxsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GXDMM
		{
			set{ _gxdmm=value;}
			get{return _gxdmm;}
		}
		#endregion Model

	}
}

