# Development Tooling

## Source Control and Branching Workflow

* [Git](https://git-scm.com/)

* [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)

* [GitVersion](https://github.com/GitTools/GitVersion)


## Configuring a Local Development Machine

The [Chocolatey](https://chocolatey.org/install) package manager can be used to install all of the tooling required to work on the repository.

```
    choco install git
    choco install gitversion.portable
    choco install npm
    choco install pester
```

Intialising Gitflow for the repository is required if you wish to work with this extension. When prompted, use the defaults provided by the `git flow init`command to initialise the branching workflow.

```
    git flow init
```


## Docker Dependencies

The connection strings in the website are setup to access [Mongo](https://docs.mongodb.com/) via a [Docker](https://www.docker.com/) container.

The `Website\App_Config\ConnectionStrings.config` file should have the Mongo connection strings configured as shown below:

```
    <?xml version="1.0" encoding="utf-8"?>
    <connectionStrings>
        <!-- 
            Sitecore connection strings.
            All database connections for Sitecore are configured here.
        -->
        <add name="core" connectionString=" ... " />
        <add name="master" connectionString=" ... " />
        <add name="web" connectionString=" ... " />
        <add name="analytics" connectionString="mongodb://mongo:27017/ssc_aggregate_analytics" />
        <add name="tracking.live" connectionString="mongodb://mongo:27017/ssc_aggregate_tracking_live" />
        <add name="tracking.history" connectionString="mongodb://mongo:27017/ssc_aggregate_tracking_history" />
        <add name="tracking.contact" connectionString="mongodb://mongo:27017/ssc_aggregate_tracking_contact" />
        <add name="reporting" connectionString=" ... " />
    </connectionStrings>
```

To setup this configuration execute the following from the Docker Quickstart Terminal:

```
    docker run -d -p 27017:27017 mongo
```

Then setup a host entry in `%WinDir%\system32\drivers\etc\hosts` as follows:

```
    <IP address of Docker machine>  mongo
```

To access the Docker machine IP address 

```
    docker-machine ip
```

To verify that the mongo database server is up and listening correctly load [http://mongo:27017/](http://mongo:27017/) in a browser. You should get the following response HTTP 200 OK response with the following being returned in the body of the response:

```
    It looks like you are trying to access MongoDB over HTTP on the native driver port.
```


## Command Line Build

The project uses [MSBuild](https://msdn.microsoft.com/en-us/library/0k6kkbsd.aspx) for its build system.

The Command Line Build is documented in [build/README.md](../build/README.md). Please review this documentation as it will inform you how to setup your local developer environment.

To run the build from the command line enter the following from the root of the repository

```
    build.cmd
```

The build process accepts **target** and **config** parameters as shown below:

```
    build.cmd test release
```


### Build Pre-Requisites

A Sitecore website installed locally with the host name of `scc.aggregate`.

[Sitecore Instance Manager](https://marketplace.sitecore.net/en/Modules/Sitecore_Instance_Manager.aspx) (SIM) can be used to install Sitecore instances on your local developer machine. A Sitecore Internal [download site](http://dl.sitecore.net/updater/sim/) is provided for the latest build of SIM.

