using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class EditModel : PageModel
{
    private readonly EstimateRequestContext _context;

    public EditModel(EstimateRequestContext context)
    {
        _context = context;
    }

    [BindProperty]
    public EstimateRequest RequestItem { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var request = await _context.EstimateRequests.FindAsync(id);
        if (request == null)
            return NotFound();

        RequestItem = request;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Attach(RequestItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.EstimateRequests.Any(e => e.Id == RequestItem.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("Index");
    }
}