using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class EmployeeConfigs : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id).HasName("Workers");
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Birthdate).HasColumnName("DateOfBirth");
            builder.Ignore(x => x.FullName);

            // Configure Relationships
            builder.HasOne(x => x.Position)
                    .WithMany(x => x.Customers)
                    .HasForeignKey(x => x.PositionNumber)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Orders)
                    .WithOne(x => x.Waiter)
                    .HasForeignKey(x => x.WaiterId).IsRequired(false);

            builder.HasOne(x => x.Resume)
                    .WithOne(x => x.Employee)
                    .HasForeignKey<Resume>(x => x.EmployeeId)
                    .IsRequired();
        }
    }
}
