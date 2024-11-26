namespace FBB.data.interfaces;

public interface IStatistics
{
     Task<VladDto> GetAgeDistribution();

     Task<VladDto> GetOutcomes();
}