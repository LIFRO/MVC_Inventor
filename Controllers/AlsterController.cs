using Microsoft.AspNetCore.Mvc;
using MVC_Training.Repositories;

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
}
