using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel; // Use for [DisplayName("")]

namespace testcsharp.Models;

public class Category
{
    [Key]
    public int Id { get; set; } // Primary Key

    [Required]
    [MaxLength(30)]
    [DisplayName("Display Name")]
    public string? Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Length must be beetwen 1 and 100")]
    [Description("This is Display Order")]
    public int DisplayOrder { get; set; }
}
// Dùng [DisplayName("")] sẽ ánh xạ qua view, đi kèm với nhận kiểu theo khai báo
// Tức là sẽ hiện các thuộc tính theo tên để trong ("")