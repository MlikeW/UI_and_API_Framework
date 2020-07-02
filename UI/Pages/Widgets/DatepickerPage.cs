using UI.Pages.Base;
using UI.Pages.Base.CommonParts;
using UI.Pages.Home;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Driver;

namespace UI.Pages.Widgets
{
    public class DatepickerPage : BasePage
    {
        protected override string PageName { get; set; } = PageNames.DatepickerPageName;
        private string _datePickerLocator = ".//*[contains(@class,'hasDatepicker')]";
        private IWebElement Date => Driver.GetElementByXpath(_datePickerLocator);
        public string DateValue => Driver. GetElementByXpath(_datePickerLocator).Text;

        public DatepickerPage(IWebDriver driver) : base(driver)
        {
        }

        protected override void AssertPage()
            => Assert.True(Driver.GetElementByXpath(PageLocator).Displayed);

        public HomePage ClickHomeButton()
        {
            Driver.ClickOn(PageName, Menus.MenuButton);
            return new HomePage(Driver);
        }

        public DatepickerPage PickDate(string fullDate)
        {
            Date.SendKeys(fullDate);
            return new DatepickerPage(Driver);
        }

        public DatepickerPage PickDate(string mm, string dd, string yyyy)
        {
            Date.SendKeys($"{mm}/{dd}/{yyyy}");
            return new DatepickerPage(Driver);
        }

    }
}
