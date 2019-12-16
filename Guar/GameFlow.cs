using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Guar
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
            rnd.BackStory_1("BackStory_1.txt");

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
            int moves = 0;

            // Show Description of area
            rnd.AreaDescription(area.Description);

            // Display game state
            rnd.DisplayGameMode(area.GameState);

            rnd.DisplayTip();

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

                moves++;
                Console.WriteLine($"Moves: {moves}");

                // Check if battle
                BattleChecker(p, moves, area);

            } while (area.GameState == GameState.Explore && p.HP > 0);
        }

        // Advantage is player advantage, who attacked first
        private void BattleLoop
            (Player p, AbstractEnemy enemy, bool advantage, AbstractArea area)
        {
            rnd.DisplayGameMode(area.GameState);

            if (advantage)
            {
                // Player attack with advantage
            }
            while (enemy.Health > 0)
            {
                Console.WriteLine("You are being attacked");
                enemy.AttackBehaviour.Attack(p, enemy);

                if (p.HP < 0)
                {
                    break;
                }

                rnd.BattleFeed(p, enemy);
                // Player attack menu
            }
        }

        // Check if battle mode is engaged and switches game mode
        private void BattleChecker(Player p, int moves, AbstractArea area)
        {
            // Batle checker
            if (area.Enemies != null)
            {
                // Enemies detect player
                // if detect gamestate = batle
                foreach (AbstractEnemy enemy in area.Enemies)
                {
                    // If an enemy detects player change gamestate
                    if (enemy.Detect(p, moves))
                    {
                        area.GameState = GameState.Battle;
                        // No advantage
                        BattleLoop(p, enemy, false, area);
                    }
                }
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
            if (dir == "south")
            {
                if (area is AreaStableRoad)
                {
                    newArea = new AreaForest(p);

                    Loop(p, newArea);
                }
            }
        }
    }
}
