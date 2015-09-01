/**  版本信息模板在安装目录下，可自行修改。
* fmd090.cs
*
* 功 能： N/A
* 类 名： fmd090
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-11-11 15:51:04   N/A    初版
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
	/// fmd090:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fmd090
	{
		public fmd090()
		{}
		#region Model
		private int _id;
		private double? _sx;
		private double? _xx;
		private double? _gc;
		private string _jsqf;
		private string _rlzbh;
		private string _rlr;
		private string _rlsj;
		private string _rldmm;
		private string _gxzbh;
		private string _gxr;
		private string _gxsj;
		private string _gxdmm;
        private bool _add;

        public bool ADD
        {
            get { return _add; }
            set { _add = value; }
        }
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? SX
		{
			set{ _sx=value;}
			get{return _sx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? XX
		{
			set{ _xx=value;}
			get{return _xx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? GC
		{
			set{ _gc=value;}
			get{return _gc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSQF
		{
			set{ _jsqf=value;}
			get{return _jsqf;}
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

