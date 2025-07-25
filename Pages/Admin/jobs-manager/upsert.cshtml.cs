using Jobs.Data;
using Jobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Pages.Admin.jobs_manager
{
    public class upsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public upsertModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public bool IsEditMode => Job != null && Job.Id != 0;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                // No id, insert mode: prepare empty Job
                Job = new Job();
            }
            else
            {
                // id provided, fetch from DB
                Job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);

                if (Job == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Provide all fields";
                return Page();
            }
            string msg = "";
            if (Job.Id == 0)
            {
                // Insert
                _context.Jobs.Add(Job);
                msg = "Job added successfully";
            }
            else
            {
                // Update
                _context.Jobs.Update(Job);
                msg = "Job updated successfully";
            }

            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                TempData["success"] = msg;
                return RedirectToPage("Index"); // Or wherever you want

            }
            TempData["error"] = "An error occured while processing your request";
            return Page();
        }
    }
}
