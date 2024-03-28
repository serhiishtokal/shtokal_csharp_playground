using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using SerilogPlayground.Extensions;
using SerilogPlayground.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.AddSmsSenders();

builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

