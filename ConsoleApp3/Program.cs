using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PresentationLayer.ViewModels;
using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;

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

        private static SaleViewModel parseLine(string line, string name)
        {
            var temp = line.Split(';');
            return new SaleViewModel(name, DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]));
        }

        //private static void SendTask(IBridgeToBLL bl, SaleViewModel model)
        //{
        //    bl.SendSaleInfo(model);
        //}


        static void Main(string[] args)
        {
            IBridgeToBLL test = new BridgeToBLL();

           

            //Task task = new Task(action);

            string SName = Path.GetFileNameWithoutExtension("D:\\Task4\\testHello.csv");
            foreach (var item in ParserCSV("D:\\Task4\\testHello.csv"))
            {
                test.SendSaleInfo(parseLine(item, SName));
            }
            //foreach (var item in ParserCSV("D:\\Task4\\test.csv"))
            //{
            //    test.SendSaleInfo(parseLine(item, SName));
            //}
            //string str1 = null;
            //string str2 = null;
            //string str3 = null;
            //Task[] tasks = new Task[3];

            ////tasks[0] = Task.Factory.StartNew(() => ShowMessage("Task1 is executed" +  tasks[0].Id));

            ////tasks[1] = Task.Factory.StartNew(() => ShowMessage ("Task2 is executed" + tasks[1].Id));

            ////tasks[2] = Task.Factory.StartNew(() => ShowMessage("Task3 is executed" + tasks[2].Id));

            //tasks[0] = Task.Run(() => ShowMessage("Task1 is executed" + tasks[0].Id));

            //tasks[1] = Task.Run(() => ShowMessage("Task2 is executed" + tasks[1].Id));

            //tasks[2] = Task.Run(() => ShowMessage("Task3 is executed" + tasks[2].Id));


            ////Task.Factory.ContinueWhenAll(tasks, completedTasks =>
            ////{
            ////    Console.WriteLine("Executed");
            ////});

            //Console.ReadLine();



        }

        public static void ShowMessage(string str)
        {
            Console.WriteLine(str);
        }
    }
}
