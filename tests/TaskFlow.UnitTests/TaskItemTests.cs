using TaskFlow.Domain.Entities;

namespace TaskFlow.UnitTests;

public class TaskItemTests
{
    [Fact]
    public void Constructor_TrimsTitle_AndCreatesPendingTask()
    {
        var task = new TaskItem("  Learn Web API  ", "Practice");

        Assert.Equal("Learn Web API", task.Title);
        Assert.False(task.IsCompleted);
        Assert.NotEqual(Guid.Empty, task.Id);
    }

    [Fact]
    public void Update_RejectsBlankTitle()
    {
        var task = new TaskItem("Valid title", null);

        Assert.Throws<ArgumentException>(() => task.Update(" ", null, false));
    }
}
