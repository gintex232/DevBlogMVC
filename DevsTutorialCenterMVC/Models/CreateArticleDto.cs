using System.ComponentModel.DataAnnotations;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class CreateArticleDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
        public IEnumerable<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
        [Required]
        public string TagId { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public string? PublicId { get; set; } = string.Empty;
    }
}
