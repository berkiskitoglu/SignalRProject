using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDtos
{
    public class ResultBasketDto
    {
      
            public int BasketID { get; set; }
            public string Status { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
            public int MenuTableID { get; set; }
            public List<ResultBasketProductDto> Products { get; set; }
        
    }
}
