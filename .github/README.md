# What is TaskoMask?


  
<p align="left">

[![build and test](https://github.com/hamed-shirbandi/TaskoMask/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/hamed-shirbandi/TaskoMask/actions/workflows/ci.yml)
[![Mutation testing](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2Fhamed-shirbandi%2FTaskoMask%2Fmaster)](https://dashboard.stryker-mutator.io/reports/github.com/hamed-shirbandi/TaskoMask/master)
<a href="https://github.com/hamed-shirbandi/TaskoMask/issues">
<img alt="GitHub issues" src="https://img.shields.io/github/issues/hamed-shirbandi/TaskoMask">
</a>
<a href="http://taskomask.online">
<img src="https://img.shields.io/website?url=http://taskomask.online">
</a>
<a href="https://github.com/hamed-shirbandi/TaskoMask/blob/master/LICENSE">
<img src="https://img.shields.io/github/license/hamed-shirbandi/TaskoMask">
</a>
<a href="https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors">
<img src="https://img.shields.io/github/contributors/hamed-shirbandi/TaskoMask">
</a>
</p>


[TaskoMask](https://github.com/hamed-shirbandi/TaskoMask/wiki/User-Guide-Documentation) is an open-source task management system built on the .Net framework. The primary objective of this project is to demonstrate the practical application of advanced software development concepts such as DDD (Domain-Driven Design), TDD (Test-Driven Development), BDD (Behavior-Driven Development), and Microservices.

In many cases, the experience of applying these concepts to real-world software products is often obscured by proprietary software companies. TaskoMask seeks to provide transparency and insight into their usage.

We invite you to explore our project's [wiki](https://github.com/hamed-shirbandi/TaskoMask/wiki) for more information

Try it [[online](http://taskomask.online)]

![taskomask website](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/images/Shots/taskomask-all-in-one-mobile.jpg)
# Documentation
  - [Domain Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Domain-Documentation)
  - [Architecture Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Architecture-Documentation)
  - [Run with Docker Compose](https://github.com/hamed-shirbandi/TaskoMask/wiki/Development-Setup#how-to-run-with-docker-compose)
  - [User Guide Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/User-Guide-Documentation)

# Plan and Progress
All the information presented beyond this section represents our project's final objectives and the broader vision. It's important to note that some of these elements may still be a work in progress. To gain insight into our project's roadmap and track our progress, please refer to the following items:

- [Milestones Page](https://github.com/hamed-shirbandi/TaskoMask/milestones)
- [Current Sprint Board](https://github.com/users/hamed-shirbandi/projects/2/views/18)
- [All Tasks Board](https://github.com/users/hamed-shirbandi/projects/2)

# Design
#### 🔴Work is in progress
Here is a comprehensive list of the patterns, principles, approaches, and methodologies that we have incorporated into our project's design. It's important to note that these have been included as examples to showcase their usage within a project. In a real-world design, you would need to carefully evaluate and select the most appropriate ones based on your project's specific trade-offs and requirements.

![development architecture](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/images/Architecture/deployment-architecture-v2.jpg)

  * ### Clean Architecture
  * ### Vertical Slice Architecture
  * ### Feature Folder Structure
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
    - [Application metrics](https://microservices.io/patterns/observability/application-metrics.html) : prometheus-net
    - [Distributed tracing](https://microservices.io/patterns/observability/distributed-tracing.html) : Opentelemetry-dotnet - Jaeger
    - [Health check API](https://microservices.io/patterns/observability/health-check-api.html) : AspNetCore.HealthChecks
    - [IDP](https://en.wikipedia.org/wiki/Identity_provider) : DuendeSoftware IdentityServer
    </details>
  * ### Testing (TDD & BDD)
    <details>
      <summary>click for details</summary>


    - Unit Testing
    - Integration Testing
    - API Testing
    - UI Testing
    - Acceptance Testing
    - Mutation Testing (check [dashboard reporter](https://dashboard.stryker-mutator.io/reports/github.com/hamed-shirbandi/TaskoMask/master#mutant))
    - [Screenplay Pattern](https://serenity-js.org/handbook/design/screenplay-pattern.html#:~:text=The%20Screenplay%20Pattern%20is%20a,testing%20and%20software%20engineering%20habits.)
    - Well written Acceptance Tests organized in :
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
    - Living Documentation
    </details>
  * ### DDD
    <details>
      <summary>click for details</summary>


    - Rich Domain Model
    - Aggregate
    - Entity
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


    - Separated Read and Write Model
    - Separated Read and Write DB
    </details>
  * ### Use Case Driven Development
  * ### Event Sourcing
  * ### Repository
  * ### Notification

# Implementation
Here is a comprehensive list of the tools and technologies we have employed to implement this project.

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
      - Entity Framework
      - SQL
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
      - [prometheus-net](https://github.com/prometheus-net/prometheus-net) : .NET library to instrument your code with Prometheus metrics
      -	[MvcPagedList.Core](https://www.nuget.org/packages/MvcPagedList.Core/) : easily paging in ASP.NET Core MVC
      -	[EasyCaching](https://github.com/dotnetcore/EasyCaching) : caching library
      -	[stryker-net](https://github.com/stryker-mutator/stryker-net): Mutation testing for .NET
      -	[nuke](https://github.com/nuke-build/nuke): Build System for C#/.NET
    </details>
  * ### Front-end:
    <details>
      <summary>click for details</summary>


      - Blazor
        - Blazor Server
            - Cookie Authentication without ASP.NET Identity
            - It was Blazor Server befor refactoring it to WebAssembly ([browse the codes here](https://github.com/hamed-shirbandi/TaskoMask/tree/a6f036f91c2185861209191d9bb3e4ae01665f46/Src/Presentation/3-UI/UserPanel))
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


      - Continuous Integration
      - [Feature Branch Workflow](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/Branch-Conventions.md)
      - [Conventional Commits](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/Commit-Conventions.md)
      - [GitHub Actions](https://github.com/hamed-shirbandi/TaskoMask/blob/master/.github/workflows/ci.yml)
      -  Mutation testing [dashboard reporter](https://dashboard.stryker-mutator.io/reports/github.com/hamed-shirbandi/TaskoMask/master#mutant)
      -	Caching Behavior using Pipeline Pattern
      -	Validation Behavior using Pipeline Pattern (Check both Fluent Validation and Data Annotation Validation)
      -	Event Storing Behavior using Pipeline Pattern
      - Exception Handling
      -	Cookie Authentication
      -	JWT Authentication
      -	Role Permission Base User Management without ASP.NET Identity (check Domain documentation)
      -	Swagger UI with JWT Support
    </details>

# Contributing
We welcome contributions, issue reports, and questions from the community. Any contributions you make are highly valued and appreciated.

  >Please refer to our [Contribution Guide](https://github.com/hamed-shirbandi/TaskoMask/tree/master/docs/CONTRIBUTING.md) for detailed instructions on how to get involved in this project.

This project thrives and evolves thanks to the dedicated individuals who [contribute](https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors) their time and expertise

<a href="https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors">
  
  ![GitHub Contributors Image](https://contrib.rocks/image?repo=hamed-shirbandi/TaskoMask)
  
</a>

# Articles And Tutorials
* Read my articles on [Medium](https://medium.com/@hamed.shirbandi)
* Follow the hashtag [#taskomask](https://twitter.com/search?q=%23taskomask) on Twitter 

# Supporting
We are dedicated to creating a valuable resource for the .NET community. If this project has been beneficial to you, please consider showing your support by giving it a ⭐ star. Your support is crucial, whether through starring the project, contributing, or sharing it with anyone who can benefit. You can also join the conversation on Twitter by using the hashtag [#taskomask](https://twitter.com/search?q=%23taskomask).

# Author & License
This project is authored by [Hamed Shirbandi](https://github.com/hamed-shirbandi) and is licensed under the [MIT](https://github.com/hamed-shirbandi/TaskoMask/blob/master/LICENSE) License. You can find Hamed across various online platforms, and please don't hesitate to reach out if you have any questions or inquiries.

<a href="https://www.linkedin.com/in/hamed-shirbandi"><img alt="LinkedIn" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/LinkedIn-v2.png" width="35"></a><a href="https://www.instagram.com/hamedshirbandi"><img alt="Instagram" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Instagram-v2.png" width="35"></a><a href="https://github.com/hamed-shirbandi"><img alt="GitHub" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/GitHub-v2.png" width="35"></a><a href="https://medium.com/@hamed.shirbandi"><img alt="Medium" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Medium-v2.png" width="35"></a><a href="https://www.nuget.org/profiles/hamed-shirbandi"><img alt="Nuget" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Nuget-v3.png" width="35"></a><a href="mailto:hamed.shirbandi@gmail.com"><img alt="Email" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Email-v2.png" width="35"></a><a href="https://t.me/hamed_shirbandi"><img alt="Telegram" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Telegram-v2.png" width="35"></a><a href="https://twitter.com/hamed_shirbandi"><img alt="Twitter" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Twitter-v2.png" width="35"></a>

# Change logs
  <details>
    <summary>2024</summary>


*	### Sep, 2024
    - [x] Upgrade to .NET 8 
  </details>


  <details>
    <summary>2023</summary>


*	### Oct, 2023
    - [x] Instrument with Prometheus metrics 
    - [x] Implement build system using nuke 
    - [x] Implement Mutation Testing using Stryker
    - [x] Integrate CI with nuke and stryker
    - [x] Mutation testing [dashboard reporter](https://dashboard.stryker-mutator.io/reports/github.com/hamed-shirbandi/TaskoMask/master#mutant)
*	### Sep, 2023
    - [x] Global Code Refactoring 
    - [x] Handle Managed and Unmanaged Exceptions
    - [x] Log Managed and Unmanaged Exceptions 
*	### Feb, 2023
    - [x] Simplify Write Service Architecture 
    - [x] Implement Unit Tests for Task Services
    - [x] Implement Integration Tests for Task Services
*	### Jan, 2023
    - [x] Extract Task Write Service
    - [x] Extract Task Read Service
    - [x] Remove Monolith Service
    - [x] Simplify Write Service Architecture 
  </details>


  <details>
    <summary>2022</summary>

*	### Dec, 2022
    - [x] Extract Board Write Service
    - [x] Extract Board Read Service
    - [x] Implement Integration Tests for Board Services
    - [x] Implement Unit Tests for Board Services
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

  </details>
    
  <details>
    <summary>2021</summary>
      
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
  
  </details>
  
  <details>
    <summary>2020</summary>
      
*	### Nov, 2020
    - [x] Upgrad from net 3.1 to net 5
    - [x] Implement user panel with ASP.NET MVC
*	### Oct, 2020
    - [x] Implement Website with ASP.NET MVC
    - [x] Implement Anemic Domain Model
    - [x] Create Repository
  
  </details>
