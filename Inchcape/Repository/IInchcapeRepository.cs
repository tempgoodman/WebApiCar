using System;
using Inchcape.Repository.Models;
namespace Inchcape.Repository
{
    public interface IInchcapeRepository
    {
        public List<Plan> GetPlans();
        public Car? GetCar(string make, string vihicleType);
        public FinancialType? GetFinancialType(string financialType);
        public List<Car> GetAllCar();
        public List<FinancialType> GetAllFinancialType();
        public void AddPlan(Plan plan);
        public void AddCar(Car car);
        public void AddFinanceType(FinancialType financialType);
    }
}

