using Microsoft.AspNetCore.Mvc;
using ZooManager.Application;

namespace ZooManager.Presentation.Controllers;

/// <summary>
/// Контроллер для статистики 
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ZooStatisticsController : ControllerBase
{
    private readonly ZooStatisticsService _zooStatisticsService;

    public ZooStatisticsController(ZooStatisticsService zooStatisticsService)
    {
        _zooStatisticsService = zooStatisticsService;
    }

    /// <summary>
    /// Получить общие количества животных
    /// </summary>
    /// <returns></returns>
    [HttpGet("total-animals")]
    public IActionResult GetTotalAnimals()
    {
        var totalAnimals = _zooStatisticsService.GetAmountOfAnimals();
        return Ok(new { TotalAnimals = totalAnimals });
    }

    /// <summary>
    /// Получить общее количества вольеров
    /// </summary>
    /// <returns></returns>
    [HttpGet("total-enclosures")]
    public IActionResult GetTotalEnclosures()
    {
        var totalEnclosures = _zooStatisticsService.GetAmountOfEnclosures();
        return Ok(new { TotalEnclosures = totalEnclosures });
    }
    
    /// <summary>
    /// Получить количество свободных вольеров
    /// </summary>
    /// <returns></returns>
    [HttpGet("free-enclosures")]
    public IActionResult GetFreeEnclosures()
    {
        var freeEnclosures = _zooStatisticsService.GetFreeEnclosureStatistics();
        return Ok(new { FreeEnclosures = freeEnclosures });
    }

    /// <summary>
    /// Получить расписания кормления животных
    /// </summary>
    /// <returns></returns>
    [HttpGet("feeding-schedule-statistics")]
    public IActionResult GetFeedingScheduleStatistics()
    {
        var feedingSchedules = _zooStatisticsService.GetFeedingScheduleStatistics();

        var result = feedingSchedules.Select(schedule => new
        {
            AnimalName = schedule.Animal.Name,
            FeedingTime = schedule.FeedingTime.Time,
            FoodType = schedule.FoodType.Type
        });

        return Ok(result);
    }
}