// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Redis.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Redis;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Response to force reboot for Redis cache.
    /// </summary>
    public partial class RedisForceRebootResponse
    {
        /// <summary>
        /// Initializes a new instance of the RedisForceRebootResponse class.
        /// </summary>
        public RedisForceRebootResponse()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RedisForceRebootResponse class.
        /// </summary>
        /// <param name="message">Status message</param>
        public RedisForceRebootResponse(string message = default(string))
        {
            Message = message;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets status message
        /// </summary>
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; private set; }

    }
}
