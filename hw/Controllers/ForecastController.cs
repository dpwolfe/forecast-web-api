using Microsoft.AspNetCore.Mvc;
using hw.DTOs.Forecast;

namespace hw.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public ForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetForecastDTO>>>> Get()
        {
            return Ok(await _forecastService.GetAllForecasts());
        }

        [HttpGet("GetAllLocations")]
        public async Task<ActionResult<ServiceResponse<List<GetLocationDTO>>>> GetAllLocations()
        {
            return Ok(await _forecastService.GetAllLocations());
        }

        [HttpGet("{latitude}/{longitude}")]
        public async Task<ActionResult<ServiceResponse<GetForecastDTO>>> GetSingle(float latitude, float longitude)
        {
            return Ok(await _forecastService.GetForecastByLatLong(latitude, longitude));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetForecastDTO>>>> Add(AddForecastDTO newForecast)
        {
            return Ok(await _forecastService.AddForecast(newForecast));
        }

        [HttpDelete("{latitude}/{longitude}")]
        public async Task<ActionResult<ServiceResponse<GetForecastDTO>>> Delete(float latitude, float longitude)
        {
            // todo: validation and/or truncating at two decimals
            return Ok(await _forecastService.DeleteForecastByLatLong(latitude, longitude));
        }
    }
}