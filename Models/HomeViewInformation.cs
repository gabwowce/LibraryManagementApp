using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class HomeViewInformation
    {
        public int TotalBooks { get; set; }
        public int TotalMembers { get; set; }
        public int TotalBooksLoanedOut { get; set; }
    }
}
