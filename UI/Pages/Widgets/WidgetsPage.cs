using UI.Pages.Base;
using UI.Pages.Base.CommonParts;
using UI.Pages.Home;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Driver;

namespace UI.Pages.Widgets
{
    public class WidgetsPage : BasePage
    {
        protected override string PageName { get; set; } = PageNames.WidgetsPageName;

        public WidgetsPage(IWebDriver driver) : base(driver)
        {
        }

        protected override void AssertPage()
            => Assert.True(Driver.GetElementByXpath(PageLocator).Displayed);

        public HomePage ClickHomeButton()
        {
            Driver.ClickOn(PageNames.HomePageName, Menus.MenuButton);
            return new HomePage(Driver);
        }

        public DatepickerPage ClickDatepickerButton()
        {
            Driver.ClickOn(PageNames.DatepickerPageName, Menus.SubMenuButton);
            return new DatepickerPage(Driver);
        }

        public SelectmenuPage ClickSelectmenuButton()
        {
            Driver.ClickOn(PageNames.SelectmenuPageName, Menus.SubMenuButton);
            return new SelectmenuPage(Driver);
        }
    }
}
