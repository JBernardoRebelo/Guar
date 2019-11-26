using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class Render
    {
        private StreamReader file;

        public void UpdatePlayer1(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> You are a {p.Role}, your stats have been" +
                $" updated and a {p.Inventory.Peek().Name}" +
                $" has been added to your inventory.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Generic option menu
        public string Option()
        {
            string option;

            Console.WriteLine("What do you do?...");
            Console.Write("-> ");
            option = Console.ReadLine().ToLower();
            return option;
        }

        // Generic Invalid option message
        public void InvalidOption()
        {
            Console.WriteLine("You can't do that!");
        }

        // Outputs to user and returns a role -- could be in another method
        public Role RolePicker()
        {
            Role role;
            string roleString;

            Thread.Sleep(2000);

        // This is not advisable
        Found:
            Console.WriteLine("... You find you still have your trusty weapon" +
                " in your bag... what is your role?...");
            Console.Write("-> ");
            roleString = Console.ReadLine().ToLower();

            switch (roleString)
            {
                case "paladin":
                    role = Role.Paladin;
                    break;
                case "assassin":
                    role = Role.Assassin;
                    break;

                case "swindler":
                    role = Role.Swindler;
                    break;

                case "wizard":
                    role = Role.Wizard;
                    break;

                default:
                    Console.WriteLine("Your role is invalid, try again");
                    goto Found;
            }
            return role;
        }

        // Print Inventory
        public void DisplayInventory(Player p)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n----- INVENTORY -----");
            foreach (IItem i in p.Inventory)
            {
                Console.WriteLine($" -> {i.Name}");
            }
            Console.WriteLine("----- --------- -----\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Accepts Player, prints all stats onscreen
        public void PrintStats(Player p)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("----- YOUR STATS -----");
            Console.WriteLine($"Level: {p.Lvl}");
            Console.WriteLine($"Role: {p.Role}");
            Console.WriteLine();
            Console.WriteLine($"Strength: {p.Strength}");
            Console.WriteLine($"Health: {p.Health}");
            Console.WriteLine($"Accuracy: {p.Accuracy}");
            Console.WriteLine($"Speech: {p.Speech}");
            Console.WriteLine($"Stealth: {p.Stealth}");
            Console.WriteLine($"Magicka: {p.Magicka}");
            Console.WriteLine();
            Console.WriteLine($"Current HP: {p.HP}");
            Console.WriteLine($"Current Energy: {p.Energy}");
            Console.WriteLine("----- ---- ----- -----");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Accepts a filename and outputs wanted text, Act1Description1
        public void Act1Description1(string filename)
        {
            string line;
            file = new StreamReader(filename);

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                Thread.Sleep(1000);
            }
        }

        // Accepts a filename and outputs wanted text line by line, BackStory1
        public void BackStory_1(string filename)
        {
            string line;
            file = new StreamReader(filename);

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                Thread.Sleep(1000);
            }
        }

        public Action<GameState> DisplayGameMode
            = gameMode => Console.WriteLine($"\n~~~~~~ {gameMode} Mode ~~~~~~\n");

        // Accepts a filename and outputs cheat sheet, Cheat sheet
        public Action<string> CmdCheatSheet
            = filename => Console.WriteLine(File.ReadAllText(filename));
    }
}
