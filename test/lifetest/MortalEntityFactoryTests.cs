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
  public class MortalEntityFactoryTests
  {

    [TestMethod]
    /// Randomness is difficult to evaluate, but this test
    /// case addresses an issue where generator was not
    /// random at all.
    public void CreateRandomTest()
    {
      IEntityFactory factory = new MortalEntityFactory();
      int counter = 0;
      int iterations = 10000;
      for (int i = 0; i < iterations; i++)
      {
        counter += (factory.Create().Alive) ? 0 : 1;
      }

      Assert.IsTrue(counter > 3000 && counter < 7000);
    }
  }
}
