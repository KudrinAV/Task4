using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface IBridgeToBLL
    {
        void AddSale(SaleViewModel sale);
        void AddSales(ICollection<SaleViewModel> sales);
        void CheckManager(ManagerViewModel manager);
        void Dispose();
    }
}
