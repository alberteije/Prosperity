using Prosperity.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Prosperity.Droid
{
    public class FileHelper : IFileHelper
	{
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }


        public void Delete(string filename)
        {
            File.Delete(GetFilePath(filename));
        }

        public bool Exists(string filename)
        {
            string filepath = GetFilePath(filename);
            return File.Exists(filepath);
        }

        public IEnumerable<string> GetFiles()
        {
            return Directory.GetFiles(GetDocsPath());
        }

        public string ReadText(string filename)
        {
            string filepath = GetFilePath(filename);
            return File.ReadAllText(filepath);
        }

        public void WriteText(string filename, string text)
        {
            string filepath = GetFilePath(filename);
            File.WriteAllText(filepath, text);
        }

        // Private methods.
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }
        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    
    }
}
