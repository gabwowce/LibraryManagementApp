using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class Loans
    {
        public int LoanID { get; set; }
        public int MemberID { get; set;}
        public int BookID { get; set; }
        public DateTime DateofLoan { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }  
    }
}
