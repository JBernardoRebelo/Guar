using System;
using System.Collections.Generic;
using System.Linq;

namespace Guar
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
        public int CarryWeight { get; private set; } // Inventory max weight
        public Stack<IItem> Inventory { get; set; }
        public AbstractArea Area { get; set; } // Player position

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

            // Update max health, energy and max weight
            UpdateMaxHealh(this);
            UpdateMaxEnergy(this);
            UpdateMaxWeight(this);
        }

        // Player actions

        // Attack
        public void Attack()
        {
        }

        // Pick up
        public void PickupItem(ICollection<IItem> inWorld)
        {
            foreach (IItem i in inWorld)
            {
                if(i is ItemNull)
                {

                }
                else if (i.Found)
                {
                    Inventory.Push(i);
                    Render.UpdateItemFeed(this);
                }
                else
                {
                    Render.NoItemToPickUp(i.Name);
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
        public bool DecorateWeapon(WeaponDecorator wpnDecorator,
            AbstractWeapon weapon)
        {
            AbstractWeapon newWeapon;

            if(weapon is WeaponDecorator)
            {
                //cant decorate
                return false;
            } 
            else if (wpnDecorator is RedGem)
            {
                //// Decorate fire weapon
                //newWeapon = new RedGem(weapon);
                //Inventory.Push(newWeapon);
                //Render.UpdateItemFeed(this);

                Inventory = new Stack<IItem>();
                // Decorate fire weapon
                newWeapon = new RedGem(weapon);
                Inventory.Push(newWeapon);
                Render.UpdateItemFeed(this);

                return true;

                // Add other items to inventory
            }
            else if (wpnDecorator is BlueGem)
            {
                //// Decorate fire weapon
                //newWeapon = new RedGem(weapon);
                //Inventory.Push(newWeapon);
                //Render.UpdateItemFeed(this);

                Inventory = new Stack<IItem>();
                // Decorate fire weapon
                newWeapon = new BlueGem(weapon);
                Inventory.Push(newWeapon);
                Render.UpdateItemFeed(this);

                return true;

                // Add other items to inventory
            }
            // Other decorations


            return false;
        }

        // Methods to assign stat changes
        public void UpdateStatsRole(Role role)
        {
            // Starter weapon
            AbstractWeapon weapon;

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
                UpdateMaxWeight(this);

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
                UpdateMaxWeight(this);

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
                UpdateMaxWeight(this);

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
                UpdateMaxWeight(this);

                weapon = new Staff(this);
                Inventory.Push(weapon);
            }
            else if (role == Role.Hobo)
            {
                Strength = 1;
                Health = 2;
                Accuracy = 2;
                Speech = 1;
                Stealth = 1;
                Magicka = 1;

                // Update max health and energy
                UpdateMaxHealh(this);
                UpdateMaxEnergy(this);
                UpdateMaxWeight(this);

                weapon = new Stick(this);
                Inventory.Push(weapon);
            }
        }

        // Update max HP and Energy
        private Action<Player> UpdateMaxHealh = p => p.HP = p.Health * 10;
        private Action<Player> UpdateMaxEnergy = p => p.Energy
            = p.Magicka * 10;
        private Action<Player> UpdateMaxWeight = p => p.CarryWeight
            = 30 + ((p.Strength * 10) - p.Stealth) / 2;
    }
}
