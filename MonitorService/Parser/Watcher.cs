using BLL.Bridges;
using BLL.Interfaces;
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
        IBridgeToModel bridge;
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;

        public Watcher()
        {
            bridge = new BridgeToModel();
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

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Parser parser = new Parser();
            string filePath = e.FullPath;
            if (Path.GetExtension(filePath) == ".csv")
            {
                foreach(var item in parser.ParserCSV(filePath))
                {
                    //bridge
                }
                
            }
           
            
        }
    }
}
