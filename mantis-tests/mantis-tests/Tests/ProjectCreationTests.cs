using System;
using System.Collections.Generic;
using NUnit.Framework;
using WebAddressbookTests;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldList = app.Projects.GetProjectsList();

            ProjectData project = new ProjectData("test");

            app.Projects.CreateNewProject(project);

            List<ProjectData> newList = app.Projects.GetProjectsList();
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
