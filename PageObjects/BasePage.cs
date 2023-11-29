using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace xyzBank.PageObjects.BasePage
{
    public class BasePage(IWebDriver webDriver)
    {
        private readonly IWebDriver driver = webDriver;

        public void Click(By by, string name, int timeInMills)
        {
            try
            {
                IsVisible(by, timeInMills);
                driver.FindElement(by).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(name + " isn't clicked");
                Assert.Fail(e.Message);
            }
        }
        public void SelectByValue(By by, string value, string name, int timeInMills)
        {
            try
            {
                IsVisible(by, timeInMills);
                var dropdown = driver.FindElement(by);
                var selectElement = new SelectElement(dropdown);
                selectElement.SelectByValue(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(name + "option isn't selected");
                Assert.Fail(e.Message);
            }

        }

        public void SelectByText(By by, string text, string name, int timeInMills)
        {
            try
            {
                IsVisible(by, timeInMills);
                var dropdown = driver.FindElement(by);
                var selectElement = new SelectElement(dropdown);
                selectElement.SelectByText(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(name + "option isn't selected");
                Assert.Fail(e.Message);
            }
        }
        public void Enter(By by, string value, string name, int timeInMills)
        {
            try
            {
                IsVisible(by, timeInMills);
                driver.FindElement(by).SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(name + " isn't clicked");
                Assert.Fail(e.Message);
            }
        }
        public bool IsVisible(By by, int timeInMills)
        {
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromMilliseconds(timeInMills));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsExist(By by, int timeInMills)
        {
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromMilliseconds(timeInMills));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IAlert FindAlertPopUp(int TimeInSec)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(TimeInSec)).Until(ExpectedConditions.AlertIsPresent());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in finding ALert popup " + e);
                return null;
            }
        }
        public IAlert SwitchToAlertPopup()
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error switch to ALert popup " + e);
                return null;
            }
        }
    }
}