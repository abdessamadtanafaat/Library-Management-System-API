# Library Management API

## Description
This project is a simple REST API for managing a library's book collection. It supports CRUD operations: adding, retrieving, updating, and deleting books. The API includes basic validation and error handling. In one version, the data is managed using in-memory models, and in another version, SQL Server is used for persistent storage.

## Features
- Add, Retrieve, Update, and Delete books
- Input validation for book properties
- Error handling with meaningful messages
- Two versions of the application:
  - **In-memory model version**: Uses a static file model without a database.
  - **SQL Server version**: Uses SQL Server for data storage and retrieval.

## Testing
- Unit tests are implemented using **xUnit**.
- **Moq** is used for mocking dependencies and simulating different scenarios in the tests.
- The tests are written to verify CRUD operations without requiring an actual database, using a file-based model for in-memory testing.

## Technologies Used
- ASP.NET Core (Web API)
- xUnit (Unit Testing)
- Moq (Mocking)
- SQL Server (for one version of the application)
