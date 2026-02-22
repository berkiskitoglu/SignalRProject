using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.NotificationDtos
{
    public class CreateNotificationDto
    {
        public required string Type { get; set; } 
        public required string Description { get; set; } 
        public required string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
