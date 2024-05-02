using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class SearchResultsViewModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<SearchArticlesViewModel> SearchResults { get; set; }
        public IEnumerable<BlogPostVM> PopularBlogPosts { get; set; }
        public IEnumerable<AuthorListItemViewModel> Authors { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}
