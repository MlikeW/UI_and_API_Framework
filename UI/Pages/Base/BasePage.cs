using OpenQA.Selenium;
using System;
using static System.String;

namespace UI.Pages.Base
{
    abstract class BasePage
    {
        private const string CommonPageLocator = ".//*[contains(@class,'entry-title') and contains(text(),'{0}')]";
        protected abstract string PageName { get; set; }
        protected string PageLocator { get; set; }
        protected IWebDriver Driver { get; set; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageLocator = Format(CommonPageLocator, PageName); // That's an interesting solution. Didn't see this coming... In a good way)
            AssertPage();
            Console.WriteLine($" Now I'm in '{PageName}' Page.\n\tTitle: '{Driver.Title}'.");
        }

        protected abstract void AssertPage();
    }
}
