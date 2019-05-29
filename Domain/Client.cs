using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel_agency.Domain
{
    public class Client:EntityBase
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual Country Country { get; set; }
    }
}