using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Models.ViewModels
{
    public class SaleVM
    {
        public IEnumerable<SalesLines> SalesLines { get; set; }

        public  Sales Sales { get; set; }
    }
}
