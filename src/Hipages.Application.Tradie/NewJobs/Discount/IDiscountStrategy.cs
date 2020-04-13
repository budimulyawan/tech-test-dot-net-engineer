using Hipages.Domain.Tradie.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Application.Tradie.NewJobs.Discount
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(Job job);
    }
}
