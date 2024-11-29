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

    [Route("countryGraph")]
    [HttpGet]
    public async Task<IActionResult> GetCountry()
    {
        VladDto result = await _st.GetCountry();
        if (result.Caption != "n/a")
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [Route("genderGraph")]
    [HttpGet]
    public async Task<IActionResult> GetGender()
    {
        VladDto result = await _st.GetGender();
        if (result.Caption != "n/a")
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [Route("timingGraph")]
    [HttpGet]
    public async Task<IActionResult> GetTiming()
    {
        VladDto result = await _st.GetTiming();
        if (result.Caption != "n/a")
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [Route("outcomesGraph")]
    [HttpGet]
    public async Task<IActionResult> GetOutcomes()
    {
        VladDto result = await _st.GetOutcomes();
        if (result.Caption != "n/a")
        {
            return Ok(result);
        }
        return BadRequest();
    }
}
