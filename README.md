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

