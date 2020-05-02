  
using AutoMapper;
using FluentValidation.AspNetCore;
using Microservice.Whatevers.Services.Mapper;
using Microservice.Whatevers.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services.IoC
{
    public static class IocServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ModelToDomainProfile));

        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
               .AddScoped<IWhateverService, WhateverService>();

        public static IMvcCoreBuilder AddFluentValidation(this IMvcCoreBuilder builder) =>
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<WhateverModelValidator>());
    }
}