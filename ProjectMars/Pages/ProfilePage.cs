using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProjectMars.Pages
{
    public class ProfilePage:CommonDriver
    {
        private IWebDriver webDriver;
        public ProfilePage()
        {
            webDriver = driver;
        }
        private IWebElement languageTab => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
        private IWebElement skillTab => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private IWebElement addNewButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement addLanguageTextBox => webDriver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement languageLevelDropdown => webDriver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement chooseBasicLanguageLevel => webDriver.FindElement(By.CssSelector("option[value='Basic']"));
        private IWebElement chooseFluentLanguageLevel => webDriver.FindElement(By.CssSelector("option[value='Fluent']"));
        private IWebElement chooseConversationalLanguageLevel => webDriver.FindElement(By.CssSelector("option[value='Conversational']"));
        private IWebElement chooseNBlLanguageLevel => webDriver.FindElement(By.CssSelector("option[value='Native/Bilingual']"));
        private IWebElement addButtonLanguage => webDriver.FindElement(By.XPath("//input[@class='ui teal button']"));
        private IWebElement newLanguage => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement newLevel => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement invalidLanguage => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        private IWebElement existingLanguage => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        private IWebElement editButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private IWebElement editTextBox => webDriver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement updateButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
        private IWebElement newEditLanguage => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement newEditLevel => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement deleteLanguageButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
        private IWebElement deletedLanguageData => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));

        public void GotoLanguageTab()
        {
            Thread.Sleep(2000);
            //wait.Waittobeclickable(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 5);         
            languageTab.Click();
        }
        public void GotoSkillsTab()
        {
            //wait.Waittobeclickable(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 2);
            Thread.Sleep(2000);
            skillTab.Click();
        }
        public void ResetLanguageRow()
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")).Count;
            
            for (int i = 0; i < rowCount; i++)
            {
                //Thread.Sleep(2000);
                Thread.Sleep(2000);
                deleteLanguageButton.Click();
            }
        }
        public void CreateLanguageRecord(string language ,string level)
        {

            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);

            addNewButton.Click();
  
            wait.Waittobevisible(driver, "Xpath", "//input[@placeholder='Add Language']",2);
            
            addLanguageTextBox.SendKeys(language);
            
            languageLevelDropdown.Click();
            if (level == "Basic")
            {            
                chooseBasicLanguageLevel.Click();
            }
            if(level == "Fluent")
            {               
                chooseFluentLanguageLevel.Click();
            }
            if(level == "Conversational")
            {               
                chooseConversationalLanguageLevel.Click();
            }
            if (level == "Native/Bilingual")
            {               
                chooseNBlLanguageLevel.Click();
            }
            addButtonLanguage.Click();
            Thread.Sleep(2000);
           }
        public string GetLanguage()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            return newLanguage.Text;
        }
        public string GetLevel()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 2);
            return newLevel.Text;
        }
        public string GetInvalidLanguage()
        {
            wait.Waittobevisible(driver,"Xpath", "//*[@class='ns-box-inner']", 2);
            return invalidLanguage.Text;
        }
        public string GetExistingLanguage()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@class='ns-box-inner']", 2);
            return existingLanguage.Text;
        }
      
        public void EditLanguageRecord( string editlanguage, string editlevel)
        {

            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 2);
            editButton.Click();
            editTextBox.Clear();
            editTextBox.SendKeys(editlanguage);
            languageLevelDropdown.Click();

            if (editlevel == "Conversational") 
            {
                chooseConversationalLanguageLevel.Click();
            }
            if (editlevel == "Native/Bilingual")
            {
                chooseNBlLanguageLevel.Click();
            }
            if (editlevel == "Basic")
            {
                chooseBasicLanguageLevel.Click();
            }
            if (editlevel == "Fluent")
            {
                chooseFluentLanguageLevel.Click();
            }
                                                     
            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]", 2); 
            updateButton.Click();
        }
            public string GetEditLanguage()
            {
            Thread.Sleep(2000);
            return newEditLanguage.Text;
            }
            public string GetEditLevel()
            {
            Thread.Sleep(2000);                                                      
            return newEditLevel.Text;
            }
        public void DeleteLanguageRecord()
        {
            Thread.Sleep(2000);
            deleteLanguageButton.Click();
            Thread.Sleep(2000);
        }
        public string GetDeleteLanguage()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@class='ns-box-inner']", 2);
            return deletedLanguageData.Text;
        }

        //skill Tab 
        private IWebElement skillsButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private IWebElement addNewSkillsButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement addNewSkillsTextBox => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        private IWebElement chooseSkillsLevelDropdown => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
        private IWebElement chooseSkillLevelBeginner => webDriver.FindElement(By.CssSelector("option[value='Beginner']"));
        private IWebElement chooseSkillLevelIntermediate => webDriver.FindElement(By.CssSelector("option[value='Intermediate']"));
        private IWebElement chooseSkillLevelExpert => webDriver.FindElement(By.CssSelector("option[value='Expert']"));
        private IWebElement addSkillsButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private IWebElement newSkill => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement newSkillLevel => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement invalidSkill => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        private IWebElement existingSkill => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        private IWebElement editSkillsButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
        private IWebElement editSkillsTextBox => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
        private IWebElement editSkillsLevelDropdown => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
        private IWebElement chooseEditSkillsLevel => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select/option[3]"));
        private IWebElement updateSkillsButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
        private IWebElement newEditSkill => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement newEditSkillLevel => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement deleteSkillButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
        private IWebElement deletedSkillData => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));

        public void ResetSkillRow()
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr")).Count;
            for (int i = 0; i < rowCount; i++)
            {
                Thread.Sleep(2000);
                deleteSkillButton.Click();
            }
        }
        public void CreateSkillsRecords(String skill ,string level)
        {
            skillsButton.Click();
            addNewSkillsButton.Click();
            addNewSkillsTextBox.SendKeys(skill);
           
            chooseSkillsLevelDropdown.Click();

            if (level == "Beginner") 
            {
                chooseSkillLevelBeginner.Click();
            }
            if (level == "Intermediate")
            {   
                chooseSkillLevelIntermediate.Click();
            }
            if (level == "Expert")
            {
                chooseSkillLevelExpert.Click();
            }           
            addSkillsButton.Click();
            Thread.Sleep(2000);
        }
        public string GetSkill()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);            
            return newSkill.Text;
        }
        public string GetSkillLevel()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 2);           
            return newSkillLevel.Text;
        }
        public string GetInvalidSkill()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@class='ns-box-inner']", 2);
            return invalidSkill.Text;
        }
        public string GetExistingSkill()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@class='ns-box-inner']", 2);
            return existingSkill.Text;
        }

        public void EditSkillsRecord( string editSkill, string editSkillLevel)
        {
            wait.Waittobeclickable(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]", 2);
            editSkillsButton.Click();
            editSkillsTextBox.Clear();
            editSkillsTextBox.SendKeys(editSkill);
            editSkillsLevelDropdown.Click();
            chooseEditSkillsLevel.Click();

            if (editSkillLevel == "Beginner")
            {
                chooseSkillLevelBeginner.Click();

            }
            if (editSkillLevel == "Intermediate")
            {
                chooseSkillLevelIntermediate.Click();
            }

            if (editSkillLevel == "Expert")
            {

                chooseSkillLevelExpert.Click();
            }
           
            updateSkillsButton.Click();
        }
        public string GetEditSkill()
        {
            Thread.Sleep(2000);
            //wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10);                                                                   
            return newEditSkill.Text;
        }
        public string GetEditSkillLevel()
        {
            Thread.Sleep(2000);
            //wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10);                                                          
            return newEditSkillLevel.Text;
        }
        public void DeleteSkillsRecord()
        { 
            Thread.Sleep(2000);
            deleteSkillButton.Click();
            Thread.Sleep(2000);

        }
        public string GetDeletedSkill()
        {
            wait.Waittobevisible(driver, "Xpath", "//*[@class='ns-box-inner']", 2);
            return deletedSkillData.Text;
        }
 
    }
}

