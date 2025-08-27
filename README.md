# Project Title
**CRUD_MSBPro_APP_EF-Core** is an Web API application having basic crud functionality for Todos.

---

## 🚀 Features
- APIs
  - Authentication APIs
    - POST /api/auth/signup - User registration
    - POST /api/auth/login - User login with JWT token response
  - Todo APIs
    - GET /api/todos?uid={uid} - Get user's todos with pagination
    - GET /api/todos/{id} - Get specific todo by ID
    - POST /api/todos - Create new todo
    - PUT /api/todos/{id} - Update existing todo
    - DELETE /api/todos/{id} - Delete todo

## 📦 Installation
- Update appseting.Development.json
  ```bash
  #Update database connection string
  "ConnectionStrings": {
    "DefaultConnectionString": "server=localhost\\MsbPro,1433;Database=DEMOEF;User Id=sa;Password=MsbPro123;TrustServerCertificate=True;"
  },
- Migrate Database
  ```bash
  # Create database migration
  dotnet ef migrations add <migration_name>
  #Migrate Database
  dotnet ef database update
- Run application
  ```bash
  #Buid and Run application
  #Terminal
  dotnet build
  dotnet run
- Import MsbPro_Collection in postman to test the API
  - Create an user via signup API
  - Login using user's username & password. This will return a JWT token
  - Add autorization of todo request's to bearer token and add the retrieved token
  - Use the crud api
