using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestTask.App.Interfaces;
using TestTask.Domain.Models;


namespace TestTask.Data.Storages
{
    public class CarStorage : ICarStorage
    {
        private readonly TestTaskSystemDbContext _carSystemDbContext;

        public CarStorage(TestTaskSystemDbContext carSystemDbContext)
        {
            _carSystemDbContext = carSystemDbContext;
        }

        public async Task AddAsync(Car car)
        {
            if (car.Id == Guid.Empty)
            {
                car.Id = Guid.NewGuid();
            }

            await _carSystemDbContext.Cars.AddAsync(car);
            await _carSystemDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var car = await _carSystemDbContext.Cars
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (car != null)
            {
                _carSystemDbContext.Cars.Remove(car);
                await _carSystemDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Guid id, Car newCar)
        {
            var car = await _carSystemDbContext.Cars
                   .FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                car.Make = newCar.Make;
                car.Model = newCar.Model;
                car.Year = newCar.Year;
                car.Color = newCar.Color;
                car.Price = newCar.Price;
                car.FuelType = newCar.FuelType;

                await _carSystemDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAsync()
        {
            var cars = await _carSystemDbContext.Cars.ToListAsync();
            
            return cars;
        }

        public async Task<Car> GetCarByIdAsync(Guid id)
        {
            Car? car = await _carSystemDbContext.Cars.FirstOrDefaultAsync(a => a.Id == id);

            if (car != null)
                return car;

            return new Car();
        }
    }
}