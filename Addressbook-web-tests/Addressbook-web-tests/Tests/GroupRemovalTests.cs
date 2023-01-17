using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.CreateGroupIfNoneExists();

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Remove(0);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());
            //remove

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            //saving old groups list state before removal
            GroupData toBeRemoved = oldGroups[0];

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            //checking if there is no element with same ID in the list
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
