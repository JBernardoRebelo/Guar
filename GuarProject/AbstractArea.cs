﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public abstract class AbstractArea
    {
        /// <summary>
        /// Name of an area
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Collection of Items contained in an area
        /// </summary>
        public abstract ICollection<IItem> Items { get; set; }

        /// <summary>
        /// Collection of Enemies contained in an area
        /// </summary>
        public virtual ICollection<AbstractEnemy> Enemies { get; set; }

        /// <summary>
        /// HashSet of Npcs in an area
        /// </summary>
        public virtual HashSet<IEntity> Npcs { get; set; }

        /// <summary>
        /// Instance of render to use
        /// </summary>
        public virtual Render Render { get; }

        /// <summary>
        /// Instance of random for npc and item generation for big areas
        /// </summary>
        public virtual Random Random { get; }

        /// <summary>
        /// Current state of game
        /// </summary>
        public abstract GameState GameState { get; set; }

        // If player is in this area updates it
        public void UpdateArea(Player p)
        {
            p.Area = this;
        }

        //public abstract void SwitchState(GameState state);

        // Add starting items to an area
        public abstract void AddItems();

        // Add starting enemies to an area
        public virtual void AddEnemies()
        {
            Render.NoEnemiesHere();
        }

        // Add starting NPCS to an area
        public virtual void AddNpcs()
        {
            Render.NoNpcsHere();
        }
    }
}
