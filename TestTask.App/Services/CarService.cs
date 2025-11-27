using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestTask.App.DTOs;
using TestTask.App.Interfaces;
using TestTask.Domain.Models;

namespace TestTask.App.Services
{
    public class CarService : ICarService
    {
        private readonly ICarStorage _carStorage;
        private readonly IMapper _mapper;

        public CarService(ICarStorage carStorage, IMapper mapper)
        {
            _carStorage = carStorage;
            _mapper = mapper;
        }

        public async Task AddCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);

            if (car.Id != Guid.Empty)
            {
                var checkCar = await _carStorage.GetCarByIdAsync(car.Id);

                if (checkCar != null)
                    throw new Exception("Авто с таким Id уже существует.");
            }
            await _carStorage.AddAsync(car);
        }

        public async Task RemoveCarAsync(Guid id)
        {
            var existingCar = await _carStorage.GetCarByIdAsync(id);
            if (existingCar == null)
                throw new Exception("Авто не найдено.");

            await _carStorage.DeleteAsync(id);
        }

        public async Task UpdateCarAsync(Guid id, CarDto newCarDto)
        {
            var newCar = _mapper.Map<Car>(newCarDto);

            var existingCar = await _carStorage.GetCarByIdAsync(id);

            if (existingCar is null)
                throw new Exception("Авто с данным Id не найдено.");

            if (newCar == null)
                throw new Exception("Нет сведений о новом авто.");

            await _carStorage.UpdateAsync(id, newCar);
        }

      
        public async Task<List<CarDto>> GetAsync()
        {
            List<Car> cars = await _carStorage.GetAsync();

            return cars.Select(_mapper.Map<CarDto>).ToList();
        }

        public async Task<CarDto> GetCarAsync(Guid CarId)
        {
            var car = await _carStorage.GetCarByIdAsync(CarId);

            if (car is null)
                throw new Exception("Авто не найдено.");

            return _mapper.Map<CarDto>(car);
        }
    }
}