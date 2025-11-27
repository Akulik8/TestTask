using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.App.DTOs
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? Color { get; set; }
        public decimal? Price { get; set; }
        public string? FuelType { get; set; }
    }
}
