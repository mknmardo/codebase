# codebase
A base code that I've created for developers who want to create Restful APIs implementing object oriented programming priciples and code design patterns.
<br />

Architecture: N-Tier Architecture
<br />
Design Pattern: Repository Pattern
<br />
The Repository pattern
<br />
Repositories classes encapsulate the logic required to access data sources. They centralize common data access functionality, providing better maintainability and decoupling the infrastructure or technology used to access databases from the domain model layer.

A repository is the intermediary between the domain model layers and data mapping, acting in a similar way to a set of domain objects in memory. Client objects declaratively build queries and send them to the repositories for answers. A repository encapsulates a set of objects stored in the database and operations that can be performed on them, providing a way that is closer to the persistence layer. 


<br />
Micro ORM: Dapper
<br />
Authorization: OAuth
<br />
IOC Container: Autofac
<br />
Transaction: Transaction Scope
<br />
Documentation: Swagger
<br /><br />
<b>Project Structure</b>
<br />
Solution Name: CodeBase
<br />
Projects:
<br /><br />
-CodeBase.Api<br />
-CodeBase.Common<br />
-CodeBase.Services (Service Layer (Business Logic Layer)<br />
-CodeBase.Repositories (Repository Layer)<br />
-CodeBase.Infrastructure<br />
-CodeBase.Cache<br />
-CodeBase.Utils





