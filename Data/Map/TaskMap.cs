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
            builder.Property(task => task.Name).IsRequired();
            builder.Property(task => task.Description).IsRequired();
            builder.Property(task => task.Status).IsRequired();
            builder.Property(task => task.UserId);
            builder.Property(task => task.CreatedAt).IsRequired();

            builder.HasOne(task => task.User);

            builder.ToTable("tasks");
        }
    }
}