# Sitecore Services Client Aggregate Service API

A community repository that provides API documentation for the [Sitecore Services Client][6] Aggregate Service.


## Developing with SSC and OData

The [Getting started with Aggregate Services][3] document will introduce the moving parts associated with the composition of an aggregate service.

* Service Descriptor
* EDM Model Builder
* Model(s)
* Service Controller(s)
* Read-Only Repository classes

For further details refer to the [Aggregate Services Code Examples][4] documentation.

## Online resources

 - [Source code][1]
 - [Aggregate Service documentation][2]
 - [Getting started with Aggregate Services guide][3]
 - [Aggregate Services Code Examples][4]
 - [SSC.AggregateService.Sample NuGet package][8]


## Instructions for Use

The latest release versions of the SSC.AggregateService packages can be found in the [NuGet package gallery][9]

* [SSC.AggregateService.Sample][8] 


### Installing SSC.AggregateService.Sample via NuGet

Ensure that the website project is set to run with .NET Framework 4.5.2

The Sitecore MyGet feed will need to be added to be added to the list of Package Manager feed sources

    https://sitecore.myget.org/F/sc-packages/api/v3/index.json

Run the following PowerShell command in the Package Manager Console of the Visual Studio solution for the target website:

    PM:> Install-Package SSC.AggregateService.Sample

If you experience difficulties in restoring the Sitecore MyGet dependencies these can be installed separately:

    PM:> Install-Package Sitecore.Services.Component -version 8.2.160729 -source https://sitecore.myget.org/F/sc-packages/api/v3/index.json



## Contributing to the Project

Please take a look at the [Development Tooling][5] documentation for information on how the GIT repos and command line build operates.


## License

The [MIT license][7]


 [1]: https://github.com/kevinobee/SSC.AggregateService/
 [2]: http://docs.sscaggregateservice.apiary.io/
 [3]: doc/features/Aggregate-Services-Getting-Started.md
 [4]: doc/features/Aggregate-Services-Code-Examples.md
 [5]: doc/Development-Tooling.md
 [6]: https://sitecorecontextitem.wordpress.com/2015/01/07/what-is-sitecore-services-client/
 [7]: https://github.com/kevinobee/SSC.AggregateService/blob/master/LICENSE
 [8]: https://www.nuget.org/packages/SSC.AggregateService.Sample/
 [9]: https://www.nuget.org/packages/ 
 [10]: https://sitecore.myget.org/F/sc-packages/api/v3/index.json
