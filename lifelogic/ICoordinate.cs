using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Represents a point in space.
  /// </summary>
  public interface ICoordinate
  {
    List<ICoordinate> GetNeighboringCoordinates();
    // TODO: Removed fixed set of coordinates from interface;
    // implement arbitrary number of coordinates.
    int x { get; set; }
    int y { get; set; }
  }
}
