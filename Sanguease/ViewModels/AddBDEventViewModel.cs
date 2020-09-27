using APIClientLibrary;
using APIClientLibrary.Models;
using EventAggregatorLibrary;
using Microsoft.Win32;
using Sanguease.Commands;
using Sanguease.Events;
using Sanguease.Models;
using Sanguease.ViewModels.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Sanguease.ViewModels
{
    public class AddBDEventViewModel : ViewModelBase, IAddBDEventViewModel
    {
        private IEventAggregator _eventAggregator;
        private ISangueaseAPI _api;

        public AddBDEventViewModel(IEventAggregator eventAggregator, ISangueaseAPI api)
        {
            _eventAggregator = eventAggregator;
            _api = api;
        }

        #region properties
        private BDEvent _event = new BDEvent() { StartDate=DateTime.Now, EndDate=DateTime.Now };
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
        RelayCommand _add;
        public ICommand Add
        {
            get
            {
                if (_add == null)
                {
                    _add = new RelayCommand(
                        async (param) =>
                        {
                            try
                            {
                                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                                    new MessageModel()
                                    {
                                        Title = "Please Wait",
                                        Message = "Sending Data",
                                        Mode = MessageMode.Notification,
                                        Closeable = false,
                                        WaitingAnimationOn = true
                                    });

                                await _api.AddBDEventAsync(Event);

                                _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();

                                _eventAggregator.GetEvent<AddBDEventClosedEvent>().Publish();

                                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                                    new MessageModel()
                                    {
                                        Title = "Success",
                                        Message = "Data Sent",
                                        Mode = MessageMode.Success,
                                        Closeable = true
                                    });

                                ViewIsVisible = false;
                            }
                            catch(Exception ex)
                            {
                                _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();

                                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                                    new MessageModel()
                                    {
                                        Title = "Error Sending Data",
                                        Message = ex.Message,
                                        Mode = MessageMode.Error,
                                        Closeable = true
                                    });
                            }
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _add;
            }
        }

        RelayCommand _cancel;
        public ICommand Cancel
        {
            get
            {
                if (_cancel == null)
                {
                    _cancel = new RelayCommand(
                        (param) =>
                        {
                            ViewIsVisible = false;
                            _eventAggregator.GetEvent<AddBDEventClosedEvent>().Publish();
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _cancel;
            }
        }

        RelayCommand _getAddress;
        public ICommand GetAddress
        {
            get
            {
                if (_getAddress == null)
                {
                    _getAddress = new RelayCommand(
                        async (param) =>
                        {
                            try
                            {
                                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                                    new MessageModel()
                                    {
                                        Title = "Please Wait",
                                        Message = "Getting Address Data",
                                        Mode = MessageMode.Notification,
                                        Closeable = false,
                                        WaitingAnimationOn = true
                                    });

                                Address = await _api.GetLocationByCoordinatesAsync(_event.Latitude, _event.Longitude);

                                _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();
                            }
                            catch (Exception ex)
                            {
                                _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();

                                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                                    new MessageModel()
                                    {
                                        Title = "Error Getting Location",
                                        Message = ex.Message,
                                        Mode = MessageMode.Error,
                                        Closeable = true
                                    });
                            }
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _getAddress;
            }
        }

        RelayCommand _browseImage;
        public ICommand BrowseImage
        {
            get
            {
                if (_browseImage == null)
                {
                    _browseImage = new RelayCommand(
                        (param) =>
                        {
                            OpenFileDialog op = new OpenFileDialog();
                            op.Title = "Select an Image";
                            op.Filter = "Portable Network Graphic (*.png)|*.png";
                            if (op.ShowDialog() == true)
                            {
                                Image = new BitmapImage(new Uri(op.FileName));
                            }
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _browseImage;
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
