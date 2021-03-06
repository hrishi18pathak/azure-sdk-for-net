// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Analytics.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.DataLake;
    using Microsoft.Azure.Management.DataLake.Analytics;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for CompileMode.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CompileMode
    {
        [EnumMember(Value = "Semantic")]
        Semantic,
        [EnumMember(Value = "Full")]
        Full,
        [EnumMember(Value = "SingleBox")]
        SingleBox
    }
    internal static class CompileModeEnumExtension
    {
        internal static string ToSerializedValue(this CompileMode? value)  =>
            value == null ? null : ((CompileMode)value).ToSerializedValue();

        internal static string ToSerializedValue(this CompileMode value)
        {
            switch( value )
            {
                case CompileMode.Semantic:
                    return "Semantic";
                case CompileMode.Full:
                    return "Full";
                case CompileMode.SingleBox:
                    return "SingleBox";
            }
            return null;
        }

        internal static CompileMode? ParseCompileMode(this string value)
        {
            switch( value )
            {
                case "Semantic":
                    return CompileMode.Semantic;
                case "Full":
                    return CompileMode.Full;
                case "SingleBox":
                    return CompileMode.SingleBox;
            }
            return null;
        }
    }
}
