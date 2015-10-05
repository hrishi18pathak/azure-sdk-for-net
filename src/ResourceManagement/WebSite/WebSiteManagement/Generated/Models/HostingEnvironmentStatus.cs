// Code generated by Microsoft (R) AutoRest Code Generator 0.11.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for HostingEnvironmentStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HostingEnvironmentStatus
    {
        [EnumMember(Value = "Preparing")]
        Preparing,
        [EnumMember(Value = "Ready")]
        Ready,
        [EnumMember(Value = "Scaling")]
        Scaling,
        [EnumMember(Value = "Deleting")]
        Deleting
    }
}