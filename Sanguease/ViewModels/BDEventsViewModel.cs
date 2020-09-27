using APIClientLibrary;
using APIClientLibrary.Models;
using EventAggregatorLibrary;
using Sanguease.Commands;
using Sanguease.Events;
using Sanguease.Models;
using Sanguease.ViewCreator;
using Sanguease.ViewModels.interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sanguease.ViewModels
{
    public class BDEventsViewModel : ViewModelBase, IBDEventsViewModel
    {
        ISangueaseAPI _api;
        IViewCreator _viewCreator;
        IEventAggregator _eventAggregator;

        public BDEventsViewModel(ISangueaseAPI api, IViewCreator viewCreator, IEventAggregator eventAggregator)
        {
            _api = api;
            _viewCreator = viewCreator;
            _eventAggregator = eventAggregator;

            //subscribe to events
            _eventAggregator.GetEvent<AddBDEventClosedEvent>().Subscribe(OnAddBDEventClosed);
            _eventAggregator.GetEvent<EditBDEventClosedEvent>().Subscribe(OnEditBDEventClosed);

            _ = UpdateBDEventsAsync();
        }

        #region events
        private void OnAddBDEventClosed()
        {
            _ = UpdateBDEventsAsync();
        }
        private void OnEditBDEventClosed()
        {
            _ = UpdateBDEventsAsync();
        }
        #endregion

        #region properties
        private ObservableCollection<BDEvent> _bdEvents;
        public ObservableCollection<BDEvent> BDEvents
        {
            get { return _bdEvents; }
            set
            {
                _bdEvents = value;
                OnPropertyChanged();
            }
        }

        private UserControl _childView;
        public UserControl ChildView 
        {
            get { return _childView; } 
            private set
            {
                _childView = value;
                OnPropertyChanged();
            } 
        }

        private BDEvent _selectedEvent;
        public BDEvent SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
        RelayCommand _refresh;
        public ICommand Refresh
        {
            get 
            {
                if(_refresh == null)
                {
                    _refresh = new RelayCommand(
                        (param) => 
                        {
                            _ = UpdateBDEventsAsync();
                        },
                        (param) =>
                        {
                            return true;
                        });
                }

                return _refresh;
            }
        }

        RelayCommand _openDetails;
        public ICommand OpenDetails
        {
            get
            {
                if(_openDetails == null)
                {
                    _openDetails = new RelayCommand(
                        (param) =>
                        {
                            ChildView = _viewCreator.GetInstance("BDEventDetailsView");
                            _eventAggregator.GetEvent<BDEventDetailsOpenedEvent>().Publish(SelectedEvent);
                        },
                        (param) =>
                        {
                            if(SelectedEvent != null)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
                }

                return _openDetails;
            }
        }

        RelayCommand _openAdd;
        public ICommand OpenAdd
        {
            get
            {
                if(_openAdd == null)
                {
                    _openAdd = new RelayCommand(
                        (param) =>
                        {
                            ChildView = _viewCreator.GetInstance("AddBDEventView");
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _openAdd;
            }
        }

        RelayCommand _openEdit;
        public ICommand OpenEdit
        {
            get
            {
                if (_openEdit == null)
                {
                    _openEdit = new RelayCommand(
                        (param) =>
                        {
                            ChildView = _viewCreator.GetInstance("EditBDEventView");
                            _eventAggregator.GetEvent<EditBDEventOpenedEvent>().Publish(SelectedEvent);
                        },
                        (param) =>
                        {
                            if (SelectedEvent != null)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
                }
                return _openEdit;
            }
        }

        RelayCommand _sortByIdAscending;
        public ICommand SortByIdAscending
        {
            get
            {
                if (_sortByIdAscending == null)
                {
                    _sortByIdAscending = new RelayCommand(
                        (param) =>
                        {
                            BDEvents = new ObservableCollection<BDEvent>(BDEvents.OrderBy(o => o.Id).ToList());
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _sortByIdAscending;
            }
        }
        RelayCommand _sortByIdDescending;
        public ICommand SortByIdDescending
        {
            get
            {
                if (_sortByIdDescending == null)
                {
                    _sortByIdDescending = new RelayCommand(
                        (param) =>
                        {
                            BDEvents = new ObservableCollection<BDEvent>(BDEvents.OrderByDescending(o => o.Id).ToList());
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _sortByIdDescending;
            }
        }

        RelayCommand _sortByNameAscending;
        public ICommand SortByNameAscending
        {
            get
            {
                if (_sortByNameAscending == null)
                {
                    _sortByNameAscending = new RelayCommand(
                        (param) =>
                        {
                            BDEvents = new ObservableCollection<BDEvent>(BDEvents.OrderBy(o => o.Name).ToList());
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _sortByNameAscending;
            }
        }
        RelayCommand _sortByNameDescending;
        public ICommand SortByNameDescending
        {
            get
            {
                if (_sortByNameDescending == null)
                {
                    _sortByNameDescending = new RelayCommand(
                        (param) =>
                        {
                            BDEvents = new ObservableCollection<BDEvent>(BDEvents.OrderByDescending(o => o.Name).ToList());
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _sortByNameDescending;
            }
        }

        RelayCommand _sortByDateAscending;
        public ICommand SortByDateAscending
        {
            get
            {
                if (_sortByDateAscending == null)
                {
                    _sortByDateAscending = new RelayCommand(
                        (param) =>
                        {
                            BDEvents = new ObservableCollection<BDEvent>(BDEvents.OrderBy(o => o.StartDate).ToList());
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _sortByDateAscending;
            }
        }
        RelayCommand _sortByDateDescending;
        public ICommand SortByDateDescending
        {
            get
            {
                if (_sortByDateDescending == null)
                {
                    _sortByDateDescending = new RelayCommand(
                        (param) =>
                        {
                            BDEvents = new ObservableCollection<BDEvent>(BDEvents.OrderByDescending(o => o.StartDate).ToList());
                        },
                        (param) =>
                        {
                            return true;
                        });
                }
                return _sortByDateDescending;
            }
        }
        #endregion

        #region private methods
        private async Task UpdateBDEventsAsync()
        {
            try
            {
                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                    new MessageModel()
                    {
                        Title = "Please Wait",
                        Message = "Fetching blood donation events",
                        Mode = MessageMode.Notification,
                        Closeable = false,
                        WaitingAnimationOn = true
                    });

                List<BDEvent> bdEvents = await _api.GetBDEventsAsync();

                _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();

                BDEvents = new ObservableCollection<BDEvent>(bdEvents);
            }
            catch(Exception ex)
            {
                _eventAggregator.GetEvent<MessageViewClosedEvent>().Publish();

                _eventAggregator.GetEvent<MessageViewOpenedEvent>().Publish(
                    new MessageModel()
                    {
                        Title = "Error Fetching Blood Donation Events",
                        Message = ex.Message,
                        Mode = MessageMode.Error,
                        Closeable = true
                    });
            }
        }
        #endregion
    }
}
