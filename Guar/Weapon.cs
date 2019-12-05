using System;
using System.Collections.Generic;
using System.Text;

namespace Guar
{
    public abstract class Weapon : IItem
    {
        public abstract int Weight { get; }
        public abstract int Value { get; }
        public abstract string Name { get; }
        public abstract int Damage { get; set; }
        public abstract int MagicDamage { get; set; }
        public abstract string inEngineName { get; }
        public bool Found { get; set; }
    }

    public abstract class WeaponDecorator : Weapon
    {
        public abstract bool Decorated { get; set; }
    }

    public class RedGem : WeaponDecorator
    {
        public override int Weight { get; }
        public override int Value { get; }
        public override string Name { get; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override bool Decorated { get; set; }
        public override string inEngineName { get; }

        // Default gem
        public RedGem()
        {
            Weight = 2;
            Value = 30;
            Name = "Red Gem";
            Damage = 0;
            MagicDamage = 10;
            Decorated = false;
            Found = false;
            inEngineName = "redgem";
        }

        /// <summary>
        /// Red gem weapon decorator
        /// </summary>
        /// <param name="weapon"> Accepts a weapon to decorate </param>
        public RedGem(Weapon weapon)
        {
            Weight += weapon.Weight;
            Value += (weapon.Value / 2) + 30;
            Name = "Flamming " + weapon.Name;
            Damage = weapon.Damage;
            MagicDamage += weapon.MagicDamage + 10;
            Decorated = true;
            inEngineName = "flamming" + weapon.inEngineName;
        }
    }

    // Class heavy sword
    public class HeavySword : Weapon
    {
        public override int Weight { get => 30; }
        public override int Value { get => 15; }
        public override string Name { get => "Heavy Sword"; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override string inEngineName { get => "heavysword"; }

        // Stats for weapons depend on level in wich they are aquired
        public HeavySword(Player p)
        {
            Damage = (p.Strength + p.Health) * 2;
            MagicDamage = 0;
            Found = true;
        }
    }

    // Class dagger
    public class Dagger : Weapon
    {
        public override int Weight => 5;
        public override int Value => 15;
        public override string Name { get => "Dagger"; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override string inEngineName { get => "dagger"; }

        // Stats for weapons depend on level in wich they are aquired
        public Dagger(Player p)
        {
            Damage = p.Accuracy + p.Stealth;
            MagicDamage = 0;
            Found = true;
        }
    }

    // Class staff
    public class Staff : Weapon
    {
        public override int Weight => 25;
        public override int Value => 15;
        public override string Name { get => "Staff"; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override string inEngineName { get => "staff"; }

        // Stats for weapons depend on level in wich they are aquired
        public Staff(Player p)
        {
            Damage = 0;
            MagicDamage = p.Energy / 2 - (p.Strength * 2) - p.Health;
            Found = true;
        }
    }

    // Class stick
    public class Stick : Weapon
    {
        public override int Weight => 5;
        public override int Value => 1;
        public override string Name { get => "Broken Stick"; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override string inEngineName { get => "brokenstick"; }

        // Stats for weapons depend on level in wich they are aquired
        public Stick(Player p)
        {
            Damage = (p.Strength + p.Health) * 2;
            MagicDamage = 0;
            Found = true;
        }
    }
}
