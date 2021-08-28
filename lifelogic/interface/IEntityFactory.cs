using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Used to populate a field with (ostensibly random) Entities.
  /// Also used to create entirely contrived test data.
  /// </summary>
  public interface IEntityFactory
  {
    IEntity Create();
    Type GetEntityType();
  }
}
