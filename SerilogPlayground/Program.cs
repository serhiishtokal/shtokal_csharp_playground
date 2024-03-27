using FastEndpoints;
using Serilog;
using SerilogPlayground.Extensions;
using SerilogPlayground.Middleware;
using SerilogPlayground.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<SampleService>();
builder.Services.AddScoped<SampleService2>();

builder.Services.AddFastEndpoints();

builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();

app.MapEndpoints();
app.UseFastEndpoints();

app.Run();

