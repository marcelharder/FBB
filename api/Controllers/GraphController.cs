using api.Controllers;
using FBB.data.dtos;
using FBB.data.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace api.Controllers;

[Authorize]
public class GraphController : BaseApiController
{
    private readonly IStatistics _st;

    public GraphController(IStatistics st)
    {
        _st = st;
    }

    [Route("ageGraph")]
    [HttpGet]
    public async Task<IActionResult> GetAge()
    {
        VladDto result = await _st.GetAgeDistribution();
        if (result.Caption != "n/a")
        {
            return Ok(result);
        }
        return BadRequest();
    }
}
