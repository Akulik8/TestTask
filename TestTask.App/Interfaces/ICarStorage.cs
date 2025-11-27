using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Models;

namespace TestTask.App.Interfaces
{
    public interface ICarStorage
    {
        public Task AddAsync(Car car);

        public Task DeleteAsync(Guid id);

        public Task UpdateAsync(Guid id, Car newCar);

        public Task<List<Car>> GetAsync();

        public Task<Car> GetCarByIdAsync(Guid id);
    }
}
