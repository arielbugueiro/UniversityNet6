using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityAPiBackEnd.Models.DataModels;

namespace UniversityAPiBackEnd.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
              .HasKey(x => x.Id);

            builder.Property(t => t.CreatedBy)
                   .HasColumnName("creation_by")
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .HasColumnName("creation_at")
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(t => t.UpdatedBy)
                   .HasColumnName("update_by")
                   .HasColumnType("varchar");

            builder.Property(t => t.UpdatedAt)
                   .HasColumnName("update_at")
                   .HasColumnType("datetime2");

            builder.Property(t => t.DeletedBy)
                 .HasColumnName("delete_by")
                 .HasColumnType("varchar")
                 .IsRequired();

            builder.Property(t => t.DeletedAt)
                   .HasColumnName("delete_at")
                   .HasColumnType("datetime2");

            builder.Property(t => t.IsDeleted)
                   .HasColumnName("is_deleted")
                   .HasColumnType("boolean");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Password)
             .HasColumnName("password")
             .HasColumnType("varchar")
             .IsRequired();

        }
    }
}
