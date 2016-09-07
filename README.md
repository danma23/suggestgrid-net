# [ SuggestGrid .NET Client ]( http://www.github.com/suggestgrid/suggestgrid-net )

We will walk through how to get started with SuggestGrid .NET Client in three steps:
    
1. [Configuration](#1-configuration)
    
2. [Post actions](#2-post-actions)
    
3. [Get recommendations](#3-get-recommendations)

If you did not [sign up for SuggestGrid](https://dashboard.suggestgrid.com/users/sign_up), this is the right time.

## Getting Started

In this guide we will demonstrate how to display personalized recommendations on an existing .NET Framework project.

We have a movie catalog .NET Framework application, SuggestGridMovies, similar to IMDb.
For logged in users we want to display movies that *similar people viewed* on movie pages.
Let's implement this feature in five minutes with SuggestGrid!

### 1. Configuration

We are beginning the development by adding the client as a dependency:


From the package manager console inside visual studio

PM> Install-Package SuggestGrid

Or search in the Package Manager UI for SuggestGrid or manually add to your packages.config file.



Applications make their API requests to their dedicated sub-domain of `suggestgrid.space`.

Most endpoints require a username and password for authentication.

An initial user name and password is given on sign up.

It is very convenient to configure SuggestGrid by setting an authenticated `SUGGESTGRID_URL` environment variable in the format below:

`http://{user}:{pass}@{region}.suggestgrid.space/{app-uuid}`

You can authenticate your application using `SUGGESTGRID_URL` environment variable like the example below:

```csharp
suggestGridURL = System.Environment.GetEnvironmentVariable("SUGGESTGRID_URL");

# Initialize the SuggestGrid client.
var suggestGridClient = new SuggestGridClient(suggestGridURL);
```


Every recommendation logic needs to belong to a *type*.
For this demonstration we can create an implicit type named as `views`.
This could be done either from the dashboard or with a snippet like this:

```csharp
try
{
    suggestGridClient.Type.GetType("views");
}
catch (Exception)
{
    suggestGridClient.Type.CreateType("views", new TypeRequestBody { Rating = "implicit" });

}
```



### 2. Post actions

Once the type exists, let's start posting actions.
We should invoke SuggestGrid client's PostAction when an user views an item in our application.

We can do this by putting the snippet below on the relevant point:

```csharp
suggestGridClient.Action.PostAction(new ActionModel { ItemId = "1", UserId = "2" });
```


The more actions SuggestGrid gets, more relevant and diverse its responses are.


### 3. Get recommendations

Finally, let's show "movies similar users viewed" on movie pages.

SuggestGrid needs *recommendation models* for returning recommendations.
Model generation is scheduled in every 24 hours.
In addition, instant model generations can be triggered on the dashboard.

Once the first model generated for 'views' type, recommendations could be get using a snippet like the following:

```csharp
var recommendedItems = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "2",
    Size = 2
});

var items = recommendedItems.Items; // get items
```
