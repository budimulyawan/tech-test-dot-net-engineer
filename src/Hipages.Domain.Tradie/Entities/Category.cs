using Hipages.Domain.Tradie.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Domain.Tradie.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}
