# Tesodev Case

Bu proje, Tesodev Case uygulaması hakkında detaylar içerir.

## Contents
- [Tesodev Case](#tesodev-case)
  - [Contents](#contents)
  - [Başlarken](#başlarken)
    - [Gereksinimler](#gereksinimler)
    - [Kurulum](#kurulum)
    - [Kullanım](#kullanım)
      - [Order API](#order-api)
      - [Customer API](#customer-api)
      - [WebApiGateway](#webapigateway)
    - [API Endpoints](#api-endpoints)
      - [Order API](#order-api-1)
      - [Customer API](#customer-api-1)
      - [WebApiGateway](#webapigateway-1)
    - [Parameters](#parameters)
    - [Example Usage](#example-usage)

## Başlarken

Bu bölüm, projeyi yerel makinenizde çalıştırmak için gereken adımları içerir.

### Gereksinimler

Bu projeyi çalıştırmak için aşağıdaki gereksinimlere ihtiyacınız vardır:

- .NET Core SDK (Sürüm 8)

### Kurulum

1. Proje dizinine gidin: `cd proje-klasoru`


2. Projeyi derlemek için aşağıdaki komutu çalıştırın:

    ```bash
   dotnet build
    ````

3. Derlenen projenin api'sini çalıştırmak için

    ```bash
    cd src/Services/Customer/Tesodev.Case.Customer.API 
    dotnet run
    ````

    ```bash
    cd src/Services/Order/Tesodev.Case.Order.API 
    dotnet run
    ````

    ```bash
    cd src/ApiGateways/WebApiGateway/Tesodev.Case.WebApiGateway
    dotnet run
    ````

### Kullanım

#### Order API

 1. Proje default olarak `5001` portu üzerinden çalışmaktadır. İstekler `http://localhost:5001` endpointine atılabilir.
   
 2. Projenin swagger dosyasına erişmek için `http://localhost:5001/swagger/index.html` url'si kullanılabilir.

 3. Postman kullanılmak istenirse root'daki `/postman` klasörünün içinde swagger dosyası, postman'den import edilebilir.
 
 4. Gateway üzerinden `http://localhost:5000/order-service` ile erişilebilir

#### Customer API

 1. Proje default olarak `5002` portu üzerinden çalışmaktadır. İstekler `http://localhost:5002` endpointine atılabilir.
   
 2. Projenin swagger dosyasına erişmek için `http://localhost:5002/swagger/index.html` url'si kullanılabilir.

 3. Postman kullanılmak istenirse root'daki `/postman` klasörünün içinde swagger dosyası, postman'den import edilebilir.
 
 4. Gateway üzerinden `http://localhost:5000/customer-service` ile erişilebilir
   
#### WebApiGateway

 1. Proje default olarak `5000` portu üzerinden çalışmaktadır. İstekler `http://localhost:5000` endpointine atılabilir.
 
 2. Gateway üzerinden `http://localhost:5000/customer-service` veya `http://localhost:5000/order-service` ile ilgili servislerin api'lerine erişilebilir.


### API Endpoints

#### Order API

- **POST /api/{version}/orders/** - Add order
- **PUT /api/{version}/orders/{id}** - Update order
- **DELETE /api/{version}/orders/{id}** - Delete order.
- **GET /api/{version}/orders** - Get orders.
- **GET /api/{version}/orders/{id}** - Get order by id.

#### Customer API

- **POST /api/{version}/customers/** - Add customer
- **PUT /api/{version}/customers/{id}** - Update customer
- **DELETE /api/{version}/customers/{id}** - Delete customer.
- **GET /api/{version}/customers** - Get customer.
- **GET /api/{version}/customers/{id}** - Get customer by id.

#### WebApiGateway

- **POST customer-service/api/{version}/customers/** - Add customer
- **POST order-service/api/{version}/orders/** - Add order
....

### Parameters

- `{version}` - The version of the app.
- `{id}` - The unique identifier of the customer.

### Example Usage

To add item to cart, send a POST request to `/api/v1/orders`.

```http
POST /api/v1/orders/