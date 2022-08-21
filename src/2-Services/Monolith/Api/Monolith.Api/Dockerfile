#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/2-Services/Monolith/Api/Monolith.Api/Monolith.Api.csproj", "src/2-Services/Monolith/Api/Monolith.Api/"]
COPY ["src/1-BuildingBlocks/Web.MVC/Web.MVC.csproj", "src/1-BuildingBlocks/Web.MVC/"]
COPY ["src/1-BuildingBlocks/Web/Web.csproj", "src/1-BuildingBlocks/Web/"]
COPY ["src/1-BuildingBlocks/Contracts/Contracts.csproj", "src/1-BuildingBlocks/Contracts/"]
COPY ["src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.CrossCutting/Infrastructure.CrossCutting.csproj", "src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.CrossCutting/"]
COPY ["src/2-Services/Monolith/Libraries/Application/Application/Application.csproj", "src/2-Services/Monolith/Libraries/Application/Application/"]
COPY ["src/2-Services/Monolith/Libraries/Domain/Domain.DomainModel/Domain.DomainModel.csproj", "src/2-Services/Monolith/Libraries/Domain/Domain.DomainModel/"]
COPY ["src/1-BuildingBlocks/Domain/Domain.csproj", "src/1-BuildingBlocks/Domain/"]
COPY ["src/2-Services/Monolith/Libraries/Domain/Domain.DataModel/Domain.DataModel.csproj", "src/2-Services/Monolith/Libraries/Domain/Domain.DataModel/"]
COPY ["src/2-Services/Monolith/Libraries/Application/Application.Core/Application.Core.csproj", "src/2-Services/Monolith/Libraries/Application/Application.Core/"]
COPY ["src/1-BuildingBlocks/Application/Application.csproj", "src/1-BuildingBlocks/Application/"]
COPY ["src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.Data.Generator/Infrastructure.Data.Generator.csproj", "src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.Data.Generator/"]
COPY ["src/1-BuildingBlocks/Infrastructure/Infrastructure.csproj", "src/1-BuildingBlocks/Infrastructure/"]
COPY ["src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.Data.Read/Infrastructure.Data.Read.csproj", "src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.Data.Read/"]
COPY ["src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.Data.Write/Infrastructure.Data.Write.csproj", "src/2-Services/Monolith/Libraries/Infrastructure/Infrastructure.Data.Write/"]
RUN dotnet restore "src/2-Services/Monolith/Api/Monolith.Api/Monolith.Api.csproj"
COPY . .
WORKDIR "/src/src/2-Services/Monolith/Api/Monolith.Api"
RUN dotnet build "Monolith.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monolith.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskoMask.Services.Monolith.Api.dll"]