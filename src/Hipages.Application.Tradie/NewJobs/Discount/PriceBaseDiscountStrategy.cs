using System;
using System.Collections.Generic;
using System.Text;
using Hipages.Domain.Tradie.Entities;

namespace Hipages.Application.Tradie.NewJobs.Discount
{
    public class PriceBaseDiscountStrategy : IDiscountStrategy
    {
        private const decimal discountRate = 0.10M;
        private const decimal basePriceForDiscount = 500M;

        public decimal CalculateDiscount(Job job)
        {
            if (job.Price > basePriceForDiscount)
                return decimal.Multiply(discountRate, job.Price);
            return 0;
        }
    }
}
