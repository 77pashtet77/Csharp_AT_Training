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
            AccountData accountForChecks = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldList = app.API.GetProjectList(accountForChecks);

            ProjectData project = new ProjectData("test");

            foreach (var item in oldList)
            {
                if (item.Name == project.Name)
                {
                    app.API.DeleteProject(accountForChecks, item.Id);
                    oldList = app.API.GetProjectList(accountForChecks);
                }
            }

            app.Projects.CreateNewProject(project);

            List<ProjectData> newList = app.API.GetProjectList(accountForChecks);
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
