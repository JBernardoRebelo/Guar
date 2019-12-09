using System;
using System.Collections.Generic;
using System.Text;

namespace Guar
{
    public class ImpEnemy : AbstractEnemy
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public override int Perception { get; set; }
        public override int ID { get; set; }
        public override int Intelligence { get; set; }
        public override int Energy { get; set; }
        public override Race Race { get => Race.Imp; }
        public override AttackBehaviour AttackBehaviour { get; set; }

        // Enemy constructor, initialize attack type
        public ImpEnemy()
        {
            AttackBehaviour = new AttackBehaviour();
            Health = 15;
            Damage = 4;
            Perception = 2;
            Intelligence = 1;
            Energy = 20;
        }
    }
}
