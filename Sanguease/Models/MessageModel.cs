using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Sanguease.Models
{
    public enum MessageMode { Notification, Error, Success }
    class MessageModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public MessageMode Mode { get; set; } = MessageMode.Notification;
        public bool Closeable { get; set; }
        public bool WaitingAnimationOn { get; set; } = false;
    }
}
