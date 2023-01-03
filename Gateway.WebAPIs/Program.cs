var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



// Download From NuGet Packages 
// MediatR
// MediatR.Extensions.Microsoft.Dependencylnjection
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.Relational + sqlServer + Postman\ swagger 

