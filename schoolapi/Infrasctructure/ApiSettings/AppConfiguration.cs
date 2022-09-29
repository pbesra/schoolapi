namespace schoolapi.Infrasctructure.ApiSettings
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfigurationSection _configurationSection;

        public AppConfiguration()
        {
            string p = @"C:\Users\Prakash.Besra\projects\schoolapi\schoolapi\Infrasctructure\ApiSettings\endpointsSettings\studentEndpoints.json";
            _configurationSection = new ConfigurationBuilder().AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, p), optional: false, reloadOnChange: false).Build().GetSection("_link");
        }

        public async Task Read()
        {
            var r = _configurationSection;
            var t = r.Value;
        }
    }
}