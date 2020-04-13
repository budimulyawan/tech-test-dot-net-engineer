using Hipages.Domain.Tradie.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Domain.Tradie.ValueObjects
{
    public class Suburb : ValueObject
    {
        public string Name { get; set; }
        public string PostCode { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return PostCode;
        }
    }
}
