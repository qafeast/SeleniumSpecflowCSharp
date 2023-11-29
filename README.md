## Specflow with C# and NUnit

#### Installation Guide:
1. Create a new folder and open a cmd from the ceated folder path
2. Install .Net sdk latest version on system
3. Use the below command to install a sample project template
`dotnet new specflowproject`
4. Install the below packages using NuGet package manager
	- Selenium.Support - Main package for Selenium
	- Selenium.WebDriver.ChromeDriver - Package that contains the ChromeDriver so Selenium is able to control the Chrome browser
	- Selenium.WebDriver - This ist to manipulate the browsers
	- DotNetSeleniumExtras.WaitHelpers - Provides an implementation of the ExpectedConditions class for use with WebDriverWait in .NET
5. After all these installation we can start write the test in feature file
------------
#### Execution Guide:
1. `dotnet test`
This command will run all the test scenarios
2. `dotnet test --logger:"console;verbosity=detailed"`
This command will run all the test scenarios and specify a logger for test results in detail
3. `dotnet test --filter Category=addcustomer`
This command will run the scenarios that tagged with @addcustomer