﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAPNUOCTANHOA.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\TANHOA.mdb")]
        public string TANHOAConnectionString {
            get {
                return ((string)(this["TANHOAConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\KHKT\\TC_HeQLHS-XP2000.mdb;Persist" +
            " Security Info=True;Jet OLEDB:Database Password=25874")]
        public string AccessFile {
            get {
                return ((string)(this["AccessFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\KHKT\\QLHSMAIN.mdb")]
        public string AccessFile2 {
            get {
                return ((string)(this["AccessFile2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SERVERG8-01\\SERVER2008;Initial Catalog=TANHOAGIS;Persist Security Inf" +
            "o=True;User ID=sa;Password=123@tanhoa")]
        public string TANHOAGISConnectionString {
            get {
                return ((string)(this["TANHOAGISConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SERVER9;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID" +
            "=sa;Password=123@tanhoa")]
        public string KTKS_DonKHConnectionString {
            get {
                return ((string)(this["KTKS_DonKHConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SERVER9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=" +
            "sa;Password=123@tanhoa")]
        public string HOADON_TAConnectionString {
            get {
                return ((string)(this["HOADON_TAConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=HP_G7\\KD;Initial Catalog=CAPNUOCTANHOA;Persist Security Info=True;Use" +
            "r ID=sa;Password=123@tanhoa")]
        public string CAPNUOCTANHOAConnectionString {
            get {
                return ((string)(this["CAPNUOCTANHOAConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=HP_G7\\KD;Initial Catalog=DocSoTH;Persist Security Info=True;User ID=s" +
            "a;Password=123@tanhoa")]
        public string DocSoTHConnectionString {
            get {
                return ((string)(this["DocSoTHConnectionString"]));
            }
        }
    }
}
