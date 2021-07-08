using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowWithSelenium.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.Specs.Steps
{
    [Binding]
    public class AutomationPracticeSteps : BasePage
    {
        private HomePageAutomationPracticePage homePage;
        private const string SiteUrl = "http://demo.guru99.com/test/newtours/";
        public AutomationPracticeSteps(IWebDriver driver) : base(driver)
        {
            homePage = new HomePageAutomationPracticePage(driver);
        }
        [Given(@"user has navigated to website")]
        public void GivenUserHasNavigatedToWebsite()
        {
            homePage.NavigateToURL(SiteUrl);
        }
        
        [Given(@"clicks on sign in button")]
        public void GivenClicksOnSignInButton()
        {
            homePage.SignInClick();
        }
        
        [When(@"enters a valid (.*) for registration")]
        public void WhenEntersAValidEmailForRegistration(string emailID)
        {
            homePage.EnterEmailId(emailID);
        }
        
        [When(@"click on register")]
        public void WhenClickOnRegister()
        {
            homePage.OpenRegisterForm();
        }
        
        [When(@"fill registration details (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenFillRegistrationDetails(string title, string firstName, string lastName, string password, string dob, string address, string city, string state, string country, string postalcode, string mobilephone)
        {
            homePage.EnterRegistrationDetails(title, firstName, lastName, password, dob, address, city, state, country, postalcode, mobilephone);
        }
        
        [When(@"click on register button")]
        public void WhenClickOnRegisterButton()
        {
            homePage.SubmitRegistration();
        }
        
        [Then(@"registration is successful")]
        public void ThenRegistrationIsSuccessful()
        {
            // Verify registration is successfull and redirect to My account page
            StringAssert.Contains("My account", GetPageTitle());
        }
    }
}
