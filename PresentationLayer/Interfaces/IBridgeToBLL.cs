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
        void SendSaleInfo(SaleViewModel sale);
        void SendSalesInfo(ICollection<SaleViewModel> sales);
        bool CheckManager(string managerLastName);
        void Dispose();
    }
}
