FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY "src/Services/Order/Api/Tesodev.Case.Order.API/Tesodev.Case.Order.API.csproj" "Services/Order/Api/Tesodev.Case.Order.API/Tesodev.Case.Order.API.csproj"
COPY "src/Services/Order/Api/Tesodev.Case.Order.Application/Tesodev.Case.Order.Application.csproj" "Services/Order/Api/Tesodev.Case.Order.Application/Tesodev.Case.Order.Application.csproj"
COPY "src/Services/Order/Api/Tesodev.Case.Order.Domain/Tesodev.Case.Order.Domain.csproj" "Services/Order/Api/Tesodev.Case.Order.Domain/Tesodev.Case.Order.Domain.csproj"
COPY "src/Services/Order/Api/Tesodev.Case.Order.Infrastructure/Tesodev.Case.Order.Infrastructure.csproj" "Services/Order/Api/Tesodev.Case.Order.Infrastructure/Tesodev.Case.Order.Infrastructure.csproj"

RUN dotnet restore "Services/Order/Api/Tesodev.Case.Order.API/Tesodev.Case.Order.API.csproj"

COPY . ./

WORKDIR "src/Services/Order/Api/Tesodev.Case.Order.API"

RUN dotnet build "Tesodev.Case.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tesodev.Case.Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tesodev.Case.Order.API.dll"]