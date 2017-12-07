using Model;
using Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (StoreAccountingContext context = new StoreAccountingContext())
            //{
            //    ManagerInfo mInfo = new ManagerInfo();
            //    mInfo.FirstName = "Vladislav";
            //    mInfo.LastName = "Dirsha";

            //    Parser parser = new Parser();
            //    IList<string> test = parser.ParserCSV("D:\\test.csv");
            //    foreach (var item in test)
            //    {
            //        Sale nSale = new Sale();
            //        string[] tmp = item.Split(';');
            //        nSale.Client = tmp[1];
            //        nSale.Date = DateTime.Parse(tmp[0]);
            //        nSale.Manager = mInfo;
            //        nSale.Price = Double.Parse(tmp[3]);
            //        nSale.Product = tmp[2];
            //        context.Sales.Add(nSale);
            //    }

            //    context.Managers.Add(mInfo);
            //    context.SaveChanges();
            //}
            Console.WriteLine(System.IO.Path.GetExtension("D:\\Task4\\testHello.csv"));


        }
    }
}
