# Tesodev Case

Bu proje, Tesodev Case uygulaması hakkında detaylar içerir.

Uygulama .NET 8.0 versiyonu ile geliştirildi. Microservislere `CQRS` implement edildi. Veritabanı olarak `PostgreSQL` kullanıldı. ORM olarak EFCore kullanıldı. `Validation`, `Logging` vs. gereksinimleri `Cross Cutting Concerns` olarak projeye eklendi. Unit Testler `xUnit` kullanılarak yazıldı. Deployment için `GitHub Action` üzerinde `CI/CD` pipeline oluşturuldu.

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
    - [CI/CD](#cicd)

### Başlarken

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
```

### CI/CD

Kod deposunda yapılan her değişiklik, GitHub Actions kullanılarak otomatik bir CI/CD sürecine dönüştürülmüştür. Bu süreçte, her değişiklik için otomatik olarak bir PR (Pull Request) oluşturulur. Bu PR, repository'nin yöneticisi tarafından gözden geçirilir ve main branch'e merge edilir. PR'nin merge edilmesi, Docker image'lerinin otomatik olarak oluşturulmasını tetikler aynı zamanda testler de yapılır. Oluşturulan her Docker image, otomatik olarak versiyonlanır ve GitHub Registry'e gönderilir. Bu süreç, kod değişikliklerini hızlı ve güvenilir bir şekilde dağıtmayı sağlayarak geliştirme sürecini optimize eder.