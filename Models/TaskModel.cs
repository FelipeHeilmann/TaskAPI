using TaskApi.Enums;

namespace TaskApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public StatusTask Status { get; set; }

        public Guid? UserId { get; set; }
        public virtual UserModel? User { get; set; }

    }
}