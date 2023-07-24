using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.Id).HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Email).IsRequired();
            builder.ToTable("users");
        }

    }
}