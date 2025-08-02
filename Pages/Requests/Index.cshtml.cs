using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class IndexModel : PageModel
{
    private readonly RequestContext _context;

    public IndexModel(RequestContext context)
    {
        _context = context;
    }

    public IList<Request> Requests { get; set; } = new List<Request>();

    public async Task OnGetAsync()
    {
        Requests = await _context.Requests.ToListAsync();
    }
}

