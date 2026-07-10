# Hotel Booking API

## Overview

A RESTful Hotel Booking API built with ASP.NET Core and Entity Framework
Core.

### Features

-   Hotels, Rooms and Bookings
-   Repository Pattern
-   Entity Framework Core
-   Global Exception Handling
-   Swagger/OpenAPI
-   xUnit + Moq unit tests

## Tech Stack

-   .NET 8
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server
-   xUnit
-   Moq

## Project Structure

``` text
HotelBookingAPI/
├── Controllers
├── Services
├── Repositories
├── Interfaces
├── Entities
├── DTOs
├── Data
├── Middleware
├── Exceptions
└── Program.cs
```

## Getting Started

1.  Clone the repository.
2.  Update the connection string in `appsettings.json`.
3.  Run database migrations:

``` bash
dotnet ef database update
```

4.  Start the application:

``` bash
dotnet run
```

5.  Open Swagger:

```{=html}
<!-- -->
```
    https://localhost:<port>/swagger

## API Endpoints

### Hotels


-   `GET /api/hotels/search?name={name}` ## Get Hotel By Name

### Rooms

-   `GET /api/room/GetAvailableRooms` ## Find available rooms between two dates for a given number of people.

### Bookings

-   `POST /api/bookings/BookRoom`  ## TO Book a room.
-   `GET /api/bookings//{reference}` ## Find booking details based on a booking reference.

###  Data Seeder 

-   `POST /api/test-data/Seed`
-    `GET /api/test-data/Reset`


## Running Tests

``` bash
dotnet test
```

## Design

-   RESTful APIs
-   SOLID Principles
-   Dependency Injection
-   Repository Pattern
-   Async Programming
-   Centralized Exception Handling

## Future Improvements

-   JWT Authentication
-   Docker
-   Azure Deployment
-   CI/CD
-   Redis Caching
