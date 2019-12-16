using System.Collections.Generic;

namespace Guar
{
    public class AreaStableRoad : AbstractArea
    {
        public override string Name { get => "Stable Road"; }
        public override ICollection<IItem> Items { get; set; }
        public override GameState GameState { get; set; }
        public override string Description => "DescriptionStable.txt";

        // Constructor
        public AreaStableRoad(Player p)
        {
            GameState = GameState.Explore;

            // Initialize collections
            Items = new List<IItem>();
            AddItems();

            UpdateArea(p);
        }

        // Add item
        public override void AddItems()
        {
            // Items in this area are always the same
            RedGem redGem = new RedGem();
            Items.Add(redGem);
        }
    }
}
