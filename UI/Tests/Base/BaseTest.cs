using UI.Pages.Base;
using UI.Pages.Base.Config;
using UI.Pages.Home;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;

namespace UI.Tests.Base
{
    [DebuggerStepThrough]
    class BaseTest
    {
        public virtual IWebDriver Driver { get; protected set; }
        private readonly Stopwatch _testStopwatch = new Stopwatch();
        private readonly Stopwatch _testSuiteStopwatch = new Stopwatch();

        private string Name => TestContext.CurrentContext.Test.FullName.Split('.').Last();
        private string Result => TestContext.CurrentContext.Result.Outcome.Status.ToString();
        private const string Type = " Suite";
        private const string BaseUrl = "https://demoqa.com/";

        [OneTimeSetUp]
        public void SetUpTestSuite()
            => StartTimer(_testSuiteStopwatch, Type);

        [OneTimeTearDown]
        public void TearDownTestSuite()
            => StopTimer(_testSuiteStopwatch, Type);

        [SetUp]
        public void SetUp()
        {
            Driver = DriverConfig.GetDriver(DriverTypes.Chrome);
            StartTimer(_testStopwatch);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            StopTimer(_testStopwatch);
        }

        private void StartTimer(Stopwatch sw, string type = "")
        {
            sw.Reset();
            Console.WriteLine($"Test{type} '{Name}' is running...");
            sw.Start();
        }

        private void StopTimer(Stopwatch sw, string type = "")
        {
            sw.Stop();
            Console.WriteLine($"Test{type} '{Name}' done in {sw.ElapsedMilliseconds} ms.\nResult: {Result}");
        }

        public static void NavigateToStartPage(IWebDriver driver, out HomePage _page)
        {
            driver.Navigate(BaseUrl);
            _page = new HomePage(driver);
        }
    }

}
