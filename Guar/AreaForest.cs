﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guar
{
    public class AreaForest : AbstractArea
    {
        public override string Name => "Forest";
        public override ICollection<AbstractEnemy> Enemies { get; set; }
        public override ICollection<IItem> Items { get; set; }
        public override GameState GameState { get; set; }
        public override string Description => "DescriptionForest.txt";

        public AreaForest(Player p)
        {
            GameState = GameState.Explore;

            Enemies = new List<AbstractEnemy>();
            Items = new List<IItem>();

            AddEnemies();
            AddItems();

            UpdateArea(p);
        }

        public override void AddEnemies()
        {
            ImpEnemy imp1 = new ImpEnemy();

            Enemies.Add(imp1);
        }

        public override void AddItems()
        {
            AbstractWeapon item = new BlueGem();

            Items.Add(item);
        }
    }
}
