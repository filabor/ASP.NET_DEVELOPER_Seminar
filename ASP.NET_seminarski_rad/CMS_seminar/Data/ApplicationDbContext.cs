using CMS_seminar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using CMS_seminar.ViewModels;

namespace CMS_seminar.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Address { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CMS_seminar.ViewModels.UserViewModel>? UserViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Title = "Kategorija 1"
                },
                new Category
                {
                    Id = 2,
                    Title = "Kategorija 2"
                },
                new Category
                {
                    Id = 3,
                    Title = "Kategorija 3"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Proizvod 1",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 8,
                    Price = 1500.00M,
                    ImageName = "Image_1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Title = "Proizvod 2",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 15,
                    Price = 1698.99M,
                    ImageName = "Image_2.jpg"
                },
                new Product
                {
                    Id = 3,
                    Title = "Proizvod 3",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 20,
                    Price = 2598.59M,
                    ImageName = "Image_3.jpg"
                },
                new Product
                {
                    Id = 4,
                    Title = "Proizvod 4",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 8,
                    Price = 3599.99M,
                    ImageName = "Image_4.jpg"
                },
                new Product
                {
                    Id = 5,
                    Title = "Proizvod 5",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 16,
                    Price = 1400.00M,
                    ImageName = "Image_5.jpg"
                },
                new Product
                {
                    Id = 6,
                    Title = "Proizvod 6",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 6,
                    Price = 1462.82M,
                    ImageName = "Image_6.jpg"
                },
                new Product
                {
                    Id = 7,
                    Title = "Proizvod 7",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 23,
                    Price = 4578.99M,
                    ImageName = "Image_7.jpg"
                },
                new Product
                {
                    Id = 8,
                    Title = "Proizvod 8",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 34,
                    Price = 1680.00M,
                    ImageName = "Image_8.jpg"
                },
                new Product
                {
                    Id = 9,
                    Title = "Proizvod 9",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 28,
                    Price = 4000.00M,
                    ImageName = "Image_9.jpg"
                },
                new Product
                {
                    Id = 10,
                    Title = "Proizvod 10",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                    Quantity = 4,
                    Price = 3495.00M,
                    ImageName = "Image_10.jpg"
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    Id = 1,
                    CategoryId = 1,
                    ProductId = 1
                },
                new ProductCategory
                {
                    Id = 2,
                    CategoryId = 2,
                    ProductId = 1
                },
                new ProductCategory
                {
                    Id = 3,
                    CategoryId = 1,
                    ProductId = 2
                },
                new ProductCategory
                {
                    Id = 4,
                    CategoryId = 3,
                    ProductId = 2
                },
                new ProductCategory
                {
                    Id = 5,
                    CategoryId = 2,
                    ProductId = 3
                },
                new ProductCategory
                {
                    Id = 6,
                    CategoryId = 3,
                    ProductId = 4
                },
                new ProductCategory
                {
                    Id = 7,
                    CategoryId = 1,
                    ProductId = 5
                },
                new ProductCategory
                {
                    Id = 8,
                    CategoryId = 3,
                    ProductId = 5
                },
                new ProductCategory
                {
                    Id = 9,
                    CategoryId = 2,
                    ProductId = 6
                },
                new ProductCategory
                {
                    Id = 10,
                    CategoryId = 1,
                    ProductId = 7
                },
                new ProductCategory
                {
                    Id = 11,
                    CategoryId = 2,
                    ProductId = 8
                },
                new ProductCategory
                {
                    Id = 12,
                    CategoryId = 3,
                    ProductId = 8
                },
                new ProductCategory
                {
                    Id = 13,
                    CategoryId = 1,
                    ProductId = 9
                },
                new ProductCategory
                {
                    Id = 14,
                    CategoryId = 1,
                    ProductId = 10
                },
                new ProductCategory
                {
                    Id = 15,
                    CategoryId = 2,
                    ProductId = 10
                },
                new ProductCategory
                {
                    Id = 16,
                    CategoryId = 3,
                    ProductId = 10
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}