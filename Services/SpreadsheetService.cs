using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Data;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Services;

public class SpreadsheetService
{
    private readonly HttpClient _httpClient = new();
    private readonly EstimateRequestContext _context;
    private const string SheetUrl = "https://docs.google.com/spreadsheets/d/1ONC99lrfho8gvG8jFH8lRpeH8WzzeatirtsWIJWly6M/export?format=csv";

    public SpreadsheetService(EstimateRequestContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        if (await _context.EstimateRequests.AnyAsync()) return;

        try
        {
            var csv = await _httpClient.GetStringAsync(SheetUrl);
            var lines = csv.Split('\n');
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var cols = line.Split(',');
                var request = new EstimateRequest
                {
                    ProjectName = cols.ElementAtOrDefault(3) ?? string.Empty,
                    ContractType = cols.ElementAtOrDefault(4),
                    ZacProjectNumber = cols.ElementAtOrDefault(5),
                    SalesPerson = cols.ElementAtOrDefault(6),
                    Estimator = cols.ElementAtOrDefault(7),
                    Status = cols.ElementAtOrDefault(8),
                    Remarks = cols.ElementAtOrDefault(10),
                    DocumentsUrl = cols.ElementAtOrDefault(11),
                    Notes = cols.ElementAtOrDefault(12)
                };

                if (int.TryParse(cols.ElementAtOrDefault(0), out var id))
                    request.Id = id;

                if (DateTime.TryParse(cols.ElementAtOrDefault(1), out var requestDate))
                    request.RequestDate = requestDate;

                if (DateTime.TryParse(cols.ElementAtOrDefault(2), out var desiredDate))
                    request.DesiredEstimateDate = desiredDate;

                if (DateTime.TryParse(cols.ElementAtOrDefault(9), out var completionDate))
                    request.EstimateCompletionDate = completionDate;

                _context.EstimateRequests.Add(request);
            }
            await _context.SaveChangesAsync();
        }
        catch
        {
            // ignore errors (e.g., network issues)
        }
    }
}