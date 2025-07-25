using Jobs.Data;
using Jobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Pages.Admin
{
    public class CreateJobModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateJobModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; } = new Job();

        public SelectList DepartmentOptions { get; set; }

        public async Task OnGetAsync()
        {
            // Populate department dropdown
            DepartmentOptions = new SelectList(await _context.Departments.ToListAsync(),
                                              nameof(Department.Id),
                                              nameof(Department.Name));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate departments if validation fails
                DepartmentOptions = new SelectList(await _context.Departments.ToListAsync(),
                                                  nameof(Department.Id),
                                                  nameof(Department.Name));
                return Page();
            }

            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Jobs/Index");
        }
    }
}
