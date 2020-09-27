using EventAggregatorLibrary;
using Sanguease.Commands;
using Sanguease.Events;
using Sanguease.Models;
using Sanguease.ViewModels.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Sanguease.ViewModels
{
    class MessageViewModel : ViewModelBase, IMessageViewModel
    {
        private IEventAggregator _eventAggregator;
        private DispatcherTimer _animTimer = new DispatcherTimer();

        public MessageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MessageDataSuppliedEvent>().Subscribe(OnMessageDataSupplied);

            _animTimer.Interval = TimeSpan.FromMilliseconds(170);
            _animTimer.Tick +=
                (s, e) =>
                {
                    if (AnimText == " . ")
                    {
                        AnimText = " . . ";
                        return;
                    }
                    if (AnimText == " . . ")
                    {
                        AnimText = " . . . ";
                        return;
                    }
                    if (AnimText == " . . . ")
                    {
                        AnimText = " . . . . ";
                        return;
                    }
                    if (AnimText == " . . . . ")
                    {
                        AnimText = " . . . . . ";
                        return;
                    }
                    if (AnimText == " . . . . . ")
                    {
                        AnimText = " . ";
                        return;
                    }
                };
        }

        private void OnMessageDataSupplied(MessageModel model)
        {
            Title = model.Title;
            Message = model.Message;

            switch (model.Mode)
            {
                case MessageMode.Error:
                    TitleColor = new SolidColorBrush(Colors.Red);
                    MessageColor = new SolidColorBrush(Colors.PaleVioletRed);
                    break;
                case MessageMode.Notification:
                    TitleColor = new SolidColorBrush(Colors.White);
                    MessageColor = new SolidColorBrush(Colors.White);
                    break;
                case MessageMode.Success:
                    TitleColor = new SolidColorBrush(Colors.Green);
                    MessageColor = new SolidColorBrush(Colors.LightGreen);
                    break;
            }

            if (model.Closeable)
            {
                Closeable = true;
            }
            else
            {
                Closeable = false;
            }

            if (model.WaitingAnimationOn)
            {
                AnimText = " . ";
                _animTimer.Start();
            }
        }

        #region properties
        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;

                OnPropertyChanged();
            }
        }
        private Brush _titleColor;
        public Brush TitleColor
        {
            get { return _titleColor; }
            set
            {
                _titleColor = value;

                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;

                OnPropertyChanged();
            }
        }
        private Brush _messageColor;
        public Brush MessageColor
        {
            get { return _messageColor; }
            set
            {
                _messageColor = value;

                OnPropertyChanged();
            }
        }

        private bool _closeable;
        public bool Closeable
        {
            get { return _closeable; }
            set
            {
                _closeable = value;

                OnPropertyChanged();
            }
        }

        private string _animText;
        public string AnimText
        {
            get { return _animText; }
            set
            {
                _animText = value;

                OnPropertyChanged();
            }
        }
        #endregion

        RelayCommand _close;
        public ICommand Close
        {
            get
            {
                if (_close == null)
                {
                    _close = new RelayCommand(
                        (param) =>
                        {
                            _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish(); 
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _close;
            }
        }
    }
}
