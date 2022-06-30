using System.Xml.Linq;

public class EnemiesDescriptor
{
    private const string _descriptorPath = "/EnemiesDescriptor.xml";
    private string _prefabPath;
    private int _damage;
    private int _hp;
    private float _speed;
    private string _name;
    public void Init(string path, string id)
    {
        Configure config = new Configure();
        XElement root = config.ConfigFile(path + _descriptorPath).Element("enemies");
        foreach (var enemy in root.Elements())
        {
            if (enemy.Attribute("id").Value.Equals(id))
            {
                _prefabPath = enemy.Attribute("path").Value;
                _damage = int.Parse(enemy.Attribute("damage").Value);
                _hp = int.Parse(enemy.Attribute("hp").Value);
                _speed = float.Parse(enemy.Attribute("speed").Value);
                _name = enemy.Attribute("name").Value;
                return;
            }
        }
    }
    public int Damage => _damage;
    public string PrefabPath => _prefabPath;
    public int Hp => _hp;
    public float Speed => _speed;
    public string Name => _name;
}
