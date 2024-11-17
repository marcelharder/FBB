using System.Text.Json;

namespace FBB.data.implementations;

public class General : IGeneral
{
   

    public General()
    {
      
    }

    public async Task<string> GetCountryNameFromCode(string id)
    {
    
    var countryName = "";
    var countryData = await System.IO.File.ReadAllTextAsync("data/config/CountryList.json");
    var countries = JsonSerializer.Deserialize<List<CountryDto>>(countryData);
        if (countries == null){return "Cant find country";}


    
    countryName = countries.FirstOrDefault(a => a.CountryCode == id).CountryName;

    return countryName;
    }
    
}