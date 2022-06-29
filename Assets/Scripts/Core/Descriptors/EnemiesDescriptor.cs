using System.Xml.Linq;

public class EnemiesDescriptor
{
    private string _prefabpath;
    private int _damage;
    public void Init(string path)
    {
        Configure config = new Configure();
        XDocument doc = config.ConfigFile(path);
    }
}
