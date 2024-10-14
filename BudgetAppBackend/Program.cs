using BudgetApp.API.Extension;
using BudgetAppBackend.Extension;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);
//Add logger service
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigurePosgreSqlContext(builder.Configuration);
builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

//Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token with 'Bearer' scheme",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },

        new string[] { }
    }});
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Budget Api",
        Version = "v1"
    });
});

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.ConfigureJWT(builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Enable Swagger middleware
    app.UseSwagger();

    // Set Swagger as the default homepage
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Budget API v1");
        c.RoutePrefix = string.Empty;  // This makes Swagger the default home page
    });
}
//app.UseSerilogRequestLogging();


app.UseMiddleware<GlobalErrorHandlingMiddleware>();

// Enable CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
