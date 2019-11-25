using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class Render
    {
        // Outputs to user and returns a role -- could be in another method
        public Role RolePicker()
        {
            Role role;
            string roleString;

        // This is not advisable
        Found:
            Console.Write("Type your role: ");
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

                default:
                    Console.WriteLine("Your role is invalid, try again");
                    goto Found;
            }
            return role;
        }

        // Accepts Player, prints all stats onscreen
        public void PrintStats(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("----- YOUR STATS -----");
            Console.WriteLine($"Strength: {p.Strength}");
            Console.WriteLine($"Health: {p.Health}");
            Console.WriteLine($"Accuracy: {p.Accuracy}");
            Console.WriteLine($"Speech: {p.Speech}");
            Console.WriteLine($"Stealth: {p.Stealth}");
            Console.WriteLine($"Magicka: {p.Magicka}");
            Console.WriteLine("----- ---- ----- -----");
            Console.WriteLine();
            Console.ForegroundColor = default;
        }

        // Accepts a filename and outputs wanted text, BackStory1
        public Action<string> BackStory_1
            = filename => Console.WriteLine(File.ReadAllText(filename));

        // Accepts a filename and outputs cheat sheet, BackStory1
        public Action<string> CmdCheatSheet
            = filename => Console.WriteLine(File.ReadAllText(filename));
    }
}
