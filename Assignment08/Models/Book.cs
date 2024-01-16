using System;
using System.Collections.Generic;

namespace Assignment08.Models
{
    public partial class Book
    {
        public int Bid { get; set; }
        public string? Title { get; set; }
        public int? Aid { get; set; }
        public int? Pid { get; set; }
        public int? Cid { get; set; }

        public virtual Author? AidNavigation { get; set; }
        public virtual Category? CidNavigation { get; set; }
        public virtual Publisher? PidNavigation { get; set; }
    }
}
