using AutoMapper;
using ControlService.Views.Dto;
using ControlService.Models.Entities;
namespace ControlService.Utilities.AutoMapper
{
    public class MapHControl : Profile
    {
        public MapHControl(IConfiguration configuration)
        {
            ConfigureHControl();
        }
        private void ConfigureHControl()
        {

            CreateMap<HydrologyControl, DtoCheckValueHControl>();
            CreateMap<DtoCheckValueHControl, HydrologyControl>();

            CreateMap<HydrologyControl, DtoCreateHControl>();
            CreateMap<DtoCreateHControl, HydrologyControl>();

            CreateMap<HydrologyControl, DtoGateIntervalHControl>();
            CreateMap<DtoGateIntervalHControl, HydrologyControl>();

            CreateMap<HydrologyControl, DtoGetDateHControl>();
            CreateMap<DtoGetDateHControl, HydrologyControl>();

            CreateMap<HydrologyControl, DtoGetHControl>();
            CreateMap<DtoGetHControl, HydrologyControl>();
        }
    }
}
