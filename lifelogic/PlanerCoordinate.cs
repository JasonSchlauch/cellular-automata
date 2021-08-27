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
  public class PlanerCoordinate : ICoordinate
  {
    public int x { get; set; }
    public int y { get; set; }
    public PlanerCoordinate(int X, int Y)
    {
      x = X;
      y = Y;
    }

    public List<ICoordinate> GetNeighboringCoordinates()
    {
      List<ICoordinate> neighbors = new List<ICoordinate>();

      { // North
        neighbors.Add(new PlanerCoordinate(x - 1, y));
      }
      { // Northwest
        neighbors.Add(new PlanerCoordinate(x - 1, y - 1));
      }
      // West
      {
        neighbors.Add(new PlanerCoordinate(x - 1, y));
      }
      // Southwest
      {
        neighbors.Add(new PlanerCoordinate(x - 1, y - 1));
      }
      // South
      {
        neighbors.Add(new PlanerCoordinate(x, y - 1));
      }
      // Southeast
      {
        neighbors.Add(new PlanerCoordinate(x + 1, y + 1));
      }
      // East
      {
        neighbors.Add(new PlanerCoordinate(x + 1, y));
      }
      // Northeast
      {
        neighbors.Add(new PlanerCoordinate(x + 1, y + 1));
      }
      return neighbors;
    }
  }
}

