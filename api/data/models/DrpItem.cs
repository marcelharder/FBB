namespace FBB.data.models;

public class DrpItem{

    public  int Value {get; set;}
    public  string Description { get; set; }

    public DrpItem(string val, string des)
    {
        Value = Convert.ToInt32(val);
        Description = des;
    }


}