using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public class MortalEntityFactory : IEntityFactory
  {
    public Type GetEntityType()
    {
      return typeof(MortalEntity);
    }

    public IEntity Create()
    {
      MortalEntity m = new MortalEntity();
      var random = new Random();
      // Next generates random r where 0 >= r > 2
      m.Alive = random.Next(0, 2) > 0;
      return m;
    }

  }
}
