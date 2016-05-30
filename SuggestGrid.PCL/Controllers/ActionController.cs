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
    public partial class ActionController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static ActionController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static ActionController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new ActionController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Create an action.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse CreateAction(Action body, string type)
        {
            Task<MessageResponse> t = CreateActionAsync(body, type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Create an action.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> CreateActionAsync(Action body, string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions/{type}");

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
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"Required `user_id` or `item_id` parameters are missing from the request body.", _context);

            else if (_response.StatusCode == 402)
                throw new APIException(@"Action limit exceeded.", _context);

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
        /// Deletes actions.
        /// </summary>
        /// <param name="actionsQuery">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteActions(ActionsQuery actionsQuery, string type)
        {
            Task<MessageResponse> t = DeleteActionsAsync(actionsQuery, type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes actions.
        /// </summary>
        /// <param name="actionsQuery">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteActionsAsync(ActionsQuery actionsQuery, string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions/{type}");

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
            var _body = APIHelper.JsonSerialize(actionsQuery);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.DeleteBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"Required `user_id` or `item_id` parameters are missing from the request body.", _context);

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
        /// Post bulk actions.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse PostBulkActions(string body, string type)
        {
            Task<MessageResponse> t = PostBulkActionsAsync(body, type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Post bulk actions.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> PostBulkActionsAsync(string body, string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions/{type}/_bulk");

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

            //append body params
             var _body = body;

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 402)
                throw new APIException(@"Action limit exceeded.", _context);

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