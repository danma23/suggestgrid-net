

## Type Methods
Type methods are used for managing SuggestGrid types.
For more information on types, refer to [Types concept documentation](http://www.suggestgrid.com/docs/concepts#types).

### Create a New Type
> `CreateType(type, body)`

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
type|string|true|The name of the type to be created.
##### Body Parameters

> TypeRequestBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
rating|string|false|The rating type of the type to be created. Could be "explicit" or "implicit" The default is "implicit". 
### Get Properties of a Type
> `GetType(type)`

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
### Delete a Type
> `DeleteType(type)`

Deletes a type with ALL of its actions and recommendation model.
Do not use this if you will need the type.


```csharp
suggestGridClient.Type.DeleteType("views");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
type|string|true|The name of the type to be deleted.
### Get All Types
> `GetAllTypes()`

Returns all type names in an array named types.


```csharp
  var response = suggestGridClient.Type.GetAllTypes();
  var types = response.Types; // get array of type names
```

### Delete All Types
> `deleteAllTypes()`

Deletes ALL the types and ALL the actions.

```csharp
suggestGridClient.Type.DeleteAllTypes();
```



## Action Methods
Action methods are for posting and deleting actions.
For more information on actions, refer to [Actions concept documentation](http://www.suggestgrid.com/docs/concepts#actions).

### Post an Action
> `PostAction(ActionModel)`

Posts an action to the given type in the body.
The body must have user id, item id and type.
Rating is required for actions sent to an explicit type.


```csharp
suggestGridClient.Action.PostAction(new ActionModel { Type = "views", ItemId = "1", UserId = "2" });
```

```csharp
suggestGridClient.Action.PostAction(new ActionModel { Type = "views", ItemId = "1", UserId = "2", Rating = 10 });
```

#### Parameters
##### Body Parameters

> Action (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
rating|number|false|The optional rating given by the user, if the type is explicit.
item_id|string|true|The item id of the item the action is performed on.
user_id|string|true|The user id of the performer of the action.
type|string|true|The type that the action belongs to.
### Post Bulk Actions
> `PostBulkActions(List<ActionModel> actions)`

Posts bulk actions to SuggestGrid.
The recommended method for posting multiple actions at once.



There's a limit of lines, hence number of actions you can send in one requests. That's default to 10000.

An example for bulk action request is the following:

```csharp
List<ActionModel> actions = new List<ActionModel>();

actions.Add(new ActionModel { Type = "views", ItemId = "1", UserId = "2" });
actions.Add(new ActionModel { Type = "views", ItemId = "3", UserId = "2"});

suggestGridClient.Action.PostBulkActions(actions);
```

Explicit actions can be post as;

```csharp

List<ActionModel> actions = new List<ActionModel>();

actions.Add(new ActionModel { Type = "views", ItemId = "1", UserId = "2", Rating = 10 });
actions.Add(new ActionModel { Type = "views", ItemId = "3", UserId = "2", Rating = 2 });

suggestGridClient.Action.PostBulkActions(actions);
```

#### Parameters
### Get Actions
> `GetActions (string type = null, string userId = null, string itemId = null, string olderThan = null)`

Type must be provided. Additionally,

* If both `user_id` and `item_id` are supplied it returns the count of the corresponding actions.
* If only `user_id` is provided, it returns the count of all the action of the given user.
* If only `user_id` is provided, it returns the count of all the action of the given item.
* If only `older_than` is provided, it returns the count of actions older than the given timestamp.
* If a few of these parameters are provided, it returns the count of the intersection of these parameters.
* If none of these are provided, it returns the count of the whole type.



#### Get Actions Count

```csharp
var response = suggestGridClient.Action.GetActions("views");

// get count
var count = response.Count;
```

#### Get Actions Count by Query

You can include any of type, user_id, item_id, and older_than path parameters and SuggestGrid return the count of such actions.

If no type is provided, the total number of actions will be returned.

This method can be particularly useful before deleting actions by query.

```csharp
var response = suggestGridClient.Action.GetActions(null, "u5321", "i1635", "891628467");

// get count
var count = response.Count;
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
type|string||The type of the actions.
user_id|string||The user id of the actions.
item_id|string||The item id of the actions.
older_than|string||Delete all actions of a type older than the given timestamp or time. Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195). 
### Delete Actions
> `DeleteActions (string type = null, string userId = null, string itemId = null, string olderThan = null)`

Type must be provided. Additionally,

* If both user id and item id are supplied the user's actions on the item will be deleted.
* If only user id is provided, all actions of the user will be deleted.
* If only item id is provided, all actions on the item will be deleted.
* If only older than is provided, all actions older than the timestamp or the duration will be deleted.
* If a few of these parameters are provided, delete action will be executed within intersection of these parameters.
* One of these parameters must be provided. In order to delete all actions, delete the type.



