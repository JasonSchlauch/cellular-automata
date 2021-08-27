using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public interface IEntity
  {
    bool Alive { get; set; }
    /// <summary>
    /// Clone may not return null.
    /// </summary>
    /// <returns></returns>
    IEntity Clone();

    

    void EvaluateNeighbors(List<IEntity> neighbors);
  }
}
