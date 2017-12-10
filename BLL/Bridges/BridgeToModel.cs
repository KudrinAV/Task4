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
using Model.Entities;

namespace BLL.Bridges
{
    public class BridgeToModel : IBridgeToModel
    {
        private IUnitOfWork _db;

        public BridgeToModel()
        {
            _db = new EFUnitOfWork();

        }

        public void AddReport(ReportDTO report)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportDTO, Report>();
            });
            IMapper mapper = config.CreateMapper();
            _db.Reports.Create(mapper.Map<ReportDTO, Report>(report));
            _db.Save();
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
            foreach(var item in sales)
            {
                AddSale(item);
            }
        }

        public bool CheckManager(string managerLastName)
        {
            if (_db.Managers.Get(x => x.LastName == managerLastName) != null) { return true; }
            else return false;
        }

        public void Dispose()
        {
            //AutoMapper.Mapper.Map<SaleDTO, Sale>.Dispose();
            _db.Dispose();
        }
    }
}
