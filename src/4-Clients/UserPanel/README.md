
# What is UserPanel?

This layer contains a user panel.
It is used by end-users for managing their tasks.
You can try it [Online](panel.taskomask.ir)

# Features:

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


# Some points:
Until ([this commit](https://github.com/hamed-shirbandi/TaskoMask/tree/a6f036f91c2185861209191d9bb3e4ae01665f46/Src/Presentation/3-UI/UserPanel)) we used Blazor server. So, if you want to see how we developed UserPanel in Blazor Server you can browse the codes related to that commit.