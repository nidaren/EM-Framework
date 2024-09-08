﻿using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Framework.Utils
{
    public class PlayerUtils
    {
        public static User GetUserByName(string UserName) => UserManager.FindUserByName(UserName);
        public static Player GetPlayerByName(string PlayerName) => GetUserByName(PlayerName).Player;
        public static User GetUser(string Filter) => UserManager.Users.FirstOrDefault(u => u.Name == Filter || u.StrangeId == Filter || u.SteamId == Filter);
        public static User GetUserFromClient(IChatClient client) => GetUser(client.Name) is not null ? GetUser(client.Name) : null;
        public static Player GetPlayerFromClient(IChatClient client) => GetPlayerByName(client.Name) is not null ? GetPlayerByName(client.Name) : null;
        public static string WhoAmI(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.SteamId))
                return user.SteamId;
            return user.StrangeId;
        }

        public static List<User> OnlineUsers => UserManager.OnlineUsers.ToList();
        public static List<User> Users => UserManager.Users.ToList();
        public static List<User> Admins => UserManager.Admins.ToList();
        public static List<User> OnlineAdmins => OnlineUsers.Where(u => u.IsAdmin == true).ToList();
    }
}
