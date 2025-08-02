using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class DeleteModel : PageModel
{
    private readonly EstimateRequestContext _context;

    public DeleteModel(EstimateRequestContext context)
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
        if (RequestItem.Id == 0)
            return NotFound();

        var request = await _context.EstimateRequests.FindAsync(RequestItem.Id);
        if (request != null)
        {
            _context.EstimateRequests.Remove(request);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
}