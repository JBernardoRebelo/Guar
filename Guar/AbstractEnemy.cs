using System;
using System.Collections.Generic;
using System.Text;

namespace Guar
{
    public abstract class AbstractEnemy : IEntity
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Perception { get; set; }
        public abstract int ID { get; set; }
        public abstract int Intelligence { get; set; }
        public abstract int Energy { get; set; }
        public abstract Race Race { get; }
        public virtual AbstractWeapon Weapon { get; set; }
        public virtual AttackBehaviour AttackBehaviour { get; set; }

        // Generic Attack
        public virtual void Attack()
        {
            AttackBehaviour.Attack();
        }

        // Detection return true if detect
        public virtual bool Detection(Player p, int moves)
        {


            return true;
            // Make something with this perception and player sneak

        }
    }
}
