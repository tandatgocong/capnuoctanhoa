﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAPNUOCTANHOA.LinQ
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TANHOAGIS")]
	public partial class GISDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public GISDataContext() : 
				base(global::CAPNUOCTANHOA.Properties.Settings.Default.TANHOAGISConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<HOSO_DONGHOKHACHHANG> HOSO_DONGHOKHACHHANGs
		{
			get
			{
				return this.GetTable<HOSO_DONGHOKHACHHANG>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HOSO_DONGHOKHACHHANG")]
	public partial class HOSO_DONGHOKHACHHANG
	{
		
		private int _OBJECTID;
		
		private string _DBDongHoNuoc;
		
		private string _MaHoSo;
		
		private string _MoTa;
		
		private System.Data.Linq.Binary _DataBlob;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
		private string _NguoiCapNhat;
		
		private string _LoaiFile;
		
		private string _TenHoSo;
		
		public HOSO_DONGHOKHACHHANG()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OBJECTID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int OBJECTID
		{
			get
			{
				return this._OBJECTID;
			}
			set
			{
				if ((this._OBJECTID != value))
				{
					this._OBJECTID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBDongHoNuoc", DbType="NVarChar(11)")]
		public string DBDongHoNuoc
		{
			get
			{
				return this._DBDongHoNuoc;
			}
			set
			{
				if ((this._DBDongHoNuoc != value))
				{
					this._DBDongHoNuoc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHoSo", DbType="NVarChar(20)")]
		public string MaHoSo
		{
			get
			{
				return this._MaHoSo;
			}
			set
			{
				if ((this._MaHoSo != value))
				{
					this._MaHoSo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoTa", DbType="NVarChar(200)")]
		public string MoTa
		{
			get
			{
				return this._MoTa;
			}
			set
			{
				if ((this._MoTa != value))
				{
					this._MoTa = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataBlob", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary DataBlob
		{
			get
			{
				return this._DataBlob;
			}
			set
			{
				if ((this._DataBlob != value))
				{
					this._DataBlob = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime2")]
		public System.Nullable<System.DateTime> NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this._NgayCapNhat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiCapNhat", DbType="NVarChar(50)")]
		public string NguoiCapNhat
		{
			get
			{
				return this._NguoiCapNhat;
			}
			set
			{
				if ((this._NguoiCapNhat != value))
				{
					this._NguoiCapNhat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoaiFile", DbType="NVarChar(10)")]
		public string LoaiFile
		{
			get
			{
				return this._LoaiFile;
			}
			set
			{
				if ((this._LoaiFile != value))
				{
					this._LoaiFile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenHoSo", DbType="NVarChar(100)")]
		public string TenHoSo
		{
			get
			{
				return this._TenHoSo;
			}
			set
			{
				if ((this._TenHoSo != value))
				{
					this._TenHoSo = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
