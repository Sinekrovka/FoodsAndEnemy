using System.Collections.Generic;
using System.Xml.Linq;

public class LevelDescriptor
{
    private string _pathPrefab;
    private XDocument _doc;
    private int _rows;
    private int _cols;
    private List<List<TileDescriptor>> _indexesTileStructure;
    public void Init(string path)
    {
        Configure config = new Configure();
        _doc = config.ConfigFile(path);
        Parse();
    }

    private void Parse()
    {
        
    }

    public int Rows => _rows;
    public int Cols => _cols;
    public List<List<TileDescriptor>> IndexesTileStructure => _indexesTileStructure;
}
