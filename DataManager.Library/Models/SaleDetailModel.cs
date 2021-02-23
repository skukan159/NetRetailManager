using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Models
{
    class SaleDetailModel
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Tax { get; set; }

    }
}
