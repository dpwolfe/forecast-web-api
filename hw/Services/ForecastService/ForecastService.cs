using hw.DTOs.Forecast;

namespace hw.Services.ForecastService
{
    public class ForecastService : IForecastService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ForecastService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetForecastDTO>>> AddForecast(AddForecastDTO newForecast)
        {
            var res = new ServiceResponse<List<GetForecastDTO>>();
            var forecast = _mapper.Map<Forecast>(newForecast);
            _context.Forecasts.Add(forecast);
            await _context.SaveChangesAsync();
            res.Data = await _context.Forecasts.Select(f => _mapper.Map<GetForecastDTO>(f)).ToListAsync();
            return res;
        }

        public async Task<ServiceResponse<List<GetForecastDTO>>> DeleteForecastByLatLong(float latitude, float longitude)
        {
            var res = new ServiceResponse<List<GetForecastDTO>>();

            Forecast? forecast = await _context.Forecasts.FirstOrDefaultAsync(
                f => f.Latitude == latitude && f.Longitude == longitude);

            if (forecast is null)
            {
                res.Success = false;
                res.Message = $"Forecast with Latitude '{latitude}' and Longitude '{longitude}' not found.";
            }
            else
            {
                _context.Forecasts.Remove(forecast);
                await _context.SaveChangesAsync();
                res.Data = await _context.Forecasts.Select(f => _mapper.Map<GetForecastDTO>(f)).ToListAsync();
            }

            return res;
        }

        public async Task<ServiceResponse<List<GetForecastDTO>>> GetAllForecasts()
        {
            var res = new ServiceResponse<List<GetForecastDTO>>();
            List<Forecast> dbForecasts = await _context.Forecasts.ToListAsync();
            res.Data = dbForecasts.Select(f => _mapper.Map<GetForecastDTO>(f)).ToList();
            return res;
        }

        public async Task<ServiceResponse<List<GetLocationDTO>>> GetAllLocations()
        {
            var res = new ServiceResponse<List<GetLocationDTO>>();
            List<Forecast> dbForecasts = await _context.Forecasts.ToListAsync();
            res.Data = dbForecasts.Select(f => _mapper.Map<GetLocationDTO>(f)).ToList();
            return res;
        }

        public async Task<ServiceResponse<GetForecastDTO>> GetForecastByLatLong(float latitude, float longitude)
        {
            var res = new ServiceResponse<GetForecastDTO>();
            List<Forecast> dbForecasts = await _context.Forecasts.ToListAsync();
            Forecast? forecast = dbForecasts.FirstOrDefault(forecast => forecast.Latitude == latitude && forecast.Longitude == longitude);
            res.Data = _mapper.Map<GetForecastDTO>(forecast);
            return res;
        }

        public async Task<ServiceResponse<GetForecastDTO>> UpdateForecast(UpdateForecastDTO newForecast)
        {
            float latitude = newForecast.Latitude;
            float longitude = newForecast.Longitude;
            var res = new ServiceResponse<GetForecastDTO>();
            Forecast? forecast = await _context.Forecasts.FirstOrDefaultAsync(
                f => f.Latitude == latitude && f.Longitude == longitude);
            if (forecast is null)
            {
                res.Success = false;
                res.Message = $"Forecast with Latitude '{latitude}' and Longitude '{longitude}' not found.";
            }
            else
            {
                forecast.Temperature = newForecast.Temperature;
                forecast.TemperatureUnit = newForecast.TemperatureUnit;
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetForecastDTO>(forecast);
            }

            return res;
        }
    }
}