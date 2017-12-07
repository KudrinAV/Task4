using Model;
using Model.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static Sale parseLine(string line, string name)
        {
            var temp = line.Split(';');
            Sale n = new Sale();
            n.ManagerName = name;
            n.Date = DateTime.Parse(temp[0]);
            n.Client = temp[1];
            n.Product = temp[2];
            n.Price = Double.Parse(temp[3]);
            return n;
        }

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


        public static void Main(string[] args)
        {
            //string filePath = "D:\testHello.csv";
            using (StoreAccountingContext db = new StoreAccountingContext())
            {
                
                //string SName = Path.GetFileNameWithoutExtension(filePath);
                foreach (var item in ParserCSV("D:\\test.csv"))
                {
                    db.Sales.Add(parseLine(item, "Hero"));
                }
                db.SaveChanges();
            }
        }
    }
}
