using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
