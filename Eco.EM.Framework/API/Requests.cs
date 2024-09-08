using Eco.Core.Serialization;
using Eco.EM.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Eco.EM.Framework.Plugins;
using Eco.Gameplay.Players;
using Newtonsoft.Json;
using Eco.EM.Framework.Helpers;
using Newtonsoft.Json.Converters;
using Eco.EM.Framework.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Eco.EM.Framework.API
{
    [AllowAnonymous, Route("elixr-mods/framework/api/v1")]
    public class RequestsController : Controller
    {
        [HttpGet("get-recipes")]
        public string GetRecipes()
        {
            if (BasePlugin.Obj.Config.EnableWebAPI)
            {
                var result = JSONRecipeExporter.BuildExportData();

                if (result is null)
                    return "No Data To Display";
                else
                    return JsonConvert.SerializeObject(result);
            }
            else
                return null;
        }

        [HttpGet("get-prices")]
        public string GetPrices([FromQuery]bool includeOutOfStock = false)
        {
            string noResult = "No Items Found";
            if (BasePlugin.Obj.Config.EnableWebAPI)
            {
                var result = ShopUtils.GetAllItems(includeOutOfStock);
                if (result is null)
                    return noResult;
                else
                    return JsonConvert.SerializeObject(result);
            }
            else
                return null;
        }
        
        [HttpGet("lookup-user")]
        public string LookupUser([FromQuery]string username = "")
        {
            if (BasePlugin.Obj.Config.EnableWebAPI)
            {
                if (string.IsNullOrWhiteSpace(username))
                    return "You must provide a user";
                var user = UserManager.FindUser(username);
                if (user is null)
                    return "No User Found";

                Dictionary<string, string> UserDetails = new()
            {
                { "UserName", user.Name },
                { "SteamID", user.SteamId?.ToString()},
                { "SLGID", user.StrangeId?.ToString()  },
                { "UserXp", user.UserXP.XP.ToString() },
                { "Position", user.Position.ToString() },
                { "Language", user.Language.ToString() },
                { "Reputation", user.Reputation.ToString() },
                { "IsActive", user.IsActive.ToString() },
                { "IsAbandoned", user.IsAbandoned.ToString() },
                { "IsAdmin", user.IsAdmin.ToString() },
                { "SkillSet", user.Skillset.Skills.ToArray().ToString() },
                { "TalentSet", user.Talentset.Talents.ToArray().ToString() },
                { "TotalPlayTime", user.TotalPlayTime.ToString() },
                { "IsOnline", user.IsOnline.ToString() }
            };

                return JsonConvert.SerializeObject(UserDetails);
            }
            else
                return null;

        }

        [HttpGet("api-check")]
        public string Test()
        {
            if (BasePlugin.Obj.Config.EnableWebAPI)
            {
                return "We Are Working Chief! API System is enabled";
            }
            else
                return null;
        }
    }
}