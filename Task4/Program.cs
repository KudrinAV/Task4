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
            using (StoreAccountingContext context =  new StoreAccountingContext())
            {
                ManagerInfo mInfo = new ManagerInfo();
                mInfo.FirstName = "Dmitry";
                mInfo.LastName = "Dirsha";
                Sale nSale = new Sale();
                nSale.Client = "Artem";
                nSale.Date = DateTime.Now;
                nSale.Manager = mInfo;
                nSale.Price = 10.35;
                nSale.Product = "Book";

                context.Managers.Add(mInfo);
                context.Sales.Add(nSale);
                context.SaveChanges();
            }
        }
    }
}
