

## Type Methods
Type methods are used for creating, getting, and deleting types.
Refer to [types](http://www.suggestgrid.com/docs/types) for an overview.

### Creates a Type
> `MessageResponse suggestGridClient.Type.CreateType(string type, TypeRequestBody settings = null)`

Creates a new type.

```csharp
suggestGridClient.Type.CreateType("views", new TypeRequestBody { Rating = "implicit" });
```

```csharp
suggestGridClient.Type.CreateType("views", new TypeRequestBody { Rating = "explicit" });
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
##### Body Parameters

> TypeRequestBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
rating|string|false|The rating type of the type. Could be "explicit" or "implicit", where "implicit" is the default.
type|string|true|The name of the type.
### Gets Properties of a Type
> `GetTypeResponse suggestGridClient.Type.GetType(string type)`

Returns the options of a type. The response rating parameter.

```csharp
var typeResponse = suggestGridClient.Type.GetType("views");
var rating = typeResponse.Rating; // get rating of type
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
type|string|true|The name of the type to get properties.
### Deletes a Type
> `MessageResponse suggestGridClient.Type.DeleteType(string type)`

Warning: Deletes the type with all of its actions and its recommendation model.


```csharp
suggestGridClient.Type.DeleteType("views");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
type|string|true|The name of the type to be deleted.
### Gets All Types
> `GetTypesResponse suggestGridClient.Type.GetAllTypes()`

Returns all type names in an array named types.

```csharp
var response = suggestGridClient.Type.GetAllTypes();
var types = response.Types; // The array of type names
```

### Deletes All Types
> `MessageResponse suggestGridClient.Type.deleteAllTypes()`

Deletes ALL the types and ALL the actions.

```csharp
suggestGridClient.Type.DeleteAllTypes();
```



## Action Methods
Action methods are for creating, getting, and deleting actions.
Refer to [actions](http://www.suggestgrid.com/docs/actions) for an overview.

### Posts an Action
> `MessageResponse suggestGridClient.Action.PostAction(Action action)`

Posts an action to the given type in the body.
The body must have user id, item id and type.
Rating is required for actions sent to an explicit type.


```csharp
Action action = new Action { Type = "views", ItemId = "1", UserId = "2" };
suggestGridClient.Action.PostAction(action);
```

```csharp
Action action = new Action { Type = "ratings", ItemId = "1", UserId = "2", Rating = 5 };
suggestGridClient.Action.PostAction(action);
```

#### Parameters
##### Body Parameters

> Action (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
itemId|string|true|The item id of the item the action is performed on.
rating|number|false|The optional rating given by the user, if the type is explicit.
timestamp|integer|false|The optional UNIX epoch timestamp of the action. Defaults to the current timestamp.
type|string|true|The type that the action belongs to.
userId|string|true|The user id of the performer of the action.
### Posts Actions
> `BulkPostResponse suggestGridClient.Action.PostBulkActions(List<Action> actions)`

Posts bulk actions to SuggestGrid.
The recommended method for posting multiple actions at once.


There's a limit of lines, hence number of objects you can send in one requests. That's default to 10000.

An example for bulk action request is the following:

```csharp
List<Action> actions = new List<Action>();
actions.Add(new Action { Type = "views", UserId = "2", ItemId = "1" });
actions.Add(new Action { Type = "views", UserId = "2", ItemId = "3" });

suggestGridClient.Action.PostBulkActions(actions);
```

Explicit actions can be post as:

```csharp
List<Action> actions = new List<Action>();
actions.Add(new Action { Type = "ratings", UserId = "2", ItemId = "1", Rating = 10 });
actions.Add(new Action { Type = "ratings", UserId = "2", ItemId = "3", Rating = 2 });

suggestGridClient.Action.PostBulkActions(actions);
```

#### Parameters
### Gets Actions
> `ActionsResponse suggestGridClient.Action.GetActions(string type = null, string userId = null, string itemId = null, string olderThan = null, long? size = null, long? mfrom = null)`

Get actions. Defaut responses will be paged by 10 actios each.
Type, user id, item id, or older than parameters could be provided.
The intersection of the provided parameters will be returned.


Get actions count:

If no query parameters is provided, all the actions will be returned:
```csharp
var response = suggestGridClient.Action.GetActions();

// The total count of actions
var count = response.TotalCount;
```

Get actions count by query:

You can include any of `type`, `userId`, `itemId`, and `olderThan` query parameters and SuggestGrid would return the actions satisfying all the query parameters:
`olderThan` value could be a [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations), or a [Unix time number](https://en.wikipedia.org/wiki/Unix_time).

This method can be particularly useful before deleting actions by query.

```csharp
var response = suggestGridClient.Action.GetActions(null, "u5321", "i1635", "891628467");

// The count of matching actions
var count = response.TotalCount;
```

You can also include `mfrom` (since `from` is a contextual C# keyword) and `size` parameters to nativage throught the reponse actions. From defaults to 0 and size defaults to 10. Returned actions are sorted from the most recent one to the least recent ones.

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
from|integer||The number of users to be skipped from the response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1". 
item_id|string||Get actions of an item id.
older_than|string||Get actions older than the given duration, or the given time number. Could be a ISO 8601 duration, or a Unix time number. Specifications are available at https://en.wikipedia.org/wiki/ISO_8601#Durations, or https://en.wikipedia.org/wiki/Unix_time. 
size|integer||The number of the users response. Defaults to 10. Must be between 1 and 10,000 inclusive. This parameter must be string represetation of an integer like "1". 
type|string||Get actions of a type.
user_id|string||Get actions of a user id.
### Delete Actions
> `DeleteSuccessResponse suggestGridClient.Action.DeleteActions(string type, string userId = null, string itemId = null, string olderThan = null)`

Warning: Please use get actions with the exact parameters first to inspect the actions to be deleted.

* Type must be provided. 
* If user id is provided, all actions of the user will be deleted.
* If item id is provided, all actions on the item will be deleted.
* If older than is provided, all actions older than the timestamp or the duration will be deleted.
* If a number of these parameters are provided, the intersection of these parameters will be deleted.
* In addition to a type, at least one of these parameters must be provided. In order to delete all the actions of a type, delete the type.


Type and at least one more parameter must be provided for all delete actions queries.

Delete a user's actions:
```csharp
suggestGridClient.Action.DeleteActions("views", "2");
```

Delete an item's actions:
```csharp
suggestGridClient.Action.DeleteActions("views", null, "2");
```

Delete actions older than a year:

`olderThan` value could be a [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations), or a [Unix time number](https://en.wikipedia.org/wiki/Unix_time).

```csharp
suggestGridClient.Action.DeleteActions("views", null, null, "P1Y");
```

Delete actions by query:

You can include any of `userId`, `itemId`, and `olderThan` parameters to the delete query and SuggestGrid would delete the intersection of the given queries accordingly.

For example, if all of `userId`, `itemId`, and `olderThan` are provided, SuggestGrid would delete the actions of the given user on the given item older than the given time or duration.

```csharp
suggestGridClient.Action.DeleteActions("views", "1", "30", "891628467");
```

It's highly recommended to first get the actions with the same parameters before deleting actions.

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
item_id|string||Delete actions of an item id.
older_than|string||Delete actions older than the given duration, or the given time number. Could be a ISO 8601 duration, or a Unix time number. Specifications are available at https://en.wikipedia.org/wiki/ISO_8601#Durations, or https://en.wikipedia.org/wiki/Unix_time. 
type|string|true|Delete actions of a type. This parameter and at least one other parameter is required.
user_id|string||Delete actions of a user id.


## Metadata Methods
Metadata methods are for creating, getting, and deleting user, and item metadata.
Refer to [metadata](http://www.suggestgrid.com/docs/metadata) for an overview.

### Posts a User
> `MessageResponse suggestGridClient.Metadata.PostUser(Metadata user)`

Posts a user metadata.
Note that this operation completely overrides previous metadata for the id, if it exists.


```csharp
string userString = "{ 'id': '9394182', 'age': 28, 'name': 'Avis Horton' }";
Metadata user = JsonConvert.DeserializeObject<SuggestGrid.Metadata>(userString);
suggestGridClient.Metadata.PostUser(user);
```

#### Parameters
##### Body Parameters

> Metadata (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
id|string|true|The id of the metadata of a user or an item. 
### Posts Users
> `BulkPostResponse suggestGridClient.Metadata.PostBulkUsers(List<Metadata> users)`

Posts user metadata in bulk.
Note that this operation completely overrides metadata with the same ids, if they exist.


There's a limit of lines, hence number of actions you can send in one requests. That's default to 10000.

An example for bulk user request is the following:
```csharp
List<SuggestGrid.Metadata> users = new List<SuggestGrid.Metadata>();
users.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{ 'id': '9394182', 'age': 28, 'name': 'Avis Horton' }" );
users.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{ 'id': '6006895', 'age': 29, 'name': 'Jami Bishop' }" );
users.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{ 'id': '6540497', 'age': 21, 'name': 'Bauer Case' }" );
users.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{ 'id': '1967970', 'age': 30, 'name': 'Rosetta Cole' }" );
users.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{ 'id': '6084106', 'age': 35, 'name': 'Shaw Simon' }" );

suggestGridClient.Metadata.PostBulkUsers(users);
```

#### Parameters
### Gets A User
> `Metadata suggestGridClient.Metadata.GetUser(string userId)`

Returns a user metadata if it exists.

```csharp
var user42 = suggestGridClient.Metadata.GetUser("42");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
user_id|string|true|The user id to get its metadata.
### Gets Users
> `UsersResponse suggestGridClient.Metadata.GetUsers(long? size = null, long? mfrom = null)`

Get items and total count of items.
Page and per-page parameters could be set.


```csharp
var response = suggestGridClient.Metadata.GetUsers();

// The total count of users
response.TotalCount;
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
from|integer||The number of users to be skipped from the response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1". 
size|integer||The number of the users response. Defaults to 10. Must be between 1 and 10,000 inclusive. This parameter must be string represetation of an integer like "1". 
### Deletes a User
> `MessageResponse suggestGridClient.Metadata.DeleteUser(string userId)`

Deletes a user metadata with the given user id.

```csharp
suggestGridClient.Metadata.DeleteUser("42");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
user_id|string|true|The user id to delete its metadata.
### Deletes All Users
> `MessageResponse suggestGridClient.Metadata.DeleteAllUsers()`

Warning: Deletes all user metadata from SuggestGrid.


```csharp
suggestGridClient.Metadata.DeleteAllUsers();
```

### Posts An Item
> `MessageResponse suggestGridClient.Metadata.PostItem(Metadata item)`

Posts an item metadata.
Note that this operation completely overrides previous metadata for the id, if it exists.


```csharp
string itemString = "{'id': '25922342', 'manufacturer': 'Vicon', 'price': 348}";
Metadata item = JsonConvert.DeserializeObject<SuggestGrid.Metadata>(itemString);
suggestGridClient.Metadata.PostItem(item);
```

#### Parameters
##### Body Parameters

> Metadata (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
id|string|true|The id of the metadata of a user or an item. 
### Posts Items
> `BulkPostResponse suggestGridClient.Metadata.PostBulkItems(List<Metadata> items)`

Posts item metadata in bulk.
Note that this operation completely overrides metadata with the same ids, if they exist.


There's a limit of lines, hence number of actions you can send in one requests. That's default to 10000.

An example for bulk user request is the following:
```csharp
List<SuggestGrid.Metadata> items = new List<SuggestGrid.Metadata>();
items.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{'id': '25922342', 'price': 348, 'manufacturer': 'Vicon'}" );
items.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{'id': '80885987', 'price': 771, 'manufacturer': 'Aquamate'}" );
items.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{'id': '71746854', 'price': 310, 'manufacturer': 'Exoplode'}" );
items.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{'id': '53538832', 'price': 832, 'manufacturer': 'Teraprene'}" );
items.Add(JsonConvert.DeserializeObject<SuggestGrid.Metadata> ( "{'id': '72006635', 'price': 832, 'manufacturer': 'Ohmnet'}" );

suggestGridClient.Metadata.PostBulkItems(items);
```

#### Parameters
### Gets An Item
> `Metadata suggestGridClient.Metadata.GetItem(string itemId)`

Returns an item metadata if it exists.

```csharp
var item42 = suggestGridClient.Metadata.GetItem("42");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
item_id|string|true|The item id to get its metadata.
### Gets Items
> `ItemsResponse suggestGridClient.Metadata.GetItems(long? size = null, long? mfrom = null)`

Gets items and total count of items.
Page and per-page parameters could be set.


```csharp
var response = suggestGridClient.Metadata.GetItems();

// The total count of items
response.TotalCount;
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
from|integer||The number of users to be skipped from the response. Defaults to 0. Must be bigger than or equal to 0. This parameter must be string represetation of an integer like "1". 
size|integer||The number of the users response. Defaults to 10. Must be between 1 and 10,000 inclusive. This parameter must be string represetation of an integer like "1". 
### Delete An Item
> `MessageResponse suggestGridClient.Metadata.DeleteItem(string itemId)`

Deletes an item metadata with the given item id.

```csharp
suggestGridClient.Metadata.DeleteItem("25");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
item_id|string|true|The item id to delete its metadata.
### Deletes All Items
> `MessageResponse suggestGridClient.Metadata.DeleteAllItems()`

Warning: Deletes all item metadata from SuggestGrid.


```csharp
suggestGridClient.Metadata.DeleteAllItems();
```



## Recommnedation Methods
Recommnedation methods are for getting recommended items for users, or recommended users for items.
Refer to [recommendations](http://www.suggestgrid.com/docs/recommendations) for an overview.

### Gets Recommended Users
> `UsersResponse GetRecommendedUsers(GetRecommendedUsersBody query)`

Returns recommended users for the query.

```csharp
var recommendedUsersResponse = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemId = "42"
});
var recommendedUsers = recommendedUsersResponse.Users; // [{id:"451"},{id:"456"}]
```

```csharp
var recommendedUsersResponse = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemIds = new List<string> { "42", "532", "841" }
});
var recommendedUsers = recommendedUsersResponse.Users; // [{id:"121"},{id:"33"},{id:"12"},{id:"32"},{id:"49"},{id:"11"},{id:"23"},{id:"54"},{id:"62"},{id:"29"}]
```

```csharp
var recommendedUsersResponse = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemIds = new List<string> { "42", "532", "841" },
    SimilarUserId = "100",
    Except = new List<string> { "100" },
    Size = 5
});
var recommendedUsers = recommendedUsersResponse.Users; // [{id:"1"},{id:"84"},{id:"9"},{id:"32"},{id:"45"}]
```

```csharp
var recommendedUsersResponse = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemId = "42",
    Fields = new List<string> { "name" },
    Size = 5,
    Filter = new { less_equal = new { age = 60 }}
});

