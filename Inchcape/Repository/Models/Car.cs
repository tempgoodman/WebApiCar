using System;
namespace Inchcape.Repository.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string VehicleType { get; set; }
        public string? ModelNumber { get; set; }
        public string? Description { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }
}

