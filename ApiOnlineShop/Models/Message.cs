using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int SenderUserId { get; set; }
        public string MessageText { get; set; } = null!;
        public DateTime Timestamp { get; set; }

        public virtual Chat? Chat { get; set; } = null!;
        public virtual User? SenderUser { get; set; } = null!;
    }
}
