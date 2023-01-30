using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void GroupDeletionTest()
        {
            bool moveContactsBeforeDelete = true;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Delete(0, moveContactsBeforeDelete);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            oldGroups.RemoveAt(0);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
