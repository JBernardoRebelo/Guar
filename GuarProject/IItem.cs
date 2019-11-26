using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    // Interface of items
    public interface IItem
    {
        int Weight { get;}
        int Value { get;}
        string Name { get; }
    }

    // Class heavy sword
    public class HeavySword : IItem
    {
        public int Weight { get => 50; }
        public int Value { get => 15; }
        public string Name { get => "Heavy Sword"; }
    }

    // Class dagger
    public class Dagger : IItem
    {
        public int Weight => 5;
        public int Value => 15;
        public string Name { get => "Dagger"; }

    }

    // Class dagger
    public class Staff : IItem
    {
        public int Weight => 25;
        public int Value => 15;
        public string Name { get => "Staff"; }

    }
}
