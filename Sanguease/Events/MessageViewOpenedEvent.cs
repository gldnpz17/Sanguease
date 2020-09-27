using EventAggregatorLibrary;
using Sanguease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguease.Events
{
    class MessageViewOpenedEvent : AggregateEvent<MessageModel>
    {
    }
}
