using FluentValidation;
using ResultProject;
using ResultProject.Dtos;
using ResultProject.Services;
using ResultProject.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IValidator<PersonDto>, PersonValidator>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddTransient(typeof(ITranslateResult<>),typeof(TranslateResult<>));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
