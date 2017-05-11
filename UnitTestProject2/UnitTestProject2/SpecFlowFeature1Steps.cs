using System;
using System.IO;
using System.Globalization;
using TechTalk.SpecFlow;
using Sdl.Core.Globalization;
using Sdl.Core.Settings;
using Sdl.ProjectApi;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;
using Sdl.ProjectAutomation.Settings;
using Sdl.ProjectApi.Implementation.XmlSerialization;
using NUnit.Framework;

namespace UnitTestProject2
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private static ProjectInfo info;
        private static FileBasedProject project;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            project = new FileBasedProject(@"C:\Users\Administrator\Desktop\Project 1\Project 1.sdlproj");
            info = project.GetProjectInfo();
            info.Description = "This is the new description";
            info.DueDate = new DateTime(2017, 5, 10, 12, 25, 25);
            project.UpdateProject(info);
            project.Save();
        }

        [Given(@"I have provided the new due date and description")]
        public void GivenIHaveProvidedTheNewDueDateAndDescription()
        {
            DateTime dateTime = new DateTime(2017, 5, 10, 12, 25, 25);
            Assert.AreEqual(project.GetProjectInfo().DueDate, dateTime);
        }

        [Then(@"the project's information should be valid")]
        public void ThenTheProjectsInformationShouldBeValid()
        {
            Assert.AreEqual(project.GetProjectInfo().Description, "This is the new description");
        }
    }
}
