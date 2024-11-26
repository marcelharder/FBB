using FBB.data.dtos;
using FBB.data.interfaces;
using FBB.data.models;
using Microsoft.EntityFrameworkCore;

namespace FBB.data.implementations;

public class Statistics : IStatistics
{
    private readonly ApplicationDbContext _context;
    private List<CaseReport> _cases;

    public Statistics(ApplicationDbContext context)
    {
        _context = context;
        _cases = new List<CaseReport>();
    }

    public async Task<VladDto> GetAgeDistribution()
    {
        var help = new List<string>();
        var helpDouble = new List<double>();
        var result = new VladDto();

        var list_of_ages = new List<int>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            int age = GetAgeFromDOB(cp.DateOfBirth);
            list_of_ages.Add(age);
        }

        await Task.Run(() =>
        {
            result.Caption = "Age distribution (all cases)";
            help.Add("0-18");
            help.Add("18-30");
            help.Add("31-40");
            help.Add("41-50");
            help.Add("51-60");
            help.Add("61-70");
            help.Add("71-80");
            help.Add("81-90");
            result.DataXas = help.ToArray();

            helpDouble.Add(getAge(0, list_of_ages));
            helpDouble.Add(getAge(1, list_of_ages));
            helpDouble.Add(getAge(2, list_of_ages));
            helpDouble.Add(getAge(3, list_of_ages));
            helpDouble.Add(getAge(4, list_of_ages));
            helpDouble.Add(getAge(5, list_of_ages));
            helpDouble.Add(getAge(6, list_of_ages));
            helpDouble.Add(getAge(7, list_of_ages));
            result.DataYas = helpDouble.ToArray();

            helpDouble.Clear();
            helpDouble.Add(1);
            helpDouble.Add(5);
            helpDouble.Add(4);
            helpDouble.Add(7);
            helpDouble.Add(4);
            helpDouble.Add(3);
            helpDouble.Add(8);
            helpDouble.Add(5);
            result.DataFused = helpDouble.ToArray();


        });
        return result;
    }

    private double getAge(int no, List<int> list_of_ages)
    {
        var help = 0.0;
        switch (no)
        {
            case 0:
                foreach (int a in list_of_ages)
                {
                    if (0 < a && a < 17)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 1:
                foreach (int a in list_of_ages)
                {
                    if (18 < a && a < 30)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 2:
                foreach (int a in list_of_ages)
                {
                    if (31 < a && a < 40)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 3:
                foreach (int a in list_of_ages)
                {
                    if (41 < a && a < 50)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 4:
                foreach (int a in list_of_ages)
                {
                    if (51 < a && a < 60)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 5:
                foreach (int a in list_of_ages)
                {
                    if (61 < a && a < 70)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 6:
                foreach (int a in list_of_ages)
                {
                    if (71 < a && a < 80)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 7:
                foreach (int a in list_of_ages)
                {
                    if (81 < a && a < 90)
                    {
                        help++;
                    }
                }
                ;
                break;
        }
        return help;
    }

    private static Int32 GetAgeFromDOB(DateTime dateOfBirth)
    {
        var today = DateTime.Today;

        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (a - b) / 10000;
    }

    public async Task<VladDto> GetOutcomes()
    {
        var help = new List<string>();
        var helpRegular = new List<double>();
        var helpFused = new List<double>();
        var result = new VladDto();

        var list_of_ages = new List<int>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            int? outcome = (int?)cp.Outcomes;
            if (cp.BatteryType == "regular") { helpRegular.Add(Convert.ToDouble(outcome)); }
            else { helpFused.Add(Convert.ToDouble(outcome)); }
        }

        await Task.Run(() =>
        {
            result.Caption = "Outcomes categories";
            help.Add("1");
            help.Add("2");
            help.Add("3");
            help.Add("4");
            help.Add("5");
            result.DataXas = help.ToArray();
            result.DataYas = helpRegular.ToArray();
            result.DataFused = helpFused.ToArray();
        });
        return result;
    }
}
