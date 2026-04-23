-Overview:
   Blocker API is a .NET Web API project built using Onion Architecture that allows blocking or allowing users based on their country using their IP address.
   The system integrates with an external IP geolocation API to detect the user's country and decide whether access should be granted or denied.
   
-Features:

. Detect user country using IP Address

. Block specific countries

. Unblock countries

. Retrieve all blocked countries

. Check if a user is blocked based on IP

. Clean architecture using Onion Architecture

. DTO-based data handling 

-Architecture
  * Core Layer
       . Entities
       . Interfaces
       . DTOs
    
* Application Layer
      .  Business logic (Services)
  
* Infrastructure Layer
      .  External API integration
      .  Repository implementation
  
 * API Layer
      .  Controllers (Endpoints)

-Technologies Used
   . ASP.NET Core Web API
   .   C#
   .  Onion Architecture
   .  Dependency Injection
   .  HttpClient
   .  Newtonsoft.Json
   .  Swagger (API Testing


-API Endpoints

 * Block Country
    POST /api/countries/block?code=EG

* Unblock Country
   DELETE /api/countries/block/EG

* Get Blocked Countries
   GET /api/countries/blocked

* Get Country From IP
   GET /api/ip/lookup?ipAddress=8.8.8.8

* Check If IP Is Blocked
   GET /api/ip/check-block

   
