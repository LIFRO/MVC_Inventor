using Microsoft.AspNetCore.Mvc;
using MVC_Training.Repositories;

namespace MVC_Training.Controllers;

public class ContactsController : Controller
{
public IActionResult Index()
    {
        return View();
    }
}
