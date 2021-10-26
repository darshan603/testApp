using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Data;
using testApp.Models;
using testApp.Repository.IRepository;

namespace testApp.Repository
{
    public class SalesRepository: Repository<Sales>, ISalesRepository
    {
        private readonly ApplicationDbContext _db;

        public SalesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      
       
    }
}
