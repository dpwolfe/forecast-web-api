namespace hw.tests
{
    public class ForecastControllerTests
    {
        private readonly ForecastController _instance;

        public ForecastControllerTests()
        {
            var fs = new Mock<IForecastService>();
            _instance = new ForecastController(fs.Object);
        }

        [Fact]
        public async Task Get_Returns200()
        {
            var res = (await _instance.Get()).Result;

            Assert.NotNull(res);
            Assert.Equal(((OkObjectResult)res).StatusCode, 200);
        }

        [Fact]
        public async Task GetAllLocations_Returns200()
        {            
            var res = (await _instance.GetAllLocations()).Result;

            Assert.NotNull(res);
            Assert.Equal(((OkObjectResult)res).StatusCode, 200);
        }
        
        [Fact]
        public async Task GetSingle_Returns200()
        {            
            var res = (await _instance.GetSingle(47.674f, -122.1215f)).Result;

            Assert.NotNull(res);
            Assert.Equal(((OkObjectResult)res).StatusCode, 200);
        }
        
        [Fact]
        public async Task Add_Returns200()
        {
            var res = (await _instance.Add(new AddForecastDTO())).Result;

            Assert.NotNull(res);
            Assert.Equal(((OkObjectResult)res).StatusCode, 200);
        }

        [Fact]
        public async Task Delete_Returns200()
        {
            var res = (await _instance.Delete(47.674f, -122.1215f)).Result;

            Assert.NotNull(res);
            Assert.Equal(((OkObjectResult)res).StatusCode, 200);
        }
    }
}