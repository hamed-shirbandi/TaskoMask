# Identity Service
This service is an Identity Provider (IDP) to centralize login logic and other workflows related to authorization and authentication for all other services.

# IdentityServer
We use [DuendeSoftware IdentityServer](https://docs.duendesoftware.com/identityserver/v6) for implementing our IDP. You can follow its documentation to learn more about it.

# Database Migration
Database for our Identity service is SQL and here are some tips related to apply new migrations to it:

> 1- Set 2-Services/Identity/Libraries/Infrastructure layer as default project in package management console
> 
> 2- run the bellow command :
> 
	Add-Migration YourMigrationName -OutputDir Data/Migrations