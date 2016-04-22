namespace KEnergy.WebUI.DSL.Interfaces
{
    public interface IUserRepository
    {
        bool Login(string email, string password);
    }
}
