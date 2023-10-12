using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw.DTOs.Forecast;

namespace hw
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Forecast,GetForecastDTO>();
            CreateMap<AddForecastDTO,Forecast>();
            CreateMap<Forecast,GetLocationDTO>();
        }
    }
}