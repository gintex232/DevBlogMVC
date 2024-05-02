using System.Security.Claims;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;
using DevsTutorialCenterMVC.Utilities;

namespace DevsTutorialCenterMVC.Services;

public class LibraryPageService
{
    private readonly HttpClientService _httpClientService;
    private readonly BlogPostService _blogPostService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LibraryPageService(HttpClientService httpClientService, BlogPostService blogPostService,
        IHttpContextAccessor httpContextAccessor)
    {
        _httpClientService = httpClientService;
        _blogPostService = blogPostService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<BlogPostListItemVM>> ReadArticles()
    {
        const string apiUrl = "api/users/get-read-articles-by-user";
        var res = await _httpClientService.GetAsync<ResponseObject<IEnumerable<BlogPostVM>>>(apiUrl);
        return res.Data.Select(blog => new BlogPostListItemVM
        {
            Id = blog.Id,
            ImageUrl = blog.ImageUrl,
            ReadTime = blog.ReadTime,
            Tag = new TagViewModel
            {
                Id = blog.TagId,
                Name = blog.TagName
            },
            Author = new Author
            {
                Id = blog.AuthorId,
                Name = blog.AuthorName,
                Image = blog.AuthorImage,
                Designation = "UI/UX Design Intern"
            },
            Title = blog.Title,
            Text = blog.Text,
            CreatedOn = blog.CreatedOn.FormatDate(),
        });
    }

    public async Task<IEnumerable<BlogPostListItemVM>> SavedArticles()
    {
        var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
        var apiUrl = $"api/articles/get-bookmarked-articles?userId={userId}";
        var res = await _httpClientService.GetAsync<ResponseObject<IEnumerable<BlogPostVM>>>(apiUrl);
        return res.Data.Select(blog => new BlogPostListItemVM
        {
            Id = blog.Id,
            ImageUrl = blog.ImageUrl,
            ReadTime = blog.ReadTime,
            Tag = new TagViewModel
            {
                Id = blog.TagId,
                Name = blog.TagName
            },
            Author = new Author
            {
                Id = blog.AuthorId,
                Name = blog.AuthorName,
                Image = blog.AuthorImage,
                Designation = "UI/UX Design Intern"
            },
            Title = blog.Title,
            Text = blog.Text,
            CreatedOn = blog.CreatedOn.FormatDate(),
        });
    }
}