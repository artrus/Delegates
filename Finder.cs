using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Finder
    {
        public delegate void EventHandler(string message);
        public event EventHandler? FileFound;
        public event EventHandler? FinderEnd;

        public delegate bool CancelHandler(int i);
        public event CancelHandler? Cancel;

        public void MaxSizeFileFind(string path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if (dir.Exists)
                {
                    int i = 0;  //для проверки события остановки поиска
                    foreach (FileInfo fileArgs in dir.GetFiles())
                    {
                        FileFound?.Invoke($"File: {fileArgs.Name}   Size={fileArgs.Length}");       //событие с передачей информации о найденом файле

                        if (Cancel.Invoke(i))   //событие остановки поиска
                            break;

                        Thread.Sleep(1000);
                        i++;   //для проверки события остановки поиска
                    }

                    var maxSizeFile = dir.GetFiles().ToList().GetMax<FileInfo>(Converters.ConvertToFileSize);
                    FinderEnd?.Invoke($"\n\rFile {maxSizeFile.FullName} is bigest. Size={maxSizeFile.Length}");     //событие с передачей результата поиска
                }
            }
        }
    }
}
