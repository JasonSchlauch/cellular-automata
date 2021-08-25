using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Zero-based coordinate scheme.  Coordinates can exist off-grid.
  /// </summary>
  public class Coordinate : ICoordinate
  {
    public int x { get; set; }
    public int y { get; set; }
    public Coordinate(int X, int Y)
    {
      x = X;
      y = Y;
    }

    public ICoordinate GetNeighboringCoordinate(NeighborPosition pos)
    {
      switch (pos)
      {
        case (NeighborPosition.N):
          {
            return new Coordinate(x - 1, y);
          }
        case (NeighborPosition.NW):
          {
            return new Coordinate(x - 1, y - 1);
          }
        case (NeighborPosition.W):
          {
            return new Coordinate(x - 1, y);
          }
        case (NeighborPosition.SW):
          {
            return new Coordinate(x - 1, y - 1);
          }
        case (NeighborPosition.S):
          {
            return new Coordinate(x, y -1);
          }
        case (NeighborPosition.SE):
          {
            return new Coordinate(x + 1, y + 1);
          }
        case (NeighborPosition.E):
          {
            return new Coordinate(x + 1, y);
          }
        case (NeighborPosition.NE):
          {
            return new Coordinate(x + 1, y + 1);
          }
        default:
          throw new ArgumentException("Unexpected value for position");
      }
    }
  }
}
