namespace Jobs.Services
{
    public interface ITokenService
    {
        string GenerateToken();
        Task StoreTokenAsync(string email, string token, int jobId);
        Task<bool> ValidateAndUseTokenAsync(string token, int jobId);
    }

}
