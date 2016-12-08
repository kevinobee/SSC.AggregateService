# Getting started with Aggregate Services

This quick start document outlines how to get started with the [SSC Aggregate Service][4] features introduced in [Sitecore 8.2][6]

For details of the underlying ASP.NET features refer to the [Microsoft OData stack][5] documentation.

## Setting up an OData Services API

### Step 1: Create a Model class

Create a class that implements `IEntityIdentity` (or derive from the abstract `EntityIdentity` class). The model class will represent an OData EntitySet.

Example:

```
    public class Todo : EntityIdentity
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
```

### Step 2: Create a repository class

Implement `Sitecore.Services.Core.Data.IReadOnlyEntityRepository<Todo>` - this repository is the mechanism SSC uses to talk to your data.

### Step 3: Create the API controller 

For simple EntitySets we use the controller solely to wire up the API controller and the repository.

Example:

```
    public class TodoListController : ServicesBaseODataController<Todo>
    {
        public TodoListController(IReadOnlyEntityRepository<Todo> repository) : base(repository)
        {
        }
    }
```

Note: Following OData convention the controller name is always a pluralized version of the model name. 

Note: The in the example above we rely on DI to select the appropriate implementation of the repository.

The class can have further actions of you need to add functions/actions to your OData service.

### Step 4: Register the repository and API controllers in DI container

Register the repository in the DI container like this:

```
    public void Configure(IServiceCollection serviceCollection)
    {
        var assemblies = new[] { this.GetType().Assembly };
        serviceCollection.AddWebApiControllers(assemblies);
        serviceCollection.AddSingleton<IReadOnlyEntityRepository<Todo>, TodoRepository>();
    }
```

Note: Lifetime chosen for repository is dependent on nature of service. Here Singleton is used only an an example.

### Step 5: Register OData metadata

Create a class that derives from `Sitecore.Services.Core.OData.AggregateDescriptor`. Use the base constructor to specify your EdmModelBuilder.

Implement an `Sitecore.Services.Core.OData.Edm.IEdmModelBuilder` that describes your service or, for simple service aggregates, use the `DefaultEdmModelBuilder`. 


## SSC Aggregate Services: References

1. **API Documentation** is available [online][2].

    The API documentation site also provides users with the chance to interact with a mock of the API and inspect recent traffic sent to this API mock.

2. **Code Examples** can be found in the [SSC.AggregateService project][1] on GitHub. For further details refer to the [Aggregate Services Code Examples][3] documentation.



 [1]: https://github.com/kevinobee/SSC.AggregateService/
 [2]: http://docs.sscaggregateservice.apiary.io/
 [3]: Aggregate-Services-Code-Examples.md
 [4]: ../../README.md
 [5]: http://odata.github.io/
 [6]: https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform.aspx