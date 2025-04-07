using API.Data;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext> (opt =>
{
    opt.UseSqlServer("Server=BHAVYA\\SQLEXPRESS;Database=DotNetShop;Trusted_Connection=True;TrustServerCertificate=true");
});

// Add CORS policy to allow all origins, methods and headers (like getting request from localhost:3000 to localhost:5000)
builder.Services.AddCors();

var app = builder.Build();


//Midleware for exception
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
// allowcredentials is used to allow the cookies to be sent from the client to the server
// withorigins is used to allow the request from the client to the server
// allowanyheader is used to allow the headers to be sent from the client to the server
// allowany method is used to allow the methods to be sent from the client to the server
// http://localhost:3000 is the origin from where the request is coming
app.UseCors(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:3000"));

app.UseAuthorization();
app.MapControllers(); 

//create scope to get the service provider , get the context and logger\
//try to migrate the database and initialize the database
//if any error occurs log the error
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    // context.Database.Migrate() will create the database if it does not exist and apply any pending migrations in the database.
    context.Database.Migrate();
    // DbInitialiser.Initialize(context) will seed the database with data and pass the context to the method.
    //DbInitialiser.Initialize(context);
    logger.LogInformation("Migration successful");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
