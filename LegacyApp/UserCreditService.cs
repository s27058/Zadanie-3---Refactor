﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable, IUserCreditService
    {
        /// <summary>
        /// Simulating database
        /// </summary>
        private readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Kowalski", 200},
                {"Malewski", 20000},
                {"Smith", 10000},
                {"Doe", 3000},
                {"Kwiatkowski", 1000}
            };
        
        public void Dispose()
        {
            //Simulating disposing of resources
        }

        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        public int GetCreditLimit(string lastName)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (!_database.ContainsKey(lastName))
                throw new ArgumentException($"Client {lastName} does not exist");
                
            return _database[lastName];
        }
        
        /// <summary>
        /// Returns null if there is no credit limit.
        /// </summary>
        public int? GetCreditLimitWithClientType(string lastName, ClientType clientType)
        {
            var creditLimit = GetCreditLimit(lastName);

            switch (clientType)
            {
                case ClientType.NormalClient:
                    return creditLimit;
                case ClientType.ImportantClient:
                    return creditLimit * 2;
                case ClientType.VeryImportantClient:
                    return null;
                default:
                    return 0;
            }
        }
    }
}