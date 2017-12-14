using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppProj.Data;
using WebAppProj.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAppProj.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Announcements
        [Authorize(Roles = "Member, Customer")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Announcements.ToListAsync());
        }

        // GET: Announcements/Details/5
        [Authorize(Roles = "Member, Customer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcement announcement = await _context.Announcements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            AnnouncementDetailsViewModel viewModel = await GetAnnouncementDetailsViewModelFromAnnouncement(announcement);

            return View(viewModel);
        }

        //Creates a new comment 
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member, Customer")]
        public async Task<IActionResult> Details([Bind("AnnouncementsId,Comment")] AnnouncementDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Comments comments = new Comments();

                comments.CommentDesc = viewModel.Comment;

                Announcement announcement = await _context.Announcements
                .SingleOrDefaultAsync(m => m.Id == viewModel.AnnouncementsId);

                if (announcement == null)
                {
                    return NotFound();
                }

                comments.MyAnnouncement = announcement;
                _context.Comments.Add(comments);
                await _context.SaveChangesAsync();

                viewModel = await GetAnnouncementDetailsViewModelFromAnnouncement(announcement);


            }

            return View(viewModel);
        }

        private async Task<AnnouncementDetailsViewModel> GetAnnouncementDetailsViewModelFromAnnouncement(Announcement announcement)
        {
            AnnouncementDetailsViewModel viewModel = new AnnouncementDetailsViewModel();

            viewModel.Announcement = announcement;

            List<Comments> comments = await _context.Comments
                .Where(m => m.MyAnnouncement == announcement).ToListAsync();

            viewModel.Comments = comments;
            return viewModel;
        }

        // GET: Announcements/Create
        [Authorize(Roles = "Member")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Create([Bind("Id,AnnouncementDesc")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.SingleOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnouncementDesc")] Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcements.SingleOrDefaultAsync(m => m.Id == id);

            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}