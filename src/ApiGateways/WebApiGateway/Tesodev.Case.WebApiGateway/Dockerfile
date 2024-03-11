FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY "src/ApiGateways/WebApiGateway/Tesodev.Case.WebApiGateway/Tesodev.Case.WebApiGateway.csproj" "ApiGateways/WebApiGateway/Tesodev.Case.WebApiGateway/Tesodev.Case.WebApiGateway.csproj"

RUN dotnet restore "ApiGateways/WebApiGateway/Tesodev.Case.WebApiGateway/Tesodev.Case.WebApiGateway.csproj"

COPY . ./

WORKDIR "src/ApiGateways/WebApiGateway/Tesodev.Case.WebApiGateway"

RUN dotnet build "Tesodev.Case.WebApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tesodev.Case.WebApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tesodev.Case.WebApiGateway.dll"]