using Microsoft.AspNetCore.Mvc;
using Inchcape.Repository.Models;
using Inchcape.Models;
using Inchcape.Repository;
using System.Numerics;
using System.Net;
using System.Security.Claims;

namespace Inchcape.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IInchcapeRepository _inchcapeRepository;

    public PlanController(IInchcapeRepository inchcapeRepository)
    {
        _inchcapeRepository = inchcapeRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<Plan> plans = _inchcapeRepository.GetPlans();
        if (plans == null)
        {
            return Ok();
        }
        List<PlanDto> result = new List<PlanDto>();
        foreach (Plan plan in plans)
        {
            Car? car = _inchcapeRepository.GetAllCar().Where(c => c.CarId == plan.CarId).FirstOrDefault();
            FinancialType? ft = _inchcapeRepository.GetAllFinancialType().Where(c => c.FinancialTypeId == plan.FinancialTypeId).FirstOrDefault();
            result.Add(new PlanDto()
            {
                Make = car?.Make??"",
                VehicleType = car?.VehicleType??"",
                FinanceType = ft?.Name??"",
                FinanceRate1 = plan.FirstQuarter,
                FinanceRate2 = plan.SecondQuarter,
                FinanceRate3 = plan.ThirdQuarter,
                FinanceRate4 = plan.AfterThirdQuarter
            });
        }
        return Ok(result);
    }
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetPlanById(int id)
    {
        Plan plan = _inchcapeRepository.GetPlans().Where(c=> c.PlanId == id).First();
        Car? car = _inchcapeRepository.GetAllCar().Where(c => c.CarId == plan.CarId).FirstOrDefault();
        FinancialType? ft = _inchcapeRepository.GetAllFinancialType().Where(c => c.FinancialTypeId == plan.FinancialTypeId).FirstOrDefault();
        return Ok(new PlanDto()
        {
            Make = car?.Make ?? "",
            VehicleType = car?.VehicleType ?? "",
            FinanceType = ft?.Name ?? "",
            FinanceRate1 = plan.FirstQuarter,
            FinanceRate2 = plan.SecondQuarter,
            FinanceRate3 = plan.ThirdQuarter,
            FinanceRate4 = plan.AfterThirdQuarter
        });
    }

    [HttpPost]
    public IActionResult Post(PlanDto plan )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        FinancialType? ft = _inchcapeRepository.GetFinancialType(plan.FinanceType);
        Car? car = _inchcapeRepository.GetCar(plan.Make, plan.VehicleType);

        if (car == null)
        {
            car = new Car()
            {
                Make = plan.Make,
                VehicleType = plan.VehicleType
            };
            _inchcapeRepository.AddCar(car);
        }
        if (ft == null)
        {
            ft = new FinancialType()
            {
                Name = plan.FinanceType
            };
            _inchcapeRepository.AddFinanceType(ft);
        }
        Plan _plan = new Plan()
        {
            CarId = car.CarId,
            FinancialTypeId = ft.FinancialTypeId,
            FirstQuarter = plan.FinanceRate1,
            SecondQuarter = plan.FinanceRate2,
            ThirdQuarter = plan.FinanceRate3,
            AfterThirdQuarter = plan.FinanceRate4
        };
        _inchcapeRepository.AddPlan(_plan);
        return CreatedAtAction(nameof(GetPlanById), new { id = _plan.PlanId }, _plan);
    }
}

