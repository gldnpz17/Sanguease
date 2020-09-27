using APIClientLibrary.Models;
using EventAggregatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguease.Events
{
    class BDEventDetailsOpenedEvent : AggregateEvent<BDEvent>
    {
    }
}
