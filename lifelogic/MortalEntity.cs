using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifelogic
{
  public class MortalEntity : IEntity
  {

    public bool Alive { get; set; }

    public IEntity Clone()
    {
      MortalEntity r = new MortalEntity();
      r.Alive = this.Alive;
      return r;
    }

    /* Conway game of life rules
     * Any live cell with fewer than two live neighbours dies, as if by underpopulation.
       Any live cell with two or three live neighbours lives on to the next generation.
       Any live cell with more than three live neighbours dies, as if by overpopulation.
       Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
       These rules, which compare the behavior of the automaton to real life, can be condensed into the following:

       Any live cell with two or three live neighbours survives.
       Any dead cell with three live neighbours becomes a live cell.
       All other live cells die in the next generation. Similarly, all other dead cells stay dead.
    */
    public void EvaluateLivingNeighborCount(int value)
    {
      if (this.Alive)
      {
        if (value < 2 ) { this.Alive = false; }
        if (value == 2 || value == 3) { this.Alive = true; }
        if (value > 3) { this.Alive = false; }
      } else 
      {
        if (value == 3)
        {
          this.Alive = true;
        }
      }
    }
  }
}
