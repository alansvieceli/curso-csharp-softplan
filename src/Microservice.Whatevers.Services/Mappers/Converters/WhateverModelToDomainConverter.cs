using System;
using System.Collections.Generic;
using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper.Converters
{
    public class WhateverModelToDomainConverter : ITypeConverter<WhateverModel, Whatever>
    {
        public Whatever Convert(WhateverModel source, Whatever destination, ResolutionContext context)
        {
            if ((source is null) || (context is null)) return default;

            var whatever = new WhateverBuilder()
               .WithId(source.Id ?? Guid.NewGuid())
               .WithName(source.Name)
               .WithTime(source.Time)
               .WithType(source.Type)
               .Build();

            foreach (var sourceThing in source.Things ?? new List<ThingModel>())
                whatever.AddThing(context.Mapper.Map<ThingModel, Thing>(sourceThing));

            return whatever;
        }
    }
}