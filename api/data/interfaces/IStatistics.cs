using FBB.data.dtos;

namespace FBB.data.interfaces;

public interface IStatistics
{
     Task<VladDto> GetAgeDistribution();
}