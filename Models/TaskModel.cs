using System.ComponentModel.DataAnnotations;
using TaskApi.Enums;

namespace TaskApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Required(ErrorMessage = "Status can not be empty")]
        [Range(1, 3, ErrorMessage = "The status should be between 1 and 3")]
        public StatusTask Status { get; set; }

        public Guid? UserId { get; set; }
        public virtual UserModel? User { get; set; }

    }
}