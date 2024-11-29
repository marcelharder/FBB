namespace FBB.data.interfaces;

public interface IStatistics
{
    Task<VladDto> GetAgeDistribution();
    Task<VladDto> GetGender();
    Task<VladDto> GetOutcomes();
    Task<VladDto> GetTiming();
    Task<VladDto> GetCountry();
}