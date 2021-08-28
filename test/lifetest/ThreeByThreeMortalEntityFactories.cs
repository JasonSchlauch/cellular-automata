using lifelogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifetest
{
  /// <summary>
  /// 3x3 Grid mortal entity factories for testing
  /// </summary>
  
  
  /// _3x3factoryTriCorn is designed to produce a 3x3 grid:
  /// 100
  /// 000
  /// 101
  public class _3x3factoryTriCorn : lifelogic.IEntityFactory
  {
    private int invocation = 0;
    // Creates 3x3 grid
    // 100
    // 000
    // 101
    public IEntity Create()
    {
      IEntity e = new MortalEntity();
      switch (invocation)
      {
        case (0):
        case (6):
        case (8):
          {
            e.Alive = true;
            break;
          }
        default:
          e.Alive = false;
          break;

      }
      invocation++;
      return e;
    }
    Type IEntityFactory.GetEntityType()
    {
      return typeof(lifelogic.MortalEntity);
    }
  }
}
