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
using AutoMapper;

namespace PresentationLayer.Bridge
{
    public class BridgeToBLL : IBridgeToBLL
    {
        IBridgeToModel _dbConnect;

        public BridgeToBLL()
        {
            _dbConnect = new BridgeToModel();
            //AutoMapper.Mapper.Initialize(c => c.CreateMap<SaleViewModel, SaleDTO>());
        }

        public void SendSaleInfo(SaleViewModel sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleViewModel, SaleDTO>();
            });
            IMapper mapper = config.CreateMapper();
            _dbConnect.AddSale(mapper.Map<SaleViewModel, SaleDTO>(sale));
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
            _dbConnect.Dispose();
        }
    }
}
