FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY "src/Services/Customer/Api/Tesodev.Case.Customer.API/Tesodev.Case.Customer.API.csproj" "Services/Customer/Api/Tesodev.Case.Customer.API/Tesodev.Case.Customer.API.csproj"
COPY "src/Services/Customer/Api/Tesodev.Case.Customer.Application/Tesodev.Case.Customer.Application.csproj" "Services/Customer/Api/Tesodev.Case.Customer.Application/Tesodev.Case.Customer.Application.csproj"
COPY "src/Services/Customer/Api/Tesodev.Case.Customer.Domain/Tesodev.Case.Customer.Domain.csproj" "Services/Customer/Api/Tesodev.Case.Customer.Domain/Tesodev.Case.Customer.Domain.csproj"
COPY "src/Services/Customer/Api/Tesodev.Case.Customer.Infrastructure/Tesodev.Case.Customer.Infrastructure.csproj" "Services/Customer/Api/Tesodev.Case.Customer.Infrastructure/Tesodev.Case.Customer.Infrastructure.csproj"

RUN dotnet restore "Services/Customer/Api/Tesodev.Case.Customer.API/Tesodev.Customer.Customer.API.csproj"

COPY . ./

WORKDIR "src/Services/Customer/Api/Tesodev.Case.Customer.API"

RUN dotnet build "Tesodev.Case.Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tesodev.Case.Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tesodev.Case.Customer.API.dll"]