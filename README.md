This repo is for paysky assesment:
it is a simple banking system that allow for basic operation like: deposit, withdraw, transfer, retreive_balance

I developed it using three layer archeticture design pattern and followed the solid principles to allow flexeipility and scalability


Database Design:

![image](https://github.com/user-attachments/assets/ba862baa-673a-4600-8d70-2d777af74ed5)


Project strucutre:

Controllers/: Contains API controllers that handle HTTP requests and define endpoints

Models/: Data models and domain entities that represent the application's data structures

Views/: User interface templates and components (for MVC applications)

Services/: Business logic implementations and service layer classes

Repositories/: Data access layer components for interacting with the database

Migrations/: Database migration files for managing database schema changes

Getting Started
Follow the steps below to get the project up and running. Make sure you have PostgreSQL installed and configured before proceeding.

1. Navigate to the project directory
2. 
cd cstest

4. Configure your PostgreSQL connection
5. 
Add your PostgreSQL connection string to the appsettings.json file.

6. Running the application
For Windows:
Run the following command to execute the application:

.\bin\Release\net9.0\win-x64\publish\cstest.exe

For Linux:
First, make the application executable:

chmod +x .\bin\Release\net9.0\lin-x64\publish\cstest

Then, run the application:

.\bin\Release\net9.0\lin-x64\publish\cstest


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
 "AccountType": 0
}

Response:

201 Created

{
  "id": 1,
  "AccountNumber": "1234567890",
 "Balance": 0,
 "AccountType": "savings"
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
 "AccountType": "savings"
}

404 Not Found

{
  "message": "Account not found."
}

400 Bad Request

{
  "message": "Error message describing the issue."
}

API Documentation for CheckingAccountOperationController and SavingAccountOperation

Overview

if you approach one of the urls with the diffrent type of account you are gonna get an error, make sure to use the url that matches your account type

Base URL

/api/checkingaccountoperation
/api/savingaccountoperation

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

