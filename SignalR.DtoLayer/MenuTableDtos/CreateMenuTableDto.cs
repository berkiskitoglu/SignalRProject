using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.MenuTableDtos
{
    public class CreateMenuTableDto
    {
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
    }
}
