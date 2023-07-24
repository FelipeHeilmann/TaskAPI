using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApi.Models;

namespace TaskApi.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Id).HasColumnName("id");
            builder.Property(task => task.Name).IsRequired().HasColumnName("name");
            builder.Property(task => task.Description).IsRequired().HasColumnName("description");
            builder.Property(task => task.Status).IsRequired().HasColumnName("status");
            builder.Property(task => task.UserId).HasColumnName("user_id");
            builder.Property(task => task.CreatedAt).IsRequired().HasColumnName("created_at");

            builder.HasOne(task => task.User);

            builder.ToTable("tasks");
        }
    }
}