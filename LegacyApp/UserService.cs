using System;

namespace LegacyApp
{
    public class UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
    {
        [Obsolete]
        public UserService() : this(new ClientRepository(), new UserCreditService()){}

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            User user;
            var client = clientRepository.GetById(clientId);
            try
            {
                user = new User
                {
                    Client = client,
                    DateOfBirth = dateOfBirth,
                    EmailAddress = email,
                    FirstName = firstName,
                    LastName = lastName
                };
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            
            var creditLimit = userCreditService.GetCreditLimitWithClientType(user.LastName, client.ClientType);
            if (creditLimit is null)
            {
                user.HasCreditLimit = false;
            }
            else
            {
                user.HasCreditLimit = true;
                try
                {
                    user.CreditLimit = creditLimit.Value;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.StackTrace);
                    return false;
                }
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
