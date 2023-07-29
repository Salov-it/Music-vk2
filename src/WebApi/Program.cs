using Myaudio.Application.CQRS.Interface;
using Myaudio.Application.CQRS.Mapping;
using System.Reflection;
using Myaudio.Application;
using Persistance.Base;
using Myaudio.Application.CQRS.Command.GetMyaudioDowload;
using Myaudio.Application.CQRS.Command.GetMyaudio;
using MyRecommendationsService.Application;
using MyRecommendationsService.Application.Interface;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

//builder.Services.Myaudio
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new Myaudio.Application.CQRS.Mapping.AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new Myaudio.Application.CQRS.Mapping.AssemblyMappingProfile(typeof(IContext).Assembly));
});


//builder.Services.Myaudio
builder.Services.AddApplication();
builder.Services.AddPersistance(configuration);
builder.Services.AddScoped<IMyaudiosRepository, MyaudiosRepository>();
builder.Services.AddScoped<Myaudio.Application.CQRS.Interface.IVkApiService, VkApiService>();
builder.Services.AddScoped<Myaudio.Application.CQRS.Interface.ILooadin, LoadingMp3>();

//builder.Services.MyRecom
builder.Services.AddApplicationMyRecom();
builder.Services.AddScoped<IAudiosRepository, MyaudiosRepositoryMyRecom>();
builder.Services.AddScoped<IVkApiServiceMyRecom, VkApiServiceMyRecom>();
builder.Services.AddScoped<ILooadinMyRecom, LoadingMp3MyRecom>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Создания бд
using (var scope = app.Services.CreateScope())
{
    var serviseProvider = scope.ServiceProvider;
    try
    {
        var context = serviseProvider.GetRequiredService<Context>();
        DbInit.init(context);
    }
    catch (Exception ex)
    {

    }
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
