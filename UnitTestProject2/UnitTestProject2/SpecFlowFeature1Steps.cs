using NUnit.Framework;
using Sdl.Core.Globalization;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace UnitTestProject2
{
    [Binding]
    public class ApiTestingFeatureSteps
    {
        private static FileBasedProject project;
        private static ProjectFile[] targetFiles;
        private static Guid[] ids;
        private static TargetLanguageStatistics[] targetStatistics;
        private static ConfirmationStatistics confirmationStatistics;
        private static ProjectStatistics projectStatistics;
        private static ProjectPackageImport result;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            result = new ProjectPackageImport();
            //project = FileBasedProject.CreateFromProjectPackage(@"C:\Users\Junior Mind\Documents\Studio 2017\Projects\Project 2.sdlppx", @"C:\Users\Junior Mind\Documents\Studio 2017\Projects\Project 2", out result);
            project = FileBasedProject.CreateFromProjectPackage(@"C:\Jenkins\workspace\APITesting\Project 2.sdlppx", @"C:\Jenkins\workspace\APITesting\Project 2", out result);
            var targetLanguage = new Language(CultureInfo.GetCultureInfo("fr-FR"));
            targetFiles = project.GetTargetLanguageFiles(targetLanguage);
            var targetFile = targetFiles[0];
            var statistics = targetFile.ConfirmationStatistics;
        }

        [Given(@"I have a document without translated segments and a TM with translation units")]
        public void GivenIHaveADocumentWithoutTranslatedSegmentsAndATMWithTranslationUnits()
        {
            projectStatistics = project.GetProjectStatistics();
            targetStatistics = projectStatistics.TargetLanguageStatistics;
            ids = targetFiles.GetIds();
            confirmationStatistics = targetStatistics[0].ConfirmationStatistics;   
        }

        [Then(@"the number of translated words should be 0 in the confirmation statistics")]
        public void ThenTheNumberOfTranslatedWordsShouldBe0InTheConfirmationStatistics()
        {
            Assert.AreEqual(0, confirmationStatistics[ConfirmationLevel.Translated].Words);
        }

        [Given(@"I run a pre-translation task using the TM")]
        public void GivenIRunAPreTranslationTaskUsingTheTM()
        {
            project.RunAutomaticTask(ids, AutomaticTaskTemplateIds.PreTranslateFiles);
        }

        [When(@"I retrieve the confirmation statistics")]
        public void WhenIRetrieveTheConfirmationStatistics()
        {
            projectStatistics = project.GetProjectStatistics();
            targetStatistics = projectStatistics.TargetLanguageStatistics;
            confirmationStatistics = targetStatistics[0].ConfirmationStatistics;
        }

        [Then(@"the number of translated words should be updated")]
        public void ThenTheNumberOfTranslatedWordsShouldBeUpdated()
        {
            Assert.AreEqual(17, confirmationStatistics[ConfirmationLevel.Translated].Words);
        }
    }
}
