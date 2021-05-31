using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Models
{
    public class Message // Dummy Klasse für eine Messages
    {
        int senderId;
        string senderName;
        int receiverId;
        string receiverName;
        bool unread;
        string text;
        DateTime messageDateTime;
    }
}
