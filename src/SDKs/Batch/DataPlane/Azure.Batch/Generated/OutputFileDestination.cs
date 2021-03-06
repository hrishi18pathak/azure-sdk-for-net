// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

//
// This file was autogenerated by a tool.
// Do not modify it.
//

namespace Microsoft.Azure.Batch
{
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The destination to which a file should be uploaded.
    /// </summary>
    public partial class OutputFileDestination : ITransportObjectProvider<Models.OutputFileDestination>, IPropertyMetadata
    {
        private readonly OutputFileBlobContainerDestination container;

        #region Constructors

        internal OutputFileDestination(Models.OutputFileDestination protocolObject)
        {
            this.container = UtilitiesInternal.CreateObjectWithNullCheck(protocolObject.Container, o => new OutputFileBlobContainerDestination(o).Freeze());
        }

        #endregion Constructors

        #region OutputFileDestination

        /// <summary>
        /// Gets a location in Azure blob storage to which files are uploaded.
        /// </summary>
        public OutputFileBlobContainerDestination Container
        {
            get { return this.container; }
        }

        #endregion // OutputFileDestination

        #region IPropertyMetadata

        bool IModifiable.HasBeenModified
        {
            //This class is compile time readonly so it cannot have been modified
            get { return false; }
        }

        bool IReadOnly.IsReadOnly
        {
            get { return true; }
            set
            {
                // This class is compile time readonly already
            }
        }

        #endregion // IPropertyMetadata

        #region Internal/private methods

        /// <summary>
        /// Return a protocol object of the requested type.
        /// </summary>
        /// <returns>The protocol object of the requested type.</returns>
        Models.OutputFileDestination ITransportObjectProvider<Models.OutputFileDestination>.GetTransportObject()
        {
            Models.OutputFileDestination result = new Models.OutputFileDestination()
            {
                Container = UtilitiesInternal.CreateObjectWithNullCheck(this.Container, (o) => o.GetTransportObject()),
            };

            return result;
        }


        #endregion // Internal/private methods
    }
}