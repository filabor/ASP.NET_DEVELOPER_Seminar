# Asp.Net_Developer_Seminar
> Simple CRUD application made as concluding independent project for ASP .NET development training program

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Setup](#setup)
* [Features](#features)
* [API Reference](#api-reference)


## General Information
- This project is final part of training program for ASP.NET devlopment, it contains all parts of the material included in the educational program and serves to prove acquired knowledge and skills
- It is simple CMS (Content Management System) for products and users based on MVC (Model-View-Controller) arhitectural pattern with E-commerce purpose
- Sql Server database is used for storing and retrieving data
- With additional development it can be a functional web store

## Technologies Used
- C# version 10.0
- .NET Framework version 6.0
- .NET WEB API version 5.3
- Bootstrap version 5.2
- SQL


 ## Setup
 
 #### Requirements
 - Microsoft Visual Studio (2019, 2022)
 - Microsoft SQL Management Studio or some other relational database management system that uses SQL

 #### Installation
 - Clone this repository `https://github.com/filabor/Asp.Net_Developer_Seminar.git` or download ZIP file
 - Open it with Visual Studio
 - Run migrations in database with Package Manager Console

   `PM> Update-Database`
 - Start the project

 ## Features
 The functionalities of the application are divided into three areas: 
 - Public area
 - Admin area
 - User area
 
 #### Public area
 - Area intended for users who are not registered or logged in and allows the user to view the products
 - Home and Products pages are available to the user in the navigation bar
 - Ten random products are displayed on the Home page, with each page reload different products will be displayed
 - The Product page offers a display of all products and the possibility of filtering products according to the category or categories to which it belongs
 - In the right corner of the navigation bar there are options for user registration and login
 
 #### Admin area
 - Area intended for registered users who have the role of administrator
 - By logging in as an administrator user interface gets an additional option in the navigation bar in the form of a drop-down menu (*Admin menu*) for CRUD operations on categories, products and users
 - Also logged in adminstrator will have another one additianal option in navigation bar *User profile* (see more in User area)
 - To log in as adminstrator use the given data: `Email: admin@admin.com` `Password: AdminPass123`

###### *Admin menu*
 - Categories menu option is used to create, read, update and delete a specific category
 - Products menu option is used for CRUD operations on the product, create action serves to enter basic data and upload a product image, and select a products category/categories
 - Users menu option is used to manage users through CRUD operations, in addition to entering basic data administrator also has the option of assigning a role to the user (Admin/User)
 
 #### User area
 - An area that can be accessed by registered users, logged in user have additional option in navigation bar *User profile*
 - *User profile* option offers user to check his personal data on his profile and allows user to edit his data
 
 ## API Reference
 - The project contains a web API that enables access to endpoints
 - Using the GET HTTP method, it is possible to access the list of all products and each product individually
 - You can test API using Postman or in Visual Studio using Swagger (set CMS_seminar.API as a startup project and start the project)
 - Endpoint with list of all products:

   `https://localhost:7160/api/Product/Products`
 - Endpoint for getting product by Id:

   `https://localhost:7160/api/Product/{id}`
