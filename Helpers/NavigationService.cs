using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryManagementApp.Helpers
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _viewsByKey;
        private readonly ContentControl _contentControl;

        public NavigationService(ContentControl contentControl)
        {
            _viewsByKey = new Dictionary<string, Type>();
            _contentControl = contentControl;
        }

        public void Configure(string key, Type viewType)
        {
            if (_viewsByKey.ContainsKey(key))
                throw new ArgumentException("The key is already configured");

            _viewsByKey.Add(key, viewType);
        }

        public void NavigateTo(string viewKey)
        {
            if (!_viewsByKey.ContainsKey(viewKey))
                throw new ArgumentException("No such view exists");

            var viewType = _viewsByKey[viewKey];
            var view = Activator.CreateInstance(viewType) as UserControl;
            _contentControl.Content = view;
        }
    }
}
