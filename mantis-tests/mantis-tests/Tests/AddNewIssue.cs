using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTest : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "10"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "some text",
                Description = "some description",
                Category = "General"
            };

            app.API.CreateNewIssue(account, project, issueData);
        }
    }
}
