using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public class ImpEnemy : AbstractEnemy
    {
        public override int Health { get; set; }
        public override int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Perception { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Intelligence { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Energy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override AttackBehaviour AttackBehaviour { get; set; }

        // Enemy constructor, initialize attack type
        public ImpEnemy()
        {
            AttackBehaviour = new AttackNoWeapon();
        }
    }
}
