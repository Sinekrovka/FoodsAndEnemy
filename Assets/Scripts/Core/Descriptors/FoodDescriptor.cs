using System.Xml.Linq;

public class FoodDescriptor
{
    private const string _descriptorPath = "/FoodDescriptor.xml";
    private string _pathPrefab;
    private int _addedHP;
    private int _livingTime;
    private string _name;
    public void Init(string path, string id)
    {
        Configure config = new Configure();
        XElement root = config.ConfigFile(path + _descriptorPath).Root;
        foreach (var food in root.Elements())
        {
            if (food.Attribute("id").Value.Equals(id))
            {
                _pathPrefab = food.Attribute("path").Value;
                _addedHP = int.Parse(food.Attribute("addedHP").Value);
                _livingTime = int.Parse(food.Attribute("livingTime").Value);
                _name = food.Attribute("name").Value;
                return;
            }
        }
    }

    public string PathPrefab => _pathPrefab;

    public int AddedHp => _addedHP;

    public int LivingTime => _livingTime;

    public string Name => _name;
}
