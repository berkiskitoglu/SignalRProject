using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
        public DateTime MessageSendDate { get; set; } 
        public bool Status { get; set; } 
    }
}