var recommendedUsers = recommendedUsersResponse.Users; // [{id:"11",name:"Robert"},{id:"848",name:"Mike"},{id:"2",name:"Jennifer"}]
```

You can read [filters](https://suggestgrid.com/docs/advanced-features#filters-parameter) and [fields](https://suggestgrid.com/docs/advanced-features#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetRecommendedUsersBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
except|array|false|These user ids that will not be included in the response.
fields|array|false|The metadata fields to be included in returned user objects.
filter||false|
from|integer|false|The number of most recommended items to be skipped from the response. Defaults to 0.
itemId|string|false|The item id of the query.
itemIds|array|false|The item ids of the query. Exactly one of item id or item ids parameters must be provided.
similarUserId|string|false|Similar user that the response should be similar to.
similarUserIds|array|false|Similar users that the response should be similar to. At most one of similar user and similar users parameters can be provided. 
size|integer|false|The number of users requested. Defaults to 10. Must be between 1 and 10,000 inclusive.
type|string|false|The type of the query. Recommendations will be calculated based on actions of this type.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
### Gets Recommended Items
> `ItemsResponse GetRecommendedItems(GetRecommendedItemsBody query)`

Returns recommended items for the query.

```csharp
var recommendedItemsResponse = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "42"
});

var recommendedItems = recommendedItemsResponse.Items; // [{id:"451"},{id:"456"}]
```

```csharp
var recommendedItemsResponse = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserIds = new List<string> { "42", "532", "841" }
});

