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
    IEntity Clone();

    void EvaluateLivingNeighborCount(int value);
  }
}
