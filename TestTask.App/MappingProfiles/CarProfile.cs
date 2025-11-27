using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.App.DTOs;
using TestTask.Domain.Models;

namespace TestTask.App.MappingProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile() 
        {
            CreateMap<CarDto, Car>();
            CreateMap<Car, CarDto>();
        }
    }
}
