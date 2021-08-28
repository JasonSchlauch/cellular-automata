using System;

namespace console_ui
{
  class Program
  {
    /// <summary>
    /// Simple console ui that creates a grid then repeatedly
    /// runs a generation and prints the results via a crude
    /// command line rendering.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      uint gridLength = 10;
      lifelogic.Grid g = new lifelogic.Grid(gridLength, new lifelogic.MortalEntityFactory());
      // Create random grid
      g.Initialize();

      for (int generation = 0; generation < 100; generation++)
      {
        Console.WriteLine("Generation {0}", generation);
        // Iterate grid and print results.
        for (int i = 0; i < gridLength; i++)
        {
          for (int j = 0; j < gridLength; j++)
          {

            lifelogic.IEntity e = g.GetEntityAt(new lifelogic.PlanerCoordinate(i, j));
            if (e == null || !e.Alive)
            {
              Console.Write(".");
            }
            else
            {
              Console.Write("*");
            }
          }
          Console.WriteLine();
        }
        Console.WriteLine();
        // Compute next generation
        g.Tick();
      }
      Console.ReadKey();
    }

  }
}
