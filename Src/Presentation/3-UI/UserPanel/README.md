
# What is UserPanel ( Blazor )?

This layer contains a user panel.
It is used by end-users for managing their tasks by using TaskoMask.

# Features:

- Blazor Server
- Cookie Authentication without ASP.NET Identity
- Working with APIs protected by JWT
- Comunication between components by messages
- Online ([here](panel.taskomask.ir))

# Some points:
We use Blazor Server but don't use backend features directly because We like to migrate it to WASM in the future when it get better support by browsers.
So we try to keep it away from extra dependencies by using .Share libraries and calling APIs for getting data instead of using Application Services directly.