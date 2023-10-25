# _Cretaceous API_

#### By _Seth Gonzales_

#### _A C# / ASP.NET Core MVC application using Entity Framework Core and MySQL._

## Technologies Used

* C#
* .NET 6
* ASP.NET Core MVC
* Entity Framework Core
* Postman
* MySQL
* MySQL Workbench

## Description

This application builds an API of animals, storing this information using a database. Users may . Anonymous users may only view the home and detail pages of each treat and flavor. Logged in users may add new treats and flavors, select to see more specific details, edit or delete entries, and assign many treats to many flavors, and vice versa. This project follows object oriented design and object relational mapping, with the treat and flavor objects. This is an ASP.NET Core MVC application that uses Identity.
<!-- <p align="center">
  <img src="./CretaceousApi/wwwroot/img/api_schema.png" alt="overview of Cretaceous Api" width="80%">
</p> -->



## Setup and Installation Requirements

### Setting up the project
* Before starting, check that all required technologies are used. For more information on configuring [MySQL](https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/) and [MySQLWorkbench](https://dev.mysql.com/doc/workbench/en/), follow the links provided.
* Navigate to the Cretaceous Api repository [GitHub](https://github.com/sethgonzales/CretaceousApi.Solution).
* Clone the repository down using `$ git clone https://github.com/sethgonzales/CretaceousApi.Solution.git` in your terminal.
* Within the production directory `CretaceousApi`, create a new file called `appsettings.json`.
* Within `appsettings.json`, put in the following code, replacing the `database`, `uid`, and `pwd` values with your own database name, username, and password for MySQL.
```json
{
  "Logging": {
      "LogLevel": {
      "Default": "Warning"
      }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=YOUR_DATABASE;uid=YOUR_USERNAME;pwd=YOUR_PASSWORD;"
  }
}
```

### Setting up the database
* If not already configured, install the Entity Framework Core tool `dotnet-ef` using the command `$ dotnet tool install --global dotnet-ef --version 6.0.0` in your terminal. This will allow for data migrations and updates to the project's database.

### Running the project
* Navigate to this project's production directory `CretaceousApi`.
* Recreate the database by running the command `$ dotnet ef database update` in your terminal.
* Navigate to your MySQLWorkbench to double check that your database has been built without error.
* In the command line, run the command `$ dotnet run` or `$ dotnet watch run` to compile and execute the application.
   * To compile the application without running it, use the following command: `$ dotnet build`.
* Begin populating your database. Use navigational links for quick access to different pages.

## API Documentation 
Explore API endpoints in your browser or in Postman. 

### Note on Pagination
The Cretaceous API defaults to 10 items per page, beginning on page number 1. To change the number of items (`pageSize`), or the starting page number (`pageIndex`), you can edit the search parameters following the example below.

### Cretaceous Animal API Endpoints
Base URL: ```http://localhost:5000```

```
GET http://localhost:5000/api/animals/
GET http://localhost:5000/api/animals/{id}
POST http://localhost:5000/api/animals/
PUT http://localhost:5000/api/animals/{id}
DELETE http://localhost:5000/api/animals/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| pageIndex | Number | 1 | not required | Returns the requested index page.
| pageSize | Number | 10 | not required | Returns up to the requested number of animals per page.
| name | String | none | not required | Return animals matching requested name.
| species | String | none | not required | Return animals matching requested species |
| minumumAge | Number | none | not required | Returns animals with an age value that is greater than or equal to the specified minimumAge number. |


### Example Queries
This query will return the first page containing up to 10 animals.
```
http://localhost:5000/api/Animals
```

This query will also return the first page containing up to 10 animals.
```
http://localhost:5000/api/Animals?pageIndex=1&pageSize=10
```
This query will return the first page containing up to 10 animals of the species Dinosaur.
```
http://localhost:5000/api/Animals?species=Dinosaur&pageIndex=1&pageSize=10
```
This query will return the first page containing up to 10 animals of the name Matilda.
```
http://localhost:5000/api/Animals?name=Matilda&pageIndex=1&pageSize=10
```
This query will return the first page containing up to 10 animals of an age greater than or equal to 2.
```
http://localhost:5000/api/Animals?minimumAge=2&pageIndex=1&pageSize=10
```
This query will return the first page containing up to 10 animals of the species Dinosaur, name Matilda, and minimum age of 2.
```
http://localhost:5000/api/Animals?species=Dinosaur&name=Matilda&minimumAge=2&pageIndex=1&pageSize=10
```

### Example JSON Response
```
[
  {
    "animalId": 3,
    "name": "Matilda",
    "species": "Dinosaur",
    "age": 2
  }
]
```


## Known Bugs

* Viewing not suited for smaller screens.
* Animation on dropdown menu broken

## MIT License
```
Copyright (c) 2023 Seth Gonzales

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

## Contact Information

If you run into any issues, or would like to contribute to our code, please email: sethgonzales157@gmail.com.

<center><a href="#">Return to Top</a></center>