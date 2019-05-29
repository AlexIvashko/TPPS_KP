using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel_agency.Domain
{
    public class Room:EntityBase
    {
        public virtual int Number { get; set; }
        public virtual string Type { get; set; }
        public virtual int Size { get; set; }
        public virtual int Price { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}