using System.ComponentModel.DataAnnotations;

namespace SEKISAN_IRAI.Models;

public class Request
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "タイトル")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "ステータス")]
    public string Status { get; set; } = string.Empty;
}