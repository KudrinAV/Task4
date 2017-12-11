using BLL.Parser;
using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Watcher watcher = new Watcher();
            watcher.Start();
            Console.ReadKey();
        }
    }
}
