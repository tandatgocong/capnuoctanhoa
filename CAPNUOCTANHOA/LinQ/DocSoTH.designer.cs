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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DocSoTH")]
	public partial class DocSoTHDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBaoThay(BaoThay instance);
    partial void UpdateBaoThay(BaoThay instance);
    partial void DeleteBaoThay(BaoThay instance);
    #endregion
		
		public DocSoTHDataContext() : 
				base(global::CAPNUOCTANHOA.Properties.Settings.Default.DocSoTHConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoTHDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoTHDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoTHDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoTHDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BaoThay> BaoThays
		{
			get
			{
				return this.GetTable<BaoThay>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BaoThay")]
	public partial class BaoThay : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BaoThayID;
		
		private string _DanhBa;
		
		private System.Nullable<byte> _LoaiBT;
		
		private System.Nullable<System.DateTime> _NgayThay;
		
		private string _HieuMoi;
		
		private System.Nullable<short> _CoMoi;
		
		private string _SoThanMoi;
		
		private string _ViTriMoi;
		
		private string _ChiThanMoi;
		
		private string _ChiCoMoi;
		
		private System.Nullable<int> _CSGo;
		
		private System.Nullable<int> _CSGan;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBaoThayIDChanging(int value);
    partial void OnBaoThayIDChanged();
    partial void OnDanhBaChanging(string value);
    partial void OnDanhBaChanged();
    partial void OnLoaiBTChanging(System.Nullable<byte> value);
    partial void OnLoaiBTChanged();
    partial void OnNgayThayChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayThayChanged();
    partial void OnHieuMoiChanging(string value);
    partial void OnHieuMoiChanged();
    partial void OnCoMoiChanging(System.Nullable<short> value);
    partial void OnCoMoiChanged();
    partial void OnSoThanMoiChanging(string value);
    partial void OnSoThanMoiChanged();
    partial void OnViTriMoiChanging(string value);
    partial void OnViTriMoiChanged();
    partial void OnChiThanMoiChanging(string value);
    partial void OnChiThanMoiChanged();
    partial void OnChiCoMoiChanging(string value);
    partial void OnChiCoMoiChanged();
    partial void OnCSGoChanging(System.Nullable<int> value);
    partial void OnCSGoChanged();
    partial void OnCSGanChanging(System.Nullable<int> value);
    partial void OnCSGanChanged();
    partial void OnNgayCapNhatChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayCapNhatChanged();
    #endregion
		
		public BaoThay()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BaoThayID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BaoThayID
		{
			get
			{
				return this._BaoThayID;
			}
			set
			{
				if ((this._BaoThayID != value))
				{
					this.OnBaoThayIDChanging(value);
					this.SendPropertyChanging();
					this._BaoThayID = value;
					this.SendPropertyChanged("BaoThayID");
					this.OnBaoThayIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DanhBa", DbType="VarChar(50)")]
		public string DanhBa
		{
			get
			{
				return this._DanhBa;
			}
			set
			{
				if ((this._DanhBa != value))
				{
					this.OnDanhBaChanging(value);
					this.SendPropertyChanging();
					this._DanhBa = value;
					this.SendPropertyChanged("DanhBa");
					this.OnDanhBaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoaiBT", DbType="TinyInt")]
		public System.Nullable<byte> LoaiBT
		{
			get
			{
				return this._LoaiBT;
			}
			set
			{
				if ((this._LoaiBT != value))
				{
					this.OnLoaiBTChanging(value);
					this.SendPropertyChanging();
					this._LoaiBT = value;
					this.SendPropertyChanged("LoaiBT");
					this.OnLoaiBTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayThay", DbType="Date")]
		public System.Nullable<System.DateTime> NgayThay
		{
			get
			{
				return this._NgayThay;
			}
			set
			{
				if ((this._NgayThay != value))
				{
					this.OnNgayThayChanging(value);
					this.SendPropertyChanging();
					this._NgayThay = value;
					this.SendPropertyChanged("NgayThay");
					this.OnNgayThayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HieuMoi", DbType="VarChar(50)")]
		public string HieuMoi
		{
			get
			{
				return this._HieuMoi;
			}
			set
			{
				if ((this._HieuMoi != value))
				{
					this.OnHieuMoiChanging(value);
					this.SendPropertyChanging();
					this._HieuMoi = value;
					this.SendPropertyChanged("HieuMoi");
					this.OnHieuMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CoMoi", DbType="SmallInt")]
		public System.Nullable<short> CoMoi
		{
			get
			{
				return this._CoMoi;
			}
			set
			{
				if ((this._CoMoi != value))
				{
					this.OnCoMoiChanging(value);
					this.SendPropertyChanging();
					this._CoMoi = value;
					this.SendPropertyChanged("CoMoi");
					this.OnCoMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoThanMoi", DbType="VarChar(50)")]
		public string SoThanMoi
		{
			get
			{
				return this._SoThanMoi;
			}
			set
			{
				if ((this._SoThanMoi != value))
				{
					this.OnSoThanMoiChanging(value);
					this.SendPropertyChanging();
					this._SoThanMoi = value;
					this.SendPropertyChanged("SoThanMoi");
					this.OnSoThanMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViTriMoi", DbType="VarChar(50)")]
		public string ViTriMoi
		{
			get
			{
				return this._ViTriMoi;
			}
			set
			{
				if ((this._ViTriMoi != value))
				{
					this.OnViTriMoiChanging(value);
					this.SendPropertyChanging();
					this._ViTriMoi = value;
					this.SendPropertyChanged("ViTriMoi");
					this.OnViTriMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChiThanMoi", DbType="VarChar(50)")]
		public string ChiThanMoi
		{
			get
			{
				return this._ChiThanMoi;
			}
			set
			{
				if ((this._ChiThanMoi != value))
				{
					this.OnChiThanMoiChanging(value);
					this.SendPropertyChanging();
					this._ChiThanMoi = value;
					this.SendPropertyChanged("ChiThanMoi");
					this.OnChiThanMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChiCoMoi", DbType="VarChar(50)")]
		public string ChiCoMoi
		{
			get
			{
				return this._ChiCoMoi;
			}
			set
			{
				if ((this._ChiCoMoi != value))
				{
					this.OnChiCoMoiChanging(value);
					this.SendPropertyChanging();
					this._ChiCoMoi = value;
					this.SendPropertyChanged("ChiCoMoi");
					this.OnChiCoMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CSGo", DbType="Int")]
		public System.Nullable<int> CSGo
		{
			get
			{
				return this._CSGo;
			}
			set
			{
				if ((this._CSGo != value))
				{
					this.OnCSGoChanging(value);
					this.SendPropertyChanging();
					this._CSGo = value;
					this.SendPropertyChanged("CSGo");
					this.OnCSGoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CSGan", DbType="Int")]
		public System.Nullable<int> CSGan
		{
			get
			{
				return this._CSGan;
			}
			set
			{
				if ((this._CSGan != value))
				{
					this.OnCSGanChanging(value);
					this.SendPropertyChanging();
					this._CSGan = value;
					this.SendPropertyChanged("CSGan");
					this.OnCSGanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="Date")]
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
					this.OnNgayCapNhatChanging(value);
					this.SendPropertyChanging();
					this._NgayCapNhat = value;
					this.SendPropertyChanged("NgayCapNhat");
					this.OnNgayCapNhatChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
