using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManager.Application;

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleStorage _feedingScheduleStorage;

    public FeedingOrganizationService(IFeedingScheduleStorage feedingScheduleStorage)
    {
        _feedingScheduleStorage = feedingScheduleStorage;
    }

    public FeedingSchedule GetFeedingSchedule(FeedingScheduleId feedingScheduleId)
    {
        return _feedingScheduleStorage.FeedingSchedules[feedingScheduleId];
    }

    public void AddFeedingSchedule(FeedingSchedule feedingSchedule)
    {
        _feedingScheduleStorage.FeedingSchedules.TryAdd(feedingSchedule.Id, feedingSchedule);
    }
}