using Microsoft.AspNetCore.Mvc;
using ZooManager.Application;
using ZooManager.Domain.Entities;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManager.Presentation.Controllers;

/// <summary>
/// Контроллер для работы с вольерами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EnclosureController : ControllerBase
{
    private readonly AnimalTransferService _animalTransferService;

    public EnclosureController(AnimalTransferService animalTransferService)
    {
        _animalTransferService = animalTransferService;
    }

    /// <summary>
    /// Добавить новый вольер
    /// </summary>
    /// <returns></returns>
    [HttpPost("add-enclosure")]
    public IActionResult AddEnclosure([FromBody] CreateEnclosureRequest request)
    {
        var enclosure = new Enclosure(
            request.Type,
            new EnclosureSize(request.Length, request.Width, request.Height),
            new EnclosureCapacity(request.Capacity)
        );

        _animalTransferService.AddEnclosure(enclosure);
        return Ok("Enclosure added successfully.");
    }

    /// <summary>
    /// Удалить вольер
    /// </summary>
    /// <returns></returns>
    [HttpDelete("remove-enclosure/{enclosureId}")]
    public IActionResult RemoveEnclosure(Guid enclosureId)
    {
        _animalTransferService.RemoveEnclosure(enclosureId);
        return Ok("Enclosure removed successfully.");
    }
}

public class CreateEnclosureRequest
{
    public EnclosureType Type { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public int Capacity { get; set; }
}