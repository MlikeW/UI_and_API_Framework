using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UI.Driver
{
    public class DriverConfig
    {
        public static IWebDriver GetDriver(DriverTypes driverName)
            => driverName switch
            {
                DriverTypes.Chrome => new ChromeDriver(),
                DriverTypes.Firefox => new FirefoxDriver(),
                _ => throw new NotImplementedException("There is no such driver in project.")
            };

        }
}