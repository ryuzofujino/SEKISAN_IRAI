using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class CreateModel : PageModel
{
    private readonly EstimateRequestContext _context;

    public CreateModel(EstimateRequestContext context)
    {
        _context = context;
    }

    [BindProperty]
    public EstimateRequest RequestItem { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.EstimateRequests.Add(RequestItem);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}