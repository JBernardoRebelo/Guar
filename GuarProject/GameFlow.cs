using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class GameFlow
    {
        private Render rnd = new Render();
        private GameState GmState;
        private string[] validExplorationOptions;
        private string[] validBattleOptions;
        private readonly string fileBackS1 = "BackStory_1.txt";
        private readonly string cmdCheatSheet = "CommandCheatSheet.txt";

        public void Start()
        {
            // Player
            Player p;
            Role r;
            Stack<IItem> inv = new Stack<IItem>();

            // Player options Explore
            validExplorationOptions = new string[]
            {
                "cheatsheet", "check inventory",
                "check stats", "attack",
                "pick up", "persuade",
                "Pick Pocket"
            };

            // Player options Battle
            validBattleOptions = new string[]
            {
                "sword swing", "stab",
                "persuade", "spell",
                "run", "sneak"
            };

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
            string option;

            rnd.UpdatePlayer1(p);

            // Description 2
            rnd.Act1Description1("Act1_Description1.txt");

            // Exploration mode 1
            do
            {
                // Display
                rnd.DisplayGameMode(gamestate);

                option = rnd.Option();

                while (!validExplorationOptions.Any(x => x.Contains(option)))
                {
                    rnd.InvalidOption();
                    option = rnd.Option();
                }

                ExecuteActionsExp(p, option);

            } while (gamestate == GameState.Explore);
        }

        // Checks game state, calls according gameloops
        private void StateCheck(GameState s)
        {
            if (s == GameState.Explore)
            {
                // Accepts current act progress
            }
            else if (s == GameState.Battle)
            {
                // Battle loop
                // Accepts a player and an entity
            }
        }

        private void ExecuteActionsExp(Player p, string action)
        {
            // Call cheatSheet
            if (action == validExplorationOptions[0])
                rnd.CmdCheatSheet("CommandCheatSheet.txt");

            // Show inventory

            // Check stats
            if (action == validExplorationOptions[2])
                rnd.PrintStats(p);

            // Go to (place)

            // Attack (engage)
            // Change game state

            // Pick up item (item name)

            // Persuade (npc name)

            // PickPocket (npc name)
        }

        private void ExecuteActionsBattle(Player p, string action)
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
