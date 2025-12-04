using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tutorial.Models;
using tutorial.Services;

namespace tutorial.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TodoService _todoService;

    public HomeController(ILogger<HomeController> logger, TodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }

    public IActionResult Index()
    {
        var todos = _todoService.GetAll();
        return View(todos);
    }

    [HttpPost]
    public IActionResult AddTodo(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            _todoService.Add(new TodoItem { Title = title });
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult ToggleTodo(int id)
    {
        _todoService.ToggleComplete(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult DeleteTodo(int id)
    {
        _todoService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
