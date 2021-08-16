using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

namespace TestProject.Utils
{
    public class WaitersWrapper
    {
        private static WebDriverWait _waiter;
        
        public static void SetWaiter(IWebDriver webDriver, string waitingTime)
        {
            int convertedWaitingTime;
            try
            {
                convertedWaitingTime = Int32.Parse(waitingTime);
            }
            catch
            {
                LoggerWrapper.LogError($"Waiting time: {waitingTime} is an invalid value.");
                throw;
            }
            _waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(convertedWaitingTime));
        }

        public static void WaitElementVisiable(By locator)
        {
            _waiter.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitElementAppearDisappear(By locator)
        {
            _waiter.Until(ExpectedConditions.ElementIsVisible(locator));
            _waiter.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitElementInteractable(By locator)
        {
            _waiter.Until(ExpectedConditions.ElementIsVisible(locator));
            _waiter.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void Wait(int seconds)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }
    }
}
