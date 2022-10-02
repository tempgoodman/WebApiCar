using System;
namespace Inchcape.Repository.Models
{
	public class FinancialType
    {
        public int FinancialTypeId { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Terms { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }
}

