﻿using System;
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
        public int Lvl { get; private set; } // Player' lvl
        public int HP { get; set; } // HP is health * 10 
        public int Energy { get; set; } // Energy is Magicka * 10 
        public Role Role { get; private set; } // Player's role
        public Stack<IItem> Inventory { get; set; }

        // Player constructor, accepts a role
        public Player(Role role)
        {
            Role = role;
            Inventory = new Stack<IItem>();
            Lvl = 1;
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
            Lvl++;

            // Update max health and energy
            UpdateMaxHealh(this);
            UpdateMaxEnergy(this);
        }

        // Player actions

        // Attack
        public void Attack()
        {
        }

        // Pick up
        public void PickupItem(List<IItem> inWorld)
        {
            foreach (IItem i in inWorld)
            {
                if (i.Found)
                {
                    Inventory.Push(i);
                    Render.UpdateItemFeed(this);
                }
            }

            // Remove item from world
            foreach (IItem i in inWorld)
            {
                if (Inventory.Contains(i))
                {
                    inWorld.Remove(i);
                    break;
                }
            }
        }

        // Persuade

        // Pick pocket

        // Decorate weapon
        public void DecorateWeapon(Stack<IItem> inv)
        {
            // Add combination weapon to inv and remove other items
            foreach (IItem i in inv)
            {
               
            }

            Console.WriteLine("Your weapon has been decorated");
        }

        // Methods to assign stat changes
        public void UpdateStatsRole(Role role)
        {
            // Starter weapon
            Weapon weapon;

            // Assign role stats // Add weapon
            if (role == Role.Paladin)
            {
                Strength = 5;
                Health = 6;
                Accuracy = 5;
                Speech = 2;
                Stealth = 1;
                Magicka = 1;

                // Update max health and energy
                UpdateMaxHealh(this);
                UpdateMaxEnergy(this);

                weapon = new HeavySword(this);
                Inventory.Push(weapon);
            }
            else if (role == Role.Assassin)
            {
                Strength = 2;
                Health = 3;
                Accuracy = 6;
                Speech = 2;
                Stealth = 6;
                Magicka = 1;

                // Update max health and energy
                UpdateMaxHealh(this);
                UpdateMaxEnergy(this);

                weapon = new Dagger(this);
                Inventory.Push(weapon);
            }
            else if (role == Role.Swindler)
            {
                Strength = 1;
                Health = 3;
                Accuracy = 5;
                Speech = 6;
                Stealth = 3;
                Magicka = 1;

                // Update max health and energy
                UpdateMaxHealh(this);
                UpdateMaxEnergy(this);

                weapon = new Dagger(this);
                Inventory.Push(weapon);
            }
            else if (role == Role.Wizard)
            {
                Strength = 1;
                Health = 3;
                Accuracy = 5;
                Speech = 3;
                Stealth = 2;
                Magicka = 6;

                // Update max health and energy
                UpdateMaxHealh(this);
                UpdateMaxEnergy(this);

                weapon = new Staff(this);
                Inventory.Push(weapon);
            }
        }

        // Update max HP and Energy
        private Action<Player> UpdateMaxHealh = p => p.HP = p.Health * 10;
        private Action<Player> UpdateMaxEnergy = p => p.Energy = p.Magicka * 10;
    }
}
