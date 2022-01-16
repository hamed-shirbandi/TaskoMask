
# What is Domain ?
This is a place that we implement Domain Model by using DDD concepts. It contains 3 BC as below at the moment and we are going to add another in future for reporting by using a separate read DB.

## Authorization
This BC contains a generic subdomain. It is used to handle everything about authorization for all type of users (Member, Operator)
We don't implement a rich domain model for it and we don't use CQRS. It is less important to have much focus on it.


## Membership
This BC contains a supporting subdomain. It is used by operators for managing application data by using an admin panel.
We don't implement a rich domain model for it and we don't use CQRS. It is less important to have much focus on it.

## Workspace
This BC contains the core domain and talks about managing tasks. We implement it by rich domain model and use CQRS. This is the most important part of system.


# Some points
- The goal of this project for DDD is to learn how can implement a Domain Model and we didn't focus on the model design. So maybe it could have been better !
- If you can help to make it better we are happy to have your help.

# Features:

- Rich Domain Modeling (Workspace BC)
- Anemic Domain Model (Membership BC)
- Aggregate Pattern
- Value Objects
- Specification Pattern
- Domain Event
- Invariants
- Always Valid Domain Model
- Domain Services
- Factory Method Pattern
