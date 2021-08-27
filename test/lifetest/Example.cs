using Microsoft.VisualStudio.TestTools.UnitTesting;
using lifelogic;

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
  }
}
