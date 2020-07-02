using NUnit.Framework;
using OpenQA.Selenium;
using UI.Driver;
using UI.Pages.Base;
using UI.Pages.Base.CommonParts;
using UI.Pages.Home;

namespace UI.Pages.Interactions
{
    public class InteractionsPage : BasePage
    {
        protected override string PageName { get; set; } = PageNames.InteractionsPageName;

        public InteractionsPage(IWebDriver driver) : base(driver)
        {
        }

        protected override void AssertPage()
            => Assert.True(Driver.GetElementByXpath(PageLocator).Displayed);

        public HomePage ClickHomeButton()
        {
            Driver.ClickOn(PageName, Menus.MenuButton);
            return new HomePage(Driver);
        }
    }
}
