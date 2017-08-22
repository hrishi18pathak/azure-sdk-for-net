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
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// List of linked server Ids of a Redis cache.
    /// </summary>
    public partial class RedisLinkedServerList
    {
        /// <summary>
        /// Initializes a new instance of the RedisLinkedServerList class.
        /// </summary>
        public RedisLinkedServerList()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RedisLinkedServerList class.
        /// </summary>
        /// <param name="value">List of linked server Ids of a Redis
        /// cache.</param>
        public RedisLinkedServerList(IList<RedisLinkedServer> value)
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets list of linked server Ids of a Redis cache.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<RedisLinkedServer> Value { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Value == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Value");
            }
        }
    }
}