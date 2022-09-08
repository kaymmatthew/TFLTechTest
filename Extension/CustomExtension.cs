using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLTechTest.Extension
{
    public static class CustomExtension
    {
        /// <summary>
        /// This method allow to click an element via javascript
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void ClickViaJs(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoview(true)", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.Click();
        }
        /// <summary>
        /// This method allows for scrolling into view and enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, IWebDriver driver, string value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.SendKeys(value);
        }
        /// <summary>
        /// This method allows to wait for element.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="timeOut"></param>
        public static void WaitFor(this IWebDriver driver, int timeOut)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeOut));
        }

        /// <summary>
        /// This method allows to wait for element.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="timeOut"></param>
        public static void MilliSec(this IWebDriver driver, int timeOut)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(timeOut));
        }

        /// <summary>
        /// This method allows to wait for element.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="timeOut"></param>
        public static void Implicit(this IWebDriver driver, int timeOut)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
        }

        /// <summary>
        /// This method allows to wait untill the element is located
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static IWebElement FindThisElement(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(x => x.FindElement(by));
        }
    }
}