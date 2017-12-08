using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.ViewModels;
using BLL.Interfaces;
using BLL.Bridges;
using BLL.DTO;

namespace PresentationLayer.Bridge
{
    public class BridgeToBLL : IBridgeToBLL
    {
        IBridgeToModel _dbConnect;

        public BridgeToBLL()
        {
            _dbConnect = new BridgeToModel();
            AutoMapper.Mapper.Initialize(c => c.CreateMap<SaleViewModel, SaleDTO>());
        }

        public void AddSale(SaleViewModel sale)
        {
            throw new NotImplementedException();
        }

        public void AddSales(ICollection<SaleViewModel> sales)
        {
            throw new NotImplementedException();
        }

        public void CheckManager(ManagerViewModel manager)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
