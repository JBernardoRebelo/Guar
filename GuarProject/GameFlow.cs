using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class GameFlow
    {
        private Render rnd = new Render();
        private GameState GmState;
        private readonly string fileBackS1 = "BackStory_1.txt";
        private readonly string cmdCheatSheet = "CommandCheatSheet.txt";

        public void Start()
        {
            Player p;
            Role r;
            Stack<IItem> inv = new Stack<IItem>();

            // Game state is explore
            GmState = GameState.Explore;

            // Get file for backstory
            rnd.BackStory_1(fileBackS1);

            // Hello player, pick role
            r = rnd.RolePicker();

            p = new Player(r);
            p.UpdateStatsRole(p.Role);

            // Call game loop
            GameLoop(p, GmState);
        }

        private void GameLoop(Player p, GameState gamestate)
        {
            // Do stuff
            rnd.PrintStats(p);

            // Rnd.Update
            rnd.UpdatePlayer1(p);

            // Description 2
            rnd.Act1Description1("Act1_Description1.txt");

            // Debug****

            p.UpdateMaxEnergy(p);
            Console.WriteLine(p.Energy);

            p.LevelUp(2, 3, 4, 2, 3, 4);

            rnd.PrintStats(p);
            // *****************
        }

        // Checks game state, calls according gameloops
        private void StateCheck(GameState s)
        {
            if(s == GameState.Explore)
            {
                // Accepts current act progress
            }
            else if (s == GameState.Battle)
            {
                // Battle loop
                // Accepts a player and an entity
            }
        }

        private void ExecuteActions(Player p, string action)
        {
            // Call cheatSheet

            // Show inventory

            // Attack (engage)

            // Pick up item (item name)

            // Persuade (npc name)

            // PickPocket (npc name)
        }

        private void ExecuteActionsBattle (Player p, string action)
        {
            // Sword swing

            // Stab

            // Persuade 

            // Spell 

            // Run

            // Sneak
        }
    }
}
