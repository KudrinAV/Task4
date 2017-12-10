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
        FileSystemWatcher watcher;
        event EventHandler<FileSystemEventArgs> Created;
        
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
            Task.Run(() => SendInfoToBLL(e));
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
    }
}