#### Delete a User's Actions

```csharp
suggestGridClient.Action.DeleteActions("views","2");
```

#### Delete an Item's Actions

```csharp
suggestGridClient.Action.DeleteActions("views",null,"2");
```

#### Delete Old Actions

In addition to unix timestamps, the method could accept:

  * Seconds. (s) For example: 100s
  * Minutes. (m) For example: 30m
  * Hours. (h) For example: 12h
  * Days. (d) For example: 7d
  * Months. (M) For example: 6M
  * Years. (y) For example: 10y

```csharp
suggestGridClient.Action.DeleteActions("views",null, null, "1d");
```

#### Delete Actions by Query

You can include any of user_id, item_id, and older_than parameters to the delete query and SuggestGrid would delete the intersection of the given queries accordingly.

For example, if all of user_id, item_id, and older_than are provided, SuggestGrid would delete the actions of the given user on the given item before the given time.

```csharp
suggestGridClient.Action.DeleteActions("views","1", "30", "891628467");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
type|string||The type of the actions.
user_id|string||The user id of the actions.
item_id|string||The item id of the actions.
older_than|string||Delete all actions of a type older than the given timestamp or time. Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195). 


## Metadata Methods
Metadata methods are for posting and deleting metadata.
For more information on metadata, refer to [Metadata concept documentation ](http://www.suggestgrid.com/docs/concepts#metadata).

### Post a User
> `PostUser(Metadata<string,object> metadata)`

Posts a user metadata.

```csharp
	suggestGridClient.Metadata.PostUser(new Metadata<string, object> { { "id", "9394182" }, { "age", 28 }, { "name", "Avis Horton" } });
```

#### Parameters
##### Body Parameters

> Metadata (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
id|string|true|The id of the user or the item that the metadata is associated with. Id parameter is necessary for all metadata. 
### Post Bulk Users
> `PostBulkUsers(List<Metadata<string, object>> users)`

Post user metadata in bulk.
This metadata can be used to filter or to be included in recommendations and similars methods.



There's a limit of lines, hence number of actions you can send in one requests. That's default to 10000.

An example for bulk user request is the following:

```csharp

List<Metadata<string, object>> users = new List<Metadata<string, object>>();

users.Add(new Metadata<string, object> { { "id", "9394182" }, { "age", 28 }, { "name", "Avis Horton" } });
users.Add(new Metadata<string, object> { { "id", "6006895" }, { "age", 29 }, { "name", "Jami Bishop" } });
users.Add(new Metadata<string, object> { { "id", "6540497" }, { "age", 21 }, { "name", "Bauer Case" } });
users.Add(new Metadata<string, object> { { "id", "1967970" }, { "age", 30 }, { "name", "Rosetta Cole" } });
users.Add(new Metadata<string, object> { { "id", "6084106" }, { "age", 35 }, { "name", "Shaw Simon" } });

suggestGridClient.Metadata.PostBulkUsers(users);
```

#### Parameters
### Get Users
> `GetUsers()`

Get information about users. Only returns count at the moment.


```csharp
var response = suggestGridClient.Metadata.GetUsers();
// get count of users
response.Count;
```

### Delete a User
> `DeleteUser(string userId)`

Deletes a user metadata with the given user id.

```csharp
suggestGridClient.Metadata.DeleteUser("6084106");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
user_id|string|true|The user id to delete its metadata.
### Delete All Users
> `DeleteAllUsers()`

Deletes all user metadata from SuggestGrid.

```csharp
suggestGridClient.Metadata.DeleteAllUsers();
```

### Post an Item
> `PostItem(Metadata<string,object> metadata)`

Posts an item metadata.
This metadata can be used to filter or to be included in recommendations and similars methods.


```csharp
suggestGridClient.Metadata.PostItem(new Metadata<string, object> { { "id", "25922342" }, { "manufacturer", "Vicon" }, { "price", 348 } });
```

#### Parameters
##### Body Parameters

