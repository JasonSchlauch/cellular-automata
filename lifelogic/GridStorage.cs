using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public class GridStorage : IFieldStorage
  {
    private IEntity[,] storage;

    public GridStorage(uint width, uint length)
    {
      storage = new IEntity[width, length];
    }

    public IEntity Get(ICoordinate coordinate)
    {
      return storage[coordinate.x, coordinate.y];
    }

    public void Store(IEntity entity, ICoordinate coordinate)
    {
      storage[coordinate.x, coordinate.y] = entity;
    }
  }
}
