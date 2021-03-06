// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.CustomerInsights.Models
{
    using Azure;
    using Management;
    using CustomerInsights;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The response of suggest relationship links operation.
    /// </summary>
    public partial class SuggestRelationshipLinksResponse
    {
        /// <summary>
        /// Initializes a new instance of the SuggestRelationshipLinksResponse
        /// class.
        /// </summary>
        public SuggestRelationshipLinksResponse() { }

        /// <summary>
        /// Initializes a new instance of the SuggestRelationshipLinksResponse
        /// class.
        /// </summary>
        /// <param name="interactionName">The interaction name.</param>
        /// <param name="suggestedRelationships">Suggested relationships for
        /// the type.</param>
        public SuggestRelationshipLinksResponse(string interactionName = default(string), IList<RelationshipsLookup> suggestedRelationships = default(IList<RelationshipsLookup>))
        {
            InteractionName = interactionName;
            SuggestedRelationships = suggestedRelationships;
        }

        /// <summary>
        /// Gets the interaction name.
        /// </summary>
        [JsonProperty(PropertyName = "interactionName")]
        public string InteractionName { get; protected set; }

        /// <summary>
        /// Gets suggested relationships for the type.
        /// </summary>
        [JsonProperty(PropertyName = "suggestedRelationships")]
        public IList<RelationshipsLookup> SuggestedRelationships { get; protected set; }

    }
}

