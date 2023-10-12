namespace hw.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Forecast> Forecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Forecast>().HasData(
                // Redmond, WA
                new Forecast { Id = 1, Latitude = 47.674f, Longitude = -122.1215f, Temperature = 58.2f, TemperatureUnit = ETemperatureUnit.Fahrenheit },
                // Los Angeles
                new Forecast { Id = 2, Latitude = 34.0522f, Longitude = -118.2437f, Temperature = 71.6f, TemperatureUnit = ETemperatureUnit.Fahrenheit },
                // New York, NY
                new Forecast { Id = 3, Latitude = 40.7143f, Longitude = -74.006f, Temperature = 61.3f, TemperatureUnit = ETemperatureUnit.Fahrenheit },
                // Phoenix, AZ
                new Forecast { Id = 4, Latitude = 33.4484f, Longitude = -112.074f, Temperature = 90.1f, TemperatureUnit = ETemperatureUnit.Fahrenheit },
                // Mount Rainier
                new Forecast { Id = 5, Latitude = 38.9415f, Longitude = -76.965f, Temperature = 58.6f, TemperatureUnit = ETemperatureUnit.Fahrenheit }
            );
        }
    }
}