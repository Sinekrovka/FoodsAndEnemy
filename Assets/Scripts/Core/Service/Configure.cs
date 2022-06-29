using System.IO;
using System.Xml.Linq;

public class Configure
{
    public XDocument ConfigFile(string path)
    {
        XDocument doc = XDocument.Parse(File.ReadAllText(path));
        return doc;
    }
}