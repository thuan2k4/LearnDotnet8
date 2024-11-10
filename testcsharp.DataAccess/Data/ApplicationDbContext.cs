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
    }
}
