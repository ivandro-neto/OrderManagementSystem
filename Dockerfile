FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /api

COPY *.sln /api/
COPY OrderManagementSystem.API/ /api/OrderManagementSystem.API
COPY OrderManagementSystem.Application/ /api/OrderManagementSystem.Application
COPY OrderManagementSystem.Communication/ /api/OrderManagementSystem.Communication
COPY OrderManagementSystem.Exceptions/ /api/OrderManagementSystem.Exceptions
COPY OrderManagementSystem.Infrastructure/ /api/OrderManagementSystem.Infrastructure

WORKDIR /api
RUN dotnet tool restore

WORKDIR /api
COPY . ./

WORKDIR /api/OrderManagementSystem.Infrastructure/
RUN dotnet ef migrations add CreateDataBase
RUN dotnet ef database update


WORKDIR /api/OrderManagementSystem.API/
RUN dotnet publish -c Release -o /api/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /api

COPY --from=build /api/out .

EXPOSE 80

ENTRYPOINT [ "dotnet", "OrderManagementSystem.API.dll" ]