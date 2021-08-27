using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Used to create (ostensibly random) Entities
  /// </summary>
  public interface IEntityFactory
  {
    IEntity Create();
    Type GetEntityType();
  }
}
