using BookManager.ApplicationLayer.Commands.Handlers;
using BookManager.ApplicationLayer.Commands.Interfaces;
using BookManager.ApplicationLayer.Interfaces;
using BookManager.ApplicationLayer.Queries.Handlers;
using BookManager.ApplicationLayer.Queries.Interfaces;
using BookManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(allowsites =>
    allowsites.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistentStorageDependencies();
builder.Services.AddScoped<IAddBookHandler, AddBookHandler>();
builder.Services.AddScoped<IDeleteBookHandler, DeleteBookHandler>();
builder.Services.AddScoped<IGetBooksHandler, GetBooksHandler>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
