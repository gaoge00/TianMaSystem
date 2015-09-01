/**  版本信息模板在安装目录下，可自行修改。
* project.cs
*
* 功 能： N/A
* 类 名： project
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
	/// project:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class project
	{
		public project()
		{}
		#region Model
		private int _p_id;
		private string _p_name;
		private string _p_porname;
		private string _p_makerno;
		private string _m_p_id;
		private string _p_order;
		private string _xsqf;
		private string _dmqf;
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
		public int P_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_NAME
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_PorName
		{
			set{ _p_porname=value;}
			get{return _p_porname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_MakerNO
		{
			set{ _p_makerno=value;}
			get{return _p_makerno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string M_P_ID
		{
			set{ _m_p_id=value;}
			get{return _m_p_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_order
		{
			set{ _p_order=value;}
			get{return _p_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XSQF
		{
			set{ _xsqf=value;}
			get{return _xsqf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DMQF
		{
			set{ _dmqf=value;}
			get{return _dmqf;}
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

