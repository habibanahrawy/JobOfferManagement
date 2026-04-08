using System;
using System.Collections.Generic;
using System.Text;

namespace JobOffer.Core.Lookups
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
