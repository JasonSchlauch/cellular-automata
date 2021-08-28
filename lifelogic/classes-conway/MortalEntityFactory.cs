using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// A factory that creates randomly alive entities.
  /// </summary>
  public class MortalEntityFactory : IEntityFactory
  {
    // Note: this tended to produce clearly non-random sequences
    // if instantiated in Create()
    private Random rando = new Random();

    public Type GetEntityType()
    {
      return typeof(MortalEntity);
    }

    public IEntity Create()
    {
      MortalEntity m = new MortalEntity();
      // Next generates random integer r where 0 <= r < 2
      m.Alive = rando.Next(0, 2) > 0;
      return m;
    }

  }
}
