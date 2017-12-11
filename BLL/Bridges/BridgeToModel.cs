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
using BLL.Infrastructure;
using System.IO;
using BLL.ParserObj;

namespace BLL.Bridges
{
    public class BridgeToModel : IBridgeToModel
    {
        private IUnitOfWork _db;

        public BridgeToModel()
        {
            _db = new EFUnitOfWork();
        }

        public void CheckFile(FileSystemEventArgs e)
        {
            string fileName = Path.GetFileNameWithoutExtension(e.FullPath);
            string[] tmp = fileName.Split('_');
            string pattern = "ddMMyyyy";
            if (CheckManager(tmp[0]))
            {
                DateTime parsedDate = DateTime.ParseExact(tmp[1], pattern, null);
                int? id = GetManagerId(tmp[0]);
                AddReport(new ReportDTO(fileName, parsedDate, (int)id));
                ParseFile(e.FullPath, (int)id);
            }
            else
            {
                AddManager(new ManagerDTO(tmp[0]));
            }
        }

        private void ParseFile(string path, int id)
        {
            Parser parser = new Parser();
            foreach (var item in parser.ParserCSV(path, id))
            {
                AddSale(item);
            }
        }

        public void AddManager(ManagerDTO manager)
        {
            if (manager.LastName.Contains("_"))
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ManagerDTO, Manager>();
                });
                IMapper mapper = config.CreateMapper();
                _db.Managers.Create(mapper.Map<ManagerDTO, Manager>(manager));
                _db.Save();
            } throw new ValidationException("Bad filing name", "");
        }

        public void AddReport(ReportDTO report)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportDTO, Report>()
                    .ForMember(dest => dest.Manager,
                            opts => opts.MapFrom(src => _db.Managers.FindById(src.ManagerId)));
            });
            IMapper mapper = config.CreateMapper();
            _db.Reports.Create(mapper.Map<ReportDTO, Report>(report));
            _db.Save();
        }


        public void AddSale(SaleDTO sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleDTO, Sale>()
                    .ForMember(dest => dest.Manager,
                             opts => opts.MapFrom(src => _db.Managers.FindById(src.ManagerId)));
            });
            IMapper mapper = config.CreateMapper();
            _db.Sales.Create(mapper.Map<SaleDTO, Sale>(sale));
            _db.Save();
        }

        public void AddSales(ICollection<SaleDTO> sales)
        {
            foreach (var item in sales)
            {
                AddSale(item);
            }
        }

        public int? GetManagerId(string managerLastName)
        {
            Manager manager = _db.Managers.Get(x => x.LastName == managerLastName).First();
            if (manager != null) { return manager.ManagerID; }
            else return null;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool CheckManager(string managerLastName)
        {
            if (_db.Managers.Get(x => x.LastName == managerLastName).Any()) return true;
            else return false;
        }
    }
}
