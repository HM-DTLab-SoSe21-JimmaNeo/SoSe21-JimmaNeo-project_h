using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainTdo
{
    public class MessageDefinitionDto
    {
        public int Id { get; set; }
        public int senderId { get; set; }
        public string senderName { get; set; }
        public int receiverId { get; set; }
        public string receiverName { get; set; }
        public bool unread { get; set; }
        public string text { get; set; }
        public DateTime messageDateTime { get; set; }
    }
}
