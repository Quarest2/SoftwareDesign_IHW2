using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManager.Infrastructure;

public class InMemoryFeedingScheduleStorage : IFeedingScheduleStorage
{
    public InMemoryFeedingScheduleStorage(Dictionary<FeedingScheduleId, FeedingSchedule> feedingSchedules)
    {
        FeedingSchedules = feedingSchedules;
    }

    public Dictionary<FeedingScheduleId, FeedingSchedule> FeedingSchedules { get; set; }
}