using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class SaleViewModel
    {
        public string ManagerName { get; private set; }
        public DateTime Date { get; private set; }
        public string Client { get; private set; }
        public string Product { get; private set; }
        public double Price { get; private set; }

        public SaleViewModel(string name, DateTime time, string client, string product, double price)
        {
            ManagerName = name;
            Date = time;
            Client = client;
            Product = product;
            Price = price;
        }
    }
}
