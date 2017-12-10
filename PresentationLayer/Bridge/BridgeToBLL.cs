﻿using PresentationLayer.Interfaces;
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

        private SaleDTO MapSale(SaleViewModel sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleViewModel, SaleDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<SaleViewModel, SaleDTO>(sale);
        }

        public void SendSaleInfo(SaleViewModel sale)
        {
            _dbConnect.AddSale(MapSale(sale));
        }

        public void SendSalesInfo(ICollection<SaleViewModel> sales)
        {
            ICollection<SaleDTO> salesInfo = new List<SaleDTO>();
            foreach(var item in sales)
            {
                salesInfo.Add(MapSale(item));
            }
            _dbConnect.AddSales(salesInfo);
        }

        bool CheckManager(string managerLastName)
        {
            return _dbConnect.CheckManager(managerLastName);
        }

        public void Dispose()
        {
            _dbConnect.Dispose();
        }
    }
}
