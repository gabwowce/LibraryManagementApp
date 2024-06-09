using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfRelease { get; set; }
        public int CategoryID { get; set; }
        public string ImageSource { get; set; }
    }
}
