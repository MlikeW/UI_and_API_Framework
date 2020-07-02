using System;
using CommonUtilities.Methods;
using UI.Pages.Base;
using UI.Pages.Home;
using UI.Pages.Interactions;
using UI.Pages.Widgets;
using UI.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.Tests.PageTests
{
    [TestFixture]
    class SimpleTests : BaseTest
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
