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
            loginPageObj = new LoginPage();
            loginPageObj.LoginActions( "antususansunila@gmail.com", "Ammuj@me5");
        }

        [Given(@"I navigate to Profile page")]
        public void GivenINavigateToProfilePage()
        {
            profilePageObj = new ProfilePage();
            profilePageObj.GotoLanguageTab();
        }

        [When(@"I add new '([^']*)' and '([^']*)'")]
        public void WhenIAddNewAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow();
            profilePageObj.CreateLanguageRecord(p0,p1);
        }

        [Then(@"the record should have new '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveNewAnd(string p0, string p1)
        {
            string newLanguage = profilePageObj.GetLanguage();
            string newLevel = profilePageObj.GetLevel();
            Assert.That(newLanguage == p0, "Language has not been created sucessfully.");
            Assert.That(newLevel == p1, "Level has not created sucessfully");
        }

        [When(@"I add invalid '([^']*)' and valid '([^']*)'")]
        public void WhenIAddInvalidAndValid(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow();
            profilePageObj.CreateLanguageRecord( p0, p1);
        }

        [Then(@"the record should  not be added '([^']*)' sucessfully")]
        public void ThenTheRecordShouldNotBeAddedSucessfully(string p2)
        {
            string invalidLanguage = profilePageObj.GetInvalidLanguage();
            Thread.Sleep(2000);
            Assert.That(p2 == invalidLanguage, "Language has not been added Successfully");
        }
        [When(@"I add new a '([^']*)' and '([^']*)'")]

        public void WhenIAddNewAAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow();
            profilePageObj.CreateLanguageRecord( p0, p1);
        }

        [When(@"I add an existing language'([^']*)' and '([^']*)'")]
        public void WhenIAddAnExistingLanguageAnd(string p2, string p3)
        {
            profilePageObj.CreateLanguageRecord( p2, p3);
        }

        [Then(@"the record should not be added '([^']*)'")]
        public void ThenTheRecordShouldNotBeAdded(string p4)
        {
            string existingLanguage = profilePageObj.GetExistingLanguage();
            Thread.Sleep(2000);
            Assert.That(p4 == existingLanguage, "Language has not been added Successfully");
        }

        [Given(@"I create  '([^']*)' and '([^']*)'")]
        public void GivenICreateAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow();
            profilePageObj.CreateLanguageRecord( p0, p1);
        }

        [When(@"I update '([^']*)' and '([^']*)'")]
        public void WhenIUpdateAnd(string p2, string p3)
        {
            profilePageObj.EditLanguageRecord( p2, p3);
        }

        [Then(@"the record should be updated as new'([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldBeUpdatedAsNewAnd(string p2, string p3)
        {
            string newEditLanguage = profilePageObj.GetEditLanguage();
            string newEditLevel = profilePageObj.GetEditLevel();
            Assert.That(newEditLanguage == p2, "Language has not been updated sucessfully.");
            Assert.That(newEditLevel == p3, "Level has not updated sucessfully");
        }

        [Given(@"I create a '([^']*)' and '([^']*)'")]
        public void GivenICreateAAnd(string p0, string p1)
        {
            profilePageObj.ResetLanguageRow();
            profilePageObj.CreateLanguageRecord( p0, p1);
        }

        [When(@"I delete a language")]
        public void WhenIDeleteALanguage()
        {
            profilePageObj.DeleteLanguageRecord();
        }

        [Then(@"the '([^']*)'  should be deleted sucessfully")]
        public void ThenTheShouldBeDeletedSucessfully(string p0)
        {
            string deletedLanguage = profilePageObj.GetDeleteLanguage();
            Assert.That(p0 == deletedLanguage, " Language has been deleted Successfully");
        }

    }
}





