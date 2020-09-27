using APIClientLibrary;
using EventAggregatorLibrary;
using IoCContainerLibrary;
using Sanguease.ViewCreator;
using Sanguease.ViewModels;
using Sanguease.ViewModels.interfaces;
using Sanguease.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanguease
{
    class ContainerConfig
    {
        private ContainerBuilder _builder = new ContainerBuilder();

        public IContainer Configure()
        {
            _builder.Register(typeof(Container), typeof(IContainer), true);
            _builder.Register(typeof(ViewCreatorConfig), typeof(IViewCreatorConfig), false);
            _builder.Register(typeof(EventAggregator), typeof(IEventAggregator), true);
            _builder.Register(typeof(ViewCreator.ViewCreator), typeof(IViewCreator), true);
            _builder.Register(typeof(SangueaseAPI), typeof(ISangueaseAPI), true);

            //Views
            _builder.Register(typeof(ShellView), typeof(ShellView), false);
            _builder.Register(typeof(BDEventsView), typeof(BDEventsView), false);
            _builder.Register(typeof(AddBDEventView), typeof(AddBDEventView), false);
            _builder.Register(typeof(EditBDEventView), typeof(EditBDEventView), false);
            _builder.Register(typeof(BDEventDetailsView), typeof(BDEventDetailsView), false);
            _builder.Register(typeof(MessageView), typeof(MessageView), false);

            //ViewModels
            _builder.Register(typeof(ShellViewModel), typeof(IShellViewModel), false);
            _builder.Register(typeof(BDEventsViewModel), typeof(IBDEventsViewModel), false);
            _builder.Register(typeof(AddBDEventViewModel), typeof(IAddBDEventViewModel), false);
            _builder.Register(typeof(EditBDEventViewModel), typeof(IEditBDEventViewModel), false);
            _builder.Register(typeof(BDEventDetailsViewModel), typeof(IBDEventDetailsViewModel), false);
            _builder.Register(typeof(MessageViewModel), typeof(IMessageViewModel), false);

            return _builder.Build();
        }
    }
}
