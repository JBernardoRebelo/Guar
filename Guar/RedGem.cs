namespace Guar
{
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
        public RedGem(AbstractWeapon weapon)
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
    public class BlueGem : WeaponDecorator
    {
        public override int Weight { get; }
        public override int Value { get; }
        public override string Name { get; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override bool Decorated { get; set; }
        public override string inEngineName { get; }

        public BlueGem()
        {
            Weight = 4;
            Value = 35;
            Name = "Blue Gem";
            Damage = 0;
            MagicDamage = 10;
            Decorated = false;
            Found = false;
            inEngineName = "bluegem";
        }

        /// <summary>
        /// Red gem weapon decorator
        /// </summary>
        /// <param name="weapon"> Accepts a weapon to decorate </param>
        public BlueGem(AbstractWeapon weapon)
        {
            Weight += weapon.Weight;
            Value += (weapon.Value / 2) + 30;
            Name = "Shock " + weapon.Name;
            Damage = weapon.Damage + 5;
            MagicDamage += weapon.MagicDamage + 8;
            Decorated = true;
            inEngineName = "shock" + weapon.inEngineName;
        }
    }

    public class GreenGem : WeaponDecorator
    {
        public override int Weight { get; }
        public override int Value { get; }
        public override string Name { get; }
        public override int Damage { get; set; }
        public override int MagicDamage { get; set; }
        public override bool Decorated { get; set; }
        public override string inEngineName { get; }

        public GreenGem()
        {
            Weight = 4;
            Value = 30;
            Name = "Green Gem";
            Damage = 5;
            MagicDamage = 5;
            Decorated = false;
            Found = false;
            inEngineName = "greengem";
        }

        /// <summary>
        /// Red gem weapon decorator
        /// </summary>
        /// <param name="weapon"> Accepts a weapon to decorate </param>
        public GreenGem(AbstractWeapon weapon)
        {
            Weight += weapon.Weight;
            Value += (weapon.Value / 2) + 30;
            Name = "Deluged " + weapon.Name;
            Damage += weapon.Damage + 5;
            MagicDamage += weapon.MagicDamage + 5;
            Decorated = true;
            inEngineName = "deluged" + weapon.inEngineName;
        }
    }
}
