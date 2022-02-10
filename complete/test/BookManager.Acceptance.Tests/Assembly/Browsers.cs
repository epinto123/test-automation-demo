using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace BookManager.Acceptance.Tests.Assembly
{
    public static class Browsers
    {
        private static IWebDriver webDriver;
        private static WebDriverWait Wait;
        private static string browser = "Chrome";

        public static void Init(string remoteAddress)
        {
            switch (browser)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("--auto-open-devtools-for-tabs");
                    chromeOptions.AddArguments("ignore-certificate-errors");
                    webDriver = new RemoteWebDriver(new Uri(remoteAddress), chromeOptions);
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public static IWebDriver WebDriver => webDriver ?? throw new NullReferenceException("Web driver is null");

        public static void Goto(string url)
        {
            if (url.StartsWith("http"))
            {
                WebDriver.Navigate().GoToUrl(url);
            }
            else
            {
                webDriver.Navigate().GoToUrl($"{webDriver.Url}{url}");
            }
        }
        public static void Close()
        {
            webDriver.Quit();
        }

        public static IWebElement RenderElement(this By by)
        {
            return Wait.Until(webDriver => webDriver.FindElement(by));
        }

        public static ReadOnlyCollection<IWebElement> RenderElements(this By by)
        {
            return Wait.Until(webDriver => webDriver.FindElements(by));
        }
    }
}
