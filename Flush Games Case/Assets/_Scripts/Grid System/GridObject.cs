using System.Collections.Generic;

public class GridObject
{
    private GridSystem _gridSystem;
    private GridPosition _gridPosition;
    private List<Gem> _gemList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        _gridSystem = gridSystem;
        _gridPosition = gridPosition;
        _gemList = new List<Gem>();
    }
    
    public override string ToString()
    {
        return _gridPosition.ToString() + "\n";
    }

    public void AddGem(Gem gem)
    {
        _gemList.Add(gem);
    }

    public void RemoveGem(Gem gem)
    {
        _gemList.Remove(gem);
    }

    public List<Gem> GetGemList()
    {
        return _gemList;
    }

    public bool HasAnyGem()
    {
        return _gemList.Count > 0;
    }

}
