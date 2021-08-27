using System;
using System.Collections.Generic;

namespace lifelogic
{
  public class Grid : IField
  {
    public uint Length { get; protected set; }
    private IEntityFactory factory;
    private GridStorage storage;
    public Grid(uint Length, IEntityFactory factory)
    {
      this.Length = Length;
      this.factory = factory;
    }

    public void Initialize()
    {
      if (factory != null)
      {
        storage = new GridStorage(Length, Length);
        List<ICoordinate> coords = GetCoordinates();
        foreach (ICoordinate coord in coords)
        {
          storage.Store(factory.Create(), coord);
        }
      }

    }

    public List<ICoordinate> GetCoordinates()
    {
      List<ICoordinate> newCoordinates = new List<ICoordinate>();
      for (int i = 0; i < this.Length; i++)
      {
        for (int j = 0; j < this.Length; j++)
        {
          PlanerCoordinate currentCell = new PlanerCoordinate(i, j);
          newCoordinates.Add(currentCell);
        }
      }
      return newCoordinates;
    }

    public void Tick()
    {
      // TODO: This is wasteful WRT object creation and
      // garbage collector pressure.
      // Better to use a double buffer.
      var storage2 = new GridStorage(Length, Length);
      // Iterate over all coordinates in the grid, assign result to "new" grid.
      
      foreach (ICoordinate coor in this.GetCoordinates())
      {
        IEntity entityClone = this.GetEntityAt(coor).Clone();
        if (entityClone == null)
        {
          throw new NullReferenceException("entity clone cannot be null");
        }
        // Retrieve the coordinate's neighbors.
        List<ICoordinate> coorList = coor.GetNeighboringCoordinates();
        // Get the cell inhabitants in those coordinates
        List<IEntity> entityList = this.GetEntitiesAt(coorList);
        // Provide that inhabitant list to entity for evaluation.
        entityClone.EvaluateNeighbors(entityList);
        // Store result
        storage2.Store(entityClone, coor);
      }
      this.storage = storage2;
    }



    public IEntity GetEntityAt(ICoordinate coordinate)
    {
      if (IsInField(coordinate))
      {
        return storage.Get(coordinate);
      }
      else
      {
        return null;
      }
    }

    public List<IEntity> GetEntitiesAt(List<ICoordinate> coordinates)
    {
      List<IEntity> newEntities = new List<IEntity>();
      foreach (ICoordinate coordinate in coordinates)
      {
        {
          IEntity ie = GetEntityAt(coordinate);
          if (ie != null)
          {
            newEntities.Add(ie);
          }
        }
      }
      return newEntities;
    }

    public bool IsInField(ICoordinate coordinate)
    {
      return coordinate.x >= 0 && coordinate.y >= 0 && coordinate.x < this.Length && coordinate.y < this.Length;
    }

    public void Deinitialize()
    {
      storage.Clear();
    }

    public void StoreEntityAt(IEntity entity, ICoordinate coordinate)
    {
      if (IsInField(coordinate))
      {
        storage.Store(entity, coordinate);
      }
    }
  }
}
