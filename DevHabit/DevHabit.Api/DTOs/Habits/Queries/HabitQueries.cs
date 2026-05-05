using DevHabit.Api.Entities;

namespace DevHabit.Api.DTOs.Habits.Queries;

public sealed class HabitQueries
{
    public static System.Linq.Expressions.Expression<Func<Habit, HabitDto>> ToDto()
    {
        return h => new HabitDto
        {
            Id = h.Id,
            Name = h.Name,
            Description = h.Description,
            Type = h.Type,
            Frequency = new FrequencyDto
            {
                Type = h.Frequency.Type,
                TimesPerPeriod = h.Frequency.TimesPerPeriod,
            },
            Target = new TargetDto
            {
                Unit = h.Target.Unit,
                Value = h.Target.Value,
            },
            Status = h.Status,
            IsArchived = h.IsArchived,
            EndDate = h.EndDate,
            Milestone = h.Milestone == null ? null : new MilestoneDto
            {
                Current = h.Milestone.Current,
                Target = h.Milestone.Target
            },
            CreatedAtUtc = h.CreatedAtUtc,
            UpdatedAtUtc = h.UpdatedAtUtc,
            LastCompletedAtUtc = h.LastCompletedAtUtc
        };
    }
}
