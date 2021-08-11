
🖥  Game Catalog.

### ⚙️  Structure

-   Client w/ TypeScript, React, Redux, React-Admin, React-Bootstrap 🔧👷
-  	Server w/ .NET Core, MongoDB, Postgres  🔧👷

### 🛠  Technologies

#### 👨‍💻 Backend
-   [.NET Core 3.1](https://dotnet.microsoft.com/download)
 - [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
-   [Heroku PostGres](https://www.heroku.com/postgres)
-  [Npgsql](https://www.npgsql.org/)
-   [MongoDB Atlas](https://www.mongodb.com/cloud/atlas)
 -   [MongoDB .NET Driver](https://docs.mongodb.com/drivers/csharp/)
#### ⚛️ Frontend
-   [React](https://pt-br.reactjs.org/)
-   [TypeScript](https://www.typescriptlang.org/)
-   [React Bootstrap](https://react-bootstrap.github.io/)
-   [Redux](https://redux.js.org/)
-    [React Admin](https://marmelab.com/react-admin/)
-    [Axios](https://axios-http.com/)

#### How to Run Locally
**Client:** 
Create a .env file with the following values 

    REACT_APP_GAME_CATALOG_API_GAMES = https://localhost:5001/api/v1/Game
    REACT_APP_GAME_CATALOG_API_GAME_INFO = https://localhost:5001/api/v1/GameInfo
    REACT_APP_GAME_CATALOG_API_USER = https://localhost:5001/api/v1/User
    REACT_APP_GAME_CATALOG_API_LOGIN = https://localhost:5001/api/v1/Login
    
**Server:** 

 1. Add a Postgres connection string the "NpgConnectionString" field in appsettings.json
    
        "NpgConnectionString": "<NPG_CONNECTION_STRING>"
         
 2. Add a JWT secret to the Secret field in appsettings.json

        "Secret": "<JWT_SECRET>"
        

3. Create a User Secret with the Mongo DB Atlas Connection String on the API project
        
        dotnet user-secrets init 
        dotnet user-secrets set "CONNECTION_STRING""<MONGO_DB_CONNECTION_STRING>"

