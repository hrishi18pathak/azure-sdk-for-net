﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest.ClientRuntime.Azure.Test.Fakes;
    using Microsoft.Azure.Management.Redis;
    using Microsoft.Azure.Management.Redis.Models;
    using Xunit;
    using Microsoft.Azure;
    using Microsoft.Rest.Azure;
    using LROResponse = Microsoft.Rest.ClientRuntime.Azure.Tests.LROOpertionTestResponses;

    public class LongRunningOperationsTest
    {
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", 
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithoutHeaderInResponses()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithoutHeaderInResponses());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[2].RequestUri.ToString());
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[3].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithNoPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithNoBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() => 
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithEmptyPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithEmptyBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithBadPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithBadPayload());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithMissingProvisioningState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithMissingProvisioningState());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithNonSuccessStatusAndInvalidResponseContent()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithNonSuccessStatusAndInvalidResponseContent());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'BadRequest'.", error.Message);
            Assert.Null(error.Body);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithoutProvisioningState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWithoutProvisioningStateInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithNonResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWitNonResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            Sku sku = fakeClient.RedisOperations.CreateOrUpdateNonResource("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("foo", sku.Name);
            Assert.Equal(3, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithSubResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWitSubResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdateSubResource("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
            Assert.Equal(3, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithImmediateSuccess()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWithImmediateSuccess());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithImmediateSuccessAndOkStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockOperaionWithImmediateSuccessOKStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithImmediateSuccessAndNoContentStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockOperaionWithImmediateSuccessNoContentStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostOperationWithImmediateSuccessAndOkStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPostOperaionWithImmediateSuccessOKStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var sku = fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
            Assert.Equal("Family", sku.Family);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostOperationWithImmediateSuccessAndNoContentStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockOperaionWithImmediateSuccessNoContentStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostOperationWithBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPostOperaionWithBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(2, handler.Requests.Count);
            Assert.Equal(HttpMethod.Post, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithNonRetryableErrorInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteOperaionWithNoRetryableErrorInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() => fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'BadRequest'.", error.Message);
            Assert.Equal(2, handler.Requests.Count);
        }

        /// <summary>
        /// It's assumed that the same pattern is used throughout the long running operation and
        /// the final http call returns status code OK for Azure-AsyncOperation.
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithoutHeaderInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteOperaionWithoutHeaderInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal("http://custom/status", handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// It's assumed that the same pattern is used throughout the long running operation and
        /// the final http call returns status code OK, Created or NoContent for Location.
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithoutLocationHeaderInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteOperaionWithoutLocationHeaderInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal("http://custom/status", handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// It's assumed that the same pattern is used throughout the long running operation and
        /// the final http request return an object with successfull state.
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithLocationHeaderWith202()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithLocationHeaderAnd202());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(4, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("http://custom/locationstatus", handler.Requests[2].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[3].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", 
                handler.Requests[3].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithAsyncHeaderWith202()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithAsyncHeaderAnd202());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithWith202AndResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithWith202AndResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", 
                handler.Requests[2].RequestUri.ToString());
            Assert.Equal("Succeeded", resource.ProvisioningState);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostWithResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPostWithResourceSku());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.Post("rg", "redis", "1234");

            Assert.Equal(2, handler.Requests.Count);
            Assert.Equal(HttpMethod.Post, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal("Family", resource.Family);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateNoAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithNoAsyncHeader());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[1].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateFailedStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithFailedStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal("Long running operation failed with status 'Failed'.", ex.Message);
                Assert.Contains(AzureAsyncOperation.FailedStatus, ex.Response.Content);
            }

        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithImmediateServerError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch(CloudException ex)
            {
                Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateNoErrorBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithNoErrorBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal(HttpStatusCode.InternalServerError, ex.Response.StatusCode);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            var now = DateTime.Now;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithAsyncHeaderTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");

            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(2, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithLocationHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithLocationHeaderTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");

            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/location/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(2, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithLocationHeaderErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithLocationHeaderError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            try
            {
                fakeClient.RedisOperations.Delete("rg", "redis", "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Null(ex.Body);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithLocationHeaderErrorHandlingSecondTime()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithLocationHeaderErrorInSecondCall());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            var ex = Assert.Throws<CloudException>(()=>fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'InternalServerError'.", ex.Message);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            var now = DateTime.Now;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            
            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(2));
        }


        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROAsynOperationFailureWith200()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROAsyncOperationFailedWith200());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                var foo = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            }
            catch(Exception ex)
            {
                Assert.Contains("DeploymentDocument", ex.Message);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROWithLocationHeaderFailureWith200()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROLocationHeaderFailedWith200());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                var foo = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            }
            catch (Exception ex)
            {
                // If the message changes in the response, this assert will also have to be updated.
                Assert.Contains("DeploymentDocument", ex.Message);
            }
        }
        
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROPUTWithCanceledState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROPUTWithCanceledStateResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                var foo = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            }
            catch (Exception ex)
            {
                Assert.Contains("preempted", ex.Message);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROWithNonStandardTerminalStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROLocHdrNonStandardTerminalStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            var foo = fakeClient.RedisOperations.PostWithHttpMessagesAsync("rg", "redis", "1234").ConfigureAwait(false).GetAwaiter().GetResult();            
            Assert.Equal<string>("OK", foo.Response.StatusCode.ToString());
        }
    }
}
