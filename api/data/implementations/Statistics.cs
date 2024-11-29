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

        var list_of_ages_reg = new List<int>();
        var list_of_ages_fused = new List<int>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            if (cp.BatteryType == "regular")
            {
                int age = GetAgeFromDOB(cp.DateOfBirth);
                list_of_ages_reg.Add(age);
            }
            else
            {
                int age = GetAgeFromDOB(cp.DateOfBirth);
                list_of_ages_fused.Add(age);
            }
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

            helpDouble.Add(getAge(0, list_of_ages_reg));
            helpDouble.Add(getAge(1, list_of_ages_reg));
            helpDouble.Add(getAge(2, list_of_ages_reg));
            helpDouble.Add(getAge(3, list_of_ages_reg));
            helpDouble.Add(getAge(4, list_of_ages_reg));
            helpDouble.Add(getAge(5, list_of_ages_reg));
            helpDouble.Add(getAge(6, list_of_ages_reg));
            helpDouble.Add(getAge(7, list_of_ages_reg));
            result.DataYas = helpDouble.ToArray();

            helpDouble.Clear();
            helpDouble.Add(getAge(0, list_of_ages_fused));
            helpDouble.Add(getAge(1, list_of_ages_fused));
            helpDouble.Add(getAge(2, list_of_ages_fused));
            helpDouble.Add(getAge(3, list_of_ages_fused));
            helpDouble.Add(getAge(4, list_of_ages_fused));
            helpDouble.Add(getAge(5, list_of_ages_fused));
            helpDouble.Add(getAge(6, list_of_ages_fused));
            helpDouble.Add(getAge(7, list_of_ages_fused));
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
        var category = new List<int>();
        var helpDouble = new List<double>();
        var helpRegular = new List<int>();
        var helpFused = new List<int>();
        var result = new VladDto();

        var list_of_ages = new List<int>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            int outcome = (int)cp.Outcomes;
            if (cp.BatteryType == "regular")
            {
                helpRegular.Add(outcome);
            }
            else
            {
                helpFused.Add(outcome);
            }
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

            helpDouble.Add(GetOutcomesCategory(0, helpRegular));
            helpDouble.Add(GetOutcomesCategory(1, helpRegular));
            helpDouble.Add(GetOutcomesCategory(2, helpRegular));
            helpDouble.Add(GetOutcomesCategory(3, helpRegular));
            helpDouble.Add(GetOutcomesCategory(4, helpRegular));
            helpDouble.Add(GetOutcomesCategory(5, helpRegular));
            result.DataYas = helpDouble.ToArray();

            helpDouble.Clear();
            helpDouble.Add(GetOutcomesCategory(0, helpFused));
            helpDouble.Add(GetOutcomesCategory(1, helpFused));
            helpDouble.Add(GetOutcomesCategory(2, helpFused));
            helpDouble.Add(GetOutcomesCategory(3, helpFused));
            helpDouble.Add(GetOutcomesCategory(4, helpFused));
            helpDouble.Add(GetOutcomesCategory(5, helpFused));
            result.DataFused = helpDouble.ToArray();
        });
        return result;
    }

    private static double GetOutcomesCategory(int no, List<int> category)
    {
        var help = 0.0;
        switch (no)
        {
            case 0:
                foreach (int a in category)
                {
                    if (a == 0)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 1:
                foreach (int a in category)
                {
                    if (a == 1)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 2:
                foreach (int a in category)
                {
                    if (a == 2)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 3:
                foreach (int a in category)
                {
                    if (a == 3)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 4:
                foreach (int a in category)
                {
                    if (a == 4)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 5:
                foreach (int a in category)
                {
                    if (a == 5)
                    {
                        help++;
                    }
                }
                ;
                break;
        }
        return help;
    }

    public async Task<VladDto> GetGender()
    {
        var help = new List<string>();
        var helpDouble = new List<double>();
        var result = new VladDto();

        var list_of_gender_reg = new List<string>();
        var list_of_gender_fused = new List<string>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            if (cp.BatteryType == "regular")
            {
                string gender = cp.Gender;
                list_of_gender_reg.Add(gender);
            }
            else
            {
                string gender = cp.Gender;
                list_of_gender_fused.Add(gender);
            }
        }

        await Task.Run(() =>
        {
            result.Caption = "Gender";
            help.Add("male");
            help.Add("female");
            result.DataXas = help.ToArray();

            helpDouble.Add(getGender(0, list_of_gender_reg));
            helpDouble.Add(getGender(1, list_of_gender_reg));

            result.DataYas = helpDouble.ToArray();

            helpDouble.Clear();
            helpDouble.Add(getGender(0, list_of_gender_fused));
            helpDouble.Add(getGender(1, list_of_gender_fused));

            result.DataFused = helpDouble.ToArray();
        });
        return result;
    }

    private int getGender(int i, List<string> lijst)
    {
        var help = 0;
        switch (i)
        {
            case 0:
                foreach (string a in lijst)
                {
                    if (a == "male")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 1:
                foreach (string a in lijst)
                {
                    if (a == "female")
                    {
                        help++;
                    }
                }
                ;
                break;
        }
        return help;
    }

    public async Task<VladDto> GetTiming()
    {
        var help = new List<string>();
        var helpDouble = new List<double>();
        var result = new VladDto();

        var list_of_dates_reg = new List<int>();
        var list_of_dates_fused = new List<int>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            if (cp.BatteryType == "regular")
            {
                DateTime d = cp.Created;
                list_of_dates_reg.Add(d.Year);
            }
            else
            {
                DateTime d = cp.Created;
                list_of_dates_fused.Add(d.Year);
            }
        }

        await Task.Run(() =>
        {
            result.Caption = "Reporting date";
            help.Add("2023");
            help.Add("2024");
            help.Add("2025");
            help.Add("2026");
            result.DataXas = help.ToArray();

            helpDouble.Add(getDate(0, list_of_dates_reg));
            helpDouble.Add(getDate(1, list_of_dates_reg));
            helpDouble.Add(getDate(2, list_of_dates_reg));
            helpDouble.Add(getDate(3, list_of_dates_reg));

            result.DataYas = helpDouble.ToArray();

            helpDouble.Clear();
            helpDouble.Add(getDate(0, list_of_dates_fused));
            helpDouble.Add(getDate(1, list_of_dates_fused));
            helpDouble.Add(getDate(2, list_of_dates_fused));
            helpDouble.Add(getDate(3, list_of_dates_fused));

            result.DataFused = helpDouble.ToArray();
        });
        return result;
    }

    private int getDate(int i, List<int> lijst)
    {
        var help = 0;
        switch (i)
        {
            case 0:
                foreach (int a in lijst)
                {
                    if (a == 2023)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 1:
                foreach (int a in lijst)
                {
                    if (a == 2024)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 2:
                foreach (int a in lijst)
                {
                    if (a == 2025)
                    {
                        help++;
                    }
                }
                ;
                break;
            case 3:
                foreach (int a in lijst)
                {
                    if (a == 2026)
                    {
                        help++;
                    }
                }
                ;
                break;
        }
        return help;
    }

    public async Task<VladDto> GetCountry()
    {
        var help = new List<string>();
        var helpDouble = new List<double>();
        var result = new VladDto();

        var list_of_country_reg = new List<string>();
        var list_of_country_fused = new List<string>();

        _cases = _context.CaseReports.FromSqlRaw("SELECT * FROM CaseReports").ToList();

        foreach (CaseReport cp in _cases)
        {
            if (cp.BatteryType == "regular")
            {
                string d = cp.Country;
                list_of_country_reg.Add(d);
            }
            else
            {
                string d = cp.Country;
                list_of_country_fused.Add(d);
            }
        }

        await Task.Run(() =>
        {
            result.Caption = "Reported from:";
            help.Add("NL");
            help.Add("FR");
            help.Add("SA");
            help.Add("UK");
            help.Add("US");
            help.Add("BE");
            help.Add("DE");
            result.DataXas = help.ToArray();

            helpDouble.Add(getC(0, list_of_country_reg));
            helpDouble.Add(getC(1, list_of_country_reg));
            helpDouble.Add(getC(2, list_of_country_reg));
            helpDouble.Add(getC(3, list_of_country_reg));
            helpDouble.Add(getC(4, list_of_country_reg));
            helpDouble.Add(getC(5, list_of_country_reg));
            helpDouble.Add(getC(6, list_of_country_reg));

            result.DataYas = helpDouble.ToArray();

            helpDouble.Clear();
            helpDouble.Add(getC(0, list_of_country_fused));
            helpDouble.Add(getC(1, list_of_country_fused));
            helpDouble.Add(getC(2, list_of_country_fused));
            helpDouble.Add(getC(3, list_of_country_fused));
            helpDouble.Add(getC(4, list_of_country_fused));
            helpDouble.Add(getC(5, list_of_country_fused));
            helpDouble.Add(getC(6, list_of_country_fused));

            result.DataFused = helpDouble.ToArray();
        });
        return result;
    }

    private int getC(int i, List<string> lijst)
    {
        var help = 0;
        switch (i)
        {
            case 0:
                foreach (string a in lijst)
                {
                    if (a == "31")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 1:
                foreach (string a in lijst)
                {
                    if (a == "33")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 2:
                foreach (string a in lijst)
                {
                    if (a == "SA")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 3:
                foreach (string a in lijst)
                {
                    if (a == "UK")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 4:
                foreach (string a in lijst)
                {
                    if (a == "US")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 5:
                foreach (string a in lijst)
                {
                    if (a == "BE")
                    {
                        help++;
                    }
                }
                ;
                break;
            case 6:
                foreach (string a in lijst)
                {
                    if (a == "DE")
                    {
                        help++;
                    }
                }
                ;
                break;
        }
        return help;
    }
}
