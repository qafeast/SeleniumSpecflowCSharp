using System;
using OpenQA.Selenium;

namespace xyzBank.PageObjects.AddCustomerPage
{
    public class AddCustomerPage(IWebDriver webDriver) : BasePage.BasePage(webDriver)
    {
        public void ClickBankManagerLogInButton()
        {
            Click(By.CssSelector("button[ng-click*='manager']"), "Customer Login button", 20000);
        }

        public void ClickAddCustomerTab()
        {
            Click(By.CssSelector("button[ng-click*='addCust']"), "Add Customer tab", 20000);
        }

        public void EnterFirstName(string firstName)
        {
            Enter(By.CssSelector("input[ng-model='fName']"), firstName, "First name", 20000);
        }

        public void EnterLastName(string lastName)
        {
            Enter(By.CssSelector("input[ng-model='lName']"), lastName, "Last name", 20000);
        }

        public void EnterPostalCode(string postalCode)
        {
            Enter(By.CssSelector("input[ng-model='postCd']"), postalCode, "Postal code", 20000);
        }

        public void ClickAddCustomerButton()
        {
            Click(By.CssSelector("form[ng-submit*='addCustomer'] button[type='submit']"), "Add Customer button", 20000);
        }

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

        public void VerifyCustomerAddedInCustomerTable(string firstName, string lastName)
        {
            if (IsVisible(By.XPath($"//table[@class='table table-bordered table-striped']//td[text()='{firstName}']//following-sibling::td[text()='{lastName}']"), 20000))
            {
                Console.WriteLine($"{firstName} {lastName} is displayed in the table");
            }
            else
            {
                Console.WriteLine($"{firstName} {lastName} is not displayed in the table");
            }
        }
    }
}