# Cleverbit Coding Task Task Template

This template should be used for coding tasks of Cleverbit.

Three projects are included in this solution:
- Cleverbit.CodingTask.Host: A .NET Core 3.1 Web Application
- Cleverbit.CodingTask.Data: A .NET Core 3.1 class library which includes the first implementation of DB Context and User table.
- Cleverbit.CodingTask.Utilities: A .NET Core 3.1 class library which includes the Hash Service.

Database initialization has been implemented and configured in startup.

Basic authentication has been implemented and wired to the User table in DbContext.

An example API controller has been implemented as PingController which includes two GET methods, one without Authorization and the other one with Authorization.

By default, db connection string is configured for SQL Express. This can be changed in appSettings.Development.json .

Following users are provisioned during startup:

|UserName|Password|
|-|-|
|User1|Password1|
|User2|Password2|
|User3|Password3|
|User4|Password4|

Example AJAX calls to ping APIs (with and without Authorization) are present under Cleverbit.CodingTask.Host/Views/index.html



<h1>Notes</h1>

- Database Migrations are being run during startup.
- A Postman collection can be found in the project's root directory
- To Add a new migration head over to the Host project and execute the following command:
``` dotnet ef migrations add ModelInit --project ../Cleverbit.CodingTask.Data/Cleverbit.CodingTask.Data.csproj ```


<h3>Api Actions</h3>

|Endpoint|Description|
|-|-|
|POST ../api/game/play|Makes an attempt to play the current game (generates and stores a random number for the logged in user). This endpoint shall be hit by the "Play now" button action.|
|GET .../api/match/results|Gets all the results (winners) for all Matches in the system. This endpoint shall be invoked by non authenticated users and all others after the login. |
|GET .../api/match|Gets the statistics of the current match. Including the user who is currently winning the match. This endpoint shall be invoked by the "Refresh Results" button action.|


<h3>Improvements:</h3>

- Add Automapper to map Domain classes into Dtos.
- Add Cancelation Token to relevant classes (E.g. Repository classes).
- Improve Base repository methods. (Add delete operations, Update, etc).
- Use DDD aggregate roots; E.g. To avoid having repositories to manage N->N relationship classes.
- Add exception Handler middleware to catch exceptions and retrieve appropriate error codes.
- Add logging.
- Data Validations; Check for Null Reference exceptions.
- Some methods in GameService can be moved to the MatchService, therefore it can refer to MatchService instead of Match related repository classes.
- If no results are found while calling an Endpoint, it should be retrieved a NoContent result instead of 200 Ok.
- Add Unit tests. (Due to time constraints, I will add some UnitTests after submiting the assignment).
- Improve github commit messages.
- Adopt Clean Architecture / DDD principles. Adapt project structure.