
# What is Domain ?
This is a place that we implement Domain Model by using DDD concepts. It contains 2 BC as below at the moment and we are going to add another in future for reporting by using a separate read DB.

## Administration
This BC contains a generic subdomain for administration area. It is used by operators for managing the system by using an admin panel.
We don't implement a rich domain model for it and we don't use CQRS. It is less important to have much focus on it.

## Workspace
This BC contains the core domain and talks about managing tasks. We implement it by rich domain model and use CQRS. This is the most important part of system.


# Some points
- The goal of this project for DDD is to learn how can implement a Domain Model and we didn't focus on the model design. So maybe it could have been better !
- If you can help to make it better we are happy to have your help.