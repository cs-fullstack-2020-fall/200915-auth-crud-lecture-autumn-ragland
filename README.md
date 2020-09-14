# 20 09 15 Authentication and Simple Authorization Review

### Topics
- Using scaffolding to initialize authorization in an mvc application
- Create an additional DbContext with one table, `Bands`
- Perform full CRUD functionality on items in `Bands` db table
- Utilize partials for views associated with CRUD functionality where appropriate
- Utilize model annotations for validation
- Implement client side validation

### Set Up
- Create an mvc application called Lecture with authorization using the `--auth individual` flag
- Add a new mvc authorization policy to services and add required imports
```c#
services.AddMvc(obj =>
{
    AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
```
- Run the application and attempt to register a new user and login
### Code Together

#### Database
- Create a BandModel class with properties id, name, yearFormed, and number of members
- Add validation and custom error messages
    - name should be required
    - year formed should be between 1960 and 2020
    - number of members should be under 15
- Add the BandModel to a db set called Bands in a BandsDbContext class that extends the DbContext class
- Add an additional connection string called BandsDbConnectionString pointing to a db file called bands
- Add the BandsDbContext to services including the appropriate connection string
- Make an apply migrations

#### Controller
- Create a new Controller called BandController
- Pull in a reference to the BandsDbContext 
- Create an endpoint that displays all bands
- Create an endpoint that displays a band's details
- Create a protected endpoint that displays a form to add a band
- Create an endpoint that adds a band to the database
- Create a protected endpoint that displays a form to update a band
- Create an endpoint that updates a band in the database
- Create a protected endpoint that displays a page to delete a band
- Create an endpoint to remove a band from the database 

#### Views
- Update the start up file to route to the endpoint that displays all bands by default
- Remove the Privacy Page navigation from the nav bar and add navigation for adding a band
- Create a partial to display band properties
- Create a view to display all bands using a partial with a button to view details
- Create a band details view that displays a bands properties using a partials with a button to update and delete the band
- Create a partial to display the form fields required to create and update a band
- Create a view that displays a model bound form using a partial submitting to the appropriate endpoint to create a band
- Create a view that displays a model bound form using a partial submitting to the appropriate endpoint to update a band
- Create a view that displays a confirmation to delete a band