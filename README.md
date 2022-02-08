# Agence Voyage
## _A fictitious travel agency_

Agence Voyage is a website made in collaboration with Sylvain Fafard during the fourth term of our program. This website offers the ability for an authentified user to make a reservation on a particular vacation plan, or for an unauthentified user to sign up. The user then gains the ability to organise each vacation plan he made reservation for.

## Tech
This Web site has been developed entirely in Visual Studio C#, using:

- ASP.NET Core Web App (MVC)
- Entity Framework Core 5
- EFC SQL Server, Tools, Code Generation Design
- Authentication, Authorization, User Creation
- Razor web pages
- Stored Procedures


## Installation

Agence Voyage requires [Visual Studio](https://visualstudio.microsoft.com/vs/) 2019+ to run.

- Copy the repository address
- Clone this repository in Visual Studio
- Run the application then close it
- Once the database has been created add this stored procedure

```sql
CREATE PROCEDURE [dbo].[GetUser]
    @username varchar(200)
AS 
    Select * from dbo.Clients where dbo.Clients.username = @username
RETURN 0
```
- Run the application again and everything should work fine

## Todo
- Add stored procedure in DB initializer to simplify installation
- Manage input validation
- Improve CSS
- Improve travel organisation

## License

MIT


