using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars.Pages;
using ProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{

    
   [Binding]
    public class SkillFeatureStepDefinitions:CommonDriver
    {
        LoginPage loginPageObj;
        ProfilePage profilePageObj;

        [Given(@"I logged into Mars website sucessfully")]
        public void GivenILoggedIntoMarsWebsiteSucessfully()
        {

            loginPageObj = new LoginPage(driver);
            loginPageObj.LoginActions(driver, "antususansunila@gmail.com", "Ammuj@me5");
        }

        [Given(@"I navigate to Skill page")]
        public void GivenINavigateToSkillPage()
        {
            profilePageObj = new ProfilePage(driver);
            profilePageObj.GotoSkillsTab(driver);
        }

        [When(@"I add a new '([^']*)' and '([^']*)'")]
        public void WhenIAddANewAnd(string p0, string p1)
        {
            profilePageObj.ResetSkillRow(driver);
            profilePageObj.CreateSkillsRecords(driver, p0, p1);
        }

        [Then(@"table should have the new '([^']*)' and  '([^']*)'")]
        public void ThenTableShouldHaveTheNewAnd(string p0, string p1)
        {
            string newSkill = profilePageObj.GetSkill(driver);
            string newSkillLevel = profilePageObj.GetSkillLevel(driver);
           Assert.That(newSkill == p0, "Skill has nott been created sucessfully");
             Assert.That(newSkillLevel == p1, "Level has not been created sucesssfully");
        }


        [When(@"I add an invalid skill'([^']*)' and valid '([^']*)'")]
        public void WhenIAddAnInvalidSkillAndValid(string p0, string p1)
        {
            profilePageObj.ResetSkillRow(driver);
            profilePageObj.CreateSkillsRecords(driver, p0, p1);
        }

        [Then(@"the record has not be added as '([^']*)' sucessfully")]
        public void ThenTheRecordHasNotBeAddedAsSucessfully(string p2)
        {
            string actualResult1 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;

            //string actualResult1 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);
            Assert.That(p2 == actualResult1, "Skill has not been added Successfully");
        }

        [When(@"I add new an '([^']*)' and '([^']*)'")]
        public void WhenIAddNewAnAnd(string p0, string p1)
        {
            profilePageObj.ResetSkillRow(driver);
            profilePageObj.CreateSkillsRecords(driver, p0, p1);
        }

        [When(@"I add an existing skill'([^']*)' and '([^']*)'")]
        public void WhenIAddAnExistingSkillAnd(string p2, string p3)
        {
            profilePageObj.CreateSkillsRecords(driver, p2, p3);
        }

        [Then(@"the record has not be added '([^']*)' Sucessfully")]
        public void ThenTheRecordHasNotBeAddedSucessfully(string p4)
        {
            string actualResult1 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;

            //string actualResult1 = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);
            Assert.That(p4 == actualResult1, "Skill has not been added Successfully");
        }

        [When(@"I creates '([^']*)' and '([^']*)'")]
        public void WhenICreatesAnd(string p0, string p1)
        {
            profilePageObj.ResetSkillRow(driver);
            profilePageObj.CreateSkillsRecords(driver, p0, p1);
        }

        [When(@"I updates '([^']*)' and '([^']*)'")]
        public void WhenIUpdatesAnd(string p2, string p3)
        {
            profilePageObj.EditSkillsRecord(driver, p2, p3);
        }

        [Then(@"the record should be updated as new '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldBeUpdatedAsNewAnd(string p2, string p3)
        {
            string newEditSkill = profilePageObj.GetEditSkill(driver);
            string newEditSkillLevel = profilePageObj.GetEditSkillLevel(driver);
            Assert.That(newEditSkill == p2, "skill has not been updated sucessfully.");
            Assert.That(newEditSkillLevel == p3, "Level has not updated sucessfully");
        }


        [When(@"I create a '([^']*)' and '([^']*)'")]
        public void WhenICreateAAnd(string p0, string p1)
        {
            profilePageObj.ResetSkillRow(driver);
            profilePageObj.CreateSkillsRecords(driver, p0, p1);
        }

        [When(@"I delete the skill record")]
        public void WhenIDeleteTheSkillRecord()
        {
            profilePageObj.DeleteSkillsRecord(driver);

        }

        [Then(@"the '([^']*)' should be deleted sucessfully")]
        public void ThenTheShouldBeDeletedSucessfully(string p0)
        {
            string actualResult = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);
            Assert.That(p0 == actualResult, "skill record has been deleted Successfully");
        }


      

        //[Then(@"the '([^']*)' and '([^']*)'  should be deleted sucessfully")]
        //public void ThenTheAndShouldBeDeletedSucessfully(string p0, string p1)
        //{
        //    Assert.That(p0 == "Fishing has been deleted" && p1 == "Expert", "skill record has been deleted Successfully");
        //}

        //[Then(@"the skill record should be deleted sucessfully")]
        //public void ThenTheSkillRecordShouldBeDeletedSucessfully()
        //{
        //    string actualResult = driver.FindElement(By.XPath("//*[@class='ns-box-inner']")).Text;

        //    Assert.True(actualResult.Contains("deleted"));
        //    //int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr")).Count;

        //    //if (rowCount == 0)
        //    //{

        //    //    Console.WriteLine("skill record has been deleted Successfully");
        //    //}
        //}

    }
}
