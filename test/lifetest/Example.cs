using Microsoft.VisualStudio.TestTools.UnitTesting;
using lifelogic;
using System.Collections.Generic;
using System.Linq;


namespace lifetest
{


  

  [TestClass]
  public class Example
  {
    [TestMethod]
    public void CreateAndIterateGrid()

    {
      Grid g = new Grid(3, new MortalEntityFactory());
      g.Initialize();
      for (int i = 0; i < 100; i++)
      {
        g.Tick();
      }
    }

    public void Coordinates()
    {
      uint gridLength = 20;
      lifelogic.Grid g = new lifelogic.Grid(gridLength, new lifelogic.MortalEntityFactory());
      List<lifelogic.ICoordinate> coords = g.GetCoordinates();
      coords.OrderBy(a => a.x).ThenBy(a => a.y);
    }
  }
}
