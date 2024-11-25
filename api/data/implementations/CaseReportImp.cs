using FBB.data.interfaces;
using FBB.data.models;
using Microsoft.EntityFrameworkCore;

namespace FBB.data.implementations;

public class CaseReportImp : ICaseReport
{
    private readonly ApplicationDbContext _context;
    private List<CaseReport> _cases;

    public CaseReportImp(ApplicationDbContext context)
    {
        _context = context;
        _cases = new List<CaseReport>();
    }

    public async Task<int> AddCaseReport(CaseReport cr)
    {
        cr.Created = DateTime.UtcNow;
        _context.Add(cr);
        if (await _context.SaveChangesAsync() > 0)
        {
            return 1;
        }
        return 0;
    }

    public async Task<int> DeleteCaseReport(CaseReport cr)
    {
        _context.Remove(cr);
        if (await _context.SaveChangesAsync() > 0)
        {
            return 1;
        }
        return 0;
    }

    public async Task<List<models.CaseReport>> GetListOfCaseReports()
    {
        if(await _context.CaseReports.AnyAsync()){
          var help = _context.CaseReports.OrderByDescending(u => u.CaseReportNo).AsQueryable();
          _cases = await help.ToListAsync();
        };
       return _cases;

    }

    public async Task<models.CaseReport> GetSpecificCaseReport(int id)
    {
        if (id != 0)
        {
            var result = await _context.CaseReports.FirstOrDefaultAsync(u => u.CaseReportNo == id);
            if (result != null)
                return result;
            else
                return null;
        }
        return null;
    }

    public async Task<int> UpdateCaseReport(CaseReport cr)
    {
        _context.Update(cr);
        if (await _context.SaveChangesAsync() > 0)
        {
            return 1;
        }
        return 0;
    }
}
