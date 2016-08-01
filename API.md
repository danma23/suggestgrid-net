

## Type Methods
Type methods are used for managing SuggestGrid types.
For more information on types, refer to [Types concept documentation](http://www.suggestgrid.com/docs/concepts#types).

### Create a New Type
Creates a new implicit or explicit type.

#### Parameters
##### type (`string`)

  * Required: `true`

The name of the type to be created.

##### TypeRequestBody (`object`)

  * ###### rating (`string`)

    * Required: `false`

  Could be "explicit" or "implicit"
The default is "implicit".

### Get Properties of a Type
Get the options of a type. Has rating parameter.

#### Parameters
##### type (`string`)

  * Required: `true`

The name of the type to get properties.

### Delete a Type
Deletes a type with ALL of its actions and recommendation model.
Do not use this if you will need the type.


#### Parameters
##### type (`string`)

  * Required: `true`

The name of the type to be deleted.

### Get All Types
Get all type names in an array named types.

### Delete All Types
Deletes ALL types and ALL actions.



## Action Methods
Action methods are for posting and deleting actions.
For more information on actions, refer to [Actions concept documentation](http://www.suggestgrid.com/docs/concepts#actions).

### Post an Action
Posts an action to the given type in the body.
The body must have user id, item id and type.
Rating is required for actions sent to an explicit type.


#### Parameters
##### Action (`object`)

  * ###### type (`string`)

    * Required: `true`

  The type that the action belongs to.

  * ###### rating (`number`)

    * Required: `false`

  The optional rating, if the type is explicit.

  * ###### user_id (`string`)

    * Required: `true`

  The user id of the performer of the action.

  * ###### item_id (`string`)

    * Required: `true`

  The item id of the item the action is performed on.

### Post Bulk Actions
Posts bulk actions to SuggestGrid.
The recommended method for posting multiple actions at once.


#### Parameters
### Get Actions
If `type` is not provided, it'll return the total number of actions.
Otherwise when `type` is provided
* If both `user_id` and `item_id` are supplied it returns the count of the corresponding actions.
* If only `user_id` is provided, it returns the count of all the action of the given user.
* If only `user_id` is provided, it returns the count of all the action of the given item.
* If only `older_than` is provided, it returns the count of actions older than the given timestamp.
* If a few of these parameters are provided, it returns the count of the intersection of these parameters.
* If none of these are provided, it returns the count of the whole type.


#### Parameters
##### type (`string`)

The type of the actions. Will return count for all actions if not provided.

##### user_id (`string`)

The user id of the actions. Wll return count for all user ids if not provided.

##### item_id (`string`)

The item id of the actions. Wll return count for all item ids if not provided.

##### older_than (`string`)

Delete all actions of a type older than the given timestamp or time.
Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195).


### Delete Actions
If `type` is not provided, it'll return the total number of actions.
Otherwise when `type` is provided
* If both `user_id` and `item_id` are supplied it returns the count of the corresponding actions.
* If only `user_id` is provided, it returns the count of all the action of the given user.
* If only `user_id` is provided, it returns the count of all the action of the given item.
* If only `older_than` is provided, it returns the count of actions older than the given timestamp.
* If a few of these parameters are provided, it returns the count of the intersection of these parameters.
* If none of these are provided, it returns the count of the whole type.


#### Parameters
##### type (`string`)

The type of the actions. Will return count for all actions if not provided.

##### user_id (`string`)

The user id of the actions. Wll return count for all user ids if not provided.

##### item_id (`string`)

The item id of the actions. Wll return count for all item ids if not provided.

##### older_than (`string`)

Delete all actions of a type older than the given timestamp or time.
Valid times are 1s, 1m, 1h, 1d, 1M, 1y, or unix timestamp (like 1443798195).




## Metadata Methods
Metadata methods are for posting and deleting metadata.
For more information on metadata, refer to [Metadata concept documentation ](http://www.suggestgrid.com/docs/concepts#metadata).

### Post a User
Posts a user metadata.

#### Parameters
##### user_id (`string`)

  * Required: `true`

The user id to associate with the metadata.

##### Metadata (`object`)

  * ###### id (`string`)

    * Required: `false`

### Post Bulk Users
Post user metadata in bulk.
This metadata can be used to filter or to be included in recommendations and similars methods.


#### Parameters
### Get Users
Get information about users. Only returns count at the moment.

### Delete a User
Delete a user metadata with the given user_id.

#### Parameters
##### user_id (`string`)

  * Required: `true`

The user_id to delete its metadata.

### Delete All Users
Deletes all user metadata from SuggestGrid.

### Post an Item
Posts an item metadata.
This metadata can be used to filter or to be included in recommendations and similars methods.


#### Parameters
##### item_id (`string`)

  * Required: `true`

The item id to associate with the metadata.

##### Metadata (`object`)

  * ###### id (`string`)

    * Required: `false`

### Post Bulk Items
Post item metadata in bulk.
This method is recommended for sharing stored data with SuggestGrid.


#### Parameters
### Get Items
Get information about items. Only returns count at the moment.

### Delete an Item
Delete an item metadata with the given item_id.

#### Parameters
##### item_id (`string`)

  * Required: `true`

The item_id to delete its metadata.

### Delete All Items
Delete all items metadata.
This method would flush all items metadata on SuggestGrid.




## Recommnedation Methods
Recommnedation methods are for getting recommended items or users responses from SuggestGrid.
For more information on recommendations, refer to [Recommendations concept documentation](http://www.suggestgrid.com/docs/concepts#recommendations).

### Get Recommended Users
Recommend users for the given body parameters.

#### Parameters
##### GetRecommendedUsersBody (`object`)

  * ###### item_ids (`array`)

    * Required: `false`

  * ###### except (`array`)

    * Required: `false`

  These ids will not be included in the response.


  * ###### type (`string`)

    * Required: `true`

  * ###### size (`integer`)

    * Required: `false`

  * ###### fields (`array`)

    * Required: `false`

  * ###### filter

    * Required: `false`

  * ###### similar_user_id (`string`)

    * Required: `false`

  * ###### item_id (`string`)

    * Required: `false`

### Get Recommended Items
Recommend items for the given body parameters.

#### Parameters
##### GetRecommendedItemsBody (`object`)

  * ###### except (`array`)

    * Required: `false`

  These ids will not be included in the response.


  * ###### user_ids (`array`)

    * Required: `false`

  * ###### similar_item_id (`string`)

    * Required: `false`

  * ###### type (`string`)

    * Required: `true`

  * ###### size (`integer`)

    * Required: `false`

  * ###### fields (`array`)

    * Required: `false`

  * ###### user_id (`string`)

    * Required: `false`

  * ###### filter

    * Required: `false`



## Similarity Methods
Similarity methods are for getting similar items or users responses from SuggestGrid.
For more information on similars, refer to [Similarities concept documentation](http://www.suggestgrid.com/docs/concepts#similarities).

### Get Similar Users
Get similar users to a user.

#### Parameters
##### GetSimilarUsersBody (`object`)

  * ###### fields (`array`)

    * Required: `false`

  * ###### user_id (`string`)

    * Required: `false`

  * ###### filter

    * Required: `false`

  * ###### user_ids (`array`)

    * Required: `false`

  * ###### type (`string`)

    * Required: `true`

  * ###### size (`integer`)

    * Required: `false`

  * ###### except (`array`)

    * Required: `false`

  These ids will not be included in the response.


### Get Similar Items
Get similar items to an item.

#### Parameters
##### GetSimilarItemsBody (`object`)

  * ###### fields (`array`)

    * Required: `false`

  * ###### item_ids (`array`)

    * Required: `false`

  * ###### filter

    * Required: `false`

  * ###### type (`string`)

    * Required: `true`

  * ###### item_id (`string`)

    * Required: `false`

  * ###### size (`integer`)

    * Required: `false`

  * ###### except (`array`)

    * Required: `false`

  These ids will not be included in the response.


