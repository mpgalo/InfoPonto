﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INFOPonto.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")]
        public string smtp {
            get {
                return ((string)(this["smtp"]));
            }
            set {
                this["smtp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("infotimewebmail@gmail.com")]
        public string loginSmtp {
            get {
                return ((string)(this["loginSmtp"]));
            }
            set {
                this["loginSmtp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("21038888")]
        public string senhaSmtp {
            get {
                return ((string)(this["senhaSmtp"]));
            }
            set {
                this["senhaSmtp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("infotimewebmail@gmail.com")]
        public string email {
            get {
                return ((string)(this["email"]));
            }
            set {
                this["email"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int porta {
            get {
                return ((int)(this["porta"]));
            }
            set {
                this["porta"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enableSsl {
            get {
                return ((bool)(this["enableSsl"]));
            }
            set {
                this["enableSsl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("infoponto")]
        public string rptLogin {
            get {
                return ((string)(this["rptLogin"]));
            }
            set {
                this["rptLogin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("649731")]
        public string rptPwd {
            get {
                return ((string)(this["rptPwd"]));
            }
            set {
                this["rptPwd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\server-dados\\SISTEMAS\\INFOPONTO\\ArquivosRecado")]
        public string pastaArquivosServidor {
            get {
                return ((string)(this["pastaArquivosServidor"]));
            }
            set {
                this["pastaArquivosServidor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\servidor\\Sistemas\\InfoPonto\\Administrativo\\Rpt\\")]
        public string rptCaminhoAdministrativo {
            get {
                return ((string)(this["rptCaminhoAdministrativo"]));
            }
            set {
                this["rptCaminhoAdministrativo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SERVER-DADOS;Initial Catalog=InfoPonto;uid=infoponto;pwd=649731;TimeO" +
            "ut=0;")]
        public string connectionstring {
            get {
                return ((string)(this["connectionstring"]));
            }
            set {
                this["connectionstring"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("InfoPonto")]
        public string redeLogin {
            get {
                return ((string)(this["redeLogin"]));
            }
            set {
                this["redeLogin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("649731")]
        public string redeSenha {
            get {
                return ((string)(this["redeSenha"]));
            }
            set {
                this["redeSenha"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\server-dados")]
        public string servidorArquivos {
            get {
                return ((string)(this["servidorArquivos"]));
            }
            set {
                this["servidorArquivos"] = value;
            }
        }
    }
}