using Eco.Core;
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Aliases;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Eco.EM.Framework.Resolvers
{
    [LocDisplayName("EM Big Shovel Plugin")]
    [ChatCommandHandler]
    [Priority(200)]
    public class EMBigShovelPlugin : Singleton<EMBigShovelPlugin>, IModKitPlugin, IConfigurablePlugin, IModInit
    {
        private static readonly PluginConfig<EMBigShovelConfig> config;
        public IPluginConfig PluginConfig => config;
        public static EMBigShovelConfig Config => config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();


        public object GetEditObject() => config.Config;
        public void OnEditObjectChanged(object o, string param) {
            this.SaveConfig(); 
            EMBigShovelResolver.Initialize(); 
        }
      
        public string GetStatus() => $"Loaded EM Big Shovel";

        static EMBigShovelPlugin()
        {
            config = new PluginConfig<EMBigShovelConfig>("EMBigShovel");
        }


        public static void PostInitialize()
        {
            EMBigShovelResolver.Initialize();
            config.SaveAsync();
        }



        public override string ToString() => Localizer.DoStr("EM BigShovel");

        [ChatCommand("Generates The EMBigShovel.eco File for people who have headless server", "gen-emshovel", ChatAuthorizationLevel.Admin)]
        public static void GenerateEmBigShovel(User user)
        {
            config.SaveAsync();
            ChatBase.ChatBaseExtended.CBOkBox("Config File Generated, you can find it in: Configs/EMBigShovel.eco", user);
        }

        [ChatCommand("Force the Rebuild of the EMBigShovel.eco File", "fbuild-emshovel", ChatAuthorizationLevel.Admin)]
        public static void ForceRebuildEmBigShovel(User user)
        {
            config.ResetAsync();
            config.SaveAsync();
            ChatBase.ChatBaseExtended.CBOkBox("Config File Reset and Re-Generated, you can find it in: Configs/EMConfigure.eco", user);
        }

        public string GetCategory() => "EM Configure";
        
    }
}
