namespace Guar
{
    public class AttackNoWeapon : AttackBehaviour
    {
        // Enemy attack with no weapon
        public override void Attack(Player p)
        {
            p.HP -= 1;
        }
    }
}
