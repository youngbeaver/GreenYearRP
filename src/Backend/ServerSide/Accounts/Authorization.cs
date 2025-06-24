using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using SDK.Accounts;
using SDK.CustomEntities;
using ServerSide.Database.EntityCore;
using ServerSide.Database.EntityCore.Models;

namespace ServerSide.Accounts
{
    internal class Authorization : Script
    {
        /// <summary>
        /// Авторизация в аккаунт
        /// </summary>
        /// <param name="player">Игрок вызывающий метод</param>
        /// <param name="login">Логин указанный игроком в CEF</param>
        /// <param name="password">Пароль от аккаунта, который игрок указал в CEF</param>
        /// <returns></returns>
        [RemoteEvent("server:AuthorizationInAccount")]
        public static async Task AuthorizationInAccount(CustomPlayer player, string login, string password)
        {
            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
                return;

            AccountsModel? accountsModel = null;

            using ApplicationContext db = new ApplicationContext();
            accountsModel = await db.accounts.FirstOrDefaultAsync(p => p.Login == login) ?? await db.accounts.FirstOrDefaultAsync(p => p.Email == login);

            if (accountsModel == null)
                return;

            string passwordHash = Convert.ToHexString(SHA256.HashData(Encoding.ASCII.GetBytes(password)));

            if (accountsModel.Password != passwordHash)
                return;

            InitAccount(player, db);
        }

        /// <summary>
        /// Создание нового аккаунта.
        /// </summary>
        /// <param name="player">Игрок вызывающий метод</param>
        /// <param name="login">Логин который игрок указал в CEF</param>
        /// <param name="password">Пароль который игрок указал в CEF</param>
        /// <returns></returns>
        [RemoteEvent("server:CreateAccount")]
        public static async Task CreateAccount(CustomPlayer player, string login, string password)
        {
            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
                return;

            string playerAddress = player.Address, playerSerial = player.Serial, playerSocial = player.SocialClubId.ToString();
            using var db = new ApplicationContext();

            bool accountIsCreated = await db.accounts.AnyAsync(p => p.Login == login || p.Email == login);

            if (accountIsCreated == true)
                return;

            string passwordHash = Convert.ToHexString(SHA256.HashData(Encoding.ASCII.GetBytes(password)));
            var accountsModel = new AccountsModel(login, passwordHash, playerAddress, playerSerial, playerSocial);

            await db.accounts.AddAsync(accountsModel);   
            await db.SaveChangesAsync();
            InitAccount(player, db);
        }

        
        [RemoteEvent("server:RecoveryPassword")]
        public static async Task RecoveryPassword(CustomPlayer player, string login)
        {
            /*
             
             if (String.IsNullOrWhiteSpace(login))
                    return;

                AccountsModel? accountsModel = null;

                ApplicationContext db = new ApplicationContext();
                bool resultFindAccout = await db.accounts.AnyAsync(p => p.Login == login);

                if (resultFindAccout == false || String.IsNullOrWhiteSpace(accountsModel.Email) == false)
                    return;
             
             */
                /*
                 TODO: Send to email.
                 */
            
        }

        /// <summary>
        /// Инициализация объекта Account для объекта CustomPlayer после авторизации в аккаунт.
        /// </summary>
        /// <param name="player">Игрок вызывающий метод</param>
        /// <param name="db">Объект созданного соединения с базой данных</param>
        private static async void InitAccount(CustomPlayer player, ApplicationContext db)
        {
            var account = await db.accounts.FirstOrDefaultAsync(a => a.SocialID == player.SocialClubId.ToString());

            if (account == null)
            {
                player.SendNotification("Ошибка инициализации аккаунта. Свяжитесь с администрацией.");
                player.KickSilent();
                return;
            }

            player.Account = account;
            player.TriggerEvent("client:SelectCharacter");
        }
    }
}
