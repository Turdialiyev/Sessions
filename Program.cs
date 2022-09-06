var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".super.secter.cookie";
    options.IdleTimeout = TimeSpan.FromSeconds(1);
    // options.Cookie.Expiration = TimeSpan.FromSeconds(10);
    // options.Cookie.MaxAge = TimeSpan.FromDays(1);
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