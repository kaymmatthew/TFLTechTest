﻿
namespace TFLTechTest.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer container;
        public Hooks(IObjectContainer _container)
        {
            container = _container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs(driver);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
            using (var process = Process.GetCurrentProcess())
            {
                if (process.ToString() == "chromedriver")
                {
                    process.Kill(true);
                }
                driver?.Dispose(); driver = null;
            }
        }
    }
}
