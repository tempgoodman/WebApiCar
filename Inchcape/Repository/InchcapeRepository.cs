using System;
using System.Numerics;
using Inchcape.Repository;
using Inchcape.Repository.Models;
using Microsoft.EntityFrameworkCore;
namespace Inchcape.Repository
{
    public class InchcapeRepository : IInchcapeRepository
    {
        public InchcapeRepository()
        {
        }

        public Car? GetCar(string make, string vihicleType)
        {
            using (var context = new InchcapeContext())
            {
                return context.Cars?.Where(c => c.Make == make && c.VehicleType == vihicleType).FirstOrDefault();
            }
        }
        public FinancialType? GetFinancialType(string financialType)
        {
            using (var context = new InchcapeContext())
            {
                return context.FinancialTypes.Where(c => c.Name == financialType).FirstOrDefault();
            }
        }
        public List<Car> GetAllCar()
        {
            using (var context = new InchcapeContext())
            {
                return context.Cars.ToList();
            }
        }
        public List<FinancialType> GetAllFinancialType()
        {
            using (var context = new InchcapeContext())
            {
                return context.FinancialTypes.ToList();
            }
        }
        public void AddCar(Car car)
        {
            using (var context = new InchcapeContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }
        public void AddFinanceType(FinancialType financialType)
        {
            using (var context = new InchcapeContext())
            {
                context.FinancialTypes.Add(financialType);                
                context.SaveChanges();
            }
        }
        public void AddPlan(Plan plan)
        {
            using (var context = new InchcapeContext())
            {
                context.Plans.Add(plan);
                context.SaveChanges();
            }
        }
        public List<Plan> GetPlans()
        {
            using (var context = new InchcapeContext())
            {
                var list = context.Plans
                    .ToList();
                return list;
            }
        }
    }
}

