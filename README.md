![GitHub Release](https://img.shields.io/github/v/release/eskhas/library-automation-project?color=%2000ff00)
# Library Automation Project
  The purpose of this project is to help library personnel to loan books to the people.
### To Run The Application
* Change SqlServer password and from connectivity string in **appsettings.json**. If you are not using SA user,
  change it according to your needs
* Add a database named "libraryDB" to your local sqlserver
```
  CREATE DATABASE libraryDB;
  GO;
```
* Apply these commands if you are using windows,
```
  dotnet ef migrations add InitialCreate
  dotnet ef database update
```
* If you are using linux,
```
  dotnet-ef migrations add InitialCreate
  dotnet-ef database update
```
* Enjoy!
