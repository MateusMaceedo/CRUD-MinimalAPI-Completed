using System.Data;
using MinimalApiCrud.Factory;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Models;
using Dapper;

namespace MinimalApiCrud.Repositories
{
  public class CarsRepository : ICarsRepository
  {
    private readonly IDbConnection _connection;
    public CarsRepository()
    {
      _connection = new SqlFactory().SqlConnection();
    }

    public bool DelecteCar(int id)
    {
      var query = "DELETE [CarDataBase].[dbo].[Cars] WHERE [Id] = @carId";
      var parameters = new { carId = id };
      var result = 0;

      using (_connection)
      {
        result = _connection.Execute(query, parameters);
      }
      return (result != 0 ? true : false);
    }

    public IEnumerable<CarsModel> GetCars()
    {
      var cars = new List<CarsModel>();
      var query = "SELECT * FROM [CarDataBase].[dbo].[Cars]";
      using (_connection)
      {
        cars = _connection.Query<CarsModel>(query).ToList();
      }
      return cars;
    }

    public bool InsertCar(CarsModel car)
    {
      var query =
      @"INSERT INTO [CarDataBase].[dbo].[Cars]
      VALUES
      (
        @modelo,
        @fabricante,
        @motor,
        @cor
      )";

      var parameters = new
      {
        modelo = car.Modelo,
        fabricante = car.Fabricante,
        motor = car.Motor,
        cor = car.Cor
      };

      int result = 0;

      using (_connection)
      {
        result = _connection.Execute(query, parameters);
      }
      return (result != 0 ? true : false);
    }

    public bool UpdateCarCor(string cor, int id)
    {
      var query =
      @"UPDATE [CarDataBase].[dbo].[Cars]
      SET
      [Cor] = @corCarro
      WHERE
      [Id] = @carId
      ";

      var parameters = new
      {
        corCarro = cor,
        carId = id
      };

      int result = 0;

      using (_connection)
      {
        result = _connection.Execute(query, parameters);
      }
      return (result != 0 ? true : false);
    }
  }
}
