using System;
using System.Collections.Generic;
using NUnit.Framework;
using WebAddressbookTests;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletetionTests : AuthTestBase
    {
        [Test]
        public void ProjectDeletetionTest()
        {
            AccountData accountForChecks = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectToCreate = new ProjectData("Some name");

            List<ProjectData> oldList = app.API.GetProjectList(accountForChecks);

            if (oldList.Count == 0)
            {
                app.API.CreateNewProject(accountForChecks, projectToCreate);
                oldList = app.API.GetProjectList(accountForChecks);
            }

            app.Projects.DeleteProject(0);

            List<ProjectData> newList = app.API.GetProjectList(accountForChecks);
            oldList.RemoveAt(0);

            Assert.AreEqual(oldList, newList);
        }
    }
}
