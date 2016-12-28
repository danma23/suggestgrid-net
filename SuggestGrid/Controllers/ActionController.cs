/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 12/18/2016
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
using Newtonsoft.Json;

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
        /// Get Actions
        /// </summary>
        /// <param name="type">Optional parameter: The type of the actions.</param>
        /// <param name="userId">Optional parameter: The user id of the actions.</param>
        /// <param name="itemId">Optional parameter: The item id of the actions.</param>
        /// <param name="olderThan">Optional parameter: Maxium timestamp of the actions. Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195).</param>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10.000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped for response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the ActionsResponse response from the API call</return>
        public ActionsResponse GetActions(
                string type = null,
                string userId = null,
                string itemId = null,
                string olderThan = null,
                int? size = null,
                int? mfrom = null)
        {
            Task<ActionsResponse> t = GetActionsAsync(type, userId, itemId, olderThan, size, mfrom);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get Actions
        /// </summary>
        /// <param name="type">Optional parameter: The type of the actions.</param>
        /// <param name="userId">Optional parameter: The user id of the actions.</param>
        /// <param name="itemId">Optional parameter: The item id of the actions.</param>
        /// <param name="olderThan">Optional parameter: Maxium timestamp of the actions. Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195).</param>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10.000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped for response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the ActionsResponse response from the API call</return>
        public async Task<ActionsResponse> GetActionsAsync(
                string type = null,
                string userId = null,
                string itemId = null,
                string olderThan = null,
                int? size = null,
                int? mfrom = null)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type },
                { "user_id", userId },
                { "item_id", itemId },
                { "older_than", olderThan },
                { "size", size },
                { "from", mfrom }
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
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new ErrorResponseException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<ActionsResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post an Action
        /// </summary>
        /// <param name="action">Required parameter: The action to be posted.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse PostAction(ActionModel action)
        {
            Task<MessageResponse> t = PostActionAsync(action);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Post an Action
        /// </summary>
        /// <param name="action">Required parameter: The action to be posted.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> PostActionAsync(ActionModel action)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions");


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
            var _body = APIHelper.JsonSerialize(action);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorResponseException(@"Required `user_id` or `item_id` parameters are missing from the request body.", _context);

            else if (_response.StatusCode == 402)
                throw new ErrorResponseException(@"Action limit exceeded.", _context);

            else if (_response.StatusCode == 404)
                throw new ErrorResponseException(@"Type does not exists.", _context);

            else if (_response.StatusCode == 429)
                throw new ErrorResponseException(@"Too many requests.", _context);

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
        /// Delete Actions
        /// </summary>
        /// <param name="type">Optional parameter: The type of the actions.</param>
        /// <param name="userId">Optional parameter: The user id of the actions.</param>
        /// <param name="itemId">Optional parameter: The item id of the actions.</param>
        /// <param name="olderThan">Optional parameter: Delete all actions of a type older than the given timestamp or time. Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195).</param>
        /// <return>Returns the DeleteSuccessResponse response from the API call</return>
        public DeleteSuccessResponse DeleteActions(
                string type = null,
                string userId = null,
                string itemId = null,
                string olderThan = null)
        {
            Task<DeleteSuccessResponse> t = DeleteActionsAsync(type, userId, itemId, olderThan);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete Actions
        /// </summary>
        /// <param name="type">Optional parameter: The type of the actions.</param>
        /// <param name="userId">Optional parameter: The user id of the actions.</param>
        /// <param name="itemId">Optional parameter: The item id of the actions.</param>
        /// <param name="olderThan">Optional parameter: Delete all actions of a type older than the given timestamp or time. Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195).</param>
        /// <return>Returns the DeleteSuccessResponse response from the API call</return>
        public async Task<DeleteSuccessResponse> DeleteActionsAsync(
                string type = null,
                string userId = null,
                string itemId = null,
                string olderThan = null)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type },
                { "user_id", userId },
                { "item_id", itemId },
                { "older_than", olderThan }
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
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorResponseException(@"Required `user_id` or `item_id` parameters are missing from the request body.", _context);

            else if (_response.StatusCode == 404)
                throw new DeleteErrorResponseException(@"Delete actions not found.", _context);

            else if (_response.StatusCode == 422)
                throw new ErrorResponseException(@"No query parameter (`user_id`, `item_id`, or `older_than`) is given.  In order to delete all actionsdelete the type.", _context);

            else if (_response.StatusCode == 429)
                throw new ErrorResponseException(@"Too many requests.", _context);

            else if (_response.StatusCode == 505)
                throw new ErrorResponseException(@"Request timed out.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<DeleteSuccessResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post Bulk Actions
        /// </summary>
        /// <param name="actions">Required parameter: A number of action objects separated with newlines. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the BulkPostResponse response from the API call</return>
        public BulkPostResponse PostBulkActions(List<ActionModel> actions)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ActionModel action in actions)
            {
                sb.Append(JsonConvert.SerializeObject(action, Formatting.None));
                sb.Append(Environment.NewLine);
            }
            Task<BulkPostResponse> t = PostBulkActionsAsync(sb.ToString());
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Post Bulk Actions
        /// </summary>
        /// <param name="actions">Required parameter: A number of action objects separated with newlines. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the BulkPostResponse response from the API call</return>
        private async Task<BulkPostResponse> PostBulkActionsAsync(string actions)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/actions/_bulk");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "SUGGESTGRID" },
                { "accept", "application/json" },
                { "content-type", "text/plain; charset=utf-8" }
            };

            //append body params
             var _body = actions;

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorResponseException(@"Body is missing.", _context);

            else if (_response.StatusCode == 402)
                throw new ErrorResponseException(@"Action limit exceeded.", _context);

            else if (_response.StatusCode == 429)
                throw new ErrorResponseException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<BulkPostResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
