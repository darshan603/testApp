using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Data;
using testApp.Models;
using testApp.Repository.IRepository;

namespace testApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
          
            Sales = new SalesRepository(_db);
            SalesLines = new SalesLinesRepository(_db);
           
        }

        public ISalesRepository Sales { get; private set; }
        public ISalesLinesRepository SalesLines { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
