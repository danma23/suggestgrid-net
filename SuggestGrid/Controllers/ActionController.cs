/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using SuggestGrid;
using SuggestGrid.Utilities;
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
        /// Posts an Action
        /// </summary>
        /// <param name="action">Required parameter: The action to be posted.</param>
        /// <return>Returns the Models.MessageResponse response from the API call</return>
        public Models.MessageResponse PostAction(Models.Action action)
        {
            Task<Models.MessageResponse> t = PostActionAsync(action);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Posts an Action
        /// </summary>
        /// <param name="action">Required parameter: The action to be posted.</param>
        /// <return>Returns the Models.MessageResponse response from the API call</return>
        public async Task<Models.MessageResponse> PostActionAsync(Models.Action action)
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
                throw new ErrorResponseException(@"Required user id or item id parameters are missing from the request.", _context);

            if (_response.StatusCode == 402)
                throw new ErrorResponseException(@"Action limit exceeded.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorResponseException(@"Action type does not exists.", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorResponseException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Posts Actions
        /// </summary>
        /// <param name="actions">Required parameter: A number of action objects separated with newlines. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the Models.BulkPostResponse response from the API call</return>
        public BulkPostResponse PostBulkActions(List<Models.Action> actions)
        {
            StringBuilder actionsStringBuilder = new StringBuilder();
            foreach (Models.Action action in actions)
            {
                actionsStringBuilder.Append(JsonConvert.SerializeObject(action, Formatting.None));
                actionsStringBuilder.Append(Environment.NewLine);
            }
            Task<BulkPostResponse> t = PostBulkActionsAsync(actionsStringBuilder.ToString());
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Posts Actions
        /// </summary>
        /// <param name="actions">Required parameter: A number of action objects separated with newlines. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the Models.BulkPostResponse response from the API call</return>
        private async Task<Models.BulkPostResponse> PostBulkActionsAsync(string actions)
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

            if (_response.StatusCode == 402)
                throw new ErrorResponseException(@"Action limit exceeded.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorResponseException(@"Action type does not exists.", _context);

            if (_response.StatusCode == 413)
                throw new ErrorResponseException(@"Bulk request maximum line count exceeded.", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorResponseException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.BulkPostResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Gets Actions
        /// </summary>
        /// <param name="type">Optional parameter: Get actions of a type.</param>
        /// <param name="userId">Optional parameter: Get actions of a user id.</param>
        /// <param name="itemId">Optional parameter: Get actions of an item id.</param>
        /// <param name="olderThan">Optional parameter: Get actions older than the given duration, or the given time number. Could be a ISO 8601 duration, or a Unix time number. Specifications are available at https://en.wikipedia.org/wiki/ISO_8601#Durations, or https://en.wikipedia.org/wiki/Unix_time.</param>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10,000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped from the response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the Models.ActionsResponse response from the API call</return>
        public Models.ActionsResponse GetActions(
                string type = null,
                string userId = null,
                string itemId = null,
                string olderThan = null,
                long? size = null,
                long? mfrom = null)
        {
            Task<Models.ActionsResponse> t = GetActionsAsync(type, userId, itemId, olderThan, size, mfrom);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Gets Actions
        /// </summary>
        /// <param name="type">Optional parameter: Get actions of a type.</param>
        /// <param name="userId">Optional parameter: Get actions of a user id.</param>
        /// <param name="itemId">Optional parameter: Get actions of an item id.</param>
        /// <param name="olderThan">Optional parameter: Get actions older than the given duration, or the given time number. Could be a ISO 8601 duration, or a Unix time number. Specifications are available at https://en.wikipedia.org/wiki/ISO_8601#Durations, or https://en.wikipedia.org/wiki/Unix_time.</param>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10,000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped from the response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the Models.ActionsResponse response from the API call</return>
        public async Task<Models.ActionsResponse> GetActionsAsync(
                string type = null,
                string userId = null,
                string itemId = null,
                string olderThan = null,
                long? size = null,
                long? mfrom = null)
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
            },ArrayDeserializationFormat,ParameterSeparator);


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
            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorResponseException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.ActionsResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete Actions
        /// </summary>
        /// <param name="type">Required parameter: Delete actions of a type. This parameter and at least one other parameter is required.</param>
        /// <param name="userId">Optional parameter: Delete actions of a user id.</param>
        /// <param name="itemId">Optional parameter: Delete actions of an item id.</param>
        /// <param name="olderThan">Optional parameter: Delete actions older than the given duration, or the given time number. Could be a ISO 8601 duration, or a Unix time number. Specifications are available at https://en.wikipedia.org/wiki/ISO_8601#Durations, or https://en.wikipedia.org/wiki/Unix_time.</param>
        /// <return>Returns the Models.DeleteSuccessResponse response from the API call</return>
        public Models.DeleteSuccessResponse DeleteActions(
                string type,
                string userId = null,
                string itemId = null,
                string olderThan = null)
        {
            Task<Models.DeleteSuccessResponse> t = DeleteActionsAsync(type, userId, itemId, olderThan);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete Actions
        /// </summary>
        /// <param name="type">Required parameter: Delete actions of a type. This parameter and at least one other parameter is required.</param>
        /// <param name="userId">Optional parameter: Delete actions of a user id.</param>
        /// <param name="itemId">Optional parameter: Delete actions of an item id.</param>
        /// <param name="olderThan">Optional parameter: Delete actions older than the given duration, or the given time number. Could be a ISO 8601 duration, or a Unix time number. Specifications are available at https://en.wikipedia.org/wiki/ISO_8601#Durations, or https://en.wikipedia.org/wiki/Unix_time.</param>
        /// <return>Returns the Models.DeleteSuccessResponse response from the API call</return>
        public async Task<Models.DeleteSuccessResponse> DeleteActionsAsync(
                string type,
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
            },ArrayDeserializationFormat,ParameterSeparator);


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
                throw new ErrorResponseException(@"Required user id or item id parameters are missing.", _context);

            if (_response.StatusCode == 404)
                throw new DeleteErrorResponseException(@"Delete actions not found.", _context);

            if (_response.StatusCode == 422)
                throw new ErrorResponseException(@"No query parameter (user id, item id, or older than) is given. qIn order to delete all actionsdelete the type.", _context);

            if (_response.StatusCode == 505)
                throw new ErrorResponseException(@"Request timed out.", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorResponseException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.DeleteSuccessResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
