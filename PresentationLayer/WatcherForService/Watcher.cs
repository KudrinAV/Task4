using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        object obj = new object();
        bool enabled = true;

        public Watcher()
        {
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
            Console.WriteLine("What do we have there? New TASK!");
            taskFactory.StartNew(()=>CheckFile(e));
        }

        private void CheckFile(FileSystemEventArgs e)
        {
            IBridgeToBLL bridge = new BridgeToBLL();
            string fileName = Path.GetFileNameWithoutExtension(e.FullPath);
            string[] tmp = fileName.Split('_');
            string pattern = "ddMMyyyy";
            if (bridge.CheckManager(tmp[0]))
            {
                DateTime parsedDate = DateTime.ParseExact(tmp[1], pattern, null);
                Console.WriteLine("hello");
                int? id = bridge.GetManagerId(tmp[0]);
                bridge.SendReport(new ReportViewModel(fileName, parsedDate, (int)id));
                SendInfoToBLL(e.FullPath, bridge, (int)id);
            }
            else
            {
                bridge.SendManagerInfo(new ManagerViewModel(tmp[0]));
            }
        }
        
        private void SendInfoToBLL(string path, IBridgeToBLL bridge, int id)
        {
            Parser parser = new Parser();
            foreach (var item in parser.ParserCSV(path, id))
            {
                bridge.SendSaleInfo(item);
            }
            Console.WriteLine("Added to db");
            bridge.Dispose();
        }

        private void RecordEntry(string fileEvent, string filePath, FileSystemEventArgs e)
        {
            //lock (obj)
            //{
            //    //taskFactory.StartNew(() => SendInfoToBLL(e));
            //    using (StreamWriter writer = new StreamWriter("D:\\templog.txt", true))
            //    {
            //        writer.WriteLine(String.Format("{0} файл {1} был {2}",
            //            DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
            //        writer.Flush();
            //    }
            //}
        }
    }
}
