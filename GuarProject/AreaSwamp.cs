using System;
using System.Collections.Generic;

namespace GuarProject
{
    public class AreaSwamp : AbstractArea
    {
        public override string Name { get => "Swamp"; }
        public override ICollection<AbstractEnemy> Enemies { get; set; }
        public override ICollection<IItem> Items { get; set; }
        public override GameState GameState { get; set; }
        public override string Descritption => "DescriptionSwamp.txt";

        public AreaSwamp(Player p)
        {
            Enemies = new List<AbstractEnemy>();
            Items = new List<IItem>();

            UpdateArea(p);
        }

        public override void AddEnemies()
        {
            ImpEnemy imp1 = new ImpEnemy();
            ImpEnemy imp2 = new ImpEnemy();

            Enemies.Add(imp1);
            Enemies.Add(imp2);
        }

        public override void AddItems()
        {
            Weapon item = new RedGem();
            Weapon item2 = new RedGem();

            Items.Add(item);
            Items.Add(item2);
        }
    }
}
