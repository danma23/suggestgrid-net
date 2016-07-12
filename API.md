# SuggestGrid .NET Client
*0.1.15-SNAPSHOT* 


## Type Methods
Type methods are used for managing SuggestGrid types.
For more information on types, refer to [Introduction to Types](www.suggestgrid.com/docs/intro/types).

### Create a New Type
Creates a new implicit or explicit type.

### Get Properties of a Type
Get the options of a type. Has rating parameter.

### Delete a Type
Deletes a type with ALL of its actions and recommendation model.
Do not use this if you will need the type.


### Get All Types
Get all type names in an array named types.

### Delete All Types
Deletes ALL types and ALL actions.



## Action Methods
Action methods are for posting and deleting actions.
For more information on actions, refer to [Introduction to Actions](www.suggestgrid.com/docs/intro/actions).

### Post an Action
Posts an action to the given type in the body.
The body must have user id, item id and type.
Rating is required for actions sent to an explicit type.


### Post Bulk Actions
Posts bulk actions to SuggestGrid.
The recommended method for posting multiple actions at once.


### Get Actions
If `type` is not provided, it'll return the total number of actions.
Otherwise when `type` is provided
* If both `user_id` and `item_id` are supplied it returns the count of the corresponding actions.
* If only `user_id` is provided, it returns the count of all the action of the given user.
* If only `user_id` is provided, it returns the count of all the action of the given item.
* If only `older_than` is provided, it returns the count of actions older than the given timestamp.
* If a few of these parameters are provided, it returns the count of the intersection of these parameters.
* If none of these are provided, it returns the count of the whole type.


### Delete Actions
If `type` is not provided, it'll return the total number of actions.
Otherwise when `type` is provided
* If both `user_id` and `item_id` are supplied it returns the count of the corresponding actions.
* If only `user_id` is provided, it returns the count of all the action of the given user.
* If only `user_id` is provided, it returns the count of all the action of the given item.
* If only `older_than` is provided, it returns the count of actions older than the given timestamp.
* If a few of these parameters are provided, it returns the count of the intersection of these parameters.
* If none of these are provided, it returns the count of the whole type.




## Metadata Methods
Metadata methods are for posting and deleting metadata.
For more information on metadata, refer to [Introduction to Metadata](www.suggestgrid.com/docs/intro/metadata).

### Post a User
Posts a user metadata.

### Post Bulk Users
Post user metadata in bulk.
This metadata can be used to filter or to be included in recommendations and similars methods.


### Get Users
Get information about users. Only returns count at the moment.

### Delete a User
Delete a user metadata with the given user_id.

### Delete All Users
Deletes all user metadata from SuggestGrid.

### Post an Item
Posts an item metadata.
This metadata can be used to filter or to be included in recommendations and similars methods.


### Post Bulk Items
Post item metadata in bulk.
This method is recommended for sharing stored data with SuggestGrid.


### Get Items
Get information about items. Only returns count at the moment.

### Delete an Item
Delete an item metadata with the given item_id.

### Delete All Items
Delete all items metadata.
This method would flush all items metadata on SuggestGrid.




## Recommnedation Methods
Recommnedation methods are for getting recommended items or users responses from SuggestGrid.
For more information on recommendations, refer to [Introduction to Recommendations](www.suggestgrid.com/docs/intro/recommendations).

### Get Recommended Users
Recommend users for the given body parameters.

### Get Recommended Items
Recommend items for the given body parameters.



## Similars Methods
Similars methods are for getting similar items or users responses from SuggestGrid.
For more information on similars, refer to [Introduction to Similars](www.suggestgrid.com/docs/intro/similars).

### Get Similar Users
Get similar users to a user.

### Get Similar Items
Get similar items to an item.

