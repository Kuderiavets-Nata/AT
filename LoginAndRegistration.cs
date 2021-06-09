using System;
using OpenQA.Selenium.Appium.Android;

namespace qw.Page
{
    public class LoginAndRegistration
    {

        private readonly AndroidDriver<AndroidElement> driver;
        public LoginAndRegistration(AndroidDriver<AndroidElement> LoginAndRegistrationDriver)
        {
            driver = LoginAndRegistrationDriver;
        }

        protected AndroidElement userName => driver.FindElementById("com.example.myapplication:id/username");
        protected AndroidElement password => driver.FindElementById("com.example.myapplication:id/password");
        protected AndroidElement loginOrRegisterButton => driver.FindElementById("com.example.myapplication:id/login");
        protected AndroidElement PopUpUsername => driver.FindElementById("com.example.automationqa:id/ValidatorUsername");
        protected AndroidElement PopUpPassword => driver.FindElementById("com.example.automationqa:id/ValidatorPassword");

        public LoginAndRegistration ClickUserName()
        {
            userName.Click();
            return this;
        }

        public LoginAndRegistration ClickPassword()
        {
            password.Click();
            return this;
        }

        public LoginAndRegistration ClickLoginOrRegisterButton()
        {
            loginOrRegisterButton.Click();
            return this;
        }

        public LoginAndRegistration EnterUserName(string text)
        {
            userName.SendKeys(text);
            return this;
        }

        public LoginAndRegistration EnterPassword(string text)
        {
            password.SendKeys(text);
            return this;
        }

        public bool LoginOrRegisterButtonIsActive()
        {
            
            return loginOrRegisterButton.Enabled;
        }

        public string GetPopUpEmail()
        {
            return PopUpUsername.GetAttribute("text");
        }

        public string GetPopPassword()
        {
            return PopUpPassword.GetAttribute("text");
        }
    }
}
