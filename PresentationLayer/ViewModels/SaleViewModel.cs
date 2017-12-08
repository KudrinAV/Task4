using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class SaleViewModel
    {
        public string ManagerName { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }

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
