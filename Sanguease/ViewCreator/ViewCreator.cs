using IoCContainerLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sanguease.ViewCreator
{
    public class ViewCreator : IViewCreator
    {
        private IContainer _container;
        private List<ViewCreatorEntry> _entries = new List<ViewCreatorEntry>();

        public ViewCreator(IContainer container, IViewCreatorConfig config)
        {
            _container = container;

            _entries = config.viewCreatorEntries;
        }

        public UserControl GetInstance(string key)
        {
            Type viewType = (from entry in _entries
                             where entry.Key == key
                             select entry).ToList().First().ViewType;

            UserControl output = (UserControl)typeof(IContainer).GetMethod("GetInstance").MakeGenericMethod(viewType).Invoke(_container, null);

            return output;
        }
    }
}
