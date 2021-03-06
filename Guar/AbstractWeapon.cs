﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guar
{
    public abstract class AbstractWeapon : IItem
    {
        public abstract int Weight { get; }
        public abstract int Value { get; }
        public abstract string Name { get; }
        public abstract int Damage { get; set; }
        public abstract int MagicDamage { get; set; }
        public abstract string inEngineName { get; }
        public bool Found { get; set; }
    }

    public abstract class WeaponDecorator : AbstractWeapon
    {
        public abstract bool Decorated { get; set; }
    }

    // Class heavy sword
    public class HeavySword : AbstractWeapon
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
    public class Dagger : AbstractWeapon
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
    public class Staff : AbstractWeapon
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
    public class Stick : AbstractWeapon
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
