using System.ComponentModel.DataAnnotations;

namespace mvcapp.Models;

public class Blog
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(100)]
    public string? Description { get; set; }
}