> Metadata (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
id|string|true|The id of the user or the item that the metadata is associated with. Id parameter is necessary for all metadata. 
### Post Bulk Items
> `PostBulkItems(List<Metadata<string, object>> items)`

Post item metadata in bulk.
This method is recommended for sharing stored data with SuggestGrid.



There's a limit of lines, hence number of actions you can send in one requests. That's default to 10000.

An example for bulk item request is the following:

```csharp

List<Metadata<string, object>> items = new List<Metadata<string, object>>();

items.Add(new Metadata<string, object> { { "id", "25922342" }, { "price", 348 }, { "manufacturer", "Vicon" } });
items.Add(new Metadata<string, object> { { "id", "80885987" }, { "price", 771 }, { "manufacturer", "Aquamate" } });
items.Add(new Metadata<string, object> { { "id", "71746854" }, { "price", 310 }, { "manufacturer", "Exoplode" } });
items.Add(new Metadata<string, object> { { "id", "53538832" }, { "price", 832 }, { "manufacturer", "Teraprene" } });
items.Add(new Metadata<string, object> { { "id", "72006635" }, { "price", 832 }, { "manufacturer", "Ohmnet" } });

suggestGridClient.Metadata.PostBulkItems(items);
```

#### Parameters
### Get Items
> `GetItems()`

Get information about items. Only returns count at the moment.


```csharp
var response = suggestGridClient.Metadata.GetItems();
// get count of items
response.Count;
```

### Delete an Item
> `DeleteItem(string itemId)`

Deletes an item metadata with the given item id.

```csharp
suggestGridClient.Metadata.DeleteItem("25922342");
```

#### Parameters
##### URI/Query Parameters

Name | Type |Required| Description
--- | --- | --- | ---
item_id|string|true|The item id to delete its metadata.
### Delete All Items
> `DeleteAllItems()`

Delete all items metadata.
This method would flush all items metadata on SuggestGrid.


```csharp
suggestGridClient.Metadata.DeleteAllItems();
```



## Recommnedation Methods
Recommnedation methods are for getting recommended items or users responses from SuggestGrid.
For more information on recommendations, refer to [Recommendations concept documentation](http://www.suggestgrid.com/docs/concepts#recommendations).

### Get Recommended Users
> `GetRecommendedUsers(GetRecommendedUsersBody body)`

Returns recommended users for the given query.

examples:

```csharp
var recommendedUsers = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemId = "42"
});
var users = recommendedUsers.Users; // [{id:"451"},{id:"456"}]
```

```csharp
var recommendedUsers = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemIds = new List<string> { "42", "532", "841" }
});
var users = recommendedUsers.Users; // [{id:"121"},{id:"33"},{id:"12"},{id:"32"},{id:"49"},{id:"11"},{id:"23"},{id:"54"},{id:"62"},{id:"29"}]
```

```csharp
var recommendedUsers = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemIds = new List<string> { "42", "532", "841" },
    SimilarUserId = "100",
    Except = new List<string> { "100" },
    Size = 5
});
var users = recommendedUsers.Users; // [{id:"1"},{id:"84"},{id:"9"},{id:"32"},{id:"45"}]
```


```csharp
var recommendedUsers = suggestGridClient.Recommendation.GetRecommendedUsers(new GetRecommendedUsersBody
{
    Type = "views",
    ItemId = "42",
    Fields = new List<string> { "name" },
    Size = 5,
    Filter = new { less_equal = new { age = 60 }}
});

var users = recommendedUsers.Users; // [{id:"11",name:"Robert"},{id:"848",name:"Mike"},{id:"2",name:"Jennifer"}]
```

You can read [filters](/docs/concepts#filters-parameter) and [fields](/docs/concepts#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetRecommendedUsersBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
item_ids|array|false|The item ids of the query. Exactly one of item id or item ids parameters must be provided.
similar_user_id|string|false|Similar user that the response should be similar to.
item_id|string|false|The item id of the query.
similar_user_ids|string|false|Similar users that the response should be similar to. At most one of similar user and similar users parameters can be provided. 
except|array|false|These user ids that will not be included in the response.
size|integer|false|The number of users asked to return in the response.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
filter||false|
type|string|false|The type of the query.
fields|array|false|The metadata fields that are to be included in returned users.
### Get Recommended Items
> `GetRecommendedItems(GetRecommendedItemsBody body)`

Returns recommended items for the given query.

examples:

```csharp
var recommendedItems = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "42"
});

var items = recommendedItems.Items; // [{id:"451"},{id:"456"}]
```

```csharp
var recommendedItems = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserIds = new List<string> { "42", "532", "841" }
});

var items = recommendedItems.Items; // [{id:"121"},{id:"33"},{id:"12"},{id:"32"},{id:"49"},{id:"11"},{id:"23"},{id:"54"},{id:"62"},{id:"29"}]
```

```csharp
var recommendedItems = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserIds = new List<string> { "42", "532", "841" },
    SimilarItemId = "321",
    Size = 3
});

var items = recommendedItems.Items; // [{id:"13"},{id:"65"},{id:"102"}]
```

```csharp
var recommendedItems = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "42",
    Size = 5,
    Filter = new { less_equal = new { price = 100 }  }
});

var items = recommendedItems.Items; // [{id:"930"},{id:"848"},{id:"102"},{id:"303"},{id:"593"}]
```

```csharp
var recommendedItems = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "42",
    Size = 5,
    Fields = new List<string> { "category" },
    Filter = new { exact = new { manufacturer = "Apple" }  }
});
var items = recommendedItems.Items; // [{id:"930",category:"notebook"},{id:"848",category:"keyboard"},{id:"102",category:"watch"}]
```

You can read [filters](/docs/concepts#filters-parameter) and [fields](/docs/concepts#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetRecommendedItemsBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
similar_item_id|string|false|Similar item that the response should be similar to.
user_id|string|false|The user id of the query.
except|array|false|These user ids that will not be included in the response.
filter||false|
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
similar_item_ids|string|false|Similar items that the response should be similar to. At most one of similar item and similar items parameters can be provided. 
user_ids|array|false|The user ids of the query. Exactly one of user id or user ids parameters must be provided.
size|integer|false|The number of users asked to return in the response.
type|string|false|The type of the query.
fields|array|false|The metadata fields that are to be included in returned users.


## Similarity Methods
Similarity methods are for getting similar items or users responses from SuggestGrid.
For more information on similars, refer to [Similarities concept documentation](http://www.suggestgrid.com/docs/concepts#similarities).

### Get Similar Users
> `GetSimilarUsers(GetSimilarUsersBody body)`

Returns similar users for the query.

examples:

```csharp
var similarUsers = suggestGridClient.Similarity.GetSimilarUsers(new GetSimilarUsersBody
{
    Type = "views",
    UserId = "1"
});

var users = similarUsers.Users; // [{id:"1"},{id:"451"},{id:"456"}]
```

```csharp
var similarUsers = suggestGridClient.Similarity.GetSimilarUsers(new GetSimilarUsersBody
{
    Type = "views",
    UserId = "1",
    Except = new List<string> { "1" }
});

var users = similarUsers.Users; // [{id:"451"},{id:"456"}]
```

```csharp
var similarUsers = suggestGridClient.Similarity.GetSimilarUsers(new GetSimilarUsersBody
{
    Type = "views",
    UserIds = new List<string> { "42", "532", "841" },
    Fields = new List<string> { "name" },
    Filter = new { less_equal = new { age = 20 } },
    Size = 3
});

var users = similarUsers.Users; // [{id:"400", name:"Jason"},{id:"132", name:"Scarlett"},{id:"503", name:"Amy"}]
```

You can read [filters](/docs/concepts#filters-parameter) and [fields](/docs/concepts#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetSimilarUsersBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
except|array|false|These user ids that will not be included in the response.
size|integer|false|The number of users asked to return in the response.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
user_id|string|false|The user id of the query.
user_ids|array|false|The user ids of the query. Exactly one of user id or user ids parameters must be provided.
filter||false|
type|string|false|The type of the query.
fields|array|false|The metadata fields that are to be included in returned users.
### Get Similar Items
> `GetSimilarItems(GetSimilarItemsBody body)`

Returns similar items for the query.

examples:

```csharp
var similarItems = suggestGridClient.Similarity.GetSimilarItems(new GetSimilarItemsBody
{
    Type = "views",
    ItemId = "1"
});

var items = similarItems.Items; // [{id:"1"},{id:"451"},{id:"456"}]
```

```csharp
var similarItems = suggestGridClient.Similarity.GetSimilarItems(new GetSimilarItemsBody
{
    Type = "views",
    ItemId = "1",
    Except = new List<string> { "1" }
});

var items = similarItems.Items; // [{id:"451"},{id:"456"}]
```

```csharp
var similarItems = suggestGridClient.Similarity.GetSimilarItems(new GetSimilarItemsBody
{
    Type = "views",
    ItemIds = new List<string> { "3", "5", "8" },
    Size = 3,
    Fields = new List<string> { "category" },
    Filter = new { greater = new { capacity = 60 } }
});

var items = similarItems.Items; // [{id:"451",category:"television"},{id:"656",category:"blu-ray-dvd-players"}]
```

You can read [filters](/docs/concepts#filters-parameter) and [fields](/docs/concepts#fields-parameter) documentations for further reference.

#### Parameters
##### Body Parameters

> GetSimilarItemsBody (`object`)

Name | Type |Required| Description
--- | --- | --- | ---
item_ids|array|false|The item ids of the query. Exactly one of item id or item ids parameters must be provided. Get similar items to given item ids. Either item id or item ids must be provided.
item_id|string|false|The item id of the query. Get similar items to given item id. Either item id or item ids must be provided.
except|array|false|These user ids that will not be included in the response.
size|integer|false|The number of users asked to return in the response.
types|string|false|The types of the query. Exactly one of type or types parameters must be provided.
filter||false|
type|string|false|The type of the query.
fields|array|false|The metadata fields that are to be included in returned users.
