using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorService.Parser
{
    class Watcher
    {
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Watcher()
        {
            watcher = new FileSystemWatcher("D:\\Task4");
            watcher.Created += Watcher_Created;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Parser parser = new Parser();
            string fileEvent = "создан";
            string filePath = e.FullPath;
            if (Path.GetExtension(filePath) == ".csv")
            {
                foreach(var item in parser.ParserCSV(filePath))
                {
                    RecordEntry(fileEvent, item);
                }
                
            }
           
            
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("D:\\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
    }
}
