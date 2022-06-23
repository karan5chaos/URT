using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace xmldatabase;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
internal sealed class backup : ApplicationSettingsBase
{
	private static backup defaultInstance = (backup)SettingsBase.Synchronized(new backup());

	public static backup Default => defaultInstance;

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("c:/temp")]
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

	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public bool autobak
	{
		get
		{
			return (bool)this["autobak"];
		}
		set
		{
			this["autobak"] = value;
		}
	}

	[DefaultSettingValue("0")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public int trigger
	{
		get
		{
			return (int)this["trigger"];
		}
		set
		{
			this["trigger"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool flag
	{
		get
		{
			return (bool)this["flag"];
		}
		set
		{
			this["flag"] = value;
		}
	}
}
