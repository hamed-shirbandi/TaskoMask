#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/2-Services/Owners/Api/Owners.Write.Api/Owners.Write.Api.csproj", "src/2-Services/Owners/Api/Owners.Write.Api/"]
COPY ["src/1-BuildingBlocks/Web.MVC/Web.MVC.csproj", "src/1-BuildingBlocks/Web.MVC/"]
COPY ["src/1-BuildingBlocks/Infrastructure/Infrastructure.csproj", "src/1-BuildingBlocks/Infrastructure/"]
COPY ["src/1-BuildingBlocks/Application/Application.csproj", "src/1-BuildingBlocks/Application/"]
COPY ["src/1-BuildingBlocks/Domain/Domain.csproj", "src/1-BuildingBlocks/Domain/"]
COPY ["src/1-BuildingBlocks/Contracts/Contracts.csproj", "src/1-BuildingBlocks/Contracts/"]
COPY ["src/1-BuildingBlocks/Web/Web.csproj", "src/1-BuildingBlocks/Web/"]
RUN dotnet restore "src/2-Services/Owners/Api/Owners.Write.Api/Owners.Write.Api.csproj"
COPY . .
WORKDIR "/src/src/2-Services/Owners/Api/Owners.Write.Api"
RUN dotnet build "Owners.Write.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Owners.Write.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskoMask.Services.Owners.Write.Api.dll"]