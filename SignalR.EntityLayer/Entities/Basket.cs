using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }
        public string Status { get; set; } = "ACTIVE";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; } = null!;
        public ICollection<BasketProduct> BasketProducts { get; set; } = new HashSet<BasketProduct>();


    }
}
