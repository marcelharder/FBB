using FBB.data.models;

namespace FBB.data.interfaces;

public interface ICaseReport
{
     Task<List<CaseReport>> GetListOfCaseReports();
     Task<CaseReport> GetSpecificCaseReport(int id);
     Task<int> UpdateCaseReport(CaseReport cr);
     Task<int> AddCaseReport(CaseReport cr);
     Task<int> DeleteCaseReport(CaseReport cr);


}