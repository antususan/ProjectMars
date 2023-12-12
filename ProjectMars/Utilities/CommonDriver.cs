using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMars.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace ProjectMars.Utilities
{

    public class CommonDriver
    {
        public static IWebDriver driver;
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

        }
        public void Close()
        {
            driver.Close();
        }
      

    }

    
}







