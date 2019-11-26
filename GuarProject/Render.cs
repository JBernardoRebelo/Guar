using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace GuarProject
{
    public class Render
    {
        private StreamReader file;

        // Output item pick up message
        public static void UpdateItemFeed(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"->{p.Inventory.Peek().Name}" +
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

        // Outputs all items in world
        public void LookAround(List<IItem> inWorld)
        {
            if (inWorld.Count > 0)
            {
                Console.WriteLine($"\nYou look around, and scattered on " +
                     $"the ground you find a... ");
                foreach (IItem i in inWorld)
                {
                    Console.WriteLine($" -> {i.Name}");
                    i.Found = true;
                }
            }
            else
            {
                // Generic description
                Console.WriteLine("You look at the hills and the sky...");
            }
        }

        // Outputs to user and returns a role -- could be in another method
        public Role RolePicker()
        {
            Role role;
            string roleString;

            Thread.Sleep(2000);

        // This is not advisable
        Found:
            Console.WriteLine("\n... You find you still have your trusty weapon" +
                " in your bag... what is your role?...\n");
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

        // Print Inventory -- returns true if are decoratables
        public void DisplayInventory(Player p)
        {
            bool decoratables = false;
            string choice;

            WeaponDecorator wd;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n----- INVENTORY -----");
            foreach (IItem i in p.Inventory)
            {
                Console.Write($" -> {i.Name}");

                if (i is WeaponDecorator)
                {
                    wd = i as WeaponDecorator;

                    if (!wd.Decorated)
                    {
                        Console.WriteLine($" -> This item can be" +
                            $" merged with your weapon...");
                        decoratables = true;
                    }
                }
            }
            Console.WriteLine("\n----- --------- -----\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // If there are decoratables output merge choice
            if (decoratables)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("...Do you wan't to merge?");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("-> ");
                choice = Console.ReadLine();

                // Call merge method
                if (choice == "yes" || choice == "y")
                {
                    MergeWeaponChoice(p);
                }
            }
        }

        public void MergeWeaponChoice(Player p)
        {
            string item1 = default;
            string item2 = default;
            List<string> itemNames = new List<string>();
            Weapon Dec1 = default;
            Weapon Dec2 = default;

        Found1:
            Console.WriteLine($"The Item you want to merge");
            Console.Write($"-> ");
            item1 = Console.ReadLine();

        Found2:
            Console.WriteLine($"The 2nd Item you want to merge");
            Console.Write($"-> ");
            item2 = Console.ReadLine();

            //foreach (IItem i in p.Inventory)
            //{
            //    itemNames.Add(i.Name);
            //}

            //// While the user's choice is not on the list ask
            //if (!itemNames.Contains(item1))
            //{
            //    Console.WriteLine($"The Item you want to merge");
            //    Console.Write($"-> ");
            //    item1 = Console.ReadLine();
            //}

            //// While the user's choice is not on the list ask
            //while (!itemNames.Contains(item2))
            //{
            //    Console.WriteLine($"The 2nd Item you want to merge");
            //    Console.Write($"-> ");
            //    item2 = Console.ReadLine();
            //}

            foreach (IItem i in p.Inventory)
            {
                if (item1 == i.Name && i is Weapon)
                {
                    Dec1 = i as Weapon;
                }
                //else
                //{
                //    Console.WriteLine($"{item1} is not is not a valid item!");
                //    goto Found1;
                //}

                if (item2 == i.Name && i is Weapon)
                {
                    Dec2 = i as Weapon;
                }
                //else
                //{
                //    Console.WriteLine($"{item2} is not is " +
                //        $"not a valid item!");
                //    goto Found2;
                //}
            }

            // Call player merge decorator
            p.DecorateWeapon(Dec1, Dec2);
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

        // First update player
        public void UpdatePlayer1(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> You are a {p.Role}, your stats have been" +
                $" updated and a {p.Inventory.Peek().Name}" +
                $" has been added to your inventory.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Generic Invalid option message
        public void InvalidOption() => Console.WriteLine("You can't do that!");

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

        // Quit game
        public void QuitGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Guar sees you soon!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Environment.Exit(0);
        }

        // Displays game state
        public void DisplayGameMode(GameState g)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n~~~~~~ {g} Mode ~~~~~~\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Accepts a filename and outputs cheat sheet, Cheat sheet
        public Action<string> CmdCheatSheet
            = filename => Console.WriteLine(File.ReadAllText(filename));
    }
}
