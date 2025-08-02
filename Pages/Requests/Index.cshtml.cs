using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Pages.Requests;

public class IndexModel : PageModel
{
    private readonly EstimateRequestContext _context;

    public IndexModel(EstimateRequestContext context)
    {
        _context = context;
    }

    public IList<EstimateRequest> Requests { get; set; } = new List<EstimateRequest>();

    public async Task OnGetAsync()
    {
        Requests = await _context.EstimateRequests.ToListAsync();
    }
}