using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using xyzBank.Drivers;

namespace xyzBank.Hooks
{
    [Binding]
    public class MyHooks()
    {
        private static IWebDriver driver;

        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            //Initialize a shared BrowserDriver in  global and we cannot do a parallel execution when using this
            testThreadContainer.BaseContainer.Resolve<BrowserDriver>();
        }

        [BeforeScenario]
        //This will run before each scenario
        public static void NavigateToUrl(BrowserDriver browserDriver)
        {
            driver = browserDriver.Current;
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login");
        }
    }
}
