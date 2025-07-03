using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Framework
{
    public class FileWriterAppender
    {
        //文件地址
        private string _filePath;
        private object _lock = new();
        
        public FileWriterAppender(string folderPath,string file,int maxFileCount)
        {
            _filePath = Path.Combine(folderPath, file);/*   filePath;*/
            int existLogCount = 0;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                //删除最老的文件
                var files = Directory.GetFiles(folderPath);
                existLogCount = files.Length;
                if (existLogCount >= maxFileCount)
                {
                    IEnumerable<FileInfo> fileInfos = FileHelper.GetNOldestFiles(folderPath,existLogCount - maxFileCount + 1);
                    foreach (var fileInfo in fileInfos)
                    {
                        fileInfo.Delete();
                    }
                }
            }
        }
        
        
        
        
        
        
        //写入文件
        public void WriteLine(Logger logger, LogLevel logLevel, string message)
        {
            lock (_lock)
            {
                using var writer = new StreamWriter(_filePath, true); //拼接模式
                writer.WriteLine(message);
            }
        }
        
        //擦除文件
        public void ClearFile()
        {
            lock (_lock)
            {
                using var writer = new StreamWriter(_filePath, false);//重写模式
                writer.WriteLine(string.Empty);
            }
        }
    }


    public class FileHelper
    {

        public static IEnumerable<FileInfo> GetNOldestFiles(string path,int n)
        {
            if (Directory.Exists(path))
            {
                var oldestFiles = Directory.GetFiles(path)
                    .Select(file => new FileInfo(file))
                    .OrderBy(fileInfo => fileInfo.CreationTime)
                    .Take(n);
                return oldestFiles;
            }
            else
            {
                MyLog.Warning("目录不存在");
                return null;
            }
        }
        
        
    }
}