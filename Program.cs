using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TweetsApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();


app.MapGroup("/auth").MapIdentityApi<IdentityUser>().WithTags("Auth");

// app.UseAuthorization();

app.MapGet("/hello", () => "Hello World!").RequireAuthorization();

app.MapGet("/info", (ClaimsPrincipal user, UserManager<IdentityUser> userManager) =>
{
    //user.Identity.Name
    return userManager.GetUserId(user);
}).RequireAuthorization();

app.Run();