var recommendedItems = recommendedItemsResponse.Items; // [{id:"121"},{id:"33"},{id:"12"},{id:"32"},{id:"49"},{id:"11"},{id:"23"},{id:"54"},{id:"62"},{id:"29"}]
```

```csharp
var recommendedItemsResponse = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserIds = new List<string> { "42", "532", "841" },
    SimilarItemId = "321",
    Size = 3
});

var recommendedItems = recommendedItemsResponse.Items; // [{id:"13"},{id:"65"},{id:"102"}]
```

```csharp
var recommendedItemsResponse = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "42",
    Size = 5,
    Filter = new { less_equal = new { price = 100 }  }
});

var recommendedItems = recommendedItemsResponse.Items; // [{id:"930"},{id:"848"},{id:"102"},{id:"303"},{id:"593"}]
```

```csharp
var recommendedItemsResponse = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "42",
    Size = 5,
    Fields = new List<string> { "category" },
    Filter = new { exact = new { manufacturer = "Apple" }  }
});
var recommendedItems = recommendedItemsResponse.Items; // [{id:"930",category:"notebook"},{id:"848",category:"keyboard"},{id:"102",category:"watch"}]
```

You can read [filters](https://suggestgrid.com/docs/advanced-features#filters-parameter) and [fields](https://suggestgrid.com/docs/advanced-features#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetRecommendedItemsBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
except|array|false|These item ids that will not be included in the response.
fields|array|false|The metadata fields to be included in returned item objects.
filter||false|
from|integer|false|The number of most recommended items to be skipped from the response. Defaults to 0.
similarItemId|string|false|Similar item that the response should be similar to.
similarItemIds|array|false|Similar items that the response should be similar to. At most one of similar item and similar items parameters can be provided. 
size|integer|false|The number of items requested. Defaults to 10. Must be between 1 and 10,000 inclusive.
type|string|false|The type of the query. Recommendations will be calculated based on actions of this type.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
userId|string|false|The user id of the query.
userIds|array|false|The user ids of the query. Exactly one of user id or user ids parameters must be provided.


## Similarity Methods
Similarity methods are for getting similar items, or similar users.
Refer to [similarities](http://www.suggestgrid.com/docs/similarities) for an overview.

### Gets Similar Users
> `ItemsResponse GetSimilarItems(GetSimilarItemsBody query)`

Returns similar users for the query.

```csharp
var similarUsersResponse = suggestGridClient.Similarity.GetSimilarUsers(new GetSimilarUsersBody
{
    Type = "views",
    UserId = "1"
});

