using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PresentationLayer.ViewModels;
using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using System.Threading;
using AutoMapper;

namespace ConsoleApp3
{

    class Program
    {

        public static IList<string> ParserCSV(string path)
        {
            IList<string> resultList = new List<string>();
            string line;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    resultList.Add(line);
                }
            }
            return resultList;
        }

        public static SaleViewModel parseLine(string line, string name)
        {
            var temp = line.Split(';');
            return new SaleViewModel(name, DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]));
        }

        public static async void addTODB(IList<string> list, string path)
        {
            IBridgeToBLL con = new BridgeToBLL();
            string name = Path.GetFileNameWithoutExtension(path);
            foreach (var item in list)
            {
                await Task.Run(()=> con.SendSaleInfo(parseLine(item, name)));
                Console.WriteLine("hello" + DateTime.Now.ToString() +  " " + Task.CurrentId.ToString());
            }
            con.Dispose();
            //test.Dispose();

        }

        
        private static void method(string path)
        {
            Task.Factory.StartNew(() => Task.Factory.StartNew(() => addTODB(ParserCSV(path), path)));
        }

        static void Main(string[] args)
        {
            string path1 = "D:\\Task4\\test.csv";
            string path2 = "D:\\Task4\\testHello.csv";
            method(path1);
            method(path2);



            Console.ReadLine();



        }

        public static void ShowMessage(string str)
        {
            Console.WriteLine(str);
        }
    }
}
