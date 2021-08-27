using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public interface ICoordinate
  {
    List<ICoordinate> GetNeighboringCoordinates();
    int x { get; set; }
    int y { get; set; }
  }
}
