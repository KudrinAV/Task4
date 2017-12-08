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
    class Watcher
    {
        IBridgeToBLL bridge;
        private CancellationTokenSource tokenSource;
        private ICollection<Task> tasks;
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;

        public Watcher()
        {
            watcher = new FileSystemWatcher("D:\\Task4");
            watcher.Created += Watcher_Created;
            tasks = new List<Task>();
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
            //tokenSource = new CancellationTokenSource();
            //var cancellation = tokenSource.Token;
            var task = Task.Run(() => SendInfoToBLL(e));
            //tasks.Add(task);
            
        }
        
        private void SendInfoToBLL(FileSystemEventArgs e)
        {
            bridge = new BridgeToBLL();
            Parser parser = new Parser();
            string filePath = e.FullPath;
            if (Path.GetExtension(filePath) == ".csv")
            {
                string SName = Path.GetFileNameWithoutExtension(filePath);
                foreach (var item in parser.ParserCSV(filePath))
                {
                    bridge.SendSaleInfo(parseLine(item, SName));
                }
            }
            bridge.Dispose();
        }

        private SaleViewModel parseLine(string line, string name)
        {
            var temp = line.Split(';');
            return new SaleViewModel(name, DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]));
        }
    }
}
