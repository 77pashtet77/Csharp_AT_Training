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
            List<ProjectData> oldList = app.Projects.GetProjectsList();

            ProjectData toBeDeleted = oldList[0];

            app.Projects.DeleteProject(0);

            List<ProjectData> newList = app.Projects.GetProjectsList();
            oldList.RemoveAt(0);

            Assert.AreEqual(oldList, newList);
        }
    }
}
