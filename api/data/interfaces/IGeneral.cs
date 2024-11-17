using FBB.data.models;

namespace FBB.data.interfaces;

public interface IGeneral
{
     
     Task<string> GetCountryNameFromCode(string id);
   


}