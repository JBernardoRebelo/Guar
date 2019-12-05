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
        private string[] validExplorationOptions;
        private string[] validBattleOptions;

        public void Start()
        {
            // Player
            Player p;
            Role r;
            AbstractArea area;

            // Player options Explore an area
            validExplorationOptions = new string[]
            {
                "cheatsheet", "inventory",
                "stats", "cheat sheet", "attack",
                "look around", "pick up", "persuade",
                "pick pocket", "quit game", "north", "south"
            };

            // Player options Battle
            validBattleOptions = new string[]
            {
                "sword swing", "stab",
                "persuade", "spell",
                "run", "sneak", "quit game"
            };

            // Get file for backstory
            //rnd.BackStory_1(fileBackS1);

            // Hello player, pick role
            r = rnd.RolePicker();

            p = new Player(r);
            p.UpdateStatsRole(p.Role);
            area = new AreaStableRoad(p);

            // Show last item
            rnd.UpdatePlayer1(p);

            // Call game loop
            Loop(p, area);
        }

        // Gameloop
        public void Loop(Player p, AbstractArea area)
        {
            string option;

            // Show Description of area
            rnd.AreaDescritption(area.Descritption);

            // Display game state
            rnd.DisplayGameMode(area.GameState);

            // Exploration mode 1
            do
            {
                // Action option
                option = rnd.Option();

                while (!validExplorationOptions.Any(x => x.Contains(option)))
                {
                    rnd.InvalidOption();
                    option = rnd.Option();
                }

                ExecuteActionsExp(p, option, area);

            } while (area.GameState == GameState.Explore);
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

        // Calls methods according to wanted action
        private void ExecuteActionsExp
            (Player p, string action, AbstractArea area)
        {
            switch (action)
            {
                // Display cheat sheet
                case "cheatsheet":
                    rnd.CmdCheatSheet("CommandCheatSheet.txt");
                    break;

                // Display cheat sheet variation
                case "cheat sheet":
                    rnd.CmdCheatSheet("CommandCheatSheet.txt");
                    break;

                // Display inventory
                case "inventory":
                    rnd.InventoryInteractions(p);
                    break;

                // Show stats
                case "stats":
                    rnd.PrintStats(p);
                    break;

                // Head north
                case "north":
                    SwitchArea(p, action, area);
                    break;

                // Head south
                case "south":
                    SwitchArea(p, action, area);
                    break;

                // Display items and npcs in area
                case "look around":
                    rnd.LookAround(area);
                    break;

                // Picks up objects
                case "pick up":
                    p.PickupItem(area.Items);
                    break;

                // Attacks an enemy
                case "attack":
                    if (area.Enemies == null)
                    {
                        rnd.NoEnemiesHere();
                    }
                    break;

                // Leave game
                case "quit game":
                    rnd.QuitGame();
                    break;

                default:
                    rnd.InvalidOption();
                    break;
            }

            // Attack (engage)
            // Change game state

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

        /// <summary>
        /// Accepts a player, a direction and an area to switch to wanted area
        /// </summary>
        /// <param name="p"></param>
        /// <param name="dir"></param>
        /// <param name="area"></param>
        private void SwitchArea(Player p, string dir, AbstractArea area)
        {
            AbstractArea newArea;

            if (dir == "north")
            {
                if (area is AreaStableRoad)
                {
                    newArea = new AreaSwamp(p);

                    Loop(p, newArea);
                }
            }
        }
    }
}
