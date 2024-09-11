using Eco.Shared.Localization;

namespace Eco.EM.Framework.Resolvers
{
    public class EMBigShovelConfig
    {
        [LocDisplayName("Enable Big Shovel")]
        [LocDescription("Enables Big shovel so all shovels will hold more then the vanilla values. Requires Server Restart.")]
        public bool EnableBigShovel { get; set; }

        [LocDisplayName("All shovels use same Stack Size")]
        [LocDescription("Should all of the shovels use the same stack size. If true then use Global value and ignore individual values. Otherwise use the individual values. Requires Server Restart.")]
        public bool BigShovelNonUniqueValues { get; set; }

        [LocDisplayName("Global Shovel Stack Size")]
        [LocDescription("Set the Stack Size of All Shovel. Requires Server Restart.")]
        public int GlobalShovelStackSize { get; set; }

        [LocDisplayName("Wood Shovel Stack Size")]
        [LocDescription("Set the Stack Size of Wood Shovel. Requires Server Restart.")]
        public int WoodShovelStackSize { get; set; }

        [LocDisplayName("Iron Shovel Stack Size")]
        [LocDescription("Set the Stack Size of Iron Shovel. Requires Server Restart.")]
        public int IronShovelStackSize { get; set; }

        [LocDisplayName("Steel Shovel Stack Size")]
        [LocDescription("Set the Stack Size of Steel Shovel. Requires Server Restart.")]
        public int SteelShovelStackSize { get; set; }

        [LocDisplayName("Modern Shovel Stack Size")]
        [LocDescription("Set the Stack Size of Modern Shovel. Requires Server Restart.")]
        public int ModernShovelStackSize { get; set; }


    }
}
