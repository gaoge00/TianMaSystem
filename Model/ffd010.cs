/**  版本信息模板在安装目录下，可自行修改。
* ffd010.cs
*
* 功 能： N/A
* 类 名： ffd010
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:46   N/A    初版
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
	/// ffd010:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ffd010
	{
		public ffd010()
		{}
		#region Model
		private long _id;
		private string _lhrq;
		private string _hlpclotno;
		private string _jprq;
		private string _clbh;
		private string _pm;
		private string _ph;
		private int? _hgsl;
		private int? _blsl;
		private int? _xdslbz;
		private int? _yrkid;
		private string _rkzf;
		private string _ylhr;
		private string _lhbgzno;
		private string _lhbgrq;
		private string _dmqf;
		private string _rlzbh;
		private string _rlr;
		private string _rlsj;
		private string _rldmm;
		private string _gxzbh;
		private string _gxr;
		private string _gxsj;
		private string _gxdmm;

        private int? _maxxdzf;
        private int? _maxddzf;
        private int? _maxxzf;



        /// <summary>
        /// 最大小袋追番
        /// </summary>
        public int? MAXXDZF
        {
            set { _maxxdzf = value; }
            get { return _maxxdzf; }
        }

        /// <summary>
        /// 最大大袋追番
        /// </summary>
        public int? MAXDDZF
        {
            set { _maxddzf = value; }
            get { return _maxddzf; }
        }

        /// <summary>
        /// 最大箱追番
        /// </summary>
        public int? MAXXZF
        {
            set { _maxxzf = value; }
            get { return _maxxzf; }
        }


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
		public string LHRQ
		{
			set{ _lhrq=value;}
			get{return _lhrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HLPCLOTNO
		{
			set{ _hlpclotno=value;}
			get{return _hlpclotno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JPRQ
		{
			set{ _jprq=value;}
			get{return _jprq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CLBH
		{
			set{ _clbh=value;}
			get{return _clbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PM
		{
			set{ _pm=value;}
			get{return _pm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PH
		{
			set{ _ph=value;}
			get{return _ph;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HGSL
		{
			set{ _hgsl=value;}
			get{return _hgsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BLSL
		{
			set{ _blsl=value;}
			get{return _blsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? XDSLBZ
		{
			set{ _xdslbz=value;}
			get{return _xdslbz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? YRKID
		{
			set{ _yrkid=value;}
			get{return _yrkid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RKZF
		{
			set{ _rkzf=value;}
			get{return _rkzf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YLHR
		{
			set{ _ylhr=value;}
			get{return _ylhr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LHBGZNO
		{
			set{ _lhbgzno=value;}
			get{return _lhbgzno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LHBGRQ
		{
			set{ _lhbgrq=value;}
			get{return _lhbgrq;}
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

