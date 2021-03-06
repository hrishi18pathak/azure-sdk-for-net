// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Batch.Protocol.Models
{
    using System.Linq;

    /// <summary>
    /// The definition of the user identity under which the task is run.
    /// </summary>
    /// <remarks>
    /// Specify either the userName or autoUser property, but not both.
    /// </remarks>
    public partial class UserIdentity
    {
        /// <summary>
        /// Initializes a new instance of the UserIdentity class.
        /// </summary>
        public UserIdentity() { }

        /// <summary>
        /// Initializes a new instance of the UserIdentity class.
        /// </summary>
        /// <param name="userName">The name of the user identity under which
        /// the task is run.</param>
        /// <param name="autoUser">The auto user under which the task is
        /// run.</param>
        public UserIdentity(string userName = default(string), AutoUserSpecification autoUser = default(AutoUserSpecification))
        {
            this.UserName = userName;
            this.AutoUser = autoUser;
        }

        /// <summary>
        /// Gets or sets the name of the user identity under which the task is
        /// run.
        /// </summary>
        /// <remarks>
        /// The userName and autoUser properties are mutually exclusive; you
        /// must specify one but not both.
        /// </remarks>
        [Newtonsoft.Json.JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the auto user under which the task is run.
        /// </summary>
        /// <remarks>
        /// The userName and autoUser properties are mutually exclusive; you
        /// must specify one but not both.
        /// </remarks>
        [Newtonsoft.Json.JsonProperty(PropertyName = "autoUser")]
        public AutoUserSpecification AutoUser { get; set; }

    }
}
