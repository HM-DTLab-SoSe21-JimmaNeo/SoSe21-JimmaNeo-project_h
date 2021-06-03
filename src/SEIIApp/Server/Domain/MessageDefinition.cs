using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class MessageDefinition
    {
        [Key]
        public int Id { get; set; }
        public int senderId { get; set; }
        public string senderName { get; set; }
        public int receiverId { get; set; }
        public string receiverName { get; set; }
        public bool unread { get; set; }
        public string text { get; set; }
        DateTime messageDateTime { get; set; }
    }
}
