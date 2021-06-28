using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace LinkGroup.DemoTests
{
    public class Utils
    {
        private readonly int timeout = 10;

        public IWebDriver Driver;
        public Utils(IWebDriver driver)
        {
            Driver = driver;
        }

        public WebDriverWait wait;
        public Actions actions;
        public SelectElement select;

        public void NavigateToURL(string URL)
        {
            try
            {
                Driver.Navigate().GoToUrl(URL);
            }
            catch (Exception ex)
            {
                throw new Exception("URL did not load");
            }
        }
        public string GetPageTitle()
        {
            try
            {
                return Driver.Title;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Current page title is: {0}", Driver.Title));
            }
        }
        public string GetCurrentURL()
        {
            try
            {
                return Driver.Url;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Current URL is: {0}", Driver.Url));
            }
        }
        public IWebElement GetElement(By selector)
        {
            try
            {
                return Driver.FindElement(selector);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Element {0} does not exist - proceeding", selector));
            }
        }
        public void Click(By selector)
        {
            IWebElement element = GetElement(selector);
            WaitForElementToBeClickable(selector);
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("The following element is not clickable: {0}", selector));
            }
        }
        public void WaitForElementToBeClickable(By selector)
        {
            try
            {
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("The following element is not clickable: {0}", selector));
            }
        }
        public void WaitForElementToBeVisible(By selector)
        {
            try
            {
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(selector));
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("The following element is not visible: {0}", selector));
            }
        }
        public void ScrollToThenClick(By selector)
        {
            IWebElement element = Driver.FindElement(selector);
            actions = new Actions(Driver);
            try
            {
                actions.MoveToElement(element).Perform();
                actions.Click(element).Perform();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("The following element is not clickable: {0}", selector));
            }
        }
        public void SendKeys(By selector, String value)
        {
            IWebElement element = GetElement(selector);
            element.Clear();
            try
            {
                element.SendKeys(value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in sending {0} to the following element: {0}", value, selector.ToString()));
            }
        }
        public IList<IWebElement> GetElements(By Selector)
        {
            WaitForElementToBeVisible(Selector);
            try
            {
                return Driver.FindElements(Selector);
            }
            catch (Exception e)
            {
                throw new NoSuchElementException(string.Format("The following element did not display: {0}", Selector.ToString()));
            }
        }
        public List<string> GetListOfElementTexts(By selector)
        {
            List<string> elementList = new List<string>();
            IList<IWebElement> elements = GetElements(selector);

            foreach (IWebElement element in elements)
            {
                if (element == null)
                {
                    throw new Exception("Some elements in the list do not exist");
                }
                if (element.Displayed)
                {
                    elementList.Add(element.Text.Trim());
                }
            }
            return elementList;
        }
    }
}
