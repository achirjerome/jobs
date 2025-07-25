using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jobs.Data;
using Jobs.Models;
using Microsoft.EntityFrameworkCore;
using Jobs.DTO;

namespace Jobs.Controllers
{
    public class v1Controller : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public v1Controller(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: v1Controller
        [AcceptVerbs("Get", "Post")]
        public JsonResult joblists()
        {
            try
            {
                var form = Request.HasFormContentType ? Request.Form : null;

                var draw = form?["draw"].FirstOrDefault() ?? Request.Query["draw"].FirstOrDefault();
                var start = form?["start"].FirstOrDefault() ?? Request.Query["start"].FirstOrDefault();
                var length = form?["length"].FirstOrDefault() ?? Request.Query["length"].FirstOrDefault();
                var orderColIndex = form?["order[0][column]"].FirstOrDefault() ?? Request.Query["order[0][column]"].FirstOrDefault();
                var sortColumn = form?[$"columns[{orderColIndex}][name]"].FirstOrDefault() ?? Request.Query[$"columns[{orderColIndex}][name]"].FirstOrDefault();
                var sortColumnDirection = form?["order[0][dir]"].FirstOrDefault() ?? Request.Query["order[0][dir]"].FirstOrDefault();
                var searchValue = form?["search[value]"].FirstOrDefault() ?? Request.Query["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 10;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                var query = dbContext.Jobs
                    .Include(j => j.Category)
                    .Include(j => j.Department)
                    .OrderByDescending(j => j.CreatedDate)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(m =>
                        m.Category.Name.Contains(searchValue) ||
                        m.Department.Name.Contains(searchValue) ||
                        m.Title.Contains(searchValue));
                }

                // Dynamic sorting
                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
                {
                    var sortExp = $"{sortColumn} {sortColumnDirection}";
                    //query = query.OrderBy(sortExp); // needs System.Linq.Dynamic.Core
                }

                var recordsTotal = query.Count();

                var data = query.Skip(skip).Take(pageSize).ToList();

                var newdata = data.Select(q => new JobResponseDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    Category = q.Category.Name,
                    Department = q.Department.Name,
                    StartDate = q.StartDate,
                    ClosingDate = q.ClosingDate,
                    active = q.Active
                }).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data = newdata });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    draw = Request.Form["draw"].FirstOrDefault() ?? Request.Query["draw"].FirstOrDefault(),
                    recordsFiltered = 0,
                    recordsTotal = 0,
                    data = new List<JobResponseDto>(),
                    error = "An error occurred: " + ex.Message
                });
            }
        }


        // GET: v1Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: v1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: v1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: v1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
