using Inchcape.Controllers;
using Inchcape.Repository;
using Microsoft.AspNetCore.Mvc;
using Inchcape.Models;

namespace Inchcape.Test;

public class PlanControllerTest
{
    private readonly PlanController _planController;
    private readonly IInchcapeRepository _inchcapeRepository;

    public PlanControllerTest()
    {
        _inchcapeRepository = new InchcapeRepositoryDummy();
        _planController = new PlanController(_inchcapeRepository);
    }

    [Fact]
    public void Get_Plan_ReturnOkResult()
    {
        // Act
        var okResult = _planController.Get() as OkObjectResult;

        // Assert
        Assert.IsType<OkObjectResult>(okResult);
    }

    [Fact]
    public void Get_Plan_ReturnAllPlan()
    {
        // Act
        var okResult = _planController.Get() as OkObjectResult;

        // Assert
        var items = Assert.IsType<List<PlanDto>>(okResult?.Value);
        Assert.Equal(3, items.Count);
    }

    [Fact]
    public void Add_InvalidObjectPassed_ReturnsBadRequest()
    {
        // Arrange
        var nameMissingItem = new PlanDto()
        {
            FinanceRate1 = 5.1,
            FinanceRate2 = 5.2,
            FinanceRate3 = 5.3,
            FinanceRate4 = 5.2,
        };
        _planController.ModelState.AddModelError("VehicleType", "Required");
        _planController.ModelState.AddModelError("Make", "Required");
        _planController.ModelState.AddModelError("FinanceType", "Required");

        // Act
        var badResponse = _planController.Post(nameMissingItem);
        // Assert
        Assert.IsType<BadRequestObjectResult>(badResponse);
    }

    [Fact]
    public void Add_Plan_ReturnCreatedResponse()
    {
        // Arrange
        PlanDto plan = new PlanDto()
        {
            Make = "BMW",
            VehicleType = "Car",
            FinanceRate1 = 5.1,
            FinanceRate2 = 5.2,
            FinanceRate3 = 5.3,
            FinanceRate4 = 5.2,
            FinanceType = "Personal Load"
        };

        // Act
        var createdResponse = _planController.Post(plan);
        var okResult = _planController.Get() as OkObjectResult;

        // Assert
        Assert.IsType<CreatedAtActionResult>(createdResponse);
        var items = Assert.IsType<List<PlanDto>>(okResult?.Value);
        Assert.Equal(4, items.Count);

    }
}
