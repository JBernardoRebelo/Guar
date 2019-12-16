namespace Guar
{
    public class AttackBehaviour
    {
        // Virtual attack that accepts a player
        public virtual void Attack(Player p, AbstractEnemy enemy)
        {
            p.HP -= enemy.Damage;

            // Render.BattleFeed
        }

        // Virtual attack that accepts a player and enemy weapon
        public virtual void Attack(Player p, AbstractWeapon w)
        {

        }

    }
}
