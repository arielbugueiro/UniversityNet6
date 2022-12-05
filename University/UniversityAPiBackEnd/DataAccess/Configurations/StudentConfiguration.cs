using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityAPiBackEnd.Models.DataModels;

namespace UniversityAPiBackEnd.DataAccess.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student")
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

            builder.Property(x => x.FirstName)
                .HasColumnName("fist_name")
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(t => t.DateOfBirth)
             .HasColumnName("Date")
             .HasColumnType("date")
             .HasMaxLength(100)
             .IsRequired();
        }
    }
}
