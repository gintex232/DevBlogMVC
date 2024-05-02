using System.ComponentModel.DataAnnotations;

namespace DevsTutorialCenterMVC.Models.Components;

public class AddCommentVM
{
    [Required]
    public string Text { get; set; }
}