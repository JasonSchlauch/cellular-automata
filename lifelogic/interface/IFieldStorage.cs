using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Abstracts back-end storage of a field.  A square field could
  /// be represented by linear storage, or planer storage of different
  /// types representing entites, or whatever.
  /// </summary>
  public interface IFieldStorage
  {
    void Store(IEntity entity, ICoordinate coordinate);
    IEntity Get(ICoordinate coordinate);
    void Clear();
  }
}
