using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public abstract class BasePageObject
    {
        protected IWebDriver _webDriver;

        protected BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
