using System;

namespace GuarProject
{
    public class AttackNoWeapon : IAttackBehaviour
    {
        // Enemy attack with no weapon
        public void Attack(Player p)
        {
            p.HP -= 1;
        }
    }
}
