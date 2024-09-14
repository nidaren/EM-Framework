using Eco.EM.Framework.Utils;
using Eco.Mods.TechTree;
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
    public class EMBigShovelResolver 
    {
        public static void Initialize()
        {
            if (EMBigShovelPlugin.Config.EnableBigShovel)
                RunBigShovelResolver();
            if (!EMBigShovelPlugin.Config.EnableBigShovel)
                RemoveBigShovel();
        }

        //When run adds override shovel files to tool folder
        public static void RunBigShovelResolver()
        {
            var coretoolsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "__core__" + Path.DirectorySeparatorChar + "AutoGen" + Path.DirectorySeparatorChar + "Tool";
            var usertoolsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "AutoGen" + Path.DirectorySeparatorChar + "Tool";

            if (!Directory.Exists(usertoolsdir))
            {
                Directory.CreateDirectory(usertoolsdir);
            }
            List<string> shovels = new List<string>() {"WoodenShovel", "IronShovel", "SteelShovel", "ModernShovel" };
            
            const Int32 BufferSize = 128;

            foreach (var shovel in shovels){
                string f = coretoolsdir + Path.DirectorySeparatorChar + shovel + ".cs";
                string nf = usertoolsdir + Path.DirectorySeparatorChar + shovel + ".override.cs";
                if (File.Exists(nf)) { File.Delete(nf); }
                List<string> contents = new List<string>();
                using (var fileStream = File.OpenRead(f))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Contains("MaxTake")){
                            if (EMBigShovelPlugin.Config.BigShovelNonUniqueValues)
                            {
                                line = "        public override int MaxTake                     => " + EMBigShovelPlugin.Config.GlobalShovelStackSize + ";\r\n";
                            }
                            else
                            {
                                switch(shovel)
                                {
                                    case "WoodenShovel":
                                        line = "        public override int MaxTake                     => " + EMBigShovelPlugin.Config.WoodShovelStackSize + ";\r\n";
                                        break;
                                    case "IronShovel":
                                        line = "        public override int MaxTake                     => " + EMBigShovelPlugin.Config.IronShovelStackSize + ";\r\n";
                                        break;
                                    case "SteelShovel":
                                        line = "        public override int MaxTake                     => " + EMBigShovelPlugin.Config.SteelShovelStackSize + ";\r\n";
                                        break;
                                    case "ModernShovel":
                                        line = "        public override int MaxTake                     => " + EMBigShovelPlugin.Config.ModernShovelStackSize + ";\r\n";
                                        break;
                                };
                            }
                        }

                        contents.Add(line);

                    }

                    File.WriteAllLines(nf, contents);
                }


            }

        }

        //Removed override files for shovels to remove big shovel mod
        public static void RemoveBigShovel()
        {
            var usertoolsdir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Mods" + Path.DirectorySeparatorChar + "UserCode" + Path.DirectorySeparatorChar + "AutoGen" + Path.DirectorySeparatorChar + "Tool";
            List<string> shovels = new List<string>() { "WoodenShovel", "IronShovel", "SteelShovel", "ModernShovel" };
            foreach (var shovel in shovels)
            {
                string nf = usertoolsdir + Path.DirectorySeparatorChar + shovel + ".override.cs";
                if (File.Exists(nf)) { File.Delete(nf); }
            }
        }

    }
}
