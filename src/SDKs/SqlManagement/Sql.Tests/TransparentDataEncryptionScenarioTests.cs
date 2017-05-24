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
    public class TransparentDataEncryptionScenarioTests
    {
        [Fact]
        public void TestCreateUpdateTransparentDataEncryption()
        {
            string testPrefix = "sqltdecrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestCreateUpdateTransparentDataEncryption", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                string serverNameV12 = SqlManagementTestUtilities.GenerateName(testPrefix);
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                string location = "North Europe";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create server
                var server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverNameV12, new Microsoft.Azure.Management.Sql.Models.Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = location,
                });
                SqlManagementTestUtilities.ValidateServer(server, serverNameV12, login, version12, tags, location);

                // Create database
                string databaseName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, databaseName, new Database()
                {
                    Location = location
                });

                // Enable TDE
                TransparentDataEncryption tde1 = sqlClient.Databases.CreateOrUpdateTransparentDataEncryptionConfiguration(resourceGroup.Name, server.Name, database.Name, new TransparentDataEncryption()
                {
                    Status = TransparentDataEncryptionStatus.Enabled
                });
                Assert.Equal(TransparentDataEncryptionStatus.Enabled, tde1.Status);

                // Validate GET indicates TDE is on
                TransparentDataEncryption tde2 = sqlClient.Databases.GetTransparentDataEncryptionConfiguration(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(TransparentDataEncryptionStatus.Enabled, tde2.Status);

                // Disable TDE
                TransparentDataEncryption tde3 = sqlClient.Databases.CreateOrUpdateTransparentDataEncryptionConfiguration(resourceGroup.Name, server.Name, database.Name, new TransparentDataEncryption()
                {
                    Status = TransparentDataEncryptionStatus.Disabled
                });
                Assert.Equal(TransparentDataEncryptionStatus.Disabled, tde3.Status);

                // Validate GET indicates TDE is off
                TransparentDataEncryption tde4 = sqlClient.Databases.GetTransparentDataEncryptionConfiguration(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(TransparentDataEncryptionStatus.Disabled, tde4.Status);
            });
        }
    }
}
