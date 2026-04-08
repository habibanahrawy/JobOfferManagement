using System;
using System.Collections.Generic;
using System.Text;

namespace JobOffer.Core.Lookups
{
    public class Country : BaseEntity<int>
    {
        
        public string Name { get; set; } = string.Empty;


        public ICollection<City> cities { get; set; } = new List<City>();
    }
}
