
namespace TFLTechTest.Support
{
    public class readTestDataConfig
    {
        private static IConfigurationRoot? config { get; set; }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Support"))
                .AddJsonFile("Settings.json");

            config = builder.Build();

            return config;
        }

        public static Uri tflUrl = new Uri(GetConfiguration().GetValue<string>("Url:TFLUrl")!);
    }
}