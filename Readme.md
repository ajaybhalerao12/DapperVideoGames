# DapperVideoGames

## Overview
`DapperVideoGames` is an ASP.NET Core API project that demonstrates how to perform CRUD (Create, Read, Update, Delete) operations using Dapper with a PostgreSQL database. This project includes endpoints for managing video game records.

## Features
- **ASP.NET Core API**: A robust and scalable web API built with ASP.NET Core.
- **Dapper Integration**: Utilizes Dapper for lightweight and high-performance data access.
- **PostgreSQL Database**: Connects to a PostgreSQL database for data storage and retrieval.
- **CRUD Operations**: Implements Create, Read, Update, and Delete operations for managing video game records.
- **Dependency Injection**: Follows best practices for dependency injection and configuration management.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/ajaybhalerao12/DapperVideoGames.git
   cd DapperVideoGames
   ```

2. **Install Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure the Database**:
   Update the connection string in `appsettings.json` to match your PostgreSQL database configuration:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=VideoGamesSimpleDB;Username=loc-pg-user;Password=password"
     }
   }
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

## Usage

### API Endpoints

- **GET /api/videogames**: Retrieve all video games.
- **GET /api/videogames/{id}**: Retrieve a video game by ID.
- **POST /api/videogames**: Create a new video game.
- **PUT /api/videogames/{id}**: Update an existing video game.
- **DELETE /api/videogames/{id}**: Delete a video game.

### Example Requests

- **GET /api/videogames**:
  ```bash
  curl -X GET https://localhost:7002/api/videogames
  ```

- **POST /api/videogames**:
  ```bash
  curl -X POST https://localhost:7002/api/videogames -H "Content-Type: application/json" -d '{
    "Title": "New Game",
    "Publisher": "New Publisher",
    "Developer": "New Developer",
    "ReleaseDate": "2024-09-08T00:00:00"
  }'
  ```

## Contributing
Contributions are welcome! Please fork the repository and submit pull requests for any enhancements or bug fixes.

## License
This project is licensed under the MIT License.

---

Feel free to customize this README file to better fit your project's specifics and goals. If you need any more help, just let me know!