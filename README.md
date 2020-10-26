# PizzaPros


 This project was completed using my knowledge of ASP.NET Core Razor pages with MVC. I liked doing the Repository Pattern  
 with other projects so much I had to create a new one to solidify my understanding. This application is a typical pizza  
 ordering system that has different users such as manager, cook, driver, and customer roles. Each screen facilitates the  
 specific user that is logged in. This project is similar to my other project [SnakPros](https://github.com/agent1red/SnackProsDemo) but there is a fucus more on making  
 a complicated repository pattern, experimenting with JavaScript, and a better go at UI design with bootstrap and modern CSS. 
 
 NOTE: Work in progress. If you fork this repo now you will not be getting the full completed project at this time.  
 In the meantime, feel free to check on [My Progress](https://github.com/agent1red/PizzaPros/blob/main/TaskList.md).




ASP.NET Core 3.1 Razor Pages With MVC Continuation Demo 

- CRUD Operations in Razor Pages
- ASP Handelers
- Repository Pattern
- API Controllers using MVC  
- Server/Client Validation
- DataBase Migrations (code first approach)
- Multi-Project structure (Easier to read and understand) 
- Table creating/sorting on load
- Image Uploading
- Creating Multiple Users with different Roles
  - Manager Role
  - Front Desk Cashier
  - Pizza maker  
  - Online Customer Ordering
- User Authorization and account Lock 
- SSO Using Facebook and Microsoft
- Shopping cart functionality with session loading 
- DOM manipulation with JQuery
- Ordering System with Order Details and Management
- Using Stripe payment system
- UI designed with Bootsrap 4 and CSS

## File Structure:
- PizzaPros => Main project with wwwroot, controllers, and Razor Pages
- PizzaPros.DataAccess => 
    - Project to handle data such as Migrations, Repositories, ApplicationDbContext  
- PizzaPros.Models => Project that Holds our blueprints (Models) and View Models
- PizzaPros.Utility => 
    - Project that holds static definitions, email client, and Stripe Ordering


# Instructions For Installing 

**1.** Fork repo to VS Studio 2019  
**2.** NUGET packages used:  
  - Microsoft.AspNetCore.Authentication.Facebook
  - Microsoft.AspNetCore.Authentication.MicrosoftAccount
  - Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
  - Microsoft.AspNetCore.Identity.UI
  - Microsoft.AspNetCore.Mvc
  - Microsoft.AspNetCore.Mvc.NewtonsoftJson
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
  - Stripe.net

