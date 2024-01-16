using System;
using System.Collections.Generic;

namespace Assignment08.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Cid { get; set; }
        public string? Cat { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
