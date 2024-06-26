﻿using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers;

[Route("editor")]
public class EditorController : Controller
{
    private readonly EditorService _editorService;
    private readonly BlogPostService _blogPostService;

    public EditorController(EditorService editorService, BlogPostService blogPostService)
    {
        _editorService = editorService;
        _blogPostService = blogPostService;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Index(bool successState=false)
    {
        var model = await _editorService.GetPendingArticles();
        if (successState)
        {
            ViewBag.SuccessMessage = "Article published successfully";
        }
        return View(model);
    }
    
    [HttpPost("approve/{articleId}")]
    public async Task<IActionResult> ApproveArticle(string articleId)
    {
        var isSuccessful = await _editorService.ApproveArticle(articleId);
        if (!isSuccessful) return BadRequest();
        return RedirectToAction("Index", new {successState = true});
    }
    
    [HttpPost("reject/{articleId}")]
    public async Task<IActionResult> RejectArticle(string articleId)
    {
        var isSuccessful = await _editorService.RejectArticle(articleId);
        if (!isSuccessful) return BadRequest();
        return RedirectToAction("Index", new {successState = true});
    }
    
    [HttpGet("articles/{articleId}")]
    public async Task<IActionResult> OpenArticle(string articleId)
    {
        var article = await _blogPostService.GetArticleById(articleId);
        return View(article);
    }
}