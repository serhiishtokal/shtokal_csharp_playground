using FastEndpoints;
using Serilog;
using SerilogPlayground.Middleware;
using SerilogPlayground.Services.Senders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<ISender1, Sender1>();
builder.Services.Decorate<ISender1, Sender1Decorator1>();

builder.Services.AddSingleton<ISender2, Sender2>();
builder.Services.Decorate<ISender2, Sender2Decorator1>();

builder.Services.AddSingleton<ISender>(sp => sp.GetRequiredService<ISender1>());
builder.Services.AddSingleton<ISender, ISender2>(sp => sp.GetRequiredService<ISender2>());

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

app.UseFastEndpoints();

app.Run();

