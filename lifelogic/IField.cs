using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  interface IField
  {
    void Initialize();
    IEntity GetEntityAt(ICoordinate coordinate);
    bool IsInField(ICoordinate coordinate);
    void Tick();
  }
}


