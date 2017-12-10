using MonitorService.Parser;
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
            //IBridgeToBLL bridge = new BridgeToBLL();
            //bridge.SendSaleInfo(new PresentationLayer.ViewModels.SaleViewModel( DateTime.Now, "test", "test", 13.5));
            //bridge.Dispose();
            Watcher watcher = new Watcher();
            watcher.Start();
            Console.ReadKey();
        }
    }
}
