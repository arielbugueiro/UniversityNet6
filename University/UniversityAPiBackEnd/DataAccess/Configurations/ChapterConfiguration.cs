using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityAPiBackEnd.Models.DataModels;

namespace UniversityAPiBackEnd.DataAccess.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapter")
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

            builder.HasOne(t => t.Course)
                .WithOne(t => t.Chapter)
                .HasForeignKey<Chapter>(x => x.CourseId);
        }
    }
}
