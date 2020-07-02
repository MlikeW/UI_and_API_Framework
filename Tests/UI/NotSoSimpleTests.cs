using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Base;
using UI.Pages.Home;
using UI.Pages.Widgets;

namespace Tests.UI
{
    [TestFixture]
    class NotSoSimpleTests : BaseUiTest
    {
        private const string FullDate = "11/11/2018";
        private const string Medium = "Medium";
        private const string Slow = "Slow";
        private HomePage _homePage;
        private WidgetsPage _widgetsPage;
        private DatepickerPage _datepickerPage;
        private SelectmenuPage _selectmenuPage;
        public override IWebDriver Driver { get; protected set; }

        [Test]
        public void FullDatepickerTest()
        {
            NavigateToStartPage(Driver, out _homePage);
            _homePage = _homePage.ClickHomeButton();
            _widgetsPage = _homePage.ClickWidgetsButton();
            _datepickerPage = _widgetsPage.ClickDatepickerButton();
            _datepickerPage.PickDate(FullDate);
        }

        [Test]
        public void SpeedMediumTest()
        {
            NavigateToStartPage(Driver, out _homePage);
            _homePage = _homePage.ClickHomeButton();
            _widgetsPage = _homePage.ClickWidgetsButton();
            _selectmenuPage = _widgetsPage.ClickSelectmenuButton();
            Assert.AreEqual(Medium, _selectmenuPage.SelectmenuSpeedText);
        }

        [Test]
        public void SpeedSlowTest()
        {
            NavigateToStartPage(Driver, out _homePage);
            _homePage = _homePage.ClickHomeButton();
            _widgetsPage = _homePage.ClickWidgetsButton();
            _selectmenuPage = _widgetsPage.ClickSelectmenuButton();
            _selectmenuPage = _selectmenuPage.ChooseSpeed(Slow);
            Assert.AreEqual(Slow, _selectmenuPage.SelectmenuSpeedText);
        }
    }
}
