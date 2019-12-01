using System.Collections.Generic;

namespace GuarProject
{
    public class AreaStableRoad : AbstractArea
    {
        public override string Name { get => "Stable Road"; }
        public override ICollection<IItem> Items { get; set; }
        public override GameState GameState { get; set; }

        // Constructor
        public AreaStableRoad(Player p)
        {
            // Initialize collections
            Items = new List<IItem>();
            UpdateArea(p);
            AddItems();
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
