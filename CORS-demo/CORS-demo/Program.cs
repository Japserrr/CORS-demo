using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add the CORS policy to the container:
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy", policy =>
    {
        //policy.AllowAnyOrigin(); // Allow any origin with methods: GET, POST
        //policy.AllowAnyOrigin().AllowAnyMethod(); // Allow any origin with any methods
        //policy.AllowAnyOrigin().WithMethods("PUT"); // Allow any origin with methods: GET, POST, PUT
        //policy.WithOrigins("https://www.google.com"); // Allow a request from google.com with methods: GET, POST

        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").WithMethods("PUT");
    });

    options.AddPolicy(name: "MyGooglePolicy", policy =>
    {
        policy.WithOrigins("https://www.google.com").WithMethods("PUT");
    });
});
// --------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

// Enable CORS and add the CORS policy to all controllers.
app.UseCors("MyPolicy");
//app.UseCors();
// --------------------------------------------------

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints => {
  //  endpoints.MapControllers()
    //    .RequireCors("MyPolicy");
//});

app.Run();
