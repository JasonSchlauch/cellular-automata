using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Represents an entity, the inhabitant of a cell in the field.
  /// </summary>
  public interface IEntity
  {
    /// <summary>
    /// Is this entity alive or not
    /// </summary>
    bool Alive { get; set; }
    
    /// <summary>
    /// Produces a memberwise duplicate of this entity.
    /// May not return null;
    /// </summary>
    /// <returns>A memberwise clone of this</returns>
    IEntity Clone();

    /// <summary>
    /// Evaluates the effect of neighbors on this entity.
    /// </summary>
    /// <param name="neighbors"></param>
    void EvaluateNeighbors(List<IEntity> neighbors);
  }
}
