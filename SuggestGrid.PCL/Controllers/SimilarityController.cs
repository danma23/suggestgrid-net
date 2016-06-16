/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 06/16/2016
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
    public partial class SimilarityController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static SimilarityController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static SimilarityController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new SimilarityController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Get similarity of two users.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="userId1">Required parameter: Example: </param>
        /// <param name="userId2">Required parameter: Example: </param>
        /// <return>Returns the UserSimilarityResponse response from the API call</return>
        public UserSimilarityResponse GetUserSimilarity(string type, string userId1, string userId2)
        {
            Task<UserSimilarityResponse> t = GetUserSimilarityAsync(type, userId1, userId2);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get similarity of two users.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="userId1">Required parameter: Example: </param>
        /// <param name="userId2">Required parameter: Example: </param>
        /// <return>Returns the UserSimilarityResponse response from the API call</return>
        public async Task<UserSimilarityResponse> GetUserSimilarityAsync(string type, string userId1, string userId2)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_similarity/_users/{user_id1}/{user_id2}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type },
                { "user_id1", userId1 },
                { "user_id2", userId2 }
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

            else if (_response.StatusCode == 555)
                throw new APIException(@"Recommendation model is not found for the given type.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<UserSimilarityResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get similarity of two items.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="itemId1">Required parameter: Example: </param>
        /// <param name="itemId2">Required parameter: Example: </param>
        /// <return>Returns the ItemSimilarityResponse response from the API call</return>
        public ItemSimilarityResponse GetItemSimilarity(string type, string itemId1, string itemId2)
        {
            Task<ItemSimilarityResponse> t = GetItemSimilarityAsync(type, itemId1, itemId2);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get similarity of two items.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="itemId1">Required parameter: Example: </param>
        /// <param name="itemId2">Required parameter: Example: </param>
        /// <return>Returns the ItemSimilarityResponse response from the API call</return>
        public async Task<ItemSimilarityResponse> GetItemSimilarityAsync(string type, string itemId1, string itemId2)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_similarity/_items/{item_id1}/{item_id2}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type },
                { "item_id1", itemId1 },
                { "item_id2", itemId2 }
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

            else if (_response.StatusCode == 555)
                throw new APIException(@"Recommendation model is not found for the given type.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<ItemSimilarityResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get similar users to a user.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public UsersResponse GetSimilarUsers(string type, string userId, SimilarUsersBody body)
        {
            Task<UsersResponse> t = GetSimilarUsersAsync(type, userId, body);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get similar users to a user.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public async Task<UsersResponse> GetSimilarUsersAsync(string type, string userId, SimilarUsersBody body)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_similar/_users/{user_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type },
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
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 555)
                throw new APIException(@"Recommendation model is not found for the given type.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<UsersResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get similar items to an item.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="itemId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public ItemsResponse GetSimilarItems(string type, string itemId, SimilarItemsBody body)
        {
            Task<ItemsResponse> t = GetSimilarItemsAsync(type, itemId, body);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get similar items to an item.
        /// </summary>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="itemId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public async Task<ItemsResponse> GetSimilarItemsAsync(string type, string itemId, SimilarItemsBody body)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_similar/_items/{item_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "type", type },
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
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<ItemsResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 