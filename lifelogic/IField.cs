using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Game of Life playfield.
  /// </summary>
  public interface IField
  {
    // Populate field
    void Initialize();
    // Unpopulate field
    void Deinitialize();
    // Returns a list of all coordinates in the field.
    List<ICoordinate> GetCoordinates();
    // Retrieves the entity at a particular coordinate
    IEntity GetEntityAt(ICoordinate coordinate);
    // Retrieves the entities for all coordinates in the list.
    List<IEntity> GetEntitiesAt(List<ICoordinate> coordinates);
    // Inserts an entity at a coordinate
    void StoreEntityAt(IEntity entity, ICoordinate coordinate);
    // Determines if a coordinate is in-bounds of a field.
    bool IsInField(ICoordinate coordinate);
    // Run generation
    void Tick();
  }
}


