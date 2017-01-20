using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ApplicationApi.Models;

namespace ApplicationApi.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationApi.Models.Customer", b =>
                {
                    b.Property<string>("email")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("PostTime");

                    b.Property<string>("comment")
                        .HasMaxLength(500);

                    b.Property<string>("contact")
                        .IsRequired();

                    b.Property<string>("experienceCompany");

                    b.Property<DateTime>("experienceDate");

                    b.Property<bool>("experienceInRole");

                    b.Property<string>("experienceTitle");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("email");

                    b.ToTable("Customers");
                });
        }
    }
}
