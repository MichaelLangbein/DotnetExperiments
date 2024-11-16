using NHibernate;
using Repositories;
using Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(NHibernateHelper.SessionFactory);
builder.Services.AddScoped(fac => fac.GetService<ISessionFactory>()!.OpenSession());
builder.Services.AddScoped<Repository>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        );  // makes sure that circular references in json-output are resolved

// builder.Services.AddSingleton<BookRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
