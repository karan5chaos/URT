using System.IO;

namespace xmldatabase;

internal class GetDirectorySizes
{
	public long GetDirectorySize(string p)
	{
		string[] files = Directory.GetFiles(p, "*.*");
		long num = 0L;
		string[] array = files;
		foreach (string fileName in array)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			num += fileInfo.Length;
		}
		return num;
	}
}
