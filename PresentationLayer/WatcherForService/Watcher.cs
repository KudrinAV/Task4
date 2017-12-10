using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorService.Parser
{
    public class Watcher
    {
        FileSystemWatcher watcher;
        TaskFactory taskFactory;
        
        public void OnCretaed(FileSystemEventArgs e)
        {

        }

        object obj = new object();
        bool enabled = true;
        Parser parser;

        public Watcher()
        {
            parser = new Parser();
            watcher = new FileSystemWatcher("D:\\Task4" , "*csv");
            watcher.Created += Watcher_Created;
            taskFactory = new TaskFactory();
            

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

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath , e);
        }
        
        private async void SendInfoToBLL(FileSystemEventArgs e)
        {
            IBridgeToBLL bridge = new BridgeToBLL();
            string filePath = e.FullPath;
            string SName = Path.GetFileNameWithoutExtension(filePath);
            foreach (var item in parser.ParserCSV(filePath))
            {
                await Task.Run(()=>bridge.SendSaleInfo(item));
            }
            bridge.Dispose();
        }

        private void RecordEntry(string fileEvent, string filePath, FileSystemEventArgs e)
        {
            lock (obj)
            {
                taskFactory.StartNew(() => SendInfoToBLL(e));
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
