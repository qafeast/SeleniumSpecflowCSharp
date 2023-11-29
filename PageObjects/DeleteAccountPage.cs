using System;
using OpenQA.Selenium;

namespace xyzBank.PageObjects.DeleteAccountPage
{
    public class DeleteAccountPage(IWebDriver webDriver) : BasePage.BasePage(webDriver)
    {
        public void ClickOkButtonFromAlertPopup()
        {
            FindAlertPopUp(10);
            IAlert alertPopup = SwitchToAlertPopup();
            string alertMessage = alertPopup.Text;
            alertPopup.Accept();
            if (alertMessage.Contains("added successfully", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"{alertMessage} is displayed");
            }
            else
            {
                Console.WriteLine($"{alertMessage} is displayed");
            }
        }
        public void ClickCustomersSection()
        {
            Click(By.CssSelector("button[ng-click*='showCust']"), "Customers tab", 20000);
        }
        public void SearchCustomer(string customerName)
        {
            Enter(By.CssSelector("input[ng-model='searchCustomer']"), customerName, "search", 20000);
        }
        public void ClickDeleteButton(string firstName, string lastName)
        {
            Click(By.XPath($"//table[@class='table table-bordered table-striped']//td[text()='{firstName}']/../td[text()='{lastName}']/../td/button"), "Delete button", 20000);
        }

        public void VerifyCustomerDeleted(string firstName, string lastName)
        {
            if (!IsExist(By.XPath($"//table[@class='table table-bordered table-striped']//td[text()='{firstName}']//following-sibling::td[text()='{lastName}']"), 5000))
            {
                Console.WriteLine($"The user {firstName} {lastName} is not displayed in the table");
            }
            else
            {
                Console.WriteLine($"The user{firstName} {lastName} is displayed in the table");
            }
        }
    }
}