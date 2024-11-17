namespace FBB.data.interfaces;

public interface IGeneral
{
     
     Task<string> GetCountryNameFromCode(string id);
     Task<List<DrpItem>> GetListOfCountries();
   


}