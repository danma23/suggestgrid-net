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

namespace SuggestGrid.Controllers
{
    public partial class TypeController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static TypeController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static TypeController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new TypeController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Get all types
        /// </summary>
        /// <return>Returns the GetTypesResponse response from the API call</return>
        public GetTypesResponse GetAllTypes()
        {
            Task<GetTypesResponse> t = GetAllTypesAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get all types
        /// </summary>
        /// <return>Returns the GetTypesResponse response from the API call</return>
        public async Task<GetTypesResponse> GetAllTypesAsync()
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/types");


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
                return APIHelper.JsonDeserialize<GetTypesResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete all types
        /// </summary>
        /// <return>Returns the GetTypesResponse response from the API call</return>
        public GetTypesResponse DeleteAllTypes()
        {
            Task<GetTypesResponse> t = DeleteAllTypesAsync();
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Delete all types
        /// </summary>
        /// <return>Returns the GetTypesResponse response from the API call</return>
        public async Task<GetTypesResponse> DeleteAllTypesAsync()
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/types");


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
                return APIHelper.JsonDeserialize<GetTypesResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get properties of a type
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the GetTypeResponse response from the API call</return>
        public GetTypeResponse GetType(string type)
        {
            Task<GetTypeResponse> t = GetTypeAsync(type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get properties of a type
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the GetTypeResponse response from the API call</return>
        public async Task<GetTypeResponse> GetTypeAsync(string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/types/{type}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type }
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
                return APIHelper.JsonDeserialize<GetTypeResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Create a new type.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Optional body for explicit parameter.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse CreateType(string type, TypeRequestBody body = null)
        {
            Task<MessageResponse> t = CreateTypeAsync(type, body);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new type.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Optional body for explicit parameter.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> CreateTypeAsync(string type, TypeRequestBody body = null)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/types/{type}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type }
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
            if (_response.StatusCode == 402)
                throw new APIException(@"Type limit reached.", _context);

            else if (_response.StatusCode == 409)
                throw new APIException(@"Type already exists.", _context);

            else if (_response.StatusCode == 422)
                throw new APIException(@"Rating type is not `implicit` or `explicit`.", _context);

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
        /// Deletes a type ALL of its actions.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteType(string type)
        {
            Task<MessageResponse> t = DeleteTypeAsync(type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a type ALL of its actions.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteTypeAsync(string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/types/{type}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type }
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
            if (_response.StatusCode == 404)
                throw new APIException(@"Type does not exists.", _context);

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