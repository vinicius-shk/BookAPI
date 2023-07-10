using BookAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
