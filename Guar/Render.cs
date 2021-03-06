﻿using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Guar
{
    public class Render
    {
        private Random _random = new Random();

        private StreamReader file;

        /// <summary>
        /// Display's a random tip
        /// </summary>
        public void DisplayTip()
        {
            // Index of tip to be used
            int tipO;

            string cheatTip = "If you are felling lost" +
                " type 'cheat sheet' to access a list of" +
                " usefull info on the game!";

            string detect = "Your Sneak points manage how" +
                " many moves you can make before an enemy notices you!";

            string warning = "Unfortunately you can't fight creatures in" +
                " this version! So don't be sad if you die D:";

            string gems = "Gems are used to power your weapon! If you" +
                " catch one you can use it right away by accessing the" +
                " inventory and pressing 'merge'";

            string classe = "Don't be sad about the class you chose," +
                " you can always restart the game!";

            string gameNotGood = "If you don't like reading, then this" +
                " game is not for you!";

            string lookAround = "As you enter an area you should always" +
                " 'look around'! By doing so, you get a list of items," +
                " enemies and npc's in it!";

            // Array of tips
            string[] tips = new string[] { cheatTip, detect,
                warning, gems, classe, cheatTip, lookAround, cheatTip};

            // Display a tip
            tipO = _random.Next(0, tips.Length);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*protip: {tips[tipO]}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Output item pick up message
        public static void UpdateItemFeed(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n** {p.Inventory.Peek().Name}" +
                $" has been added to your inventory.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void BattleFeed(Player p, AbstractEnemy e)
        {
            Console.WriteLine($"Your HP: {p.HP}");
        }

        // Generic option menu
        public string Option()
        {
            string option;

            //Console.WriteLine("What do you do?...");
            Console.Write("-> ");
            option = Console.ReadLine().ToLower();
            return option;
        }

        // Outputs all items in world
        public void LookAround(AbstractArea area)
        {
            if (area.Enemies != null || area.Items != null || area.Npcs != null)
            {
                if (area.Enemies != null && area.Enemies.Count > 0)
                {
                    Console.WriteLine($"Enemies...");
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (AbstractEnemy e in area.Enemies)
                    {

                        Console.WriteLine($" -* {e.Race.ToString()}");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (area.Items != null && area.Items.Count > 0)
                {
                    Console.WriteLine($"Items on ground...");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (IItem i in area.Items)
                    {
                        if (i is ItemNull)
                        {
                            Console.WriteLine("..only rocks, sticks and dirt");
                        }
                        else
                        {
                            Console.WriteLine($" -* {i.Name}");
                            i.Found = true;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    // Generic description
                    AreaDescription(area.Description);
                }

                if (area.Npcs != null && area.Npcs.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (AbstractEnemy e in area.Enemies)
                    {
                        Console.WriteLine($" -- {e.Race.ToString()}");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                // Generic description
                AreaDescription(area.Description);
            }
        }

        // Outputs to user and returns a role -- could be in another method
        public Role RolePicker()
        {
            string roleString;

            // Paladin roles
            string[] paladinRoles =
                new string[] { "paladin", "fighter", "tank", "knight" };

            // Assissin roles
            string[] assassinRoles =
                new string[] { "assassin", "rogue", "butcher" };

            // Wizard roles
            string[] wizardRoles =
                new string[] { "wizard", "mage" };

            // Swindler
            string[] swindlerRoles =
                 new string[] { "swindler", "thief" };

            Thread.Sleep(2000);

            Console.WriteLine("\n... You find you still have your trusty weapon" +
                " in your bag... what is your role?...\n");
            Console.Write("-> ");


            roleString = Console.ReadLine().ToLower();

            if (paladinRoles.Contains(roleString))
            {
                return Role.Paladin;
            }
            else if (assassinRoles.Contains(roleString))
            {
                return Role.Assassin;
            }
            else if (swindlerRoles.Contains(roleString))
            {
                return Role.Swindler;
            }
            else if (wizardRoles.Contains(roleString))
            {
                return Role.Wizard;
            }
            else
            {
                return Role.Hobo;
            }
        }

        // Print Inventory -- returns true if are decoratables
        public void InventoryInteractions(Player p)
        {
            string choice;
            string invAction;
            string action;
            string itemName;
            string[] split;
            string[] split2;

            // Display inventory items
            ShowInventoryItems(p);
            invAction = Console.ReadLine().ToLower();

            // Close inventory
            if (invAction == "close")
            {
                Console.WriteLine("You closed the inventory");
            }
            else
            {
                try
                {
                    split = invAction.Split(' ');

                    // Assign action in inventory and item name
                    action = split[0];
                    itemName = split[1];
                    for (int i = 2; i < split.Length; i++)
                    {
                        itemName += split[i];
                    }
                    if (action == "merge")
                    {
                        foreach (IItem i in p.Inventory)
                        {
                            if (itemName == i.inEngineName
                                && i is WeaponDecorator)
                            {
                                WeaponDecorator wd = i as WeaponDecorator;

                                // Select the weapon decorator
                                Console.WriteLine("Whats the weapon you" +
                                    " want to enpower?");
                                Console.Write("-> ");
                                choice = Console.ReadLine();

                                split2 = choice.Split(' ');
                                choice = split2[0];

                                // Append code
                                for (int k = 1; k < split2.Length; k++)
                                {
                                    choice += split2[k];
                                }

                                // Decorate if valid
                                foreach (IItem j in p.Inventory)
                                {
                                    if (choice == j.inEngineName
                                        && j is AbstractWeapon)
                                    {
                                        AbstractWeapon w = j as AbstractWeapon;

                                        // Call decoration method
                                        if (p.DecorateWeapon(wd, w))
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"That's not something" +
                                    $" you can merge!");
                            }
                        }
                    }
                    else if (action == "stats")
                    {
                        foreach (IItem i in p.Inventory)
                        {
                            if (itemName == i.inEngineName)
                            {
                                ShowItemStats(i);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid option");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The Inventory does not " +
                        "recognize those words\n");
                    Console.WriteLine(e);
                }
            }
        }

        // Accepts an IItem prints stats onscreen
        private void ShowItemStats(IItem i)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n{i.Name} Stats:");
            Console.WriteLine($"    Value: {i.Value}");
            Console.WriteLine($"    Weight: {i.Weight}\n");

            if (i is AbstractWeapon)
            {
                AbstractWeapon w = i as AbstractWeapon;
                Console.WriteLine($"    Damage: {w.Damage}");
                Console.WriteLine($"    Magic Damage: {w.MagicDamage}\n");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Show inventory
        private void ShowInventoryItems(Player p)
        {
            int weight = 0;
            int maxweight = p.CarryWeight;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n----- INVENTORY -----");
            foreach (IItem i in p.Inventory)
            {
                Console.WriteLine($" -> {i.Name}");

                weight += i.Weight;
            }
            Console.WriteLine($"\nCarrying: {weight} of {maxweight}");
            Console.WriteLine("\n----- --------- -----\n");
            Console.Write("-> ");
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
            Console.WriteLine($"Area: {p.Area.Name}");
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

        /// <summary>
        /// First update, role and stats
        /// </summary>
        /// <param name="p"> Accepts a player </param>
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
        public void AreaDescription(string filename)
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

        // No npcs around
        public void NoNpcsHere()
        {
            Console.WriteLine("There is no one around...");
        }

        // No enemies
        public void NoEnemiesHere()
        {
            Console.WriteLine("There is nothing to attack");
        }

        // Displays game state
        public void DisplayGameMode(GameState g)
        {
            if (g == GameState.Explore)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n~~~~~~ {g} Mode ~~~~~~\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (g == GameState.Battle)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n~~~~~~ {g} Mode ~~~~~~\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        // Display no items to pick up message
        public static void NoItemToPickUp()
            => Console.WriteLine("Nothing to pick up");

        // Accepts a filename and outputs cheat sheet, Cheat sheet
        public Action<string> CmdCheatSheet
            = filename => Console.WriteLine(File.ReadAllText(filename));
    }
}
