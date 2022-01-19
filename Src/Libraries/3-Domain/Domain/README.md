
# What is Domain ?
This is a place that we implement Domain Model (Write Model) and Data Model (Read Model).

# What is WriteModel ?
This is a place that we implement Domain Model by using DDD concepts. It contains 3 BC as below. It has its own Database to store the state of agggregates but we are going to follow Event Sourcing instead of storing state.

## Authorization BC
This BC contains a generic subdomain. It is used to handle everything about authorization for all type of users (Owner, Operator)
We don't implement a rich domain model for it and we don't use CQRS. It is less important to have much focus on it.


## Membership BC
This BC contains a supporting subdomain. It is used by operators for managing application data by using an admin panel.
We don't implement a rich domain model for it and we don't use CQRS. It is less important to have much focus on it.

## Workspace BC
This BC contains the core domain and talks about managing tasks. We implement it by rich domain model and use CQRS. This is the most important part of system.

# What is ReadModel ?
This is a place that we implement Data Model to be used in Queries (Read Side). It has its own database that is updated by listening to events on the write side.
Read Model for Authorization and Membership is on Write Side. It means we use Domain Model as Data Model for this 2 BC.


# Features:

- Rich Domain Modeling (Workspace BC)
- Anemic Domain Model (Membership & Authorization BC)
- Aggregate Pattern
- Value Objects
- Specification Pattern
- Domain Event
- Event Sourcing (to be completed)
- Invariants
- Always Valid Domain Model
- Domain Services
- Factory Method Pattern
- Separate Read and Write Model
- Separate Read Side DB and Write Side DB


#Read Domain Documentation
We have prepared a documentation to get more information about it. You can read it [HERE](https://github.com/hamed-shirbandi/TaskoMask/wiki/Domain-Documentation)