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
### Nuget Packages
- Swagger - to document and test the API (!Note - This needs to be removed for Production )
- SQL Client - to open the connection to the DB and execute queries.
- Dapper - to map our Model properties with the query parameters instead of passing Primitive Data types.



