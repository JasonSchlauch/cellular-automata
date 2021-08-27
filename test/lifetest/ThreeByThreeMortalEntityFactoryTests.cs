using lifelogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifetest
{
  public class _3x3factory : lifelogic.IEntityFactory
  {
    private int invocation = 0;
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
