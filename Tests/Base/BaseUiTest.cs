using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using UI.Driver;
using UI.Pages.Home;

namespace Tests.Base
{
    internal class BaseUiTest : BaseTest
    {
        public virtual IWebDriver Driver { get; protected set; }
        private const string BaseUrl = "https://demoqa.com/";

        [SetUp]
        public void SetUpUi() => Driver = DriverConfig.GetDriver(DriverTypes.Chrome);

        [TearDown]
        public void TearDownUi() => Driver.Close();

        public static void NavigateToStartPage(IWebDriver driver, out HomePage page)
        {
            driver.Navigate(BaseUrl);
            page = new HomePage(driver);
        }
    }
}
