using System.Collections.Generic;

namespace travel_agency.Domain
{
    public class Country:EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Capital { get; set; }
        public virtual string Language { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Religion { get; set; }
    }
}