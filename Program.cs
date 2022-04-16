using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Repositories;
using Microsoft.AspNetCore.Mvc;
using MinimalApiCrud.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICarsRepository, CarsRepository>();

var app = builder.Build();

app.MapGet("/v1/cars", ([FromServices]ICarsRepository repository) =>
{
  return repository.GetCars();
});

app.MapPost("/v1/cars", ([FromServices]ICarsRepository repository, CarsModel car) =>
{
  var result = repository.InsertCar(car);

  return (result ?
  Results.Ok($"Carro {car.Modelo} inserido com sucesso")
  :
  Results.BadRequest("Não foi possivel inserir o carro")
  );
});

app.MapPut("v1/cars",
([FromServices]ICarsRepository repository, int id, string cor) =>
{
  var result = repository.UpdateCarCor(cor, id);

  return (result ?
  Results.Ok($"Cor alterado com sucesso")
  :
  Results.BadRequest("Não foi possivel alterar a cor do carro")
  );
});

app.MapDelete("v1/cars",
([FromServices]ICarsRepository repository, int id) =>
{
  var result = repository.DelecteCar(id);

  return (result ?
  Results.Ok($"Carro apagado com sucesso")
  :
  Results.BadRequest("Não foi possivel apagar o carro")
  );
});

app.Run();
