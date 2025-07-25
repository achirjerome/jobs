using Jobs.Data;
using Jobs.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
namespace Jobs.Services
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationDbContext _context;
        private const int TokenExpiryMinutes = 30;

        public TokenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GenerateToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes);
        }

        private string ComputeHash(string token)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
            return Convert.ToBase64String(bytes);
        }

        public async Task StoreTokenAsync(string email, string token, int jobId)
        {
            var tokenHash = ComputeHash(token);
            var entity = new VerificationToken
            {
                Email = email,
                TokenHash = tokenHash,
                JobId = jobId,
                ExpiryDateTime = DateTime.UtcNow.AddMinutes(TokenExpiryMinutes)
            };
            _context.VerificationTokens.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateAndUseTokenAsync(string token, int jobId)
        {
            var tokenHash = ComputeHash(token);
            var entity = await _context.VerificationTokens
                .FirstOrDefaultAsync(t => t.TokenHash == tokenHash && t.JobId == jobId);

            if (entity == null || entity.ExpiryDateTime < DateTime.UtcNow)
                return false;

            // One-time use: remove after validation
            _context.VerificationTokens.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
