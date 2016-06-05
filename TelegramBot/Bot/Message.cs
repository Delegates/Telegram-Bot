using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace UniveralBot
{
    public class Message
    {
        public static Message EmptyMessage => new Message(MessageType.Empty, null,null);
        public MessageType Type { get; set; }
        public object Data { get; set; }
        public string ChatId { get; set; }

        public Message(MessageType type, object data, string chatId)
        {
            Type = type;
            Data = data;
            ChatId = chatId;
        }
    }

    public enum MessageType
    {
        Text,
        Location, 
        Photo,
        Empty,
        Unknown
    }
}
