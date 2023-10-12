namespace hw.tests
{
    public class ForecastServiceTests
    {
        private readonly ForecastService _instance;
        public ForecastServiceTests()
        {
            var forecast = new Forecast { 
                Id = 6, Latitude = 47.674f, Longitude = -122.1215f, Temperature = 58.2f, TemperatureUnit = ETemperatureUnit.Fahrenheit
            };
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<Forecast>(It.IsAny<AddForecastDTO>()))
                .Returns(forecast);
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dataContext = new DataContext(options);
            dataContext.Database.EnsureCreated();
            _instance = new ForecastService(mockMapper.Object, dataContext);
        }

        [Fact]
        public async Task AddForecast_Succeeds()
        {
            var res = await _instance.AddForecast(new AddForecastDTO());

            Assert.NotNull(res);
            Assert.True(res.Success);
        }

        [Fact]
        public async Task DeleteForecastByLatLong_Succeeds()
        {
            var res = await _instance.DeleteForecastByLatLong(38.9415f, -76.965f);

            Assert.NotNull(res);
            Assert.True(res.Success);
        }

        [Fact]
        public async Task GetAllForecasts_Succeeds()
        {
            var res = await _instance.GetAllForecasts();

            Assert.NotNull(res);
            Assert.True(res.Success);
        }

        [Fact]
        public async Task GetAllLocations_Succeeds()
        {
            var res = await _instance.GetAllLocations();

            Assert.NotNull(res);
            Assert.True(res.Success);
        }

        [Fact]
        public async Task GetForecastByLatLong_Succeeds()
        {
            var res = await _instance.GetForecastByLatLong(38.9415f, -76.965f);

            Assert.NotNull(res);
            Assert.True(res.Success);
        }

        [Fact]
        public async Task UpdateForecast_Succeeds()
        {
            var res = await _instance.UpdateForecast(new UpdateForecastDTO {
                Latitude = 38.9415f, Longitude = -76.965f, Temperature = -10.0f, TemperatureUnit = ETemperatureUnit.Fahrenheit
            });

            Assert.NotNull(res);
            Assert.True(res.Success);
        }
    }
}