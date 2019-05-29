using System;
using System.Collections.Generic;

namespace travel_agency.Domain
{
    public class Order:EntityBase
    {
        public virtual Room Room { get; set; }
        public virtual Client Client { get; set; }
        public virtual string Travel_starts { get; set; }
        public virtual string Travel_ends { get; set; }

    }
}