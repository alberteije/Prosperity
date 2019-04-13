using System.Collections.Generic;

namespace Prosperity
{
	public interface IFileHelper
	{
        //arquivo do banco de dados
        string GetLocalFilePath(string filename);

        //demais arquivos
        bool Exists(string filename);
        void WriteText(string filename, string text);
        string ReadText(string filename);
        IEnumerable<string> GetFiles();
        void Delete(string filename);
    }
}
