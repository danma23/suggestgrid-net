# [ SuggestGrid .NET Framework Client ]( http://www.github.com/suggestgrid/suggestgrid-net )

We will walk through how to get started with SuggestGrid .NET Framework Client in three steps:
    
1. [Configuration](#1-configuration)
    
2. [Post actions](#2-post-actions)
    
3. [Get recommendations](#3-get-recommendations)

## Getting Started

In this guide we will demonstrate how to display personalized recommendations on an existing .NET Framework project.

We have a movie catalog .NET Framework application, SuggestGridMovies, similar to IMDb.
For logged in users we want to display movies that *similar people viewed* on movie pages.
Let's implement this feature in five minutes with SuggestGrid!

### 1. Configuration

We are beginning the development by adding the client as a dependency.

SuggestGrid .NET client is a .NET Core library and could be used from a variety of .NET frameworks.

Install the package from the package manager console inside Visual Studio:

```
PM> Install-Package SuggestGrid
```

One can also SuggestGrid in the Package Manager UI or manually add the dependecy to packages.config or project.json files.



Once you [sign up for SuggestGrid](https://dashboard.suggestgrid.com/users/sign_up), you'll see your SUGGESTGRID_URL parameter on the dashboard in the format below:

`http://{user}:{pass}@{region}.suggestgrid.space/{app-uuid}`

You can authenticate your application using `SUGGESTGRID_URL` environment variable like the example below:

```csharp
string suggestGridURL = System.Environment.GetEnvironmentVariable("SUGGESTGRID_URL");
SuggestGridClient suggestGridClient = new SuggestGrid.SuggestGridClient(suggestGridURL);
```


Every recommendation logic needs to belong to a *type*.
For this demonstration we can create an implicit type named as `views`.
This could be done either from the dashboard or with a snippet like this:

```csharp
try
{
    suggestGridClient.Type.GetType("views");
}
catch (APIException e)
{
    suggestGridClient.Type.CreateType("views", new TypeRequestBody { Rating = "implicit" });
}
```



### 2. Post actions

Once the type exists, let's start posting actions.
We should invoke SuggestGrid client's suggestGridClient.Action.PostAction when an user views an item in our application.

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
var recommendedItemsResponse = suggestGridClient.Recommendation.GetRecommendedItems(new GetRecommendedItemsBody
{
    Type = "views",
    UserId = "2",
    Size = 2
});

var recommendedItems = recommendedItemsResponse.Items; // get items
```
