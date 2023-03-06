using Firebase.Storage;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<BookSellingContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
builder.Services.AddRazorPages();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "MyScheme";
    options.DefaultAuthenticateScheme = "MyScheme";
    options.DefaultChallengeScheme = "MyScheme";
    options.DefaultSignInScheme = "MyScheme";
})
.AddScheme<SessionAuthenticationOptions, SessionAuthenticationHandler>("MyScheme", options => { })
.AddCookie(options => { })
.AddGoogle(options =>
{
    options.ClientId = "546584990405-i57t58ev9ib0dh3kk1celkulfdoiolgq.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Scope.Add("https://www.googleapis.com/auth/user.gender.read");
    options.Events = new OAuthEvents
    {
        OnCreatingTicket = context =>
        {
            // get the user's email address from the claims
            var email = context.Identity.FindFirst(ClaimTypes.Email)?.Value;
            var gender = context.Identity.FindFirst("gender");

            Console.WriteLine(email);
            Console.WriteLine(gender);
            // add a custom claim to the user's identity
            if (!string.IsNullOrEmpty(email))
            {
                // remove the default NameIdentifier claim if it exists
                var nameIdentifierClaim = context.Identity.FindFirst(ClaimTypes.NameIdentifier);
                if (nameIdentifierClaim != null)
                {
                    context.Identity.RemoveClaim(nameIdentifierClaim);
                }

                // add the email as the new NameIdentifier claim
                var newClaim = new Claim(ClaimTypes.NameIdentifier, email);
                context.Identity.AddClaim(newClaim);
            }

            return Task.CompletedTask;
        }
    };
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "MyScheme";
//    options.DefaultChallengeScheme = "MyScheme";
//})
//        .AddScheme<SessionAuthenticationOptions, SessionAuthenticationHandler>(
//            "MySession", options => { });

//builder.Services
//.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//    options.DefaultSignOutScheme = GoogleDefaults.AuthenticationScheme;
//})
//.AddCookie(options =>
//{
//})
//.AddGoogle(options =>
//{
//    options.ClientId = "546584990405-i57t58ev9ib0dh3kk1celkulfdoiolgq.apps.googleusercontent.com";
//    options.ClientSecret = "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";
//    options.Events = new OAuthEvents
//    {
//        OnCreatingTicket = context =>
//        {
//            // get the user's email address from the claims
//            var email = context.Identity.FindFirst(ClaimTypes.Email)?.Value;
//            Console.WriteLine(email);
//            // add a custom claim to the user's identity
//            if (!string.IsNullOrEmpty(email))
//            {
//                // remove the default NameIdentifier claim if it exists
//                var nameIdentifierClaim = context.Identity.FindFirst(ClaimTypes.NameIdentifier);
//                if (nameIdentifierClaim != null)
//                {
//                    context.Identity.RemoveClaim(nameIdentifierClaim);
//                }

//                // add the email as the new NameIdentifier claim
//                var newClaim = new Claim(ClaimTypes.NameIdentifier, email);
//                context.Identity.AddClaim(newClaim);
//            }

//            return Task.CompletedTask;
//        }
//    };
//});


builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.Use(async (context, next) =>
//{
//    await next();
//    if (context.Response.StatusCode == 404)
//    {
//        context.Request.Path = "/View/NotFound.cshtml";
//        await next();
//    }
//});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
//pattern: "{controller=Book}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notificationHub");
});


app.Run();
