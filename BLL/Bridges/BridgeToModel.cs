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

namespace BLL.Bridges
{
    public class BridgeToModel : IBridgeToModel
    {
        private IUnitOfWork _db;

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
            AutoMapper.Mapper.Initialize(c => c.CreateMap< SaleDTO, Sale > ());
            _db.Sales.Create(AutoMapper.Mapper.Map<SaleDTO, Sale>(sale));
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
            _db.Dispose();
        }
    }
}
