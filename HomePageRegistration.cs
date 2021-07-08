using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SpecFlowWithSelenium.Pages
{
    public class HomePageRegistration : BasePage
    {
        public HomePageRegistration(IWebDriver driver) : base(driver) { }

        private readonly By registerLink = By.LinkText("REGISTER");
		private readonly By txtFirstName = By.CssSelector("input[name='firstName']");
        private readonly By txtLastName = By.CssSelector("input[name='lastName']");
		private readonly By txtMobilePhone = By.CssSelector("input[name='phone']");
		private readonly By txtEmail = By.CssSelector("input[name='userName']");
		
		private readonly By txtAddress = By.CssSelector("input[name='address1']");
        private readonly By txtCity = By.CssSelector("input[name='city']");
        private readonly By selectState = By.CssSelector("input[name='state']");
        private readonly By txtPostcode = By.CssSelector("input[name='postalCode']");
        private readonly By selectCountry = By.CssSelector("select[name='country']");
		
		private readonly By registerEmail = By.Id("email_create");
        private readonly By txtPassword = By.Id("passwd");
		private readonly By txtConfirmPassword = By.Id("confirmpasswd");
        
        public void RegisterClick()
        {
            WaitForElementToBeVisible(registerLink);
            Click(registerLink);
        }

        // public void EnterEmailId(string emailID)
        // {
            // WaitForElementToBeVisible(registerEmail);
            // SendKeys(registerEmail, emailID);
        // }

        // public void OpenRegisterForm()
        // {
            // Click(createRegisterButton);
        // }

        public void EnterRegistrationDetails(string title, string firstName, string lastName, string password, string dob, string address, string city, string state, string country, string postalcode, string mobilephone)
        {
            WaitForElementToBeVisible(titleGenderMale);
            if (title == "Mr")
            {
                var genderMale = GetRadioButtons(titleGenderMale).FirstOrDefault();
                genderMale.Click();
            }
            else
            {
                Click(titleGenderFeMale);
                var genderFeMale = GetRadioButtons(titleGenderFeMale).FirstOrDefault();
                genderFeMale.Click();
            }

            SendKeys(txtFirstName, firstName);
            SendKeys(txtLastName, lastName);
            SendKeys(txtPassword, password);

            // Parse day, month, year from DOB
            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            SelectElement day = GetSelectElement(selectDay);
            day.SelectByValue(dateTime.Day.ToString());

            SelectElement month = GetSelectElement(selectMonth);
            month.SelectByValue(dateTime.Month.ToString());

            SelectElement year = GetSelectElement(selectYear);
            year.SelectByValue(dateTime.Year.ToString());

            //SendKeys(addrTxtFirstName, firstName);
            //SendKeys(addrTxtLastName, lastName);
            SendKeys(txtAddress1, address);
            SendKeys(txtCity, city);

            SelectElement stateSelect = GetSelectElement(selectState);
            stateSelect.SelectByText(state);

            SendKeys(txtPostcode, postalcode);

            SelectElement countrySelect = GetSelectElement(selectCountry);
            countrySelect.SelectByText(country);

            SendKeys(txtMobilePhone, mobilephone);
        }
        public void SubmitRegistration()
        {
            Click(btnSubmitRegistration);
        }
    }
}
