using Prosperity.WinPhone;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Prosperity.WinPhone
{
    public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
		}
	}
}
