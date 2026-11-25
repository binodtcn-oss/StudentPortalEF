using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalEntityFramework.Data;
using StudentPortalEntityFramework.Models;

namespace StudentPortalEntityFramework.Controllers;

public class StudentsController : Controller
{
    private readonly AppDbContext _db;

    public StudentsController(AppDbContext db) => _db = db;

    // GET: /Students?search=anita
    public async Task<IActionResult> Index(string? search)
    {
        var query = _db.Students.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(s => s.Name.Contains(search));

        ViewData["Search"] = search;
        return View(await query.OrderBy(s => s.Id).ToListAsync());
    }

    // GET: /Students/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var student = await _db.Students.FindAsync(id);
        return student == null ? NotFound() : View(student);
    }

    public IActionResult Create() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid) return View(student);
        _db.Students.Add(student);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var student = await _db.Students.FindAsync(id);
        return student == null ? NotFound() : View(student);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Student student)
    {
        if (!ModelState.IsValid) return View(student);
        _db.Students.Update(student);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var student = await _db.Students.FindAsync(id);
        return student == null ? NotFound() : View(student);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student != null)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
