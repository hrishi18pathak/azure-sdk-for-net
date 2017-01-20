// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    internal partial class TrafficManagerAzureEndpointImpl 
    {
        /// <summary>
        /// Gets the type of the target Azure resource.
        /// </summary>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TargetAzureResourceType Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerAzureEndpoint.TargetResourceType
        {
            get
            {
                return this.TargetResourceType() as Microsoft.Azure.Management.Trafficmanager.Fluent.TargetAzureResourceType;
            }
        }

        /// <summary>
        /// Gets the resource id of the target Azure resource.
        /// </summary>
        string Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerAzureEndpoint.TargetAzureResourceId
        {
            get
            {
                return this.TargetAzureResourceId();
            }
        }
    }
}