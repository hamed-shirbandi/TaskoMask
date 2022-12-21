# What is TaskoMask?


  
<p align="left">

[![build and test](https://github.com/hamed-shirbandi/TaskoMask/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/hamed-shirbandi/TaskoMask/actions/workflows/ci.yml)
  <a href="https://github.com/hamed-shirbandi/TaskoMask/issues">
  <img alt="GitHub issues" src="https://img.shields.io/github/issues/hamed-shirbandi/TaskoMask">
</a>
 <a href="http://taskomask.ir">
  <img src="https://img.shields.io/website?url=http://taskomask.ir">
</a>
   <a href="https://github.com/hamed-shirbandi/TaskoMask/blob/master/LICENSE">
 <img src="https://img.shields.io/github/license/hamed-shirbandi/TaskoMask">
</a>
 <a href="https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors">
  <img src="https://img.shields.io/github/contributors/hamed-shirbandi/TaskoMask">
</a>
</p>

[TaskoMask](http://taskomask.ir/) is a free and open-source task management system based on .Net. This project is [online](http://taskomask.ir/), and everyone can use it as a team member or project owner.
But the primary goal of this project is to be an effort to show how we can implement software technologies and patterns by .Net, so this can be used by developers who are looking for a real example project with real challenges. Please take a look at its [wiki](https://github.com/hamed-shirbandi/TaskoMask/wiki)!

Try it online:
[`Website`](http://taskomask.ir/) - [`User Panel`](http://panel.taskomask.ir) - [`API`](http://api.taskomask.ir/)

![taskomask website](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/images/Shots/taskomask-all-in-one-mobile.jpg)
# Documentation
  - [Domain Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Domain-Documentation)
  - [Architecture Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Architecture-Documentation)
  - [API Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Rest-Api-Documentation)
  - [User Guide Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/User-Guide-Documentation)
  - [Run with Docker Compose](https://github.com/hamed-shirbandi/TaskoMask/wiki/Development-Setup#how-to-run-with-docker-compose)

# Plan and Progress
All information presented after this section are the final goal and our big picture. Maybe at this time some of them are not ready yet. To see the progress and the timing for each task, please take a look at the following items:

- [Milestones Page](https://github.com/hamed-shirbandi/TaskoMask/milestones)
- [Current Sprint Board](https://github.com/users/hamed-shirbandi/projects/2/views/17)
- [All Tasks Board](https://github.com/users/hamed-shirbandi/projects/2)

# Design
#### 🔴Work is in progress
![development architecture](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/images/Architecture/deployment-architecture-v2.jpg)

  * ### Onion Architecture
    <details>
      <summary>click for details</summary>


    - Architecture was Onion until this [last commit](https://github.com/hamed-shirbandi/TaskoMask/tree/af7f7418c7811ecf2db3bb9324bd070e37eb7a82)
    </details>
  * ### Clean Architecture
  * ### Vertical Slice Architecture
  * ### Feature Folder Structure
  * ### Monolithic Architecture
    <details>
      <summary>click for details</summary>


    - Architecture was Monolithic until this [last commit](https://github.com/hamed-shirbandi/TaskoMask/tree/af7f7418c7811ecf2db3bb9324bd070e37eb7a82)
    </details>
  * ### Microservices Architecture
    <details>
      <summary>click for details</summary>


    - [Strangler application pattern](https://microservices.io/refactoring/)
    - [Decompose by subdomain](https://microservices.io/patterns/decomposition/decompose-by-subdomain.html)
    - [Database per service](https://microservices.io/patterns/data/database-per-service.html)
    - [Saga](https://microservices.io/patterns/data/saga.html)
    - [API Composition](https://microservices.io/patterns/data/api-composition.html)
    - [Docker](https://www.docker.com/)
    - [Docker-Compose](https://docs.docker.com/compose/)
    - [Kubernetes](https://kubernetes.io/)
    - [Messaging](https://microservices.io/patterns/communication-style/messaging.html) : MassTransit (RabbitMQ)
    - [Remote Procedure Call](https://microservices.io/patterns/communication-style/rpi.html) : Grpc.AspNetCore
    - [Idempotent Consumer](https://microservices.io/patterns/communication-style/idempotent-consumer.html)
    - [API Gateway](https://microservices.io/patterns/apigateway.html) : Ocelot
    - [Backend for front-end](https://microservices.io/patterns/apigateway.html)
    - [Service discovery](https://microservices.io/patterns/3rd-party-registration.html) : Kubernetes - Consul
    - [Circuit Breaker](https://microservices.io/patterns/reliability/circuit-breaker.html) : Polly
    - [Log aggregation](https://microservices.io/patterns/observability/application-logging.html) : Serilog - Seq
    - [Application metrics](https://microservices.io/patterns/observability/application-metrics.html) : Opentelemetry-dotnet - Prometheus
    - [Distributed tracing](https://microservices.io/patterns/observability/distributed-tracing.html) : Opentelemetry-dotnet - Jaeger
    - [Health check API](https://microservices.io/patterns/observability/health-check-api.html) : AspNetCore.HealthChecks
    - [IDP](https://en.wikipedia.org/wiki/Identity_provider) : DuendeSoftware IdentityServer
    </details>
  * ### Testing (TDD & BDD)
    <details>
      <summary>click for details</summary>


    - [Unit Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Unit) : xUnit, FluenAssertion, NSubstitute
    - [Integration Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Integration)
    - [API Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Acceptance/Tests.Acceptance.API)
    - [UI Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Acceptance/Tests.Acceptance.UI): Selenium
    - [Acceptance Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Acceptance) : Gherkin, SpecFlow
    - [Screenplay Pattern](https://serenity-js.org/handbook/design/screenplay-pattern.html#:~:text=The%20Screenplay%20Pattern%20is%20a,testing%20and%20software%20engineering%20habits.) : Suzianna
    - Well written tests organized in :
        - [Business Rule Layer](https://www.oreilly.com/library/view/bdd-in-action/9781617291654/)
        - [Business Flow Layer](https://www.oreilly.com/library/view/bdd-in-action/9781617291654/)
        - [Technical Layer](https://www.oreilly.com/library/view/bdd-in-action/9781617291654/)
    - [Object Mother Pattern](http://xunitpatterns.com/Test%20Helper.html#Object%20Mother)
    - Test Data Builder
    - Test Hooks
    - Test Doubles
    - Dummy
    - Stub
    - Mock
    - Teardown
        - [Sandbox](http://xunitpatterns.com/Database%20Sandbox.html)
    - Fixture Management
        - [Fresh](http://xunitpatterns.com/Fresh%20Fixture.html)
        - [Shared](http://xunitpatterns.com/Shared%20Fixture.html)
        - [Transient](http://xunitpatterns.com/Fresh%20Fixture.html#Transient%20Fresh%20Fixture)
        - [Persistent](http://xunitpatterns.com/Persistent%20Fixture%20Management.html)
    - Verification
        - [State Verification](http://xunitpatterns.com/ResultVerification.html)
        - [Output/Value Verification](http://xunitpatterns.com/ResultVerification.html)
        - [Interaction/Behavior Verification](http://xunitpatterns.com/ResultVerification.html)
    </details>
  * ### DDD
    <details>
      <summary>click for details</summary>


    - Rich Domain Model (for core domain)
    - Anemic Domain Model (for less important subdomains)
    - Aggregate
    - Value Object
    - Domain Event
    - Domain Service
    - Always Valid Domain Model
    - Invariants
    - Specification
    - Factory Method
    - Optimistic Concurrency
    - Separate Domain Model and Data Model
    </details>
  * ### CQRS
    <details>
      <summary>click for details</summary>


    - Separate Read and Write Model
    - Separate Read Side DB and Write Side DB
    </details>
  * ### Use Case Driven Development
  * ### Event Sourcing
  * ### Unit of Work
  * ### Repository
  * ### Notification

# Implementation
  * ### Back-end:
    <details>
      <summary>click for details</summary>


      - .Net 6 
      - C#
      - ASP.NET Web API
      - ASP.NET MVC
      - ASP.NET Identity
      -	MongoDB
      -	Redis
      - [Ocelot](https://ocelot.readthedocs.io/) : .NET core API Gateway
      - [DuendeSoftware IdentityServer](https://docs.duendesoftware.com/identityserver/v6) : OpenID Connect and OAuth 2.x framework for ASP.NET Core
      - [MassTransit](https://masstransit-project.com/) : a framework on top of message transports such as RabbitMQ 
      - [xUnit](https://xunit.net/) : testing framework
      -	[FluenAssertion](https://fluentassertions.com/) : write fluent assertions
      - [NSubstitute](https://nsubstitute.github.io/) : to make test double (Mock, stub, fake, spy)
      - [Gherkin](https://specflow.org/learn/gherkin/) : use native language to describe test cases
      - [SpecFlow](https://www.nuget.org/packages/SpecFlow.xUnit/) : turns Gherkin scenarios into automated tests
      - [Suzianna](https://github.com/suzianna/Suzianna) : writing acceptance tests, using Screenplay Pattern
      - [Selenium](https://www.nuget.org/packages/Selenium.WebDriver/) : supporting browser automation
      -	[MediatR](https://github.com/jbogard/MediatR) : simple mediator implementation
      -	[Grpc.AspNetCore](https://www.nuget.org/packages/Grpc.AspNetCore/) : gRPC library for ASP.NET Core
      -	[AutoMapper](https://automapper.org/) : an object-object mapper
      -	[FluentValidation](https://docs.fluentvalidation.net/en/latest/) : building strongly-typed validation rules
      -	[Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore) : expose Swagger JSON endpoints from APIs
      -	[Serilog](https://serilog.net/) : provides diagnostic logging
      - [AspNetCore.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) : ASP.NET Core Health Check
      -	[MvcPagedList.Core](https://www.nuget.org/packages/MvcPagedList.Core/) : easily paging in ASP.NET Core MVC
      -	[EasyCaching](https://github.com/dotnetcore/EasyCaching) : caching library
    </details>
  * ### Front-end:
    <details>
      <summary>click for details</summary>


      - Blazor
        - Blazor Server ([last commit](https://github.com/hamed-shirbandi/TaskoMask/tree/a6f036f91c2185861209191d9bb3e4ae01665f46/Src/Presentation/3-UI/UserPanel))
            - Cookie Authentication without ASP.NET Identity
        - Blazor WebAssembly (standalone)
            - JWT Authentication
        - Comunication between components
        - Local Storage
        - Consume REST API
        - Retry using HttpClientRetryHelper
        - Handle Drag and Drop
        - Using Modal, Toast, etc.
      -	.HTML
      -	CSS
      -	JavaScript 
      -	JQuery
      -	Bootstrap
      -	Jquery.noty
      -	Chart.js
    </details>
  * ### Some other Features:
    <details>
      <summary>click for details</summary>


      -	Caching Behavior using Pipeline Pattern
      -	Validation Behavior using Pipeline Pattern (Check both Fluent Validation and Data Annotation Validation)
      -	Event Storing Behavior using Pipeline Pattern
      - Exception Handling
      -	Cookie Authentication
      -	JWT Authentication
      -	Role Permission Base User Management without ASP.NET Identity
      -	Swagger UI with JWT Support
    </details>

# Contributing
Contributions, issues, and feature requests are welcome. Any contributions you make are greatly appreciated.
  >Please see the [Contribution Guide](https://github.com/hamed-shirbandi/TaskoMask/tree/master/docs/CONTRIBUTING.md) and follow the instructions to be a part of this project.

This project exists thanks to all the people who [contribute](https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors).

<a href="https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors">
  
  ![GitHub Contributors Image](https://contrib.rocks/image?repo=hamed-shirbandi/TaskoMask)
  
</a>

# Articles And Tutorials
* [Real-world open-source project based on .NET 6 with DDD, ES, CQRS concepts](https://medium.com/@hamed.shirbandi/real-world-open-source-project-based-on-ddd-es-cqrs-af261cc24353)
* [How to Blazor articles](https://medium.com/@hamed.shirbandi/how-to-blazor-articles-2bda783d9502)
* [Learning By Doing (podcats)](https://topenddevs.com/podcasts/adventures-in-net/episodes/learning-by-doing-net-122)

# Supporting
We work hard to make something useful for .NET community, so please give a star ⭐ if this project helped you!
We need your support by giving a star or contributing or sharing this project with anyone who can benefit from it.

# Author & License
This project is developed by [Hamed Shirbandi](https://github.com/hamed-shirbandi) under [MIT](https://github.com/hamed-shirbandi/TaskoMask/blob/master/LICENSE) licensed.
Find Hamed around the web and feel free to ask your question.

<a href="https://www.linkedin.com/in/hamed-shirbandi"><img alt="LinkedIn" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/LinkedIn-v2.png" width="35"></a><a href="https://www.instagram.com/hamedshirbandi"><img alt="Instagram" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Instagram-v2.png" width="35"></a><a href="https://github.com/hamed-shirbandi"><img alt="GitHub" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/GitHub-v2.png" width="35"></a><a href="https://medium.com/@hamed.shirbandi"><img alt="Medium" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Medium-v2.png" width="35"></a><a href="https://www.nuget.org/profiles/hamed-shirbandi"><img alt="Nuget" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Nuget-v3.png" width="35"></a><a href="mailto:hamed.shirbandi@gmail.com"><img alt="Email" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Email-v2.png" width="35"></a><a href="https://t.me/hamed_shirbandi"><img alt="Telegram" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Telegram-v2.png" width="35"></a><a href="https://twitter.com/hamed_shirbandi"><img alt="Twitter" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Twitter-v2.png" width="35"></a>

# Change logs
*	### Dec, 2022
    - [x] Handle RPC requests by gRPC
    - [x] Extract API Gateway Aggregator
    - [x] Complete API Gateway Configs by Ocelot
*	### Nov, 2022
    - [x] Implement Unit Tests for Owner Services
    - [x] Implement Integration Tests for Owner Services
*	### Oct, 2022
    - [x] Extract Owner Write Service
    - [x] Extract Owner Read Service
    - [x] Handle Messaging by RabbitMQ
*	### Sep, 2022
    - [x] Extract Identity Service
    - [x] Add IdentityServer as IDP
    - [x] Add ASP.NET Identity
    - [x] Add User Panel API Gateway
    - [x] Refactor to Clean Architecture
    - [x] Follow Vertical Slice Architecture
    - [x] Follow Use Case Driven Development
*	### Aug, 2022
    - [x] Migrate from Monolith to Microservices
*	### July, 2022
    - [x] Convert UserPanel from Blazor Server to Blazor WebAssembly
    - [x] Complete the functionalities for single user usage
*	### Apr, 2022
    - [x] Implement Unit Tests
    - [x] Implement Integration Tests
    - [x] Implement Acceptance Tests
    - [x] Implement API Tests
    - [x] Implement UI Tests
*	### Jan, 2022
    - [x] Full refactor Domain model with DDD concepts
    - [x] Separate Domain Model and Data Model
    - [x] Separate Read Side and Write Side Database
*	### Dec, 2021
    - [x] Upgrade to .NET 6
*	### Nov, 2021
    - [x] Convert user panel from ASP.NET MVC to Blazor Server
*	### Oct, 2021
    - [x] Implement admin panel with ASP.NET MVC
    - [x] Implement administration subdomain
*	### Aug, 2021
    - [x] Remove Asp.net Identity
    - [x] Add cookie authentication
    - [x] Add JWT authorization
    - [x] Implement API with ASP.NET Web API
*	### Jul, 2021
    - [x] Full refactore
*	### Nov, 2020
    - [x] Upgrad from net 3.1 to net 5
    - [x] Implement user panel with ASP.NET MVC
*	### Oct, 2020
    - [x] Implement Website with ASP.NET MVC
    - [x] Implement Anemic Domain Model
    - [x] Create Repository
  