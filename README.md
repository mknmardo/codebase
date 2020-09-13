# codebase
A base code that I've created for developers who want to create Restful APIs implementing object oriented programming priciples and code design patterns.
<br />

<h3>Architecture: N-Tier Architecture</h3>

<h4>N-tier architecture</h4>
<p>
It is also called multi-tier architecture because the software is engineered to have the processing, data management, and presentation functions physically and logically separated. This architecture makes your project easier to manage. This is because when you work on one section, the changes you make will not affect the other functions. And if there is a problem, you can easily pinpoint where it originates.
</p>
<br />
<h3>Design Pattern: Repository Pattern / Inversion Of Control (IOC)</h3>
<br />
<h4>The Repository pattern</h4>
<p>
Repositories classes encapsulate the logic required to access data sources. They centralize common data access functionality, providing better maintainability and decoupling the infrastructure or technology used to access databases from the domain model layer.
<br />
A repository is the intermediary between the domain model layers and data mapping, acting in a similar way to a set of domain objects in memory. Client objects declaratively build queries and send them to the repositories for answers. A repository encapsulates a set of objects stored in the database and operations that can be performed on them, providing a way that is closer to the persistence layer. 
</p>

<br />
<h3>Micro ORM: Dapper</h3>
<p>
Dapper is a micro ORM or it is a simple object mapper framework which helps to map the native query output to a domain class or a C# class. It is a high performance data access system built by StackOverflow and released as open source. If your project prefers writing stored procedures or writing native query instead of using a full-fledged ORM tools like EntityFramework or NHibernate then Dapper is obvious choice for you.
</p>
<br />
<h3>Authorization: OAuth (Token-based Authentication)</h3>
<br />
<h3>Dependency Injection: Constructor Injection</h3>

<h4>Dependency Injection</h4>
<p>
Dependency Injection, also known as DI, is a Design Pattern used to avoid coupling inside your code. According to the best practices in software development and part of one of S.O.L.I.D. principles, a class should depend on abstractions and not from concrete classes.
</p>
IOC Container: Autofac

<h3>Transaction: Transaction Scope</h3>
<h3>Documentation: Swagger</h3>
<h3>Project Structure</h3>
<h3>Solution Name: CodeBase<h3>
<h3>Projects:</h3>
-CodeBase.Api<br />
-CodeBase.Common<br />
-CodeBase.Services (Service Layer (Business Logic Layer)<br />
-CodeBase.Repositories (Repository Layer)<br />
-CodeBase.Infrastructure<br />
-CodeBase.Cache (MemCache)<br />
-CodeBase.Utils (Helper Classes)








