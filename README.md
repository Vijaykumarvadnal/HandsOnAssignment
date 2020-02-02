# HandsOnAssignment

Basically this application was written to check if we can integrate FluentMigrator with .net Core application.
Once you download/clone this application you are required to create blank database with name **HoA** in SQL Server.

Once blank **HoA** database is created, now you need to verify connection string in appsettings.json under **HoA.UI** project and point it to correct SQL Server path.
There is a configuration call within **startup.cs** file this method will take care of running migrations from **HoA.DBMigration** class library project.

This project is now bifurcated into different projects to handle calls from MVC View to Web API and then database calls via service/business logic layer.

Database layer i.e. **HoA.Dal** is configured to have Dapper & DapperExtension for ORM, Dapper is micro-ORM which is purely based on POCO that means your entity/domain classes should have same set of properties matching to columns mentioned in database along with class names should also match with database table name.
