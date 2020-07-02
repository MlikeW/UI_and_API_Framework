using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UI.Pages.Base.Config
{
    class DriverConfig
    {
        public static IWebDriver GetDriver(DriverTypes driverName)
            => driverName switch
            {
                DriverTypes.Chrome => (IWebDriver) new ChromeDriver(),
                DriverTypes.Firefox => new FirefoxDriver(),
                _ => new ChromeDriver()
            };

        }
}
