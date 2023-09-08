using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id=1,
                    Name="Black Pencil",
                    CategoryId=1,
                    Price=1,
                    Stock=20,
                    CreatedDate=DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "Red Pencil",
                    CategoryId = 1,
                    Price = 2,
                    Stock = 25,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Tales",
                    CategoryId = 2,
                    Price = 5,
                    Stock = 25,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    Name = "Poets",
                    CategoryId = 2,
                    Price = 6,
                    Stock = 25,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 5,
                    Name = "Math Pad",
                    CategoryId = 3,
                    Price = 1,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
