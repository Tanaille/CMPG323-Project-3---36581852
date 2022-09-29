# CMPG323 Project 3 - 36581852 
### Patterns and standards project for CMPG323
### Basic information 
!!! ADD URLs/URIs !!!

### API Structure 
This API is composed of three primary controllers: 

- **Categories**  
Enables interaction with the product Category tables. 
- **Devices**  
Enables interaction with the Device tables. 
- **Zones**  
Enables interaction with the product Zone tables.
 
### API Access 
The API can be accessed via the root URI provided above. 

Access to the API is granted via a registered user account. A user must create an account before accessing any API functions. There is currently no restriction
on account creation (other than uniqueness) and there are no different user classes. 
Upon first use, users are prompted to either log in with an existing account, or register a new account.

### Project-Specific API Details
The APi makes use of the repository design pattern to ensure proper implementation of SOLID principles. 
A generic repository class (GenericRepository.cs) and interface (IGenericRepository.cs) provides the logic for basic data retrieval and deletion operations.
Each data model implements a class-specific repository class and interface, which extends the generic repository and provides data modification operations.

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

