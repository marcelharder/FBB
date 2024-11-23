namespace api.Controllers;

[Authorize]
public class CaseReportController : BaseApiController
{
    private readonly ICaseReport _caseRep;
    public CaseReportController(ICaseReport caseRep)
    {
        _caseRep=caseRep;
    }

    [Route("getListOfCaseReports")]
    public async Task<IActionResult> GetListOfCaseReports(){
        var p = await _caseRep.GetListOfCaseReports();
        return Ok(p);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        var p = await _caseRep.GetSpecificCaseReport(id);
        return Ok(p);

    }
    [HttpPut]
    public async Task<IActionResult> Put(CaseReport cr){
        var p = await _caseRep.AddCaseReport(cr);
        return Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CaseReport car){
        var p = car;
        var x = await _caseRep.UpdateCaseReport(p);
        return Ok(x);
    }
     [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var p = await _caseRep.GetSpecificCaseReport(id);
        var x = await _caseRep.DeleteCaseReport(p);
        return Ok(x);
    }

}