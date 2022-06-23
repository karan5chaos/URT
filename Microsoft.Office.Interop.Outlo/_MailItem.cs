using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Outlook;

[ComImport]
[CompilerGenerated]
[TypeIdentifier]
[Guid("00063034-0000-0000-C000-000000000046")]
public interface _MailItem
{
	Attachments Attachments
	{
		[DispId(63509)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	string Body
	{
		[DispId(37120)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[DispId(37120)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	OlImportance Importance
	{
		[DispId(23)]
		get;
		[DispId(23)]
		[param: In]
		set;
	}

	string Subject
	{
		[DispId(55)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[DispId(55)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	string CC
	{
		[DispId(3587)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[DispId(3587)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	bool ReadReceiptRequested
	{
		[DispId(41)]
		get;
		[DispId(41)]
		[param: In]
		set;
	}

	Recipients Recipients
	{
		[DispId(63508)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	string To
	{
		[DispId(3588)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[DispId(3588)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	void _VtblGap1_5();

	void _VtblGap2_2();

	void _VtblGap3_10();

	void _VtblGap4_14();

	void _VtblGap5_6();

	[DispId(61606)]
	void Display([Optional][In][MarshalAs(UnmanagedType.Struct)] object Modal);

	void _VtblGap6_10();

	void _VtblGap7_16();

	void _VtblGap8_7();

	void _VtblGap9_22();

	void _VtblGap10_8();

	[DispId(61557)]
	void Send();
}
