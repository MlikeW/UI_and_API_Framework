﻿using NUnit.Framework;
using OpenQA.Selenium;
using UI.Driver;
using UI.Pages.Base;
using UI.Pages.Base.CommonParts;
using UI.Pages.Interactions;
using UI.Pages.Widgets;

namespace UI.Pages.Home
{
    public class HomePage : BasePage
    {
        protected override string PageName { get; set; } = PageNames.HomePageName;

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        protected override void AssertPage()
            => Assert.True(Driver.GetElementBy(By.XPath(PageLocator)).Displayed);
        
        public HomePage ClickHomeButton()
        {
            Driver.ClickOn(PageName, Menus.MenuButton);
            return this;
        }

        public InteractionsPage ClickInteractionsButton()
        {
            Driver.ClickOn(PageNames.InteractionsPageName, Menus.MenuButton);
            return new InteractionsPage(Driver);
        }

        public WidgetsPage ClickWidgetsButton()
        {
            Driver.ClickOn(PageNames.WidgetsPageName, Menus.MenuButton);
            return new WidgetsPage(Driver);
        }

    }
}
