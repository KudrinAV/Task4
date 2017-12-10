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

        public void AddManager(ManagerDTO manager)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerDTO, Manager>();
            });
            IMapper mapper = config.CreateMapper();
            _db.Managers.Create(mapper.Map<ManagerDTO, Manager>(manager));
            _db.Save();
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

        public int CheckManager(string managerLastName)
        {
            Manager manager = _db.Managers.Get(x => x.LastName == managerLastName).First();
            if (manager!=null) { return manager.ManagerID; }
            else return 0;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
