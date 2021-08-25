using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public class Grid : IField
  {
    public uint Length { get; protected set; }
    private IEntity[,] entities;
    private IEntityFactory factory;
    public Grid(uint Length, IEntityFactory factory)
    {
      this.Length = Length;
      this.factory = factory;
      entities = new IEntity[this.Length, this.Length];
    }

    public void Initialize()
    {
      if (factory != null)
      {
        for (int i = 0; i < Length; i++)
        {
          for (int j = 0; j < Length; j++)
          {
            entities[i, j] = factory.Create();
          }
        }
      }

    }

    public void Tick()
    {
      IEntity[,] resultingEntities = new IEntity[this.Length, this.Length];
      for (int i = 0; i < Length; i++)
      {
        for (int j = 0; j < Length; j++)
        {
          Coordinate currentCell = new Coordinate(i, j);
          IEntity e = GetEntityAt(currentCell);
          int counter = 0;
          foreach (var v in Enum.GetValues(typeof(NeighborPosition)))
          {
            ICoordinate neighborCell = (ICoordinate)currentCell.GetNeighboringCoordinate((NeighborPosition)v);
            IEntity e2 = GetEntityAt(neighborCell);
            if (e2 != null && e2.Alive)
            {
              counter++;
            }
          }
          IEntity copy = e.Clone();
          copy.EvaluateLivingNeighborCount(counter);
          resultingEntities[i, j] = copy;
        }
      }
      this.entities = resultingEntities;
    }


    public IEntity GetEntityAt(ICoordinate coordinate)
    {
      if (IsInField(coordinate))
        return entities[coordinate.x, coordinate.y];
      return null;
    }

    public bool IsInField(ICoordinate coordinate)
    {
      return coordinate.x >= 0 && coordinate.y >= 0 && coordinate.x < this.Length && coordinate.y < this.Length;
    }
  }
}
