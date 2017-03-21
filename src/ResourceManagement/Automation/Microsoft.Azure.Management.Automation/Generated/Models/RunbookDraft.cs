// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation.Models
{
    /// <summary>
    /// Definition of the runbook type.
    /// </summary>
    public partial class RunbookDraft
    {
        private DateTimeOffset _creationTime;
        
        /// <summary>
        /// Optional. Gets or sets the creation time of the runbook draft.
        /// </summary>
        public DateTimeOffset CreationTime
        {
            get { return this._creationTime; }
            set { this._creationTime = value; }
        }
        
        private ContentLink _draftContentLink;
        
        /// <summary>
        /// Optional. Gets or sets the draft runbook content link.
        /// </summary>
        public ContentLink DraftContentLink
        {
            get { return this._draftContentLink; }
            set { this._draftContentLink = value; }
        }
        
        private bool _inEdit;
        
        /// <summary>
        /// Optional. Gets or sets whether runbook is in edit mode.
        /// </summary>
        public bool InEdit
        {
            get { return this._inEdit; }
            set { this._inEdit = value; }
        }
        
        private DateTimeOffset _lastModifiedTime;
        
        /// <summary>
        /// Optional. Gets or sets the last modified time of the runbook draft.
        /// </summary>
        public DateTimeOffset LastModifiedTime
        {
            get { return this._lastModifiedTime; }
            set { this._lastModifiedTime = value; }
        }
        
        private IList<string> _outputTypes;
        
        /// <summary>
        /// Optional. Gets or sets the runbook output types.
        /// </summary>
        public IList<string> OutputTypes
        {
            get { return this._outputTypes; }
            set { this._outputTypes = value; }
        }
        
        private IDictionary<string, RunbookParameter> _parameters;
        
        /// <summary>
        /// Optional. Gets or sets the runbook draft parameters.
        /// </summary>
        public IDictionary<string, RunbookParameter> Parameters
        {
            get { return this._parameters; }
            set { this._parameters = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the RunbookDraft class.
        /// </summary>
        public RunbookDraft()
        {
            this.OutputTypes = new LazyList<string>();
            this.Parameters = new LazyDictionary<string, RunbookParameter>();
        }
    }
}