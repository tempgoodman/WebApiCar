using System;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using Inchcape.Repository;
using Inchcape.Repository.Models;

namespace Inchcape.Repository
{
    public class InchcapeRepositoryDummy : IInchcapeRepository
    {
        private List<Plan> _plans;

        private List<Car> _cars;

        private List<FinancialType> _financialTypes;
        
        public InchcapeRepositoryDummy()
        {
            _cars = new List<Car>();
            _cars.Add(new Car()
            {
                CarId = 1,
                Description = "",
                Make = "BMW",
                VehicleType = "Van"
            });
            _cars.Add(new Car()
            {
                CarId = 2,
                Description = "",
                Make = "Audi",
                VehicleType = "Car"
            });

            _financialTypes = new List<FinancialType>();
            _financialTypes.Add(new FinancialType()
            {
                FinancialTypeId = 1,
                Name = "Flexible finance",
            });
            _financialTypes.Add(new FinancialType()
            {
                FinancialTypeId = 1,
                Name = "Personal loan",
            });

            _plans = new List<Plan>();
            _plans.Add(new Plan()
            {
                PlanId = 1,
                CarId = 1,
                FinancialTypeId = 1,
                FirstQuarter = 5,
                SecondQuarter = 6,
                ThirdQuarter = 7,
                AfterThirdQuarter = 8
            });
            _plans.Add(new Plan()
            {
                PlanId = 1,
                CarId = 2,
                FinancialTypeId = 1,
                FirstQuarter = 5.1,
                SecondQuarter = 6.1,
                ThirdQuarter = 7.1,
                AfterThirdQuarter = 8.1
            });
            _plans.Add(new Plan()
            {
                PlanId = 1,
                CarId = 1,
                FinancialTypeId = 2,
                FirstQuarter = 5.2,
                SecondQuarter = 6.2,
                ThirdQuarter = 7.2,
                AfterThirdQuarter = 8.2
            });
        }

        public Car? GetCar(string make, string vihicleType)
        {
            return _cars.Where(c => c.Make == make && c.VehicleType == vihicleType).FirstOrDefault();
        }
        public FinancialType? GetFinancialType(string financialType)
        {
            return _financialTypes.Where(c => c.Name == financialType).FirstOrDefault();
        }
        public List<Car> GetAllCar()
        {
            return _cars;
        }
        public List<FinancialType> GetAllFinancialType()
        {
            return _financialTypes;
        }
        public void AddCar(Car car)
        {
            car.CarId = _cars.Count;
            _cars.Add(car);
        }
        public void AddFinanceType(FinancialType financialType)
        {
            financialType.FinancialTypeId = _financialTypes.Count;
            _financialTypes.Add(financialType);
        }
        public void AddPlan(Plan plan)
        {
            plan.PlanId = _plans.Count;
            _plans.Add(plan);
        }
        public List<Plan> GetPlans()
        {
            return _plans;
        }
    }
}

