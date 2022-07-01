using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class LevelDescriptor
{
    private XDocument _doc;
    private int _rows;
    private int _cols;
    private List<List<TileDescriptor>> _indexesTileStructure;
    private List<EnemiesDescriptor> _enemiesDescriptors;
    private List<FoodDescriptor> _foodDescriptors;
    private int _levelTime;
    private string _globalPath;
    
    public void Init(string path)
    {
        _globalPath = path;
        Configure config = new Configure();
        _doc = config.ConfigFile(path + "/LevelTest.xml");
        InitializationLevelTiles();
        InitilizationEnemiesOnLevel();
        InitilizationFoodOnLevel();
        InitilizationTimeOnLevel();
    }

    private void InitializationLevelTiles()
    {
        string[] tiles = _doc.Root.Element("levelTiles").Attribute("tiles").Value.Split("!");
        _rows = tiles.Length;
        _indexesTileStructure = new List<List<TileDescriptor>>();
        for (int i = 0; i < _rows; ++i)
        {
            List<TileDescriptor> tileList = new List<TileDescriptor>();
            string[] bigRowData = tiles[i].Split(' ');
            List<string> row = bigRowData[bigRowData.Length - 1].Split(',').ToList();
            _cols = row.Count;
            for (int j = 0; j < _cols; ++j)
            {
                TileDescriptor tileDescriptor = new TileDescriptor();
                tileDescriptor.Init(_globalPath, row[j]);
                tileList.Add(tileDescriptor);
            }
            _indexesTileStructure.Add(tileList);
        }
        _cols = tiles[0].Split(",").Length;
    }

    private void InitilizationEnemiesOnLevel()
    {
        _enemiesDescriptors = new List<EnemiesDescriptor>();
        XElement enemy = _doc.Root.Element("levelEnemies");
        foreach (var enem in enemy.Elements())
        {
            EnemiesDescriptor enemiesDescriptor = new EnemiesDescriptor();
            enemiesDescriptor.Init(_globalPath, enem.Attribute("id").Value);
            _enemiesDescriptors.Add(enemiesDescriptor);
        }
    }

    private void InitilizationFoodOnLevel()
    {
        _foodDescriptors = new List<FoodDescriptor>();
        XElement foodElement = _doc.Root.Element("levelFood");
        foreach (var food in foodElement.Elements())
        {
            FoodDescriptor foodDescriptor = new FoodDescriptor();
            foodDescriptor.Init(_globalPath, food.Attribute("id").Value);
            _foodDescriptors.Add(foodDescriptor);
        }
    }

    private void InitilizationTimeOnLevel()
    {
        _levelTime = int.Parse(_doc.Root.Element("levelTime").Attribute("time").Value);
    }

    public int Rows => _rows;
    public int Cols => _cols;
    public List<List<TileDescriptor>> IndexesTileStructure => _indexesTileStructure;

    public List<EnemiesDescriptor> EnemiesDescriptors => _enemiesDescriptors;

    public List<FoodDescriptor> FoodDescriptors => _foodDescriptors;

    public TileDescriptor GetTileDescriptorOnCoordinates(int row, int col)
    {
        if (row < _rows && col < _cols)
        {
            return _indexesTileStructure[row][col];
        }

        return null;
    }

    public int LevelTime => _levelTime;
}
