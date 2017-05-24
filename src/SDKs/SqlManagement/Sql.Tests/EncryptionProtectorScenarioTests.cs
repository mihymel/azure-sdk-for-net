// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sql.Tests
{
    public class EncryptionProtectorScenarioTests
    {
        [Fact]
        public void TestUpdateEncryptionProtector()
        {
            string testPrefix = "sqlserverkeycrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestWithTdeByokSetup(suiteName, "TestUpdateEncryptionProtector", testPrefix, 
                (resClient, sqlClient, resourceGroup, server, keyBundle) =>
            {
                // update encryption protector to akv
                var serverKeyName = $"{keyBundle.KeyIdentifier.Vault}_{keyBundle.KeyIdentifier.Name}_{keyBundle.KeyIdentifier.Version}";
                var encProtector = sqlClient.EncryptionProtectors.CreateOrUpdate(resourceGroup.Name, server.Name, "current", new EncryptionProtector()
                {
                    ServerKeyName = serverKeyName,
                    ServerKeyType = "AzureKeyVault"
                });

                // validate encrytion protector

                // update encryption protector to service managed

                // validate encryption protector
            });
        }
    }
}
