using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Data;
using testApp.Models;
using testApp.Repository.IRepository;

namespace testApp.Repository
{
    public class SalesLinesRepository : Repository<SalesLines>, ISalesLinesRepository
    {
        private readonly ApplicationDbContext _db;

        public SalesLinesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
