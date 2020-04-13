using AutoMapper;
using FluentValidation;
using Hipages.Application.Tradie.Common.Events;
using Hipages.Application.Tradie.NewJobs.Discount;
using Hipages.Domain.Tradie.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hipages.Application.Tradie
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddSingleton<IDiscountStrategy, PriceBaseDiscountStrategy>(); // when there are multiple strategy may need to change to builder pattern 

            return services;
        }
    }
}
