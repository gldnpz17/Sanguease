using EventAggregatorLibrary;
using Sanguease.Commands;
using Sanguease.Events;
using Sanguease.Models;
using Sanguease.ViewCreator;
using Sanguease.ViewModels.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sanguease.ViewModels
{
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        private IViewCreator _viewCreator;
        private IEventAggregator _eventAggregator;

        private UserControl _mainView;

        public ShellViewModel(IViewCreator viewCreator, IEventAggregator eventAggregator)
        {
            _viewCreator = viewCreator;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MessageViewOpenedEvent>().Subscribe(OnMessageViewOpened);
            _eventAggregator.GetEvent<MessageViewClosedEvent>().Subscribe(OnMessageViewClosed);

            _mainView = _viewCreator.GetInstance("BDEventsView");
            ChildView = _mainView;
        }

        private void OnMessageViewOpened(MessageModel model)
        {
            OverlayView = _viewCreator.GetInstance("MessageView");
            _eventAggregator.GetEvent<MessageDataSuppliedEvent>().Publish(model);
        }
        private void OnMessageViewClosed()
        {
            OverlayView = null;
        }

        private UserControl _childView;
        public UserControl ChildView
        {
            get { return _childView; }
            set
            {
                _childView = value;
                OnPropertyChanged();
            }
        }

        private UserControl _overlayView;
        public UserControl OverlayView
        {
            get { return _overlayView; }
            set
            {
                _overlayView = value;
                OnPropertyChanged();
            }
        }

        RelayCommand _about;
        public ICommand About
        {
            get
            {
                if (_about == null)
                {
                    _about = new RelayCommand(
                        (param) =>
                        {
                            _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                                new MessageModel()
                                {
                                    Title = "About",
                                    Message = "Firdaus Bisma Suryakusuma\n(19/444051/TK/49247)\nKelas Senin B",
                                    Mode = MessageMode.Success,
                                    Closeable = true,
                                    WaitingAnimationOn = true
                                });
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _about;
            }
        }
    }
}
