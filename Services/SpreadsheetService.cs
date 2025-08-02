using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Services;

public class SpreadsheetService
{
    private readonly HttpClient _httpClient = new();
    private readonly RequestContext _context;
    private const string SheetUrl = "https://docs.google.com/spreadsheets/d/1ONC99lrfho8gvG8jFH8lRpeH8WzzeatirtsWIJWly6M/export?format=csv";

    public SpreadsheetService(RequestContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (_context.Requests.Any()) return;

        try
        {
            var csv = await _httpClient.GetStringAsync(SheetUrl);
            var lines = csv.Split('\n');
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var cols = line.Split(',');
                var request = new Request
                {
                    Title = cols.ElementAtOrDefault(0) ?? string.Empty,
                    Status = cols.ElementAtOrDefault(1) ?? string.Empty
                };
                _context.Requests.Add(request);
            }
            await _context.SaveChangesAsync();
        }
        catch
        {
            // ignore errors (e.g., network issues)
        }
    }
}