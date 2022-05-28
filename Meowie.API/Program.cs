using Meowie.API.Hubs;
using Meowie.Lib.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddSingleton<ChatHub>();

builder.Services.AddHostedService<Chatter>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<CatFactsClient>(sp =>
    new CatFactsClient(
        new HttpClient
        {
            BaseAddress = new Uri(@"https://catfact.ninja")
        }));


builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
   
    });
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        listenOptions.AllowAnyClientCertificate();
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.WithOrigins("*")
        .AllowAnyHeader()
        .WithMethods("GET", "POST");
});



app.MapHub<ChatHub>("/chathub");
app.UseResponseCompression();

app.Run();