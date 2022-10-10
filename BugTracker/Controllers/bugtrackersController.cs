using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using System.Data.SqlClient;
using System.Data;

namespace BugTracker.Controllers
{
    public class bugtrackersController : Controller
    {
         private readonly BugTrackerContext _context;

        public bugtrackersController(BugTrackerContext context)
        {
            _context = context;
        }

        // GET: bugtrackers
        public async Task<IActionResult> Index(string sortOrder)
        {
            if (String.IsNullOrEmpty(sortOrder))
                ViewBag.StatusSortParm = "status_desc";
            else if (sortOrder == "status")
                ViewBag.StatusSortParm = "status_desc";
            else if (sortOrder == "status_desc")
                ViewBag.StatusSortParm = "status";

            var c = await _context.bugtracker.ToListAsync();
           
            switch (sortOrder)
            {
                case "status_desc":
                    var k = c.OrderByDescending(c => c.Status);
                    return View(k);
                case "status":
                    var s = c.OrderBy(c => c.Status);
                    return View(s);
              
            }

            
            return View(c.ToList());
            return View(await _context.bugtracker.ToListAsync());
        }

        

        // GET: bugtrackers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugtracker = await _context.bugtracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugtracker == null)
            {
                return NotFound();
            }

            return View(bugtracker);
        }

        // GET: bugtrackers/Create
        public IActionResult Create()
        {
            
            var g = GetUser(_context.Database.GetDbConnection().ConnectionString);
            List<SelectListItem> mySkills = new List<SelectListItem>();
            mySkills.Add(new SelectListItem());
            foreach (var i in g)
            {
                mySkills.Add(new SelectListItem(i, i));
            }

            ViewBag.User = mySkills;

            return View();
        }

        // POST: bugtrackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Title,Description,ReportedBy,AssignedTo,CreationDate")] bugtracker bugtracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugtracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugtracker);
        }

        // GET: bugtrackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugtracker = await _context.bugtracker.FindAsync(id);
            if (bugtracker == null)
            {
                return NotFound();
            }

            
            var g = GetUser(_context.Database.GetDbConnection().ConnectionString);
            List<SelectListItem> mySkills = new List<SelectListItem>();
            mySkills.Add(new SelectListItem());
            foreach (var i in g)
            {
                mySkills.Add(new SelectListItem(i, i));
            }

            ViewBag.User = mySkills;

            return View(bugtracker);
        }

        // POST: bugtrackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Title,Description,ReportedBy,AssignedTo,CreationDate")] bugtracker bugtracker)
        {
            if (id != bugtracker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugtracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bugtrackerExists(bugtracker.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var g = GetUser(_context.Database.GetDbConnection().ConnectionString);
            List<SelectListItem> mySkills = new List<SelectListItem>();
            mySkills.Add(new SelectListItem());
            foreach (var i in g)
            {
                mySkills.Add(new SelectListItem(i, i));
            }

            ViewBag.User = mySkills;
            return View(bugtracker);
        }

        // GET: bugtrackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugtracker = await _context.bugtracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugtracker == null)
            {
                return NotFound();
            }

            return View(bugtracker);
        }

        // POST: bugtrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugtracker = await _context.bugtracker.FindAsync(id);
            _context.bugtracker.Remove(bugtracker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bugtrackerExists(int id)
        {
            return _context.bugtracker.Any(e => e.Id == id);
        }

        private List<string> GetUser(string cstring)
        {
            SqlConnection con;//= new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BugTrackerContext-cfcf2e63-8adf-4ae6-9b36-cffd5f90d5de;Integrated Security=True");

            con = new SqlConnection(cstring);

            SqlCommand com = new SqlCommand("select admin_id, admin_id from [User]", con);
            com.CommandType = CommandType.Text;
            con.Open();

            List<String> c = new List<String>();
            using (SqlDataReader sdr = com.ExecuteReader())
            {
                while (sdr.Read())
                {
                    c.Add(sdr["admin_id"].ToString());
                }
            }

            //var sl = c.Select(c => new SelectListItem { Value = c })
            //    .ToList();
            con.Close();

            return c;

        }
    }
}
