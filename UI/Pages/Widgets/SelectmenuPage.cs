using UI.Pages.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Driver;
using static System.String;

namespace UI.Pages.Widgets
{
    public class SelectmenuPage : BasePage
    {
        private enum SelectmenuFields
        {
            speed,
            files,
            number,
            salutation
        }

        protected override string PageName { get; set; } = PageNames.SelectmenuPageName;
        private const string SelectmenuLocator = ".//*[contains(@id,'{0}-button')]//*[contains(@class,'ui-selectmenu-text')]";
        private const string ChooseMenu = ".//*[contains(@id,'{0}-menu')]//*[text()='{1}']";

        protected IWebElement SelectmenuSpeed => Driver.GetElementByXpath(Format(SelectmenuLocator, SelectmenuFields.speed.ToString())); // That's a neat solution
        protected IWebElement SelectmenuFile => Driver.GetElementByXpath(Format(SelectmenuLocator, SelectmenuFields.files.ToString()));
        protected IWebElement SelectmenuNumber => Driver.GetElementByXpath(Format(SelectmenuLocator, SelectmenuFields.number.ToString()));
        protected IWebElement SelectmenuTitle => Driver.GetElementByXpath(Format(SelectmenuLocator, SelectmenuFields.salutation.ToString()));
        public string SelectmenuSpeedText => SelectmenuSpeed.Text;
        public string SelectmenuFileText => SelectmenuFile.Text;
        public string SelectmenuNumberText => SelectmenuNumber.Text;
        public string SelectmenuTitleText => SelectmenuTitle.Text;

        public SelectmenuPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement GetElementByFieldName(SelectmenuFields field) => Driver.GetElementByXpath(Format(SelectmenuLocator, field.ToString()));

        protected override void AssertPage()
            => Assert.True(Driver.GetElementByXpath(PageLocator).Displayed);

        public SelectmenuPage SetSpeed()
        {
            SelectmenuSpeed.ClickOnElement();
            return this;
        }

        public SelectmenuPage ChooseSpeed(string choice)
        {
            SelectmenuFields v = SelectmenuFields.speed;
            SelectmenuSpeed.ClickOnElement();
            Driver.GetElementByXpath(Format(ChooseMenu, SelectmenuFields.speed.ToString(), choice)).ClickOnElement();
            return this;
        }
    }
}
