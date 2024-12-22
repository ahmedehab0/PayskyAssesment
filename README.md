This repo is for paysky assesment:
it is a simple banking system that allow for basic operation like: deposit, withdraw, transfer, retreive_balance

I developed it using mvc design pattern and followed the solid principles to allow flexeipility and scalability

Project strucutre:
Controllers/: Contains API controllers that handle HTTP requests and define endpoints
Models/: Data models and domain entities that represent the application's data structures
Views/: User interface templates and components (for MVC applications)
Services/: Business logic implementations and service layer classes
Repositories/: Data access layer components for interacting with the database
Migrations/: Database migration files for managing database schema changes

Getting Started

Ensure you have .NET 9.0 SDK installed
Clone the repository
Navigate to the project directory
Run dotnet restore to restore dependencies
Run dotnet build to build the project
Run dotnet run to start the application

API Documentation for Account Management

Overview

The AccountController provides API endpoints to manage accounts. This includes creating, retrieving, updating, and deleting accounts. Below is a detailed description of each endpoint, including how to use them and the expected input/output.

Endpoints

1. Create Account

URL: POST /api/Account

Description: Creates a new account.

Request Body:

Content-Type: application/json

Example:

{
 "AccountNumber": "1234567890",
 "Balance": 0,
 "AccountType": "saving"
}

Response:

201 Created

{
  "id": 1,
  "AccountNumber": "1234567890",
 "Balance": 0,
 "AccountType": "saving"
}

400 Bad Request

{
  "message": "Error message describing the issue."
}

2. Get Account by ID

URL: GET /api/Account/{id}

Description: Retrieves an account by its ID.

Path Parameter:

id (integer): The unique identifier of the account.

Response:

200 OK

{
  "id": 1,
  "AccountNumber": "1234567890",
 "Balance": 0,
 "AccountType": "saving"
}

404 Not Found

{
  "message": "Account not found."
}

400 Bad Request

{
  "message": "Error message describing the issue."
}

API Documentation for CheckingAccountOperationController

Overview

The CheckingAccountOperationController provides a set of API endpoints to perform operations on a checking account. These include deposit, withdrawal, transfer, and balance inquiry. The controller interacts with an account operation service to process requests.

Base URL

/api/CheckingAccountOperation

Endpoints

1. Deposit

URL: /depositMethod: POST

Description: Deposits a specified amount into the given account.

Request Body:

{
  "AccountId": 123,
  "Amount": 500.0
}

Response:

Success:

{
  "AccountId": 123,
  "Balance": 1500.0
}

Error:

{
  "error": "Error message here"
}

2. Withdraw

URL: /withdrawMethod: POST

Description: Withdraws a specified amount from the given account.

Request Body:

{
  "AccountId": 123,
  "Amount": 200.0
}

Response:

Success:

{
  "AccountId": 123,
  "Balance": 1300.0
}

Error:

{
  "error": "Error message here"
}

3. Transfer

URL: /transferMethod: POST

Description: Transfers a specified amount from one account to another.

Request Body:

{
  "AccountId": 123,
  "ToAccountId": 456,
  "Amount": 300.0
}

Response:

Success:

{
  "AccountId": 123,
  "Balance": 1000.0,
  "ToAccountId": 456,
  "ToAccountBalance": 800.0
}

Error:

{
  "error": "Error message here"
}

4. Balance Inquiry

URL: /balance/{id}Method: GET

Description: Retrieves the balance of the specified account.

Path Parameter:

id: The ID of the account to query.

Response:

Success:

{
  "AccountId": 123,
  "Balance": 1500.0
}

Error:

{
  "error": "Error message here"
}

Error Handling

All endpoints return a 400 Bad Request status code if an error occurs, along with an error message in the response body.

Models

DepositRequest

public class DepositRequest
{
    public int AccountId { get; set; }
    public int? ToAccountId { get; set; } // For transfer
    public double Amount { get; set; }
}
