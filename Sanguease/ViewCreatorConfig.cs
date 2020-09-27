using Sanguease.ViewCreator;
using Sanguease.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguease
{
    public class ViewCreatorConfig : IViewCreatorConfig
    {
        public List<ViewCreatorEntry> viewCreatorEntries { get; set; } = new List<ViewCreatorEntry>()
        {
            new ViewCreatorEntry(){ Key="BDEventsView", ViewType=typeof(BDEventsView) },
            new ViewCreatorEntry(){ Key="AddBDEventView", ViewType=typeof(AddBDEventView) },
            new ViewCreatorEntry(){ Key="BDEventDetailsView", ViewType=typeof(BDEventDetailsView) },
            new ViewCreatorEntry(){ Key="EditBDEventView", ViewType=typeof(EditBDEventView) },
            new ViewCreatorEntry(){ Key="MessageView", ViewType=typeof(MessageView) }
        };
    }
}
