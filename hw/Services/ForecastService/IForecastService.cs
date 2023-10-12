using hw.DTOs.Forecast;

namespace hw.Services.ForecastService
{
    public interface IForecastService
    {
        Task<ServiceResponse<List<GetForecastDTO>>> AddForecast(AddForecastDTO newForecast);
        Task<ServiceResponse<List<GetForecastDTO>>> DeleteForecastByLatLong(float latitude, float longitude);
        Task<ServiceResponse<List<GetForecastDTO>>> GetAllForecasts();
        Task<ServiceResponse<List<GetLocationDTO>>> GetAllLocations();
        Task<ServiceResponse<GetForecastDTO>> GetForecastByLatLong(float latitude, float longitude);
        Task<ServiceResponse<GetForecastDTO>> UpdateForecast(UpdateForecastDTO newForecast);
    }
}