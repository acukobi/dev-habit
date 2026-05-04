using System.Xml.Linq;
using DevHabit.Api.DTOs.Habits;
using DevHabit.Api.Entities;
using OpenTelemetry.Trace;

namespace DevHabit.Api.Transformers.Habits;

public class HabitTransformer
{
    public HabitDto MapHabitToHabitDto(Habit habit)
    {
        return new HabitDto
        {

            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            Type = habit.Type,
            Frequency = new FrequencyDto
            {
                Type = habit.Frequency.Type,
                TimesPerPeriod = habit.Frequency.TimesPerPeriod,
            },
            Target = new TargetDto
            {
                Unit = habit.Target.Unit,
                Value = habit.Target.Value,
            },
            Status = habit.Status,
            IsArchived = habit.IsArchived,
            EndDate = habit.EndDate,
            Milestone = habit.Milestone == null ? null : new MilestoneDto
            {
                Current = habit.Milestone.Current,
                Target = habit.Milestone.Target
            },
            CreatedAtUtc = habit.CreatedAtUtc,
            UpdatedAtUtc = habit.UpdatedAtUtc,
            LastCompletedAtUtc = habit.LastCompletedAtUtc
        };
    }
}
