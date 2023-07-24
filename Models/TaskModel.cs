using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Enums;

namespace TaskApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public StatusTask Status { get; set; }

        public string? UserId { get; set; }
        public virtual UserModel? User { get; set; }

    }
}