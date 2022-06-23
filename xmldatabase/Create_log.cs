using System;
using System.IO;
using xmldatabase.Properties;

namespace xmldatabase;

internal class Create_log
{
	public void create_l(string msg, string errmsg)
	{
		if (!File.Exists(xmldatabase.Properties.Settings.Default.log_path + "/log.txt"))
		{
			File.Create(xmldatabase.Properties.Settings.Default.log_path + "/log.txt");
		}
		File.AppendAllText(xmldatabase.Properties.Settings.Default.log_path, "user :" + Environment.UserName + "\ntime" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\nactivity" + msg + "\nerror:" + errmsg + "." + Environment.NewLine);
	}
}
