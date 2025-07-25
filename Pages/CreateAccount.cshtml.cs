using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Jobs.Data;
using Jobs.Services;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Jobs.Models;
using Microsoft.EntityFrameworkCore;


namespace Jobs.Pages
{   
    public class CreateAccountModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        [BindProperty]
        public CreateAccountInput Input { get; set; }

        [BindProperty(SupportsGet = true)]
        public int JobId { get; set; }

        public CreateAccountModel(ApplicationDbContext context, ITokenService tokenService, IEmailService emailService)
        {
            _context = context;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public void OnGet(int jobId)
        {
            JobId = jobId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Check if applicant already exists
            var existing = await _context.ApplicantAccounts.FirstOrDefaultAsync(a => a.Email == Input.Email);
            if (existing != null)
            {
                ModelState.AddModelError(string.Empty, "An account with this email already exists.");
                return Page();
            }

            var applicant = new ApplicantAccount
            {               
                Email = Input.Email,
                IsEmailVerified = false
            };

            var hasher = new PasswordHasher<ApplicantAccount>();
            applicant.PasswordHash = hasher.HashPassword(applicant, Input.Password);

            _context.ApplicantAccounts.Add(applicant);
            await _context.SaveChangesAsync();

            // Create verification token
            var token = _tokenService.GenerateToken();
            await _tokenService.StoreTokenAsync(applicant.Email, token, JobId);

            var verificationLink = Url.PageLink(
                "/ApplicationForm",
                values: new { token, jobId = JobId }
            );

            await _emailService.SendVerificationEmail(applicant.Email, verificationLink);

            return RedirectToPage("VerificationSent");
        }
    }

    public class CreateAccountInput
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
