namespace LegacyApp;

public interface IUserCreditService
{ 
    int GetCreditLimit(string lastName);
    int? GetCreditLimitWithClientType(string lastName, ClientType clientType);
}