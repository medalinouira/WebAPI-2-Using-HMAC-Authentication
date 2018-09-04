namespace SampleWebAPI.Domain.IServices
{
    public interface IUserServices
    {
        bool IsUserExist(string email, string password);
        bool IsConfidentials(string email);
    }
}
