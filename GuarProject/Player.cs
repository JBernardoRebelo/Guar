using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class Player
    {
        public int Strength { get; private set; }
        public int Health { get; private set; }
        public int Accuracy { get; private set; }
        public int Speech { get; private set; }
        public int Stealth { get; private set; }
        public int Magicka { get; private set; }

        // HP is health * 10
        public int HP { get; set; }

        // Energy is Magicka * 10
        public int Energy { get; set;}

        // Player's role
        public Role Role { get; private set; }

        public Player(Role role)
        {
            Role = role;
        }

        // Level up, update stats
        public void LevelUp(int strength, int health,
                            int accuracy, int speech,
                            int stealth, int magicka)
        {
            Strength += strength;
            Health += health;
            Accuracy += accuracy;
            Speech += speech;
            Stealth += stealth;
            Magicka += magicka;
        }

        // Player actions

        // Update max HP and Energy
        public Action<Player> UpdateMaxHealh = p => p.HP = p.Health * 10;
        public Func<Player, int> UpdateMaxEnergy = p => p.Energy = p.Magicka * 10;

        // Methods to assign stat changes
        public void UpdateStatsRole(Role role)
        {
            // Assign role stats // Add weapon
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
                Strength = 2;
                Health = 3;
                Accuracy = 6;
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
            else if (role == Role.Wizard)
            {
                Strength = 1;
                Health = 3;
                Accuracy = 5;
                Speech = 3;
                Stealth = 2;
                Magicka = 6;
            }
        }
    }
}
