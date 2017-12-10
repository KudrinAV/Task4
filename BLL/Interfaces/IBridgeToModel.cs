using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBridgeToModel
    {
        void AddSale(SaleDTO sale);
        void AddSales(ICollection<SaleDTO> sales);
        bool CheckManager(string managerLastName);
        void Dispose();
    }
}
