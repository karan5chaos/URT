using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace xmldatabase.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default => defaultInstance;

	[UserScopedSetting]
	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	public string group
	{
		get
		{
			return (string)this["group"];
		}
		set
		{
			this["group"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("C:/update_tool")]
	[UserScopedSetting]
	public string path
	{
		get
		{
			return (string)this["path"];
		}
		set
		{
			this["path"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	public bool fwflag
	{
		get
		{
			return (bool)this["fwflag"];
		}
		set
		{
			this["fwflag"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public bool emailconfirm
	{
		get
		{
			return (bool)this["emailconfirm"];
		}
		set
		{
			this["emailconfirm"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("WEU")]
	public string region
	{
		get
		{
			return (string)this["region"];
		}
		set
		{
			this["region"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public string lastkey
	{
		get
		{
			return (string)this["lastkey"];
		}
		set
		{
			this["lastkey"] = value;
		}
	}

	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string jirauser
	{
		get
		{
			return (string)this["jirauser"];
		}
		set
		{
			this["jirauser"] = value;
		}
	}

	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string jirapass
	{
		get
		{
			return (string)this["jirapass"];
		}
		set
		{
			this["jirapass"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public bool savesendconfirm
	{
		get
		{
			return (bool)this["savesendconfirm"];
		}
		set
		{
			this["savesendconfirm"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public bool pcache
	{
		get
		{
			return (bool)this["pcache"];
		}
		set
		{
			this["pcache"] = value;
		}
	}

	[DefaultSettingValue("C:/update_tool")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public string varpath
	{
		get
		{
			return (string)this["varpath"];
		}
		set
		{
			this["varpath"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("False")]
	public bool hidei
	{
		get
		{
			return (bool)this["hidei"];
		}
		set
		{
			this["hidei"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("\\\\pmumnetapp-1\\GPO_Production\\XTDL\\Documents\\Update_tool_extras\\Access_file")]
	[DebuggerNonUserCode]
	public string access_man
	{
		get
		{
			return (string)this["access_man"];
		}
		set
		{
			this["access_man"] = value;
		}
	}

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("piprani")]
	public string superadmin => (string)this["superadmin"];

	[UserScopedSetting]
	[DefaultSettingValue("-")]
	[DebuggerNonUserCode]
	public string lastmailpath
	{
		get
		{
			return (string)this["lastmailpath"];
		}
		set
		{
			this["lastmailpath"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("True")]
	[DebuggerNonUserCode]
	public bool set_con
	{
		get
		{
			return (bool)this["set_con"];
		}
		set
		{
			this["set_con"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("C:/update_tool")]
	public string log_path
	{
		get
		{
			return (string)this["log_path"];
		}
		set
		{
			this["log_path"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	[UserScopedSetting]
	public string tempi1
	{
		get
		{
			return (string)this["tempi1"];
		}
		set
		{
			this["tempi1"] = value;
		}
	}

	[DefaultSettingValue("")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public string tempi2
	{
		get
		{
			return (string)this["tempi2"];
		}
		set
		{
			this["tempi2"] = value;
		}
	}

	[DefaultSettingValue("https://mapopsjira.in.here.com")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public string mapops
	{
		get
		{
			return (string)this["mapops"];
		}
		set
		{
			this["mapops"] = value;
		}
	}

	private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
	{
	}

	private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
	{
	}
}
