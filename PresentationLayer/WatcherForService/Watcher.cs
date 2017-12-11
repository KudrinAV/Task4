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

namespace BLL.Parser
{
    public class Watcher
    {
        FileSystemWatcher watcher;
        TaskFactory taskFactory;

        object obj = new object();
        bool enabled = true;

        public Watcher()
        {
            watcher = new FileSystemWatcher("D:\\Task4", "*csv");
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
            IBridgeToBLL bridge = new BridgeToBLL();
            taskFactory.StartNew(() => { bridge.CheckFile(e);
            bridge.Dispose();
            });
        }
    }
}
