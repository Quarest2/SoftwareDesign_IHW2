using ZooManager.Domain;
using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;

namespace ZooManager.Application;

public class ZooStatisticsService
{
    private readonly IAnimalStorage _animalStorage;
    private readonly IEnclosureStorage _enclosureStorage;
    private readonly IFeedingScheduleStorage _feedingScheduleStorage;

    public ZooStatisticsService(IAnimalStorage animalStorage, IEnclosureStorage enclosureStorage, IFeedingScheduleStorage feedingScheduleStorage)
    {
        _animalStorage = animalStorage;
        _enclosureStorage = enclosureStorage;
        _feedingScheduleStorage = feedingScheduleStorage;
    }

    public int GetAmountOfAnimals()
    {
        return _animalStorage.Animals.Count;
    }

    public int GetAmountOfEnclosures()
    {
        return _enclosureStorage.Enclosures.Count;
    }
    
    public int GetFreeEnclosureStatistics()
    {
        return _enclosureStorage.Enclosures.Count(e => e.Value.AnimalsCount.Count == 0);
    }

    public IEnumerable<FeedingSchedule> GetFeedingScheduleStatistics()
    {
        return _feedingScheduleStorage.FeedingSchedules.Values;
    }
}