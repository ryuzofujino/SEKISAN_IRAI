using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class EditModel : PageModel
{
    private readonly RequestContext _context;

    public EditModel(RequestContext context)
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
        if (!ModelState.IsValid)
            return Page();

        _context.Attach(Request).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Requests.Any(e => e.Id == Request.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("Index");
    }
}