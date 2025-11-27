using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.App.DTOs;

namespace TestTask.App.Interfaces
{
    public interface ICarService
    {
        public Task AddCarAsync(CarDto carDto);

        public Task RemoveCarAsync(Guid id);

        public Task UpdateCarAsync(Guid id, CarDto newCarDto);

        public Task<List<CarDto>> GetAsync();

        public Task<CarDto> GetCarAsync(Guid CarId);
    }
}
