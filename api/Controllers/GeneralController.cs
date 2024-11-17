using System.Text.Json;

namespace api.Controllers;

public class GeneralController : BaseApiController
{

  private readonly IGeneral _gen;
    public GeneralController(IGeneral gen )
    { 
        _gen = gen;
    }

    [HttpGet("getCountryNameFromCode/{id}")]
    public async Task<ActionResult> GetCountryNameFromIsoCode(string id){
        var result = await _gen.GetCountryNameFromCode(id);
    return Ok(result);        
    }

    [HttpGet("getCountries")]
    public async Task<ActionResult> GetCountryNameFromIsoCode(){
        var result = await _gen.GetListOfCountries();
    return Ok(result);        
    }

    

}