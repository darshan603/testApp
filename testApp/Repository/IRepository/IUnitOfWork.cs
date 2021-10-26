using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISalesRepository Sales { get; }
        ISalesLinesRepository SalesLines { get; }
       
        void Save();
    }
}
