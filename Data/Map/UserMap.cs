using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(user => user.Name).IsRequired().HasColumnName("name");
            builder.Property(user => user.Email).IsRequired().HasColumnName("email");
            builder.ToTable("users");
        }

    }
}