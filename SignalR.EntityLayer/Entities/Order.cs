using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = null!;
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; } = null!;
    }
}
