using ZooManager.Domain.Entities;
using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManager.Domain.Interfaces;

public interface IFeedingScheduleStorage
{
    public Dictionary<FeedingScheduleId, FeedingSchedule> FeedingSchedules { get; set; }
    
    public FeedingSchedule GetFeedingScheduleById(FeedingScheduleId id)
    {
        return FeedingSchedules[id];
    }
}