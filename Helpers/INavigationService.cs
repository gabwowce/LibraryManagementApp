using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Helpers
{
    public interface INavigationService
    {
        void Configure(string key, Type viewType);
        void NavigateTo(string viewKey);
    }
}
