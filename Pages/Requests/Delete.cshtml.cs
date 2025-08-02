using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class DeleteModel : PageModel
{
    private readonly RequestContext _context;

    public DeleteModel(RequestContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Request Request { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var request = await _context.Requests.FindAsync(id);
        if (request == null)
            return NotFound();

        Request = request;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Request.Id == 0)
            return NotFound();

        var request = await _context.Requests.FindAsync(Request.Id);
        if (request != null)
        {
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
}