using UI.Pages.Base;
using UI.Pages.Base.CommonParts;
using UI.Pages.Home;
using NUnit.Framework;
using OpenQA.Selenium;

namespace UI.Pages.TooltipAndDouble
{
    class TooltipAndDoublePage : BasePage
    {
        protected override string PageName { get; set; } = PageNames.TooltipAndDoublePageName;

        public TooltipAndDoublePage(IWebDriver driver) : base(driver)
        {
        }

        protected override void AssertPage()
            => Assert.True(Driver.GetElementByXpath(PageLocator).Displayed);

        public HomePage ClickHomeButton()
        {
            Driver.ClickOn(PageNames.HomePageName, Menus.MenuButton);
            return new HomePage(Driver);
        }
    }
}
