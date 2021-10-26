using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Models
{
    public class Sales
    {
        [Key]
        public int SalesID { get; set; }

        public int InvNo { get; set; }

        public DateTime SalesDate { get; set; }

        public double Amount { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public int Tel { get; set; }

        public string SalesType { get; set; }


    }
}
