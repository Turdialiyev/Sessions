var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddSession(options => 
{
    options.Cookie.Name = ".super.sector.cookie";
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    // options.IOTimeout = TimeSpan.FromSeconds(10);
     options.Cookie.MaxAge = TimeSpan.FromDays(1);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
