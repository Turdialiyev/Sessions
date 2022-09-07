var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".request.count";
    options.IdleTimeout = TimeSpan.FromSeconds(5);
    // options.Cookie.Expiration = TimeSpan.FromSeconds(10);
    // options.IOTimeout = TimeSpan.FromSeconds(10);
    // options.Cookie.MaxAge = TimeSpan.FromSeconds(10);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();

app.MapControllers();
app.Run();