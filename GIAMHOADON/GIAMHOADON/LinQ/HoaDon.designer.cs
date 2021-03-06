﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIAMHOADON.LinQ
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HoaDon")]
	public partial class HoaDonDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAGB(AGB instance);
    partial void UpdateAGB(AGB instance);
    partial void DeleteAGB(AGB instance);
    partial void InsertHD(HD instance);
    partial void UpdateHD(HD instance);
    partial void DeleteHD(HD instance);
    partial void InsertThucThu(ThucThu instance);
    partial void UpdateThucThu(ThucThu instance);
    partial void DeleteThucThu(ThucThu instance);
    #endregion
		
		public HoaDonDataContext() : 
				base(global::GIAMHOADON.Properties.Settings.Default.HoaDonConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HoaDonDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HoaDonDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HoaDonDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HoaDonDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<AGB> AGBs
		{
			get
			{
				return this.GetTable<AGB>();
			}
		}
		
		public System.Data.Linq.Table<HD> HDs
		{
			get
			{
				return this.GetTable<HD>();
			}
		}
		
		public System.Data.Linq.Table<ThucThu> ThucThus
		{
			get
			{
				return this.GetTable<ThucThu>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AGB")]
	public partial class AGB : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _IDKey;
		
		private System.Nullable<System.DateTime> _Ngaythanhtoan;
		
		private System.Nullable<int> _TThu;
		
		private System.Nullable<double> _TNuoc;
		
		private System.Nullable<double> _TGTGT;
		
		private System.Nullable<double> _PBVMT;
		
		private string _SHDon;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnIDKeyChanging(string value);
    partial void OnIDKeyChanged();
    partial void OnNgaythanhtoanChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaythanhtoanChanged();
    partial void OnTThuChanging(System.Nullable<int> value);
    partial void OnTThuChanged();
    partial void OnTNuocChanging(System.Nullable<double> value);
    partial void OnTNuocChanged();
    partial void OnTGTGTChanging(System.Nullable<double> value);
    partial void OnTGTGTChanged();
    partial void OnPBVMTChanging(System.Nullable<double> value);
    partial void OnPBVMTChanged();
    partial void OnSHDonChanging(string value);
    partial void OnSHDonChanged();
    #endregion
		
		public AGB()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKey", DbType="NVarChar(20)")]
		public string IDKey
		{
			get
			{
				return this._IDKey;
			}
			set
			{
				if ((this._IDKey != value))
				{
					this.OnIDKeyChanging(value);
					this.SendPropertyChanging();
					this._IDKey = value;
					this.SendPropertyChanged("IDKey");
					this.OnIDKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ngaythanhtoan", DbType="DateTime")]
		public System.Nullable<System.DateTime> Ngaythanhtoan
		{
			get
			{
				return this._Ngaythanhtoan;
			}
			set
			{
				if ((this._Ngaythanhtoan != value))
				{
					this.OnNgaythanhtoanChanging(value);
					this.SendPropertyChanging();
					this._Ngaythanhtoan = value;
					this.SendPropertyChanged("Ngaythanhtoan");
					this.OnNgaythanhtoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TThu", DbType="Int")]
		public System.Nullable<int> TThu
		{
			get
			{
				return this._TThu;
			}
			set
			{
				if ((this._TThu != value))
				{
					this.OnTThuChanging(value);
					this.SendPropertyChanging();
					this._TThu = value;
					this.SendPropertyChanged("TThu");
					this.OnTThuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TNuoc", DbType="Float")]
		public System.Nullable<double> TNuoc
		{
			get
			{
				return this._TNuoc;
			}
			set
			{
				if ((this._TNuoc != value))
				{
					this.OnTNuocChanging(value);
					this.SendPropertyChanging();
					this._TNuoc = value;
					this.SendPropertyChanged("TNuoc");
					this.OnTNuocChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TGTGT", DbType="Float")]
		public System.Nullable<double> TGTGT
		{
			get
			{
				return this._TGTGT;
			}
			set
			{
				if ((this._TGTGT != value))
				{
					this.OnTGTGTChanging(value);
					this.SendPropertyChanging();
					this._TGTGT = value;
					this.SendPropertyChanged("TGTGT");
					this.OnTGTGTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PBVMT", DbType="Float")]
		public System.Nullable<double> PBVMT
		{
			get
			{
				return this._PBVMT;
			}
			set
			{
				if ((this._PBVMT != value))
				{
					this.OnPBVMTChanging(value);
					this.SendPropertyChanging();
					this._PBVMT = value;
					this.SendPropertyChanged("PBVMT");
					this.OnPBVMTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SHDon", DbType="NVarChar(50)")]
		public string SHDon
		{
			get
			{
				return this._SHDon;
			}
			set
			{
				if ((this._SHDon != value))
				{
					this.OnSHDonChanging(value);
					this.SendPropertyChanging();
					this._SHDon = value;
					this.SendPropertyChanged("SHDon");
					this.OnSHDonChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HD")]
	public partial class HD : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IDKey;
		
		private string _DBo;
		
		private string _KHang;
		
		private string _DChi1;
		
		private string _DChi2;
		
		private string _GBieu;
		
		private System.Nullable<int> _DMuc;
		
		private System.Nullable<short> _KyHD;
		
		private string _LoaiHD;
		
		private string _NamHD;
		
		private System.Nullable<double> _PBVMT;
		
		private string _SHDon;
		
		private System.Nullable<double> _TGTGT;
		
		private System.Nullable<double> _TNuoc;
		
		private System.Nullable<int> _TThu;
		
		private System.Nullable<System.DateTime> _ngaythanhtoan;
		
		private System.Nullable<bool> _dathanhtoan;
		
		private System.Nullable<short> _dot;
		
		private string _Ma_LT;
		
		private string _MaNH;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDKeyChanging(string value);
    partial void OnIDKeyChanged();
    partial void OnDBoChanging(string value);
    partial void OnDBoChanged();
    partial void OnKHangChanging(string value);
    partial void OnKHangChanged();
    partial void OnDChi1Changing(string value);
    partial void OnDChi1Changed();
    partial void OnDChi2Changing(string value);
    partial void OnDChi2Changed();
    partial void OnGBieuChanging(string value);
    partial void OnGBieuChanged();
    partial void OnDMucChanging(System.Nullable<int> value);
    partial void OnDMucChanged();
    partial void OnKyHDChanging(System.Nullable<short> value);
    partial void OnKyHDChanged();
    partial void OnLoaiHDChanging(string value);
    partial void OnLoaiHDChanged();
    partial void OnNamHDChanging(string value);
    partial void OnNamHDChanged();
    partial void OnPBVMTChanging(System.Nullable<double> value);
    partial void OnPBVMTChanged();
    partial void OnSHDonChanging(string value);
    partial void OnSHDonChanged();
    partial void OnTGTGTChanging(System.Nullable<double> value);
    partial void OnTGTGTChanged();
    partial void OnTNuocChanging(System.Nullable<double> value);
    partial void OnTNuocChanged();
    partial void OnTThuChanging(System.Nullable<int> value);
    partial void OnTThuChanged();
    partial void OnngaythanhtoanChanging(System.Nullable<System.DateTime> value);
    partial void OnngaythanhtoanChanged();
    partial void OndathanhtoanChanging(System.Nullable<bool> value);
    partial void OndathanhtoanChanged();
    partial void OndotChanging(System.Nullable<short> value);
    partial void OndotChanged();
    partial void OnMa_LTChanging(string value);
    partial void OnMa_LTChanged();
    partial void OnMaNHChanging(string value);
    partial void OnMaNHChanged();
    #endregion
		
		public HD()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKey", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDKey
		{
			get
			{
				return this._IDKey;
			}
			set
			{
				if ((this._IDKey != value))
				{
					this.OnIDKeyChanging(value);
					this.SendPropertyChanging();
					this._IDKey = value;
					this.SendPropertyChanged("IDKey");
					this.OnIDKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBo", DbType="NVarChar(50)")]
		public string DBo
		{
			get
			{
				return this._DBo;
			}
			set
			{
				if ((this._DBo != value))
				{
					this.OnDBoChanging(value);
					this.SendPropertyChanging();
					this._DBo = value;
					this.SendPropertyChanged("DBo");
					this.OnDBoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KHang", DbType="NVarChar(255)")]
		public string KHang
		{
			get
			{
				return this._KHang;
			}
			set
			{
				if ((this._KHang != value))
				{
					this.OnKHangChanging(value);
					this.SendPropertyChanging();
					this._KHang = value;
					this.SendPropertyChanged("KHang");
					this.OnKHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DChi1", DbType="NVarChar(255)")]
		public string DChi1
		{
			get
			{
				return this._DChi1;
			}
			set
			{
				if ((this._DChi1 != value))
				{
					this.OnDChi1Changing(value);
					this.SendPropertyChanging();
					this._DChi1 = value;
					this.SendPropertyChanged("DChi1");
					this.OnDChi1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DChi2", DbType="NVarChar(255)")]
		public string DChi2
		{
			get
			{
				return this._DChi2;
			}
			set
			{
				if ((this._DChi2 != value))
				{
					this.OnDChi2Changing(value);
					this.SendPropertyChanging();
					this._DChi2 = value;
					this.SendPropertyChanged("DChi2");
					this.OnDChi2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GBieu", DbType="NVarChar(50)")]
		public string GBieu
		{
			get
			{
				return this._GBieu;
			}
			set
			{
				if ((this._GBieu != value))
				{
					this.OnGBieuChanging(value);
					this.SendPropertyChanging();
					this._GBieu = value;
					this.SendPropertyChanged("GBieu");
					this.OnGBieuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DMuc", DbType="Int")]
		public System.Nullable<int> DMuc
		{
			get
			{
				return this._DMuc;
			}
			set
			{
				if ((this._DMuc != value))
				{
					this.OnDMucChanging(value);
					this.SendPropertyChanging();
					this._DMuc = value;
					this.SendPropertyChanged("DMuc");
					this.OnDMucChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KyHD", DbType="SmallInt")]
		public System.Nullable<short> KyHD
		{
			get
			{
				return this._KyHD;
			}
			set
			{
				if ((this._KyHD != value))
				{
					this.OnKyHDChanging(value);
					this.SendPropertyChanging();
					this._KyHD = value;
					this.SendPropertyChanged("KyHD");
					this.OnKyHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoaiHD", DbType="NVarChar(50)")]
		public string LoaiHD
		{
			get
			{
				return this._LoaiHD;
			}
			set
			{
				if ((this._LoaiHD != value))
				{
					this.OnLoaiHDChanging(value);
					this.SendPropertyChanging();
					this._LoaiHD = value;
					this.SendPropertyChanged("LoaiHD");
					this.OnLoaiHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NamHD", DbType="NVarChar(50)")]
		public string NamHD
		{
			get
			{
				return this._NamHD;
			}
			set
			{
				if ((this._NamHD != value))
				{
					this.OnNamHDChanging(value);
					this.SendPropertyChanging();
					this._NamHD = value;
					this.SendPropertyChanged("NamHD");
					this.OnNamHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PBVMT", DbType="Float")]
		public System.Nullable<double> PBVMT
		{
			get
			{
				return this._PBVMT;
			}
			set
			{
				if ((this._PBVMT != value))
				{
					this.OnPBVMTChanging(value);
					this.SendPropertyChanging();
					this._PBVMT = value;
					this.SendPropertyChanged("PBVMT");
					this.OnPBVMTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SHDon", DbType="NVarChar(50)")]
		public string SHDon
		{
			get
			{
				return this._SHDon;
			}
			set
			{
				if ((this._SHDon != value))
				{
					this.OnSHDonChanging(value);
					this.SendPropertyChanging();
					this._SHDon = value;
					this.SendPropertyChanged("SHDon");
					this.OnSHDonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TGTGT", DbType="Float")]
		public System.Nullable<double> TGTGT
		{
			get
			{
				return this._TGTGT;
			}
			set
			{
				if ((this._TGTGT != value))
				{
					this.OnTGTGTChanging(value);
					this.SendPropertyChanging();
					this._TGTGT = value;
					this.SendPropertyChanged("TGTGT");
					this.OnTGTGTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TNuoc", DbType="Float")]
		public System.Nullable<double> TNuoc
		{
			get
			{
				return this._TNuoc;
			}
			set
			{
				if ((this._TNuoc != value))
				{
					this.OnTNuocChanging(value);
					this.SendPropertyChanging();
					this._TNuoc = value;
					this.SendPropertyChanged("TNuoc");
					this.OnTNuocChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TThu", DbType="Int")]
		public System.Nullable<int> TThu
		{
			get
			{
				return this._TThu;
			}
			set
			{
				if ((this._TThu != value))
				{
					this.OnTThuChanging(value);
					this.SendPropertyChanging();
					this._TThu = value;
					this.SendPropertyChanged("TThu");
					this.OnTThuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaythanhtoan", DbType="DateTime")]
		public System.Nullable<System.DateTime> ngaythanhtoan
		{
			get
			{
				return this._ngaythanhtoan;
			}
			set
			{
				if ((this._ngaythanhtoan != value))
				{
					this.OnngaythanhtoanChanging(value);
					this.SendPropertyChanging();
					this._ngaythanhtoan = value;
					this.SendPropertyChanged("ngaythanhtoan");
					this.OnngaythanhtoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dathanhtoan", DbType="Bit")]
		public System.Nullable<bool> dathanhtoan
		{
			get
			{
				return this._dathanhtoan;
			}
			set
			{
				if ((this._dathanhtoan != value))
				{
					this.OndathanhtoanChanging(value);
					this.SendPropertyChanging();
					this._dathanhtoan = value;
					this.SendPropertyChanged("dathanhtoan");
					this.OndathanhtoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dot", DbType="SmallInt")]
		public System.Nullable<short> dot
		{
			get
			{
				return this._dot;
			}
			set
			{
				if ((this._dot != value))
				{
					this.OndotChanging(value);
					this.SendPropertyChanging();
					this._dot = value;
					this.SendPropertyChanged("dot");
					this.OndotChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ma_LT", DbType="NVarChar(20)")]
		public string Ma_LT
		{
			get
			{
				return this._Ma_LT;
			}
			set
			{
				if ((this._Ma_LT != value))
				{
					this.OnMa_LTChanging(value);
					this.SendPropertyChanging();
					this._Ma_LT = value;
					this.SendPropertyChanged("Ma_LT");
					this.OnMa_LTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNH", DbType="NVarChar(5)")]
		public string MaNH
		{
			get
			{
				return this._MaNH;
			}
			set
			{
				if ((this._MaNH != value))
				{
					this.OnMaNHChanging(value);
					this.SendPropertyChanging();
					this._MaNH = value;
					this.SendPropertyChanged("MaNH");
					this.OnMaNHChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ThucThu")]
	public partial class ThucThu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IDKey;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDKeyChanging(string value);
    partial void OnIDKeyChanged();
    #endregion
		
		public ThucThu()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKey", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDKey
		{
			get
			{
				return this._IDKey;
			}
			set
			{
				if ((this._IDKey != value))
				{
					this.OnIDKeyChanging(value);
					this.SendPropertyChanging();
					this._IDKey = value;
					this.SendPropertyChanged("IDKey");
					this.OnIDKeyChanged();
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
