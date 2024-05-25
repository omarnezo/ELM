using AutoMapper;
using ELM.Data.Context;
using ELM.Data.IRepository;
using ELM.Data.Repository;
using ELM.Infraa.IService;
using ELM.Infraa.Mapper;
using ELM.Infraa.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ELMContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddAutoMapper(typeof(Program));
var mappingConfig = new MapperConfiguration(e =>
{
    e.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
