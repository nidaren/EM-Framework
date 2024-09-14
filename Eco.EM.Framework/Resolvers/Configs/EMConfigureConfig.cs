using Eco.Shared.Localization;

namespace Eco.EM.Framework.Resolvers
{
    public class EMConfigureBaseConfig
    {

        [LocDisplayName("Remove Stockpile Stack Restriction")]
        [LocDescription("Removes the Stack Limit Restriction in Stockpiles. Requires Manual Removal after Disable. Requires a Server Restart.")]
        public bool OverrideVanillaStockpiles { get; set; }

        [LocDisplayName("Enable Lucky Strike For All")]
        [LocDescription("Enables Lucky Strike as a Default Thing, which means the talent is no longer needed, Requires Manual Removal after Disable. Requires Server Restart.")]
        public bool EnableGlobalLuckyStrike { get; set; }

        //Below code adds ability to turn the axe murderer and tampbable desert sand mods on and off in the server interface
        [LocDisplayName("Enable Axe animal Damage")]
        [LocDescription("Enables ability to damage animals using an axe. Requires Server Restart.")]
        public bool EnableAxeMurdererMod { get; set; }

        [LocDisplayName("Enable Tamp-able Desert Sand")]
        [LocDescription("Enables ability to Tamp Desert Sand without it reverting back to Desert Sand. Requires Server Restart.")]
        public bool EnableTampableDesertSand { get; set; }
    }
}
