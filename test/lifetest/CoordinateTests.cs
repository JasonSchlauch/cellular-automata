using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lifelogic;
using System.Collections.Generic;
using System.Linq;

namespace lifetest
{
  [TestClass]
  public class CoordinateTests
  {
    [TestMethod]
    public void StaticSetsShouldReturnKnownResults()
    {
      // Contrived 3x3 grid
      Grid g = new Grid(3, new _3x3factory());
      g.Initialize();

      // Assure all correct coordinates are in collection
      List<ICoordinate> coordinates = g.GetCoordinates();
      Assert.IsTrue(coordinates.Count == 9);
      Assert.IsTrue(coordinates.Count(c => (c.x == 0 && c.y == 0)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 0 && c.y == 1)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 0 && c.y == 2)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 1 && c.y == 0)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 1 && c.y == 1)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 1 && c.y == 2)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 2 && c.y == 0)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 2 && c.y == 1)) == 1);
      Assert.IsTrue(coordinates.Count(c => (c.x == 2 && c.y == 2)) == 1);

      // Verify correct neighbor calculation
      ICoordinate coordinate1 = new PlanerCoordinate(0, 1);
      List<ICoordinate> coordinates2 = coordinate1.GetNeighboringCoordinates();
      Assert.IsTrue(coordinates2.Count == 8);
      Assert.IsTrue(coordinates2.Count(c => (c.x == 1 && c.y == 1)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == 1 && c.y == 0)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == 0 && c.y == 0)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == -1 && c.y == 0)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == -1 && c.y == 1)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == -1 && c.y == 2)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == 0 && c.y == 2)) == 1);
      Assert.IsTrue(coordinates2.Count(c => (c.x == 1 && c.y == 2)) == 1);

      /*
      foreach (PlanerCoordinate coordinate in coordinates)
      {
        IEntity e = g.GetEntityAt(coordinate);
        if (coordinate.x == 1 && coordinate.y == 1)
        {
          Assert.IsTrue(e.Alive);
        }
        else
        {
          Assert.IsFalse(e.Alive);
        }
      }
      */

    }
  }
}
