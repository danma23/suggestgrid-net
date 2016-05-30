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
    public partial class RecommendationController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static RecommendationController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static RecommendationController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new RecommendationController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Predict a users score for an item.
        /// </summary>
        /// <param name="itemId">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="userId">Required parameter: Example: </param>
        /// <return>Returns the PredictionResponse response from the API call</return>
        public PredictionResponse Predict(string itemId, string type, string userId)
        {
            Task<PredictionResponse> t = PredictAsync(itemId, type, userId);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Predict a users score for an item.
        /// </summary>
        /// <param name="itemId">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <param name="userId">Required parameter: Example: </param>
        /// <return>Returns the PredictionResponse response from the API call</return>
        public async Task<PredictionResponse> PredictAsync(string itemId, string type, string userId)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_predict/{user_id}/{item_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "item_id", itemId },
                { "type", type },
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
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"Request body is missing.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 555)
                throw new APIException(@"Recommendation model is not found for the given type.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<PredictionResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Recommend users for the given body parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public UsersResponse RecommendUsers(RecommendUsersBody body, string type)
        {
            Task<UsersResponse> t = RecommendUsersAsync(body, type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Recommend users for the given body parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public async Task<UsersResponse> RecommendUsersAsync(RecommendUsersBody body, string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_recommend/_users");

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
                throw new APIException(@"Request body is missing.", _context);

            else if (_response.StatusCode == 429)
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
        /// Recommend items for the given body parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public ItemsResponse RecommendItems(RecommendItemsBody body, string type)
        {
            Task<ItemsResponse> t = RecommendItemsAsync(body, type);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Recommend items for the given body parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="type">Required parameter: Example: </param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public async Task<ItemsResponse> RecommendItemsAsync(RecommendItemsBody body, string type)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{type}/_recommend/_items");

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
                throw new APIException(@"Request body is missing.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

            else if (_response.StatusCode == 555)
                throw new APIException(@"Recommendation model is not found for the given type.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

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