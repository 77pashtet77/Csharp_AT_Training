﻿using System;
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

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
