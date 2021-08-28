using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Game of Life playfield.  Represents line/plane/cube/other dimensional
  /// shape.
  /// </summary>
  public interface IField
  {
    // Populate field.  IEntityFactory.Create() is used to populate each cell.
    void Initialize();

    // Unpopulate field
    void Deinitialize();
    
    // Returns a list of all coordinates in the field.
    // Does not guarantee any specific order of list.
    List<ICoordinate> GetCoordinates();

    // Retrieves the entity at a particular coordinate.
    // coordinate need not be in bounds, and in such
    // cases GetEntityAt must return null.
    // Note that "wraparound" shapes can be implemented
    // if field chooses to honor out-of-bounds requests
    // by "wrapping around" the borders of the field.
    IEntity GetEntityAt(ICoordinate coordinate);

    // Retrieves the entities for all coordinates in the list.
    // coordinates need not be in bounds, and in such cases
    // no entity is inserted into the resulting list.
    List<IEntity> GetEntitiesAt(List<ICoordinate> coordinates);

    // Inserts an entity at a coordinate.
    // coordinate need not be in bounds, but oob storage will
    // silently fail.
    void StoreEntityAt(IEntity entity, ICoordinate coordinate);

    // Determines if a coordinate is in-bounds of a field.
    bool IsInField(ICoordinate coordinate);
    
    // Run generation.  Probably should be moved.
    void Tick();
  }
}


