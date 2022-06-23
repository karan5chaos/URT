using System.Reflection;
using System.Windows.Forms;

namespace xmldatabase;

public static class ControlExtensions
{
	public static void DoubleBuffered(this Control control, bool enable)
	{
		PropertyInfo property = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		property.SetValue(control, enable, null);
	}
}
