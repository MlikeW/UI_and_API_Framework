using CommonUtilities.Methods;
using CommonUtilities.Methods.CustomAttributes;
using OpenQA.Selenium;
using System;

namespace UI.Pages.Base
{
    public  static class BaseDriver
    {
        private const int DefaultTimeOutSec = 10;

        public static IWebElement GetElementBy(this ISearchContext rootElement, By locator, int timeOutSec = DefaultTimeOutSec)
            => TryCatchMethods.TryCatchReturn(() => rootElement?.FindElement(locator), timeOutSec);

        public static IWebElement GetElementByXpath(this ISearchContext rootElement, string xpath, int timeOutSec = DefaultTimeOutSec)
            => rootElement.GetElementBy(By.XPath(xpath), timeOutSec);

        public static void ClickOnElement(this IWebElement element, int timeOutSec = DefaultTimeOutSec)
            => TryCatchMethods.TryCatchVoid(element.Click, timeOutSec);

        public static void Navigate(this IWebDriver driver, string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        public static void ClickOn(this IWebDriver driver, string name, Enum menuType)
            => driver.GetElementByXpath(
                string.Format(menuType.GetEnumSinglePropertyValue<XPathAttribute>(), name)
                ).ClickOnElement();

        public static void ConditionIsTrue(Func<bool> condition, string conditionDescription = "Condition", int timeoutSec = 15)
        {
            void IsResultTrue()
            {
                if (!condition())
                {
                    throw new Exception();
                }
            }

            TryCatchMethods.TryCatchVoid(IsResultTrue, timeoutSec, $"{conditionDescription} was not true after timeout.");
        }

        public static void ElementClickable(this IWebElement element)
        {
            bool Condition() => element != null && element.Displayed && element.Enabled;
            ConditionIsTrue(Condition);
        }
    }
}
