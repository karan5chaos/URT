using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace xmldatabase;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		string embeddedResource = "xmldatabase.Resources.Jira.SDK.dll";
		string embeddedResource2 = "xmldatabase.Resources.MsgReader.dll";
		string embeddedResource3 = "xmldatabase.Resources.Newtonsoft.Json.dll";
		string embeddedResource4 = "xmldatabase.Resources.RestSharp.dll";
		EmbeddedAssembly.Load(embeddedResource, "Jira.SDK.dll");
		EmbeddedAssembly.Load(embeddedResource2, "MsgReader.dll");
		EmbeddedAssembly.Load(embeddedResource3, "Newtonsoft.Json.dll");
		EmbeddedAssembly.Load(embeddedResource4, "RestSharp.dll");
		AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		bool createdNew;
		Mutex mutex = new Mutex(initiallyOwned: true, "Update Repo Tool", out createdNew);
		if (createdNew)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new Form1());
		}
	}

	private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
	{
		return EmbeddedAssembly.Get(args.Name);
	}
}
