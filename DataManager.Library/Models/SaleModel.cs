using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Models
{
    public class SaleModel
    {
        public string CashierId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

    }
}
