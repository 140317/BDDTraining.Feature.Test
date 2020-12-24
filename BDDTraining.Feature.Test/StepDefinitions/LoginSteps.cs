using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BDDTraining.Feature.Test.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _context;
        private IWebDriver _webDriver;

        public LoginSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = new ChromeDriver(@"C:\Users\ustdn18\Downloads\chromedriver_win32");


        }
        [Given(@"the correct username as '(.*)'")]
        public void GivenTheCorrectUsernameAs(string username)
        {
            _webDriver.Navigate().GoToUrl("https://github.com/login?return_to=%2F140317");
            System.Threading.Thread.Sleep(4000);
            IWebElement usernameField = _webDriver.FindElement(By.Name("login"));
            usernameField.SendKeys(username);
        }

        [Given(@"the correct password is '(.*)'")]
        public void GivenTheCorrectPasswordIs(string pwd)
        {
            IWebElement pwdField = _webDriver.FindElement(By.Name("password"));
            pwdField.SendKeys(pwd);
        }

        [When(@"I click on the submit button")]
        public void WhenIClickOnTheSubmitButton()
        {

            IWebElement btn = _webDriver.FindElement(By.Name("commit"));
            btn.Click();
        }

        [Then(@"I will be redirected to the Home page")]
        public void ThenIWillBeRedirectedToTheHomePage()
        {

        }

    }
}
