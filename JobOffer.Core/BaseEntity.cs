using System;
using System.Collections.Generic;
using System.Text;

namespace JobOffer.Core
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
