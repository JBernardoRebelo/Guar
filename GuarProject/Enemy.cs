using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public abstract class AbstractEnemy : IEntity, IAttackBehaviour
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Perception { get; set; }
        public abstract int ID { get; set; }
        public abstract int Intelligence { get; set; }
        public abstract  int Energy { get; set; }
        public virtual Weapon Weapon { get; set; }

        // Generic attack to be overriden
        public virtual void Attack(Player p)
        {
            // Generic attack
            p.HP -= Weapon.Damage;
        }
    }
}
