# Getting started with Aggregate Services

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

Note: Following OData convention the controller name is always a pluralised version of the model name. 

Note: The in the example above we rely on DI to select the appropriate implementation of the repository.

The class can have further actions of you need to add functions/actions to your OData service.

### Step 4: Register the repository and API controllers in DI container

Register the repository in the DI continer like this:

```
    public void Configure(IServiceCollection serviceCollection)
    {
        var assemblies = new[] { this.GetType().Assembly };
        serviceCollection.AddWebApiControllers(assemblies);
        serviceCollection.AddSingleton<IReadOnlyEntityRepository<Todo>, TodoRepository>();
    }
```

Note: Lifetime choosen for repository is dependent on nature of service. Here Singleton is used only an an example.

### Step 5: Register OData metadata

Create a class that derives from `Sitecore.Services.Core.OData.AggregateDescriptor`. Use the base constructor to specify your EdmModelBuilder.

Implement an `Sitecore.Services.Core.OData.Edm.IEdmModelBuilder` that describes your service (or for simple service aggrigates use the `DefaultEdmModelBuilder`). 
