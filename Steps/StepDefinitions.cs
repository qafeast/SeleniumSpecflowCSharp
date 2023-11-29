using TechTalk.SpecFlow;
using xyzBank.PageObjects.AddCustomerPage;
using xyzBank.Drivers;
using xyzBank.PageObjects.OpenAccountPage;
using xyzBank.PageObjects.DeleteAccountPage;

namespace xyzBank.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private readonly AddCustomerPage addCustomerPage;
        private readonly OpenAccountPage openAccountPage;
        private readonly DeleteAccountPage deleteAccountPage;

        public StepDefinitions(BrowserDriver browserDriver)
        {
            addCustomerPage = new AddCustomerPage(browserDriver.Current);
            openAccountPage = new OpenAccountPage(browserDriver.Current);
            deleteAccountPage = new DeleteAccountPage(browserDriver.Current);
        }

        [Given("Login to bank manager account")]
        public void LoginToBankManagerAccount()
        {
            addCustomerPage.ClickBankManagerLogInButton();
        }

        [Then("Navigate to add customer section")]
        public void NavigateToAddCustomerSection()
        {
            addCustomerPage.ClickAddCustomerTab();
        }

        [Then(@"Enter firstname as ""(.*)"" lastname as ""(.*)"" and postal code as ""(.*)""")]
        public void EnterFirstnameAsLastnameAsAndPostalCodeAs(string firstName, string lastName, string postalCode)
        {
            addCustomerPage.EnterFirstName(firstName);
            addCustomerPage.EnterLastName(lastName);
            addCustomerPage.EnterPostalCode(postalCode);
        }

        [When("Click add customer button")]
        public void ClickAddCustomerButton()
        {
            addCustomerPage.ClickAddCustomerButton();
            addCustomerPage.ClickOkButtonFromAlertPopup();
        }

        [Then(@"Customer ""(.*)"" ""(.*)"" should be added to the customer list")]
        public void CustomerShouldBeAddedToTheCustomerList(string firstName, string lastName)
        {
            addCustomerPage.ClickCustomersSection();
            addCustomerPage.VerifyCustomerAddedInCustomerTable(firstName, lastName);
        }

        [When("Navigate to the open account section")]
        public void NavigateToTheOpenAccountSection()
        {
            openAccountPage.ClickOpenAccountTab();
        }

        [Then(@"Select a customer name as ""(.*)"" ""(.*)""")]
        public void SelectACustomerNameAs(string firstName, string lastName)
        {
            openAccountPage.SelectACustomerName(firstName, lastName);
        }

        [Then(@"Select a currency ""(.*)""")]
        public void SelectACurrency(string currency)
        {
            openAccountPage.SelectACurrency(currency);
        }

        [When("Click the process button")]
        public void ClickTheProcessButton()
        {
            openAccountPage.ClickProcessButton();
        }

        [Then(@"The account should be added for the customer ""(.*)"" ""(.*)""")]
        public void TheAccountShouldBeAddedForTheCustomer(string firstName, string lastName)
        {
            openAccountPage.ClickOkButtonFromAlertPopup();
        }

        [Given("Navigate to the customers section")]
        public void NavigateToTheCustomersSection()
        {
            deleteAccountPage.ClickCustomersSection();
        }

        [When(@"Click the delete button of the user ""(.*)"" ""(.*)""")]
        public void ClickTheDeleteButtonOfTheUser(string firstName, string lastName)
        {
            deleteAccountPage.ClickDeleteButton(firstName, lastName);
        }

        [Then(@"The user ""(.*)"" ""(.*)"" account should be deleted")]
        public void TheUserAccountShouldBeDeleted(string firstName, string lastName)
        {
            deleteAccountPage.VerifyCustomerDeleted(firstName, lastName);
        }
    }
}


