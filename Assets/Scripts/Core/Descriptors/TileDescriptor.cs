using System;
using System.Xml.Linq;
using UnityEngine;

public class TileDescriptor
{
    private bool _type;
    private static string _descriptorPath = "/TileDescriptor.xml";
    private string _pathPrefab;
    private bool _rotation;

    public void Init(string path, string id)
    {
        Configure config = new Configure();
        XElement root = config.ConfigFile(path + _descriptorPath).Element("tiles");
        foreach (var tile in root.Elements())
        {
            if (tile.Attribute("id").Value.Equals(id))
            {
                _type = Boolean.Parse(tile.Attribute("walkable").Value);
                _pathPrefab = tile.Attribute("path").Value;
                _rotation = Boolean.Parse(tile.Attribute("rotation").Value);
                break;
            }
        }
    }

    public string PathPrefab => _pathPrefab;
    public bool Rotation => _rotation;
    public bool Type => _type;
}