using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMars.Pages;
using ProjectMars.Utilities;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    
    public class LanguageFeatureStepDefinitions:CommonDriver
    {
        LoginPage loginPageObj;
        ProfilePage profilePageObj;

        [Given(@"I logged into Mars portal sucessfully")]
        public void GivenILoggedIntoMarsPortalSucessfully()
        {
            loginPageObj = new LoginPage(driver);
            loginPageObj.LoginActions(driver, "antususansunila@gmail.com", "Ammuj@me5");
        }

        [Given(@"I navigate to Profile page")]
        public void GivenINavigateToProfilePage()
        {
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GotoLanguageTab(driver);
        }

        [When(@"I add new '([^']*)' and '([^']*)'")]
        public void WhenIAddNewAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow(driver);
            profilePageObj.CreateLanguageRecord(driver,p0,p1);
            
        }

        [Then(@"the record should have new '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveNewAnd(string p0, string p1)
        {
            string newLanguage = profilePageObj.GetLanguage(driver);
            string newLevel = profilePageObj.GetLevel(driver);
            Assert.That(newLanguage == p0, "Language has not been created sucessfully.");
            Assert.That(newLevel == p1, "Level has not created sucessfully");
        }


        [When(@"I add invalid '([^']*)' and valid '([^']*)'")]
        public void WhenIAddInvalidAndValid(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow(driver);
            profilePageObj.CreateLanguageRecord(driver, p0, p1);
        }

        [Then(@"the record should  not be added '([^']*)' sucessfully")]
        public void ThenTheRecordShouldNotBeAddedSucessfully(string p2)
        {
            
            string actualResult1 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;

            //string actualResult1 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);
            Assert.That(p2 == actualResult1, "Language has not been added Successfully");
        }
        [When(@"I add new a '([^']*)' and '([^']*)'")]

        public void WhenIAddNewAAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow(driver);
            profilePageObj.CreateLanguageRecord(driver, p0, p1);
        }


        [When(@"I add an existing language'([^']*)' and '([^']*)'")]
        public void WhenIAddAnExistingLanguageAnd(string p2, string p3)
        {

            profilePageObj.CreateLanguageRecord(driver, p2, p3);
        }

        [Then(@"the record should not be added '([^']*)'")]
        public void ThenTheRecordShouldNotBeAdded(string p4)
        {
            string actualresult2 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);
            Assert.That(p4 == actualresult2, "Language has not been added Successfully");

        }





        //[Then(@"the record should  not be added as '([^']*)' and valid '([^']*)'")]
        //public void ThenTheRecordShouldNotBeAddedAsAndValid(string p0, string p1)
        //{


        //       // Assert.That(p0 == "Please enter language and level" && p1 == "Fluent", " Language has not been added Successfully");
        //}


        [Given(@"I create  '([^']*)' and '([^']*)'")]
        public void GivenICreateAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow(driver);
            profilePageObj.CreateLanguageRecord(driver, p0, p1);
        }

        [When(@"I update '([^']*)' and '([^']*)'")]
        public void WhenIUpdateAnd(string p2, string p3)
        {
            profilePageObj.EditLanguageRecord(driver, p2, p3);
        }

        [Then(@"the record should be updated as new'([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldBeUpdatedAsNewAnd(string p2, string p3)
        {
            string newEditLanguage = profilePageObj.GetEditLanguage(driver);
            string newEditLevel = profilePageObj.GetEditLevel(driver);
            Assert.That(newEditLanguage == p2, "Language has not been updated sucessfully.");
            Assert.That(newEditLevel == p3, "Level has not updated sucessfully");
        }

    
        [Given(@"I create a '([^']*)' and '([^']*)'")]
        public void GivenICreateAAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow(driver);
            profilePageObj.CreateLanguageRecord(driver, p0, p1);
        }

     
        [When(@"I delete a language")]
        public void WhenIDeleteALanguage()
        {
          
            profilePageObj.DeleteLanguageRecord(driver);
        }

        [Then(@"the '([^']*)'  should be deleted sucessfully")]
        public void ThenTheShouldBeDeletedSucessfully(string p0)
        {
            string actualResult = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;
            Assert.That(p0 == actualResult, " Language has been deleted Successfully");
        }

       

        //[Then(@"the record should be deleted sucessfully")]
        //public void ThenTheRecordShouldBeDeletedSucessfully()
        //{

        //    string actualResult = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;

        //    Assert.True(actualResult.Contains("deleted from your languages"));


        //    //int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")).Count;
        //    //if (rowCount == 0)
        //    //{

        //    //    Console.WriteLine("Language has been deleted Successfully");
        //    //}
        //}





    }
}
