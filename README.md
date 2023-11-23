# Employee-Intranet Project
## Requirements
This an employee management intranet that will manage employees and their leave

We will be creating a company intranet to manage employees and their leave.

Below are the basic required functions, but is not limited only to below. If you think something can be added additionally then you are more than welcome to add it.

- Employees need to Login
- Employees can manage their own profile
- Employees can view each others profiles
- Employees need to have a manager assigned whom will be approving leave
- Leave should display total days available, days taken for the year etc..
- Leave days should first be approved and then employee should be able to see it is approved.
- Error when trying to apply for days not available etc..
- Employee should be able to cancel leave request.

## Database
- !DB needs to be published before running the project.
- the database is a SQL database that is stored on a MYSQL server.
- We use Stored Procedures to execute SQL queries on the DB.
  

## RestFul API
### Nuget Packages - API
- Swagger - to document and test the API (!Note - This needs to be disabled for Production )
- SQL Client - to open the connection to the DB and execute queries.
- Dapper - to map our Model properties with the query parameters instead of passing Primitive Data types.
  #### Authentication and Authorization
  Since we are using .Net for our API the simplest and logical thing to do would be to use the Identity system to handle all of our Authentication and Authorize, however we will  not be using that or package to handle the authentication, we will build it from ourselves. 


## User Interface (UI)
-  For this project we only have one UI which is a .NET MVC web application.
-  DOM manipulation will be handled by the MVC and a little bit of Javascript on specific things.
-  the structure and styling of the site will be done in HTML5 and CSS3

### Nuget Packages - UI
- HTTPClient -  to open a connection to our API, so that we can do HTTP calls to the API and recieve responses of Status Codes and payloads.
  
