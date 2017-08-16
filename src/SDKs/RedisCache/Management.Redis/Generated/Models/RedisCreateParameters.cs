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
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parameters supplied to the Create Redis operation.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class RedisCreateParameters : Resource
    {
        /// <summary>
        /// Initializes a new instance of the RedisCreateParameters class.
        /// </summary>
        public RedisCreateParameters()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RedisCreateParameters class.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <param name="sku">The SKU of the Redis cache to deploy.</param>
        /// <param name="id">Resource ID.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="redisConfiguration">All Redis Settings. Few possible
        /// keys:
        /// rdb-backup-enabled,rdb-storage-connection-string,rdb-backup-frequency,maxmemory-delta,maxmemory-policy,notify-keyspace-events,maxmemory-samples,slowlog-log-slower-than,slowlog-max-len,list-max-ziplist-entries,list-max-ziplist-value,hash-max-ziplist-entries,hash-max-ziplist-value,set-max-intset-entries,zset-max-ziplist-entries,zset-max-ziplist-value
        /// etc.</param>
        /// <param name="enableNonSslPort">Specifies whether the non-ssl Redis
        /// server port (6379) is enabled.</param>
        /// <param name="tenantSettings">tenantSettings</param>
        /// <param name="shardCount">The number of shards to be created on a
        /// Premium Cluster Cache.</param>
        /// <param name="subnetId">The full resource ID of a subnet in a
        /// virtual network to deploy the Redis cache in. Example format:
        /// /subscriptions/{subid}/resourceGroups/{resourceGroupName}/Microsoft.{Network|ClassicNetwork}/VirtualNetworks/vnet1/subnets/subnet1</param>
        /// <param name="staticIP">Static IP address. Required when deploying a
        /// Redis cache inside an existing Azure Virtual Network.</param>
        public RedisCreateParameters(string location, Sku sku, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), IDictionary<string, string> redisConfiguration = default(IDictionary<string, string>), bool? enableNonSslPort = default(bool?), IDictionary<string, string> tenantSettings = default(IDictionary<string, string>), int? shardCount = default(int?), string subnetId = default(string), string staticIP = default(string))
            : base(location, id, name, type, tags)
        {
            RedisConfiguration = redisConfiguration;
            EnableNonSslPort = enableNonSslPort;
            TenantSettings = tenantSettings;
            ShardCount = shardCount;
            SubnetId = subnetId;
            StaticIP = staticIP;
            Sku = sku;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets all Redis Settings. Few possible keys:
        /// rdb-backup-enabled,rdb-storage-connection-string,rdb-backup-frequency,maxmemory-delta,maxmemory-policy,notify-keyspace-events,maxmemory-samples,slowlog-log-slower-than,slowlog-max-len,list-max-ziplist-entries,list-max-ziplist-value,hash-max-ziplist-entries,hash-max-ziplist-value,set-max-intset-entries,zset-max-ziplist-entries,zset-max-ziplist-value
        /// etc.
        /// </summary>
        [JsonProperty(PropertyName = "properties.redisConfiguration")]
        public IDictionary<string, string> RedisConfiguration { get; set; }

        /// <summary>
        /// Gets or sets specifies whether the non-ssl Redis server port (6379)
        /// is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableNonSslPort")]
        public bool? EnableNonSslPort { get; set; }

        /// <summary>
        /// Gets or sets tenantSettings
        /// </summary>
        [JsonProperty(PropertyName = "properties.tenantSettings")]
        public IDictionary<string, string> TenantSettings { get; set; }

        /// <summary>
        /// Gets or sets the number of shards to be created on a Premium
        /// Cluster Cache.
        /// </summary>
        [JsonProperty(PropertyName = "properties.shardCount")]
        public int? ShardCount { get; set; }

        /// <summary>
        /// Gets or sets the full resource ID of a subnet in a virtual network
        /// to deploy the Redis cache in. Example format:
        /// /subscriptions/{subid}/resourceGroups/{resourceGroupName}/Microsoft.{Network|ClassicNetwork}/VirtualNetworks/vnet1/subnets/subnet1
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnetId")]
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets static IP address. Required when deploying a Redis
        /// cache inside an existing Azure Virtual Network.
        /// </summary>
        [JsonProperty(PropertyName = "properties.staticIP")]
        public string StaticIP { get; set; }

        /// <summary>
        /// Gets or sets the SKU of the Redis cache to deploy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (Sku == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Sku");
            }
            if (SubnetId != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(SubnetId, "^/subscriptions/[^/]*/resourceGroups/[^/]*/providers/Microsoft.(ClassicNetwork|Network)/virtualNetworks/[^/]*/subnets/[^/]*$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "SubnetId", "^/subscriptions/[^/]*/resourceGroups/[^/]*/providers/Microsoft.(ClassicNetwork|Network)/virtualNetworks/[^/]*/subnets/[^/]*$");
                }
            }
            if (StaticIP != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(StaticIP, "^\\d+\\.\\d+\\.\\d+\\.\\d+$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "StaticIP", "^\\d+\\.\\d+\\.\\d+\\.\\d+$");
                }
            }
            if (Sku != null)
            {
                Sku.Validate();
            }
        }
    }
}
