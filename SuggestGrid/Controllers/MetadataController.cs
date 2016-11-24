/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 11/24/2016
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
        /// Get An User
        /// </summary>
        /// <param name="userId">Required parameter: The user id to delete its metadata.</param>
        /// <return>Returns the Metadata response from the API call</return>
        public Metadata<string,object> GetUser(string userId)
        {
            Task<Metadata<string,object>> t = GetUserAsync(userId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get An User
        /// </summary>
        /// <param name="userId">Required parameter: The user id to delete its metadata.</param>
        /// <return>Returns the Metadata response from the API call</return>
        public async Task<Metadata<string,object>> GetUserAsync(string userId)
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
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 404)
                throw new ErrorResponseException(@"User not found.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Metadata<string,object>>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="userId">Required parameter: The user id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteUser(string userId)
        {
            Task<MessageResponse> t = DeleteUserAsync(userId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="userId">Required parameter: The user id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteUserAsync(string userId)
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
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10.000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped for response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public UsersResponse GetUsers(int? size = null, int? mfrom = null)
        {
            Task<UsersResponse> t = GetUsersAsync(size, mfrom);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10.000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped for response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the UsersResponse response from the API call</return>
        public async Task<UsersResponse> GetUsersAsync(int? size = null, int? mfrom = null)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/users");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
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
                return APIHelper.JsonDeserialize<UsersResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post a User
        /// </summary>
        /// <param name="user">Required parameter: The metadata to be saved. Metadata format has its restrictions.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse PostUser(Metadata<string,object> user)
        {
            Task<MessageResponse> t = PostUserAsync(user);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Post a User
        /// </summary>
        /// <param name="user">Required parameter: The metadata to be saved. Metadata format has its restrictions.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> PostUserAsync(Metadata<string,object> user)
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
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(user);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new DetailedErrorResponseException(@"Metadata is invalid.", _context);

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
        /// Delete All Users
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteAllUsers()
        {
            Task<MessageResponse> t = DeleteAllUsersAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete All Users
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteAllUsersAsync()
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
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get An Item
        /// </summary>
        /// <param name="itemId">Required parameter: The item id to delete its metadata.</param>
        /// <return>Returns the Metadata response from the API call</return>
        public Metadata<string,object> GetItem(string itemId)
        {
            Task<Metadata<string,object>> t = GetItemAsync(itemId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get An Item
        /// </summary>
        /// <param name="itemId">Required parameter: The item id to delete its metadata.</param>
        /// <return>Returns the Metadata response from the API call</return>
        public async Task<Metadata<string,object>> GetItemAsync(string itemId)
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
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 404)
                throw new ErrorResponseException(@"Item not found.", _context);

            else if (_response.StatusCode == 500)
                throw new APIException(@"Unexpected internal error.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Metadata<string,object>>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete An Item
        /// </summary>
        /// <param name="itemId">Required parameter: The item id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteItem(string itemId)
        {
            Task<MessageResponse> t = DeleteItemAsync(itemId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete An Item
        /// </summary>
        /// <param name="itemId">Required parameter: The item id to delete its metadata.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteItemAsync(string itemId)
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
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get Items
        /// </summary>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10.000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped for response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public ItemsResponse GetItems(int? size = null, int? mfrom = null)
        {
            Task<ItemsResponse> t = GetItemsAsync(size, mfrom);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get Items
        /// </summary>
        /// <param name="size">Optional parameter: The number of the users response. Defaults to 10. Must be between 1 and 10.000 inclusive. This parameter must be string represetation of an integer like "1".</param>
        /// <param name="mfrom">Optional parameter: The number of users to be skipped for response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1".</param>
        /// <return>Returns the ItemsResponse response from the API call</return>
        public async Task<ItemsResponse> GetItemsAsync(int? size = null, int? mfrom = null)
        {
            //the base uri for api requestss
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/items");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
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
                return APIHelper.JsonDeserialize<ItemsResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post an Item
        /// </summary>
        /// <param name="item">Required parameter: The metadata to be saved. Metadata format has its restrictions.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse PostItem(Metadata<string,object> item)
        {
            Task<MessageResponse> t = PostItemAsync(item);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Post an Item
        /// </summary>
        /// <param name="item">Required parameter: The metadata to be saved. Metadata format has its restrictions.</param>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> PostItemAsync(Metadata<string,object> item)
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
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(item);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new DetailedErrorResponseException(@"Metadata is invalid.", _context);

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
        /// Delete All Items
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public MessageResponse DeleteAllItems()
        {
            Task<MessageResponse> t = DeleteAllItemsAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete All Items
        /// </summary>
        /// <return>Returns the MessageResponse response from the API call</return>
        public async Task<MessageResponse> DeleteAllItemsAsync()
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
                return APIHelper.JsonDeserialize<MessageResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Post Bulk Users
        /// </summary>
        /// <param name="users">Required parameter: A number of user metadata objects separated with newlines. Each user metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the BulkPostResponse response from the API call</return>
        public BulkPostResponse PostBulkUsers(List<Metadata<string, object>> users)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Metadata<string, object> user in users)
            {
                sb.Append(JsonConvert.SerializeObject(user, Formatting.None));
                sb.Append(Environment.NewLine);
            }
            Task<BulkPostResponse> t = PostBulkUsersAsync(sb.ToString());
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Post Bulk Users
        /// </summary>
        /// <param name="users">Required parameter: A number of user metadata objects separated with newlines. Each user metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the BulkPostResponse response from the API call</return>
        private async Task<BulkPostResponse> PostBulkUsersAsync(string users)
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
                { "accept", "application/json" },
                { "content-type", "text/plain; charset=utf-8" }
            };

            //append body params
             var _body = users;

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorResponseException(@"Body is missing.", _context);

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

        /// <summary>
        /// Post Bulk Items
        /// </summary>
        /// <param name="items">Required parameter: A number of item metadata objects separated with newlines. Each item metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the BulkPostResponse response from the API call</return>
        public BulkPostResponse PostBulkItems(List<Metadata<string, object>> items)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Metadata<string, object> item in items)
            {
                sb.Append(JsonConvert.SerializeObject(item, Formatting.None));
                sb.Append(Environment.NewLine);
            }
            Task<BulkPostResponse> t = PostBulkItemsAsync(sb.ToString());
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Post Bulk Items
        /// </summary>
        /// <param name="items">Required parameter: A number of item metadata objects separated with newlines. Each item metadata object must have its id field. Note that this is not a valid JSON data structure. The body size is limited to 10 thousand lines.</param>
        /// <return>Returns the BulkPostResponse response from the API call</return>
        private async Task<BulkPostResponse> PostBulkItemsAsync(string items)
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
                { "accept", "application/json" },
                { "content-type", "text/plain; charset=utf-8" }
            };

            //append body params
             var _body = items;

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorResponseException(@"Body is missing.", _context);

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
