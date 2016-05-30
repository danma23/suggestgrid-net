/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 05/30/2016
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuggestGrid;
using SuggestGrid.Http.Request;
using SuggestGrid.Http.Response;
using SuggestGrid.Http.Client;
using SuggestGrid.Models;
using Newtonsoft.Json;

namespace SuggestGrid.Controllers
{
    public partial class MetadataController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static MetadataController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static MetadataController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MetadataController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Create a user metadata.
        /// </summary>
        /// <param name="metadata">Required parameter: Example: </param>
        /// <param name="userId">Required parameter: The user_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse CreateAUserMetadata(Metadata<string,object> metadata, string userId)
        {
            Task<MessageResponse> t = CreateAUserMetadataAsync(metadata, userId);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Create a user metadata.
        /// </summary>
        /// <param name="metadata">Required parameter: Example: </param>
        /// <param name="userId">Required parameter: The user_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> CreateAUserMetadataAsync(Metadata<string,object> metadata, string userId)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/users/{user_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "user_id", userId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(metadata);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"Metadata is invalid.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete a user metadata.
        /// </summary>
        /// <param name="userId">Required parameter: The user_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteAUserMetadata(string userId)
        {
            Task<MessageResponse> t = DeleteAUserMetadataAsync(userId);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete a user metadata.
        /// </summary>
        /// <param name="userId">Required parameter: The user_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteAUserMetadataAsync(string userId)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/users/{user_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "user_id", userId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get information about users.
        /// </summary>
        /// <return>Returns the MetadataInformationResponse response from the API call</return>
        public MetadataInformationResponse GetUsers()
        {
            Task<MetadataInformationResponse> t = GetUsersAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get information about users.
        /// </summary>
        /// <return>Returns the MetadataInformationResponse response from the API call</return>
        public async Task<MetadataInformationResponse> GetUsersAsync()
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/users");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MetadataInformationResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete all user metadata.
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteAllUserMetadata()
        {
            Task<MessageResponse> t = DeleteAllUserMetadataAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete all user metadata.
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteAllUserMetadataAsync()
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/users");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Create an item metadata.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="itemId">Required parameter: The item_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse CreateAnItemMetadata(Metadata<string,object> body, string itemId)
        {
            Task<MessageResponse> t = CreateAnItemMetadataAsync(body, itemId);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Create an item metadata.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="itemId">Required parameter: The item_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> CreateAnItemMetadataAsync(Metadata<string,object> body, string itemId)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/items/{item_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "item_id", itemId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"Metadata is invalid.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete an item metadata.
        /// </summary>
        /// <param name="itemId">Required parameter: The item_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteAnItemMetadata(string itemId)
        {
            Task<MessageResponse> t = DeleteAnItemMetadataAsync(itemId);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete an item metadata.
        /// </summary>
        /// <param name="itemId">Required parameter: The item_id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteAnItemMetadataAsync(string itemId)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/items/{item_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "item_id", itemId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get information about items.
        /// </summary>
        /// <return>Returns the MetadataInformationResponse response from the API call</return>
        public MetadataInformationResponse GetItems()
        {
            Task<MetadataInformationResponse> t = GetItemsAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get information about items.
        /// </summary>
        /// <return>Returns the MetadataInformationResponse response from the API call</return>
        public async Task<MetadataInformationResponse> GetItemsAsync()
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/items");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MetadataInformationResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete all item metadata.
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteAllItemMetadata()
        {
            Task<MessageResponse> t = DeleteAllItemMetadataAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete all item metadata.
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteAllItemMetadataAsync()
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/items");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post bulk user metadata.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse PostBulkUserMetadata(List<Metadata<string, object>> metas)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Metadata<string, object> meta in metas)
            {
                sb.Append(JsonConvert.SerializeObject(meta, Formatting.None));
                sb.Append(Environment.NewLine);
            }
            Task<MessageResponse> t = PostBulkUserMetadataAsync(sb.ToString());
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Post bulk user metadata.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        private async Task<MessageResponse> PostBulkUserMetadataAsync(string body)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/users/_bulk");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //append body params
             var _body = body;

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 207)
                throw new APIException(@"Some metadata is not uploaded successfully.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post bulk item metadata.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse PostBulkItemMetadata(List<Metadata<string, object>> metas)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Metadata<string, object> meta in metas)
            {
                sb.Append(JsonConvert.SerializeObject(meta, Formatting.None));
                sb.Append(Environment.NewLine);
            }
            Task<MessageResponse> t = PostBulkItemMetadataAsync(sb.ToString());
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Post bulk item metadata.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        private async Task<MessageResponse> PostBulkItemMetadataAsync(string body)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/items/_bulk");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" }
            };

            //append body params
             var _body = body;

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 207)
                throw new APIException(@"Some metadata is not uploaded successfully.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
