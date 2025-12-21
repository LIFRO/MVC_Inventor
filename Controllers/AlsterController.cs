using Microsoft.AspNetCore.Mvc;
using MVC_Training.Models;
using MVC_Training.Repositories;
using System.Linq;

namespace MVC_Training.Controllers;

public class AlsterController : Controller
{
    private readonly IAlsterRepository _repo;

    public AlsterController(IAlsterRepository repo)
    {
        _repo = repo;
    }

public async Task<IActionResult> Index(CancellationToken ct)
    {
        var alster = await _repo.GetAllAsync(ct);
        return View(alster);
        
    }

    [HttpGet("/Alster/Kategori/{categoryId:int}")]
    public async Task<IActionResult> Category(int categoryId, CancellationToken ct)
    {
        var alsters = await _repo.GetByCategoryAsync(categoryId, ct);
        if (!alsters.Any()) return NotFound();
        ViewData["Title"] = $"Kategori {categoryId}";
        return View("Index", alsters);
    }
}
