using APIClientLibrary;
using APIClientLibrary.Models;
using EventAggregatorLibrary;
using Sanguease.Commands;
using Sanguease.Events;
using Sanguease.Models;
using Sanguease.ViewModels.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Sanguease.ViewModels
{
    public class BDEventDetailsViewModel : ViewModelBase, IBDEventDetailsViewModel
    {
        private ISangueaseAPI _api;
        private IEventAggregator _eventAggregator;

        public BDEventDetailsViewModel(ISangueaseAPI api, IEventAggregator eventAggregator)
        {
            _api = api;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<BDEventDetailsOpenedEvent>().Subscribe(OnBDEventDetailsOpened);
        }

        #region events
        private async void OnBDEventDetailsOpened(BDEvent model)
        {
            Event = model;

            _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(new MessageModel()
            {
                Title = "Please Wait",
                Message = "Getting Address Data",
                Mode = MessageMode.Notification,
                Closeable = false,
                WaitingAnimationOn = true
            });

            Address = await _api.GetLocationByCoordinatesAsync(model.Latitude, model.Longitude);

            _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();
        }
        #endregion

        #region properties
        private BDEvent _event;
        public BDEvent Event
        {
            get { return _event; }
            set
            {
                _event = value;

                OnPropertyChanged();
            }
        }

        private bool _viewIsVisible = true;
        public bool ViewIsVisible
        {
            get { return _viewIsVisible; }
            set
            {
                _viewIsVisible = value;

                OnPropertyChanged();
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;

                OnPropertyChanged();
            }
        }

        public BitmapImage Image
        {
            get { return ConvertByteArrayToBitmapImage(_event.Image); }
            set
            {
                _event.Image = ConvertPngImageToByteArray(value);

                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
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
                            ViewIsVisible = false;
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _close;
            }
        }
        #endregion

        #region private methods
        private BitmapImage ConvertByteArrayToBitmapImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0) return null;
            BitmapImage image = new BitmapImage();
            using (var mem = new MemoryStream(imageBytes))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        byte[] ConvertPngImageToByteArray(BitmapImage image)
        {
            byte[] output;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                output = ms.ToArray();
            }

            return output;
        }
        #endregion
    }
}