var similarUsers = similarUsersResponse.Users; // [{id:"12"},{id:"451"},{id:"456"}]
```

```csharp
var similarUsersResponse = suggestGridClient.Similarity.GetSimilarUsers(new GetSimilarUsersBody
{
    Type = "views",
    UserId = "1",
    Except = new List<string> { "12" }
});

var similarUsers = similarUsersResponse.Users; // [{id:"451"},{id:"456"}]
```

```csharp
var similarUsersResponse = suggestGridClient.Similarity.GetSimilarUsers(new GetSimilarUsersBody
{
    Type = "views",
    UserIds = new List<string> { "42", "532", "841" },
    Fields = new List<string> { "name" },
    Filter = new { less_equal = new { age = 20 } },
    Size = 3
});

var similarUsers = similarUsersResponse.Users; // [{id:"400", name:"Jason"},{id:"132", name:"Scarlett"},{id:"503", name:"Amy"}]
```

You can read [filters](https://suggestgrid.com/docs/advanced-features#filters-parameter) and [fields](https://suggestgrid.com/docs/advanced-features#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetSimilarUsersBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
except|array|false|These user ids that will not be included in the response.
fields|array|false|The metadata fields to be included in returned user objects.
filter||false|
from|integer|false|The number of most similar users to be skipped from the response. Defaults to 0.
size|integer|false|The number of users requested. Defaults to 10. Must be between 1 and 10,000 inclusive.
type|string|false|The type of the query. Similarities will be calculated based on actions of this type.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
userId|string|false|The user id of the query.
userIds|array|false|The user ids of the query. Exactly one of user id or user ids parameters must be provided.
### Gets Similar Items
> `UsersResponse GetSimilarUsers(GetSimilarUsersBody query)`

Returns similar items for the query.

```csharp
var similarItemsResponse = suggestGridClient.Similarity.GetSimilarItems(new GetSimilarItemsBody
{
    Type = "views",
    ItemId = "1"
});

