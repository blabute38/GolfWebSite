using AutoMapper;
using Golf.ServiceLayer.Dto.Implementations;
using Golf.ViewModels.Golfers;

namespace Golf.MVCApplication.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<GolferViewModel, GolferDto>();
                config.CreateMap<GolferDto, GolferViewModel>();
            });
        }
    }
}