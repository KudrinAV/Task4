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
            string[] tmp = Path.GetFileNameWithoutExtension(e.FullPath).Split('_');
            Console.WriteLine("Checking File" + tmp[0] + "_" + tmp[1]);
            if (bridge.CheckManager(tmp[0]))
            {
                bridge.SendReport(new ReportViewModel(tmp[0], DateTime.Parse(tmp[1])));
                SendInfoToBLL(e, bridge);
            }
            else { bridge.SendManagerInfo(new ManagerViewModel(tmp[0])); }
        }
        
        private void SendInfoToBLL(FileSystemEventArgs e, IBridgeToBLL bridge)
        {
            string filePath = e.FullPath;
            Parser parser = new Parser();
            //string SName = Path.GetFileNameWithoutExtension(filePath);
            foreach (var item in parser.ParserCSV(filePath))
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
