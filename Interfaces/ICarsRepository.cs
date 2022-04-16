using MinimalApiCrud.Models;

namespace MinimalApiCrud.Interfaces
{
    public interface ICarsRepository
    {
         IEnumerable<CarsModel> GetCars();
         bool InsertCar(CarsModel car);
         bool UpdateCarCor(string cor, int id);
         bool DelecteCar(int id);
    }
}
