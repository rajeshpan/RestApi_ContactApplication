mation_RestAPI
Contact information Rest Api application with MVC and entity data model

Contact Information Contactinformation is an ASP.NET MVC small POC which is used to maintain the contact records in an organisation.

Entity Framework 
We have used Entity Framework ORM(instead of ADO.Net) in this project which is used to directly communicate to the Application Database .
Add Ado.net Entity data model to Create Db contact entities .

Razor View Engine
Razor is an ASP.NET programming syntax used to create dynamic web pages with the C# or Visual Basic .NET programming language. ASP.NET MVC Razor views, with an emphasis on producing functional HTML forms with a minimum amount of code.

Design Patterns
Model-View-ViewModel

Solution Projects
Project  Solution	        -  RestApiproject.sln
Application Layer(UI)     -	Contact.MvcUI
Service Layer	            - Contact.WebApi
Bussiness models	        -ContactDataModel
Entity Data Model	        -ContactdataModel.EDMX
Unit Test	                -Contact.MvcUI.Tests

Technologies

Dependency	                                   Version*
.NET Framework	                               4.5.2
ASP.NET MVC	                                   v4.0.30319
Bootstrap	                                     V3.0.0
C#	                                           C#6.0
Entity Framework	                             EF6
jQuery	                                       1.10.2
jQuery Validation	                             1.11.1



Approach
Database First Approach



Getting Started
1.	Download or clone this repository.
2.	Open the solution in Visual Studio 2015 or higher.
3.	Open Database and run the below mentioned Sql Scripts:
a.	Create and Use database :
	create database ContactDB
	Use ContactDB
b.	Create table Scripts :

    CREATE TABLE ContactInformation(
    ContactId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) ,
    PhoneNumber VARCHAR(50) NOT NULL,
    Email VARCHAR(320),
    Status VARCHAR(255)  NOT NULL)

4.	Contact.WebApi -> models ->ContactDataModel.edmx generated
5.	Add Connection string in Web.config file of ContactMvcUI project in the below given format :

   <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-Contact.MvcUI-20180712013706.mdf;Initial Catalog=aspnet-Contact.MvcUI-20180712013706;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>

Default Connection- Default name of the data Connection string.
	DataSource – Server address .
	Initial Catalog – DataBase Name
	Integrated Security – SSPI ,
	User – username
	Password – Password

6.	Open the RestApiProject.sln file and run the application.


Configuration
•	The project contains a configuration string which may require modification for the developer's specific environment:
Project	File
RestApiProject.web	Web.config   
•	The configuration strings specify the instance of SQL Server Express installed with Visual Studio 2015 as the target database server: Data Source=(localdb)\ProjectsV13. Developers using a different target database will have to change the connection strings in both projects.
