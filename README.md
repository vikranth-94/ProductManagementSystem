# ProductManagementSystem
Technologies Used:
.netCore 6.0
enity framework core 6.0.32
UnitTest : NUnit,moq

API Features:
1. I used Repository design pattern to develop, taking into consideration all the SOLID principles.
2. Made all the Endpoint protected and need  JWT Token authentication inorder to access endpoint.
3. Added health checks for API.
4. Added build-in Logger for logging the exception and also added unique CorrelationId to the API headers which will help in querying the log information.
5. i have used entity framework code first approch.
6. Added Unit test project and added testcases for controller implementation.
7. made service lifetime as scoped ,to make sure each HTTP request gets its own instance of ProductDbContext.to avoid duplications and concurrent data access.

Application Flow:
1. Register endpoint will add the user details.here username must be unique.
2. Login endpoint will give you generated JWT bearer token based on successfull login.
3. these tokens we have to use to validate Product endpoints.

   Note:
   1. username and password are required fields for authentication process.
   2. Name,Description,Category,Price,AvailableStock are the required fields for product endpoints.
      


