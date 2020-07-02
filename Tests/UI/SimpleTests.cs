using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Base;
using UI.Pages.Home;
using UI.Pages.Interactions;
using UI.Pages.Widgets;

namespace Tests.UI
{
    [TestFixture]
    class SimpleTests : BaseUiTest
    {
        private HomePage _homePage;
        private InteractionsPage _interactionsPage;
        private WidgetsPage _widgetsPage;
        public override IWebDriver Driver { get; protected set; }

        [Test]
        public void NavigateToHomeAndInteractionsPagesTest()
        {
            NavigateToStartPage(Driver, out _homePage);
            _homePage = _homePage.ClickHomeButton();
            _interactionsPage = _homePage.ClickInteractionsButton();
        }

        [Test]
        public void NavigateToHomeAndWidgetsPagesTest()
        {
            NavigateToStartPage(Driver, out _homePage);
            _homePage = _homePage.ClickHomeButton();
            _widgetsPage = _homePage.ClickWidgetsButton();
        }

        [Test]
        public void NavigateToPagesTest()
        {
            NavigateToStartPage(Driver, out _homePage);
            _homePage = _homePage.ClickHomeButton();
            _widgetsPage = _homePage.ClickWidgetsButton();
        }
    }
}