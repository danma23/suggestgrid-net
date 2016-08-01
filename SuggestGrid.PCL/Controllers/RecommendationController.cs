/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 08/01/2016
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
        /// Get Recommended Users
        /// </summary>
        /// <param name="body">Required parameter: Parameters for recommend users method.</param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public UsersResponse GetRecommendedUsers(GetRecommendedUsersBody body)
        {
            Task<UsersResponse> t = GetRecommendedUsersAsync(body);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get Recommended Users
        /// </summary>
        /// <param name="body">Required parameter: Parameters for recommend users method.</param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public async Task<UsersResponse> GetRecommendedUsersAsync(GetRecommendedUsersBody body)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/recommend/users");


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
                throw new APIException(@"Request body is invalid.", _context);

            else if (_response.StatusCode == 422)
                throw new APIException(@"Required parameters are missing.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

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
        /// Get Recommended Items
        /// </summary>
        /// <param name="body">Required parameter: Parameters for recommend items method.</param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public ItemsResponse GetRecommendedItems(GetRecommendedItemsBody body)
        {
            Task<ItemsResponse> t = GetRecommendedItemsAsync(body);
            Task.WaitAll(t);
            return t.Result;
        }

        /// <summary>
        /// Get Recommended Items
        /// </summary>
        /// <param name="body">Required parameter: Parameters for recommend items method.</param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public async Task<ItemsResponse> GetRecommendedItemsAsync(GetRecommendedItemsBody body)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/recommend/items");


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
                throw new APIException(@"Request body is invalid.", _context);

            else if (_response.StatusCode == 422)
                throw new APIException(@"Required parameters are missing.", _context);

            else if (_response.StatusCode == 429)
                throw new APIException(@"Too many requests.", _context);

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