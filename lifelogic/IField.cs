using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public interface IField
  {
    void Initialize();

    void Deinitialize();
    List<ICoordinate> GetCoordinates();
    IEntity GetEntityAt(ICoordinate coordinate);
    List<IEntity> GetEntitiesAt(List<ICoordinate> coordinates);
    void StoreEntityAt(IEntity entity, ICoordinate coordinate);
    bool IsInField(ICoordinate coordinate);
    void Tick();
  }
}


