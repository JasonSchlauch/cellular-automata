using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  /// <summary>
  /// Implements an entity or cell in Conway's game of life.
  /// </summary>
  public class MortalEntity : IEntity
  {

    public bool Alive { get; set; }

    public IEntity Clone()
    {
      MortalEntity r = new MortalEntity();
      r.Alive = this.Alive;
      return r;
    }

    /// <summary>
    /// EvaluateNeighbors() gives an entity an opportunity to examine its neighbors and
    /// respond accordingly.  This one implements John Conway's game of life.
    /// 
    /// Conway game of life rules
    /// Any live cell with fewer than two live neighbours dies, as if by underpopulation.
    /// Any live cell with two or three live neighbours lives on to the next generation.
    /// Any live cell with more than three live neighbours dies, as if by overpopulation.
    /// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    /// All other live cells die in the next generation.   Similarly, all other dead cells stay dead.

    /* Truth table pre and post evaluation
     *  Alive N               new Alive
          1   0,1             ->  0  # Lonely
          1   4,5,6,7,8       ->  0  # Overcrowded
          1   2,3             ->  1  # Lives
          0   3               ->  1  # It takes three to give birth! (note js - ???)
          0   0,1,2,4,5,6,7,8 ->  0  # Barren
    */
    /// </summary>
    /// <param name="neighbors">A list of IEntities that border this cell</param>
    public void EvaluateNeighbors(List<IEntity> neighbors)
    {
      // Null collection equals empty collection
      var liveNeighborCount = (neighbors == null ? 0 : neighbors.Count(b => b.Alive == true));
      if (this.Alive)
      {
        if (liveNeighborCount < 2) { this.Alive = false; }
        // Shown for clarity, this case will be optimized out
        if (liveNeighborCount == 2 || liveNeighborCount == 3) { this.Alive = true; }
        if (liveNeighborCount > 3) { this.Alive = false; }
      }
      else
      { // Current cell is dead
        if (liveNeighborCount == 3)
        {
          this.Alive = true;
        }
      }
    }
  }
}
