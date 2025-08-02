using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class CreateModel : PageModel
{
    private readonly RequestContext _context;

    public CreateModel(RequestContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Request Request { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Requests.Add(Request);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}