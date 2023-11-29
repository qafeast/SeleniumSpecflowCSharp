using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace xyzBank.PageObjects.OpenAccountPage
{
    public class OpenAccountPage(IWebDriver webDriver) : BasePage.BasePage(webDriver)
    {
        public void ClickOpenAccountTab()
        {
            Click(By.CssSelector("button[ng-click='openAccount()']"), "Open account tab", 20000);
        }

        public void SelectACustomerName(string firstName, string lastName)
        {
            SelectByText(By.CssSelector("select#userSelect"), $"{firstName} {lastName}", "Customer name", 20000);
        }

        public void SelectACurrency(string currency)
        {
            SelectByValue(By.CssSelector("select#currency"), currency, "Currency", 20000);
        }

        public void ClickProcessButton()
        {
            Click(By.CssSelector("button[type='submit']"), "Procces button", 20000);
        }
        public void ClickOkButtonFromAlertPopup()
        {
            FindAlertPopUp(10);
            IAlert alertPopup = SwitchToAlertPopup();
            string alertMessage = alertPopup.Text;
            alertPopup.Accept();
            if (alertMessage.Contains("Account created successfully", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"{alertMessage} is displayed");
            }
            else
            {
                Console.WriteLine($"{alertMessage} is displayed");
            }
        }
    }
}