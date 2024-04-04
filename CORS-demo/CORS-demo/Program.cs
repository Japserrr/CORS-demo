using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add the CORS policy to the container:
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy", policy =>
    {
        //policy.AllowAnyOrigin(); // Allow any origin with methods: GET, POST
        //policy.AllowAnyOrigin().AllowAnyMethod(); // Allow any origin with any methods
        //policy.AllowAnyOrigin().WithMethods("PUT"); // Allow any origin with methods: GET, POST, PUT
        //policy.WithOrigins("http://127.0.0.1:5500").WithMethods("PUT"); // Allow a request from 127.0.0.1:5500 with methods: GET, POST, PUT

        //policy.WithOrigins("https://www.google.com"); // Allow a request from google.com with methods: GET, POST

        //policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "127.0.0.1").WithMethods("PUT");
    });

    //options.AddPolicy(name: "BlockGet", policy => { });

    //options.AddPolicy(name: "MyGooglePolicy", policy =>
    //{
    //    policy.WithOrigins("https://www.google.com").WithMethods("PUT");
    //});
});


// --------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

// Enable CORS and add the CORS policy to all controllers.
app.UseCors("MyPolicy");
//app.UseCors("MyGooglePolicy");
//app.UseCors();
// --------------------------------------------------

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers()
//        .RequireCors("MyPolicy");
//});

app.Run();
