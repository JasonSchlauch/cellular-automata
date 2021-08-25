using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public interface IEntityFactory
  {
    IEntity Create();
    Type GetEntityType();
  }
}
