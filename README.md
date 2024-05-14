# Todo List Backend

This project is a simple backend application for managing a todo list. It provides endpoints for creating, reading, updating, and deleting todos.

## Requirements

- .NET 5 SDK
- SQL Server (or another supported database)
- Git

## Setup

1. **Clone the Repository**

    ```
    git clone https://github.com/yusufmhmd4/epimax-todo-backend.git
    ```

2. **Navigate to the Project Directory**

    ```
    cd TodoListBackend
    ```

3. **Restore Packages**

    ```
    dotnet restore
    ```

4. **Set Up Database Connection**

    - Open the `appsettings.json` file and update the `ConnectionStrings` section with your database connection details.

5. **Run Migrations**

    ```
    dotnet ef database update
    ```

## Running the Application

To run the application locally, execute the following command:
```
dotnet run
```

The application will start, and you should see output indicating that it's listening on a specific port https://localhost:7082/api/Todos

## Endpoints

- **GET /api/todos** - Retrieve all todos.
- **GET /api/todos/{id}** - Retrieve a specific todo by its ID.
- **POST /api/todos** - Create a new todo.
- **DELETE /api/todos/{id}** - Delete a todo by its ID.
- **PATCH /api/todos/{id}** - Update the status of a todo by its ID.
- **PATCH /api/todos/description/{id}** - Update the description of a todo by its ID.

## Usage

You can test the API endpoints using tools like Swagger or  Postman or cURL.
