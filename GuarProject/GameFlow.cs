using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class GameFlow
    {
        private Render rnd = new Render();
        private readonly string fileBackS1 = "BackStory_1.txt";
        private readonly string cmdCheatSheet = "CommandCheatSheet.txt";

        public void Start()
        {
            Player p;
            Role r;

            // Get file for backstory
            rnd.BackStory_1(fileBackS1);

            // Hello player, pick role
            r = rnd.RolePicker();

            p = new Player(r);
            p.UpdateStatsRole(p.Role);

            // Call game loop
            GameLoop(p);
        }

        private void GameLoop(Player p)
        {
            // Do stuff
            rnd.PrintStats(p);

            // Debug****

            p.UpdateMaxEnergy(p);
            Console.WriteLine(p.Energy);

            p.LevelUp(2, 3, 4, 2, 3, 4);

            rnd.PrintStats(p);
            // *****************
        }
    }
}
