using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lifelogic;


namespace lifetest
{
  [TestClass]
  public class MortalEntityTest
  {
    [TestMethod]
    public void NeighborEvaluationTests()
    {
      MortalEntity me = new MortalEntity();
      // Start with living entity
      me.Alive = true;

      List<IEntity> neighbors = new List<IEntity>();
      // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
      Assert.IsTrue(neighbors.Count == 0);
      me.EvaluateNeighbors(neighbors);
      Assert.IsFalse(me.Alive, "Any live cell with fewer than two live neighbours dies, as if by underpopulation.");

      neighbors.Add(new MortalEntity() { Alive = true });
      Assert.IsTrue(neighbors.Count == 1);
      me.Alive = true;
      me.EvaluateNeighbors(neighbors);
      Assert.IsFalse(me.Alive, "Any live cell with fewer than two live neighbours dies, as if by underpopulation.");

      // Any live cell with two or three live neighbours lives on to the next generation.
      me.Alive = true;
      neighbors.Add(new MortalEntity() { Alive = true });
      Assert.IsTrue(neighbors.Count == 2);
      me.EvaluateNeighbors(neighbors);
      Assert.IsTrue(me.Alive, "Any live cell with two or three live neighbours lives on to the next generation.");

      me.Alive = true;
      neighbors.Add(new MortalEntity() { Alive = true });
      Assert.IsTrue(neighbors.Count == 3);
      me.EvaluateNeighbors(neighbors);
      Assert.IsTrue(me.Alive, "Any live cell with two or three live neighbours lives on to the next generation.");

      // Any live cell with more than three live neighbours dies, as if by overpopulation.
      neighbors.Add(new MortalEntity() { Alive = true });
      Assert.IsTrue(neighbors.Count == 4);
      me.EvaluateNeighbors(neighbors);
      Assert.IsFalse(me.Alive, "Any live cell with more than three live neighbours dies, as if by overpopulation.");


      // Check results with more entity items in list
      neighbors = new List<IEntity>()
        { new MortalEntity() { Alive = true },
          new MortalEntity() { Alive = true },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = false } };
      me.Alive = true;
      me.EvaluateNeighbors(neighbors);
      Assert.IsTrue(me.Alive, "Any live cell with two or three live neighbours lives on to the next generation.");

      // Revival scenario
      neighbors = new List<IEntity>()
        { new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = true },
          new MortalEntity() { Alive = false },
          new MortalEntity() { Alive = true },
          new MortalEntity() { Alive = true } };
      me.Alive = false;
      me.EvaluateNeighbors(neighbors);
      Assert.IsTrue(me.Alive, "Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.");
    }


  }
}
