using Eco.EM.Framework.Utils;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eco.Shared.Utils.LimitMapper;

namespace Eco.EM.Framework.Resolvers
{
    internal class EMConfigureResolver
    {
        public static void Initialize()
        {
            if (EMConfigurePlugin.Config.OverrideVanillaStockpiles)
                RunStockpileResolver();
            if (EMConfigurePlugin.Config.EnableGlobalLuckyStrike)
                RunLuckyStrikeResolver();
            if (EMConfigurePlugin.Config.EnableAxeMurdererMod) // Add call to axe murderer enable resolver
                RunAxeMurdererResolver();
            if (!EMConfigurePlugin.Config.EnableAxeMurdererMod) //Add call to remove axe murderer mod
                RemoveAxeMurderer();
            if (EMConfigurePlugin.Config.EnableTampableDesertSand) // Add call to tamp-able desert sand enable resolver
                RunTampableDesertSandResolver();
            if (!EMConfigurePlugin.Config.EnableTampableDesertSand) //Add call to remove tamp-able desert sand mod
                RemoveTampableDesertSand();
        }

        private static void RunLuckyStrikeResolver()
        {

            var alsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Tools";

            if (!Directory.Exists(alsdir))
            {
                Directory.CreateDirectory(alsdir);
            }
            if (!File.Exists(Path.Combine(alsdir, "PickaxeItem.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "pickaxe.txt", alsdir, ".cs", specificFileName: "PickaxeItem.override");
        }

        private static void RunStockpileResolver()
        {
            var agdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Objects";

            if (!Directory.Exists(agdir))
            {
                Directory.CreateDirectory(agdir);
            }

            if (!File.Exists(Path.Combine(agdir, "StockpileObject.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "Stockpile.txt", agdir, ".cs", specificFileName: "StockpileObject.override");
            if (!File.Exists(Path.Combine(agdir, "SmallStockpileObject..override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "smallStockpile.txt", agdir, ".cs", specificFileName: "SmallStockpileObject.override");
            if (!File.Exists(Path.Combine(agdir, "LumberStockpileObject.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "lumberStockpile.txt", agdir, ".cs", specificFileName: "LumberStockpileObject.override");
            if (!File.Exists(Path.Combine(agdir, "LargeLumberStockpileObject.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "largelumberStockpile.txt", agdir, ".cs", specificFileName: "LargeLumberStockpileObject.override");

        }

        // Uses template to create axeItem override file that adds the ability to damage aniumals with an axe
        private static void RunAxeMurdererResolver()
        {

            var alsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Tools";

            if (!Directory.Exists(alsdir))
            {
                Directory.CreateDirectory(alsdir);
            }
            if (!File.Exists(Path.Combine(alsdir, "AxeItem.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "axe.txt", alsdir, ".cs", specificFileName: "AxeItem.override");
        }

        // Removes the axeitem override file
        private static void RemoveAxeMurderer()
        {
            var alsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Tools";
            string f = Path.Combine(alsdir, "AxeItem.override.cs");
            if (File.Exists(f)) { File.Delete(f); }

        }
        // Uses template to create Road Tool and dirt road override files that adds the ability to damage aniumals with an axe
        private static void RunTampableDesertSandResolver()
        {

            var alsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Tools";
            var rddir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Blocks";

            if (!Directory.Exists(alsdir))
            {
                Directory.CreateDirectory(alsdir);
            }
            if (!Directory.Exists(rddir))
            {
                Directory.CreateDirectory(rddir);
            }
            if (!File.Exists(Path.Combine(alsdir, "RoadToolItem.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "roadtool.txt", alsdir, ".cs", specificFileName: "RoadToolItem.override");
            
            if (!File.Exists(Path.Combine(rddir, "DirtRoad.override.cs")))
                WritingUtils.WriteFromEmbeddedResource("Eco.EM.Framework.SpecialItems", "dirtroad.txt", rddir, ".cs", specificFileName: "DirtRoad.override");

        }

        // Removes the Road Tool and dirt road override files
        private static void RemoveTampableDesertSand()
        {
            var alsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Tools";
            string f = Path.Combine(alsdir, "RoadToolItem.override.cs");
            if (File.Exists(f)) { File.Delete(f); }

            var rddir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "Blocks";
            string rf = Path.Combine(rddir, "DirtRoad.override.cs");
            if (File.Exists(rf)) { File.Delete(rf); }

        }
    }
}
