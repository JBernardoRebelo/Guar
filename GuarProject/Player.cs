using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class Player
    {
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Accuracy { get; set; }
        public int Speech { get; set; }
        public int Stealth { get; set; }
        public int Magicka { get; set; }

        public Role Role { get; private set; }

        public Player(Role role)
        {
            Role = role;
        }

        // Methods to assign stat changes
        public void UpdateStatsRole(Role role)
        {
            // Assign role stats
            if (role == Role.Paladin)
            {
                Strength = 5;
                Health = 6;
                Accuracy = 5;
                Speech = 2;
                Stealth = 1;
                Magicka = 1;
            }
            else if (role == Role.Assassin)
            {
                Strength = 3;
                Health = 3;
                Accuracy = 5;
                Speech = 2;
                Stealth = 6;
                Magicka = 1;
            }
            else if (role == Role.Swindler)
            {
                Strength = 1;
                Health = 3;
                Accuracy = 5;
                Speech = 6;
                Stealth = 3;
                Magicka = 1;
            }
        }
    }
}
