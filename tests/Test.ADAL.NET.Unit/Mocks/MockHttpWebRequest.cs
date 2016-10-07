﻿//----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//----------------------------------------------------------------------

using System.Net;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Test.ADAL.NET.Unit.Mocks
{
    internal class MockHttpWebRequest : IHttpWebRequest
    {
        private readonly IHttpWebResponse _response;
        public MockHttpWebRequest(IHttpWebResponse response)
        {
            this._response = response;
            Headers = new WebHeaderCollection();
        }

        public RequestParameters BodyParameters { get; set; }
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public string Method { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public WebHeaderCollection Headers { get; set; }
        public Task<IHttpWebResponse> GetResponseSyncOrAsync(CallState callState)
        {
            return Task.Run(()=>_response);
        }
    }
}