
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Framework.Extentsions.Items
{
    [Serialized]
    public abstract class ConsumptionItem : DurabilityItem //changed to abstract class. partial class was causing errors and asking for more things to be added, 
    {
        public virtual float Durability { get; set; } = 100f;
        public override float GetDurability() => Durability;
        //updated UseDurability method, copied from RepairableItem
        public virtual void UseDurability(float amountToConsume, Player player, bool notify = true)
        {
            if (!this.Decays || this.Broken) return; //Ignore for items that dont lose durability or broken already

            this.Durability = Math.Max(0, this.Durability - amountToConsume);
            if (this.Durability == 0 && player != null)
            {
                this.Broken = true;
                if (notify) player.ErrorLoc($"Your {this.UILink()} broke!  It will be much less efficient until repaired.");
            }
        }
    }
}