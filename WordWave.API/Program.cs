using Microsoft.EntityFrameworkCore;
using WordWave.API.Extensions;
using WordWave.Infrastructure.DataAccess;
using WordWave.Infrastructure.Interfaces;
using WordWave.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BlogDatabass");

builder.Services.AddDbContext<BlogDbContext>(
    options => options.UseSqlServer("Data Source=LAPTOP-8SM8C2KU; Initial Catalog = BlogDatabass; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")
);


builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services for controllers with NewtonsoftJson
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Add support for minimal APIs to use Newtonsoft.Json
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Use routing
app.UseRouting();


app.BlogEndPoints();
app.CommentEndPoints();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
