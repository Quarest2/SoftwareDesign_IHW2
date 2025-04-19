using Microsoft.AspNetCore.Mvc;
using ZooManager.Application;
using ZooManager.Domain.Entities;
using ZooManager.Domain.ValueObjects.AnimalValueObjects;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;
using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;
using System.Text.Json.Serialization;
using ZooManager.Domain.Utils;
using ZooManager.Infrastructure;

namespace ZooManager.Presentation.Controllers;

/// <summary>
/// Контроллер для управления животными в зоопарке
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AnimalController : ControllerBase
{
    private readonly AnimalService _animalService;
    private readonly AnimalTransferService _animalTransferService;
    private readonly FeedingOrganizationService _feedingOrganizationService;
    
    public AnimalController(AnimalService animalService,
        AnimalTransferService animalTransferService, 
        FeedingOrganizationService feedingOrganizationService)
    {
        _animalService = animalService;
        _animalTransferService = animalTransferService;
        _feedingOrganizationService = feedingOrganizationService;
    }

    /// <summary>
    /// Добавить новое животное
    /// </summary>
    /// <param name="request">Данные для создания животного</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Животное успешно добавлено</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost("add-animal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddAnimal([FromBody] CreateAnimalRequest request)
    {
        var animal = new Animal(
            new AnimalType(request.Type),
            new AnimalName(request.Name),
            new AnimalBirthday(request.Birthday),
            request.Gender,
            new AnimalFavoriteFood(request.FavoriteFood),
            request.Health
        );

        _animalService.AddAnimal(animal);
        return Ok("Animal added successfully.");
    }

    /// <summary>
    /// Удалить животное
    /// </summary>
    /// <param name="animalId">Идентификатор животного</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Животное успешно удалено</response>
    /// <response code="404">Животное не найдено</response>
    [HttpDelete("remove-animal/{animalId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RemoveAnimal(Guid animalId)
    {
        _animalTransferService.RemoveAnimal(animalId);
        return Ok("Animal removed successfully.");
    }

    /// <summary>
    /// Переместить животное между вольерами
    /// </summary>
    /// <param name="request">Данные для перемещения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Животное успешно перемещено</response>
    /// <response code="400">Некорректные данные</response>
    /// <response code="404">Животное или вольер не найдены</response>
    [HttpPost("transfer-animal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult TransferAnimal([FromBody] TransferAnimalRequest request)
    {
        _animalTransferService.TransferAnimal(
            request.AnimalId,
            request.SourceEnclosureId,
            request.TargetEnclosureId
        );
        return Ok("Animal transferred successfully.");
    }
    
    /// <summary>
    /// Добавить расписание кормления
    /// </summary>
    /// <param name="request">Данные для создания расписания</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Расписание успешно добавлено</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost("add-feeding")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddFeeding([FromBody] CreateFeedingRequest request)
    {

        var schedule = new FeedingSchedule(
            _animalService.GetAnimal(request.AnimalId), 
            new FoodType(request.FoodType), 
            new FeedingTime(request.FeedingTime)
        );

        _feedingOrganizationService.AddFeedingSchedule(schedule);

        return Ok("Feeding schedule added successfully.");
    }
    
    /// <summary>
    /// Получить всех животных
    /// </summary>
    /// <returns>Результат операции</returns>
    /// <response code="200">Успех</response>
    [HttpPost("get-animals")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllAnimals()
    {
        var result = _animalService.GetAllAnimals();

        return Ok(result);
    }
}

public class CreateAnimalRequest
{
    /// <summary>
    /// Тип животного (вид)
    /// </summary>
    /// <example>Лев</example>
    public string Type { get; set; }

    /// <summary>
    /// Имя животного
    /// </summary>
    /// <example>Симба</example>
    public string Name { get; set; }

    /// <summary>
    /// Дата рождения (формат: YYYY-MM-DD)
    /// </summary>
    /// <example>2020-05-15</example>
    [JsonConverter(typeof(DateOnlyJsonConverter))] // Конвертер для DateOnly
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Пол животного (1 - самец, 2 - самка)
    /// </summary>
    /// <example>0</example>
    public AnimalGender Gender { get; set; }

    /// <summary>
    /// Любимая еда
    /// </summary>
    /// <example>Мясо</example>
    public string FavoriteFood { get; set; }

    /// <summary>
    /// Состояние здоровья
    /// </summary>
    /// <example>Healthy</example>
    public AnimalHealth Health { get; set; }
}

public class TransferAnimalRequest
{
    /// <summary>
    /// ID животного
    /// </summary>
    /// <example>1</example>
    public Guid AnimalId { get; set; }

    /// <summary>
    /// ID исходного вольера
    /// </summary>
    /// <example>1</example>
    public Guid SourceEnclosureId { get; set; }

    /// <summary>
    /// ID целевого вольера
    /// </summary>
    /// <example>1</example>
    public Guid TargetEnclosureId { get; set; }
}

public class CreateFeedingRequest
{
    /// <summary>
    /// Животное
    /// </summary>
    /// <example>1</example>
    public Guid AnimalId { get; set; }

    /// <summary>
    /// Тип пищи
    /// </summary>
    /// <example>Мясо</example>
    public string FoodType { get; set; }

    /// <summary>
    /// Время кормления
    /// </summary>
    /// <example>7:20</example>
    public TimeOnly FeedingTime { get; set; }
}