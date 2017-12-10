using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Model.Interfaces;
using Model.DataModel;
using Model.DALElements;
using AutoMapper;

namespace BLL.Bridges
{
    public class BridgeToModel : IBridgeToModel
    {
        private IUnitOfWork _db;

        //MapperConfiguration config = new MapperConfiguration(cfg =>
        //{
        //    cfg.CreateMap<SaleDTO, Sale>();
        //});

        //public BridgeToModel(IUnitOfWork unitOfWork)
        //{
        //    _db = unitOfWork;
        //}

        public BridgeToModel()
        {
            _db = new EFUnitOfWork();

        }

        public void AddSale(SaleDTO sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleDTO, Sale>();
            });
            IMapper mapper = config.CreateMapper();
            _db.Sales.Create(mapper.Map<SaleDTO, Sale>(sale));
            _db.Save();
        }

        public void AddSales(ICollection<SaleDTO> sales)
        {
            throw new NotImplementedException();
        }

        public void CheckManager(ManagerDTO manager)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //AutoMapper.Mapper.Map<SaleDTO, Sale>.Dispose();
            _db.Dispose();
        }
    }
}
