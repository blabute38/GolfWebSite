using AutoMapper;
using Golf.Model;
using Golf.ServiceLayer.Dto.Implementations;
using System.Collections.Generic;

namespace Golf.RESTService.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Golfer, GolferDto>();
                config.CreateMap<GolferDto, Golfer>();
            });
        }
    }
}