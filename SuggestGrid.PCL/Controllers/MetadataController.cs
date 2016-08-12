/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 08/12/2016
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
using SuggestGrid.Exceptions;
using SuggestGrid.Models;

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
        /// Get Users
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public ErrorResponse GetUsers()
        {
            Task<ErrorResponse> t = GetUsersAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public async Task<ErrorResponse> GetUsersAsync()
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
                return APIHelper.JsonDeserialize<ErrorResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete All Users
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public ErrorResponse DeleteAllUsers()
        {
            Task<ErrorResponse> t = DeleteAllUsersAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete All Users
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public async Task<ErrorResponse> DeleteAllUsersAsync()
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
                return APIHelper.JsonDeserialize<ErrorResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get Items
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public ErrorResponse GetItems()
        {
            Task<ErrorResponse> t = GetItemsAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get Items
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public async Task<ErrorResponse> GetItemsAsync()
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
                return APIHelper.JsonDeserialize<ErrorResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete All Items
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public ErrorResponse DeleteAllItems()
        {
            Task<ErrorResponse> t = DeleteAllItemsAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete All Items
        /// </summary>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public async Task<ErrorResponse> DeleteAllItemsAsync()
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
                return APIHelper.JsonDeserialize<ErrorResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post Bulk Users
        /// </summary>
        /// <param name="body">Required parameter: A number of user metadata objects separated with newlines. Each user metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public ErrorResponse PostBulkUsers(List<Metadata<string, object>> metas)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Metadata<string, object> meta in metas)
            {
                sb.Append(JsonConvert.SerializeObject(meta, Formatting.None));
                sb.Append(Environment.NewLine);
            }
            Task<ErrorResponse> t = PostBulkUsersAsync(sb.ToString());
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Post Bulk Users
        /// </summary>
        /// <param name="body">Required parameter: A number of user metadata objects separated with newlines. Each user metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the ErrorResponse response from the API call</return>
        private async Task<ErrorResponse> PostBulkUsersAsync(string body)
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
            if (_response.StatusCode == 209)
                throw new APIException(@"Some metadata is not uploaded successfully.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<ErrorResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post Bulk Items
        /// </summary>
        /// <param name="body">Required parameter: A number of item metadata objects separated with newlines. Each item metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public ErrorResponse PostBulkItems(string body)
        {
            Task<ErrorResponse> t = PostBulkItemsAsync(body);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Post Bulk Items
        /// </summary>
        /// <param name="body">Required parameter: A number of item metadata objects separated with newlines. Each item metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the ErrorResponse response from the API call</return>
        public async Task<ErrorResponse> PostBulkItemsAsync(string body)
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
            if (_response.StatusCode == 209)
                throw new APIException(@"Some metadata is not uploaded successfully.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<ErrorResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