var similarItems = similarItemsResponse.Items; // [{id:"12"},{id:"451"},{id:"456"}]
```

```csharp
var similarItemsResponse = suggestGridClient.Similarity.GetSimilarItems(new GetSimilarItemsBody
{
    Type = "views",
    ItemId = "1",
    Except = new List<string> { "12" }
});

var similarItems = similarItemsResponse.Items; // [{id:"451"},{id:"456"}]
```

```csharp
var similarItemsResponse = suggestGridClient.Similarity.GetSimilarItems(new GetSimilarItemsBody
{
    Type = "views",
    ItemIds = new List<string> { "3", "5", "8" },
    Size = 3,
    Fields = new List<string> { "category" },
    Filter = new { greater = new { capacity = 60 } }
});

var similarItems = similarItemsResponse.Items; // [{id:"451",category:"television"},{id:"656",category:"blu-ray-dvd-players"}]
```

You can read [filters](https://suggestgrid.com/docs/advanced-features#filters-parameter) and [fields](https://suggestgrid.com/docs/advanced-features#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetSimilarItemsBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
except|array|false|These item ids that will not be included in the response.
fields|array|false|The metadata fields to be included in returned item objects.
filter||false|
from|integer|false|The number of most similar items to be skipped from the response. Defaults to 0.
itemId|string|false|The item id of the query. Get similar items to given item id. Either item id or item ids must be provided.
itemIds|array|false|The item ids of the query. Exactly one of item id or item ids parameters must be provided. Get similar items to given item ids. Either item id or item ids must be provided.
size|integer|false|The number of items requested. Defaults to 10. Must be between 1 and 10,000 inclusive.
type|string|false|The type of the query. Similarities will be calculated based on actions of this type.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
