using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class LoginPage
    {
        private IWebDriver webDriver;
        public LoginPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        private IWebElement signInButton => webDriver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailTextBox => webDriver.FindElement(By.Name("email"));
        private IWebElement passwordTextBox => webDriver.FindElement(By.Name("password"));
        private IWebElement loginButton => webDriver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void LoginActions(IWebDriver driver,string emailid,string password)
        {
            
            signInButton.Click();
            emailTextBox.SendKeys(emailid);
            wait.Waittobevisible(driver, "Name", "password", 5); 
            passwordTextBox.SendKeys(password);
            loginButton.Click();
        }
    }
}
