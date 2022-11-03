using Api;
using Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DAL.DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"), sql => { });
});

builder.Services.AddAutoMapper(typeof(mapperProfile).Assembly);

builder.Services.AddScoped<UserService>();

var app = builder.Build();

using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
{
    if (serviceScope != null)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<DAL.DataContext>();
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
