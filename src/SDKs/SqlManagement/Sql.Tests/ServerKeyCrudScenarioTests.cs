// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Management.Sql.Models;

namespace Sql.Tests
{
    public class ServerKeyCrudScenarioTests
    {
        [Fact]
        public void TestCreateUpdateGetDropServerKey()
        {
            string testPrefix = "sqlserverkeycrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestWithTdeByokSetup(suiteName, "", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // validate key exists by getting key

                // validate key exists by listing keys

                // delete key

                // validate key is gone by get key

                // validate key is gone by listing keys
            });
        }
    }
}
