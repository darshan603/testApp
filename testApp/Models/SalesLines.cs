using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Models
{
    public class SalesLines
    {
        [Key]
        public int SalesLineID { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }

        public double Total { get; set; }

        [Required]
        public int SSalesID { get; set; }
        [ForeignKey("SSalesID")]
        public Sales Sales { get; set; }
    }
}
