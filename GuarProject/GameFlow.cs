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
        private string[] validMovementOptions;
        private string[] validBattleOptions;
        private readonly string fileBackS1 = "BackStory_1.txt";
        private readonly string cmdCheatSheet = "CommandCheatSheet.txt";

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
                "stats", "go to", "attack",
                "look around", "pick up", "persuade",
                "persuade", "pick pocket", "quit game"
            };

            // Travel trough areas
            validMovementOptions = new string[]
            {
                "north", "south"
            };

            // Player options Battle
            validBattleOptions = new string[]
            {
                "sword swing", "stab",
                "persuade", "spell",
                "run", "sneak", "quit game"
            };

            // Game state is explore
            GmState = GameState.Explore;

            // Get file for backstory
            //rnd.BackStory_1(fileBackS1);

            // Hello player, pick role
            r = rnd.RolePicker();

            p = new Player(r);
            p.UpdateStatsRole(p.Role);
            area = new AreaSwamp(p);

            // Show last item
            rnd.UpdatePlayer1(p);

            // Call game loop
            Loop(p, GmState, area);
        }

        // Gameloop
        public void Loop(Player p, GameState gameState, AbstractArea area)
        {
            string option;
            area.GameState = gameState;

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

                ExecuteActionsExp(p, option, area.Items);

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

        private void ExecuteActionsExp
            (Player p, string action, ICollection<IItem> inWorld)
        {
            // Call cheatSheet
            if (action == validExplorationOptions[0])
                rnd.CmdCheatSheet("CommandCheatSheet.txt");

            // Show inventory
            if (action == validExplorationOptions[1])
                rnd.InventoryInteractions(p);

            // Check stats
            if (action == validExplorationOptions[2])
                rnd.PrintStats(p);

            // Go to (place)
            if(action == validMovementOptions[0])

            // void TravelTo(place)

            // Attack (engage)
            // Change game state

            // Look around
            if (action == validExplorationOptions[5])
                rnd.LookAround(inWorld);

            // Pick up item
            if (action == validExplorationOptions[6])
                p.PickupItem(inWorld);

            // Persuade (npc name)

            // PickPocket (npc name)

            // Quit game
            if (action == validExplorationOptions[10])
                rnd.QuitGame();
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
