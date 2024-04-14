using Eco.Core.Utils;
using Eco.Shared.Localization;

namespace Eco.EM.Framework.Resolvers
{
    public class EMRecipesConfig
    {

        [LocDisplayName("Use Config Recipes")]
        [LocDescription("Enable to use config file based Recipes or disable to let the mod handle its own recipes")]
        public bool UseConfigOverrides { get; set; }

        [LocDescription("Recipes loaded by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Recipes")]
        public SerializedSynchronizedCollection<RecipeModel> EMRecipes { get; set; } = new();
    }
}
