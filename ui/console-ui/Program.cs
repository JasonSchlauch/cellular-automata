using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_ui
{
  class Program
  {
    static void Main(string[] args)
    {
      uint gridLength = 10;
      lifelogic.Grid g = new lifelogic.Grid(gridLength, new lifelogic.MortalEntityFactory());
      g.Initialize();

      for (int generation = 0; generation < 100; generation++)
      {
        Console.WriteLine("Generation {0}", generation);
        for (int i = 0; i < gridLength; i++)
        {
          for (int j = 0; j < gridLength; j++)
          {
            lifelogic.IEntity e = g.GetEntityAt(new lifelogic.PlanerCoordinate(i, j));
            if (e == null || !e.Alive)
            {
              Console.Write(" ");
            }
            else
            {
              Console.Write("■");
            }
          }
          Console.WriteLine();
        }
        Console.WriteLine();
        g.Tick();
      }
      Console.ReadKey();
    }
    
  }
}
