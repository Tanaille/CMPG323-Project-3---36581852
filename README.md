# CMPG323 Project 3 - 36581852 
### Patterns and standards project for CMPG323
### Basic information 
API Web UI: https://project3-36581852.azurewebsites.net/

### API Structure 
This API is composed of three primary controllers: 

- **Categories**  
Enables interaction with the product Category tables. 
- **Devices**  
Enables interaction with the Device tables. 
- **Zones**  
Enables interaction with the product Zone tables.
 
### API Access 
The API can be accessed via the web UI URL provided above. 

Users may access the API with the following test account, or create their own:
- Username: testuser@test.com
- Password: YYGL8DuTWEhLjUq2@

Access to the API is granted via a registered user account. A user must create an account before accessing any API functions. There is currently no restriction
on account creation (other than email address uniqueness) and there are no different user classes. 
Upon first use, users are prompted to either log in with an existing account, or register a new account.

### Project-Specific API Details
The APi makes use of the repository design pattern to ensure proper implementation of SOLID principles. 
A generic repository class (GenericRepository.cs) and interface (IGenericRepository.cs) provides the logic for basic data retrieval and deletion operations.
Each data model implements a class-specific repository class and interface, which extends the generic repository and provides data modification operations.
These repository classes are:
- ICategoryRepository.cs / CategoryRepository.cs
- IZoneRepository.cs / ZoneRepository.cs
- IDeviceRepository.cs / DeviceRepository.cs

Database operations are performed within the repository classes. No database context instances are found in the controller classes.

### Known Issues
When editing or deleting a category, zone or device, the API encounters a generic HTTP 500 error when the controllers execute the RedirectToAction() method to load the index page. The cause of this error is currently unkown. This error cannot be replicated in a local development environment and appears to only occur when deployed to an Azure instance.

Refreshing the page or clicking the back button in the browser correctly loads the index pages, and any data modifications show correctly. Backend / database operations seem to be working without issue, as items can be added, changed and deleted correctly.

### API Operations 

All API functions are accessible via the user interface.

**Categories** 
<pre> 
GET api/Categories                        Retrieve all categories.
GET api/Categories/{id}                   Retrieve a category, by category ID.
GET api/Categories/Devices                Retrieve all devices within a specific category, based on category ID.
GET api/Categories/Zones                  Get the number of zones associated to a specific category, based on category ID.
POST api/Categories                       Create a new category.
PUT api/Categories/{id}                   Modify a category, by category ID.
DELETE api/Categories/{id}                Delete a category, by category ID.
</pre>

**Devices** 
<pre> 
GET api/Devices                           Retrieve all devices.
GET api/Devices/{id}                      Retrieve a device, by device ID.
POST api/Devices                          Create a new device.
PUT api/Devices/{id}                      Modify a device, by device ID.
DELETE api/Devices/{id}                   Delete a device, by device ID.
</pre>

**Zones**  
<pre>
GET api/Zones                             Retrieve all zones.
GET api/Zones/{id}                        Retrieve a zone, by zone ID.
GET api/Zones/Devices                     Retrieve all devices within a specific zone, based on zone ID.
POST api/Zones                            Create a new zone.
PUT api/Zones/{id}                        Modify a zone, by zone ID.
DELETE api/Zones/{id}                     Delete a zone, by zone ID.
</pre>

### Security
The database connection string is stored within the **appsettings.json** file of the project. This file has been excluded from source control via the **.gitignore** file.

### Reference List

1. https://github.com/JacquiM/CMPG-323-IOT-Device-Management
2. https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1
3. https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
4. https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
5. https://programmingwithmosh.com/net/should-you-split-your-asp-net-mvc-project-into-multiple-projects/
6. https://procodeguide.com/design/solid-principles-with-csharp-net-core/
7. https://www.c-sharpcorner.com/article/solid-with-net-core/
8. https://stackoverflow.com/questions/24068981/how-to-use-generic-type-with-the-database-context-in-ef6-code-first
9. https://stackoverflow.com/questions/668589/how-can-i-add-an-item-to-a-selectlist-in-asp-net-mvc
10. https://stackoverflow.com/questions/6018711/generic-way-to-check-if-entity-exists-in-entity-framework
11. https://stackoverflow.com/questions/9591165/ef-4-how-to-properly-update-object-in-dbcontext-using-mvc-with-repository-patte
12. https://stackoverflow.com/questions/30088226/asp-net-mvc-4-5-1-redirecttoaction-500-error-only-after-publishing
13. https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/
14. https://techfunda.com/howto/279/update-record-into-database
15. https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
16. https://www.c-sharpcorner.com/article/bind-add-update-delete-data-using-mvc-entity-framework-and-linq/
17. https://www.codeproject.com/Questions/5324878/Mvc-index-wont-refresh-after-HTTP-post
18. https://www.dotnettricks.com/learn/mvc/return-view-vs-return-redirecttoaction-vs-return-redirect-vs-return-redirecttoroute
19. https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
20. https://deviq.com/design-patterns/repository-pattern
21. https://makingloops.com/why-should-you-use-the-repository-pattern/
22. https://www.pragimtech.com/blog/blazor/rest-api-repository-pattern/
23. https://www.freecodecamp.org/news/solid-principles-explained-in-plain-english/
24. https://www.baeldung.com/solid-principles
25. https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
26. https://www.c-sharpcorner.com/article/implement-unit-of-work-and-generic-repository-pattern-in-a-web-api-net-core-pro/
27. https://code-maze.com/net-core-web-development-part4/
28. https://www.laneways.agency/software-development-principles/
