﻿// <auto-generated />
using CurrencyConverter.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyConverter.Infrastructure.Migrations
{
    [DbContext(typeof(CurrencyConverterContext))]
    partial class CurrencyConverterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("CurrencyConverter.Infrastructure.RateValue", b =>
                {
                    b.Property<int>("RateValueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<decimal>("Value");

                    b.HasKey("RateValueId");

                    b.ToTable("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}