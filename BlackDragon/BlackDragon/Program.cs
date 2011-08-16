using System;

namespace BlackDragon
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BlackDragon game = new BlackDragon())
            {
                game.Run();
            }
        }
    }
#endif
}

