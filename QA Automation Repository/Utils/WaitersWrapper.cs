using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Utils
{
    public static class WaitersWrapper
    {
        public static void WaitElementVisiable(IWebDriver webDriver, By locator, int seconds)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitElementAppearDisappear(IWebDriver webDriver, By locator, int seconds)
        {
            WebDriverWait waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            waiter.Until(ExpectedConditions.ElementIsVisible(locator));
            waiter.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitElementInteractable(IWebDriver webDriver, By locator, int seconds)
        {
            WebDriverWait waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            waiter.Until(ExpectedConditions.ElementIsVisible(locator));
            waiter.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void Wait(int seconds)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }
    }
}
