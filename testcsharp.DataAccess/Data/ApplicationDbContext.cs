using System;
using Microsoft.EntityFrameworkCore;
using testcsharp.Models;

namespace testcsharp.DataAccess.Data;
// kế thừa entity DbContext
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    // ánh xạ class Category với bảng Categories trong DB
    // Nếu chưa có sẽ tạo table với tên tương ứng
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Chèn data mẫu mỗi khi tạo table mà không cần chèn thủ công 
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Action2", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Action3", DisplayOrder = 3 }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Tittle = "Book Title 1",
                Description = "Description for Book 1",
                ISBN = "123-4567890123",
                Author = "Author 1",
                ListPrice = 20,
                Price = 18,
                Price50 = 15,
                Price100 = 10,
                CategoryId = 1,
                ImageUrl = ""
            },
            new Product
            {
                Id = 2,
                Tittle = "Book Title 2",
                Description = "Description for Book 2",
                ISBN = "123-4567890124",
                Author = "Author 2",
                ListPrice = 25,
                Price = 22,
                Price50 = 20,
                Price100 = 18,
                CategoryId = 2,
                ImageUrl = ""
            },
            new Product
            {
                Id = 3,
                Tittle = "Book Title 3",
                Description = "Description for Book 3",
                ISBN = "123-4567890125",
                Author = "Author 3",
                ListPrice = 30,
                Price = 28,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 3,
                ImageUrl = ""

            }
        );

    }
}
