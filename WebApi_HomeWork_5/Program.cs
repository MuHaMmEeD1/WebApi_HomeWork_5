using WebApi_HomeWork_5.Hubs;
using WebApi_HomeWork_5.Services.Abstract;
using WebApi_HomeWork_5.Services.Cocrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(p => {


    p.AddPolicy("crosapp", builder => {

        builder.WithOrigins("")
        .AllowAnyMethod()
        .AllowAnyHeader();
    
    });

});


builder.Services.AddSingleton<IFileService, FileService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials();


});


app.UseAuthorization();

app.MapControllers();
app.MapHub<MessageHub>("/offers");

app.Run();
