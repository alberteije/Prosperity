using Prosperity.UWP;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using System.Collections.Generic;

[assembly: Dependency(typeof(FileHelper))]
namespace Prosperity.UWP
{
    public class FileHelper : IFileHelper
	{
        public void Delete(string filename)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string filename)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetFiles()
        {
            throw new System.NotImplementedException();
        }

        public string GetLocalFilePath(string filename)
		{
			return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
		}

        public string ReadText(string filename)
        {
            throw new System.NotImplementedException();
        }

        public void WriteText(string filename, string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
