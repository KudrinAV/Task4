﻿using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataModel;
using Model.Repositories;
using Model.Entities;

namespace Model.DALElements
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StoreAccountingContext _context;
        private IGenericRepository<Manager> _managers;
        private IGenericRepository<Sale> _sales;
        private IGenericRepository<Report> _reports;

        public EFUnitOfWork()
        {
            _context = new StoreAccountingContext();
        }

        public IGenericRepository<Report> Reports
        {
            get
            {
                return _reports ?? new EFGenericRepository<Report>(_context);
            }
        }

        public IGenericRepository<Manager> Managers
        {
            get
            {
                return _managers ?? new EFGenericRepository<Manager>(_context);
            }
        }

        public IGenericRepository<Sale> Sales
        {
            get
            {
                return _sales ?? new EFGenericRepository<Sale>(_context);
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
