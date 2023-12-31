using System.Reflection;
using Myaudio.Application;
using Persistance.Base;
using UserService.Application;
using UserService.Application.Interface;
using AudioSearchService.Application;
using AudioSearchService.Application.Interface;
using AudioPopularService.Application;
using AudioPopularService.Application.Interface;
using Myaudio.Application.CQRS.Query.GetMyaudioDowload;
using Myaudio.Application.Interface;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

//builder.Services.Myaudio
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new Myaudio.Application.Mapping.AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new Myaudio.Application.Mapping.AssemblyMappingProfile(typeof(IContext).Assembly));
});

builder.Services.AddHttpClient();
builder.Services.AddControllers();


//builder.Services.Myaudio
builder.Services.AddApplication();
builder.Services.AddPersistance(configuration);
builder.Services.AddScoped<IMyaudiosRepository, MyaudiosRepository>();
builder.Services.AddScoped<IVkApiService, VkApiService>();


//builder.Services.UserService
builder.Services.AddUserService();
builder.Services.AddScoped<IUserContext, Context>();


//AudioSearchService
builder.Services.AddAudioSearchService();
builder.Services.AddScoped<IAudioSearchContext, Context>();

//AudioPopularService
builder.Services.AddAudioPopularService();
builder.Services.AddScoped<IAudioPopularContext, Context>();





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//�������� ��
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

public partial class Program { }
