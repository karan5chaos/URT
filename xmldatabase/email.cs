using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace xmldatabase;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
[CompilerGenerated]
internal sealed class email : ApplicationSettingsBase
{
	private static email defaultInstance = (email)SettingsBase.Synchronized(new email());

	public static email Default => defaultInstance;

	[UserScopedSetting]
	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	public string to
	{
		get
		{
			return (string)this["to"];
		}
		set
		{
			this["to"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	public string cc
	{
		get
		{
			return (string)this["cc"];
		}
		set
		{
			this["cc"] = value;
		}
	}

	[DefaultSettingValue("")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public string message
	{
		get
		{
			return (string)this["message"];
		}
		set
		{
			this["message"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	public string subject
	{
		get
		{
			return (string)this["subject"];
		}
		set
		{
			this["subject"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public bool attachments
	{
		get
		{
			return (bool)this["attachments"];
		}
		set
		{
			this["attachments"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool readr
	{
		get
		{
			return (bool)this["readr"];
		}
		set
		{
			this["readr"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	public bool sendconfirm
	{
		get
		{
			return (bool)this["sendconfirm"];
		}
		set
		{
			this["sendconfirm"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool sendsave
	{
		get
		{
			return (bool)this["sendsave"];
		}
		set
		{
			this["sendsave"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public bool priority
	{
		get
		{
			return (bool)this["priority"];
		}
		set
		{
			this["priority"] = value;
		}
	}
}
