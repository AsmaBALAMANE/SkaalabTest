using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestSkaalab.Data;
using TestSkaalab.Models;

namespace TestSkaalab.Controllers
{
    public class LearningRessoucesController : Controller
    {
        private readonly TestSkaalabContext _context;

        public LearningRessoucesController(TestSkaalabContext context)
        {
            _context = context;
        }

        // GET: LearningRessouces
        public async Task<IActionResult> Index()
        {
              return _context.LearningRessouce != null ? 
                          View(await _context.LearningRessouce.ToListAsync()) :
                          Problem("Entity set 'TestSkaalabContext.LearningRessouce'  is null.");
        }

        // GET: LearningRessouces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LearningRessouce == null)
            {
                return NotFound();
            }

            var learningRessouce = await _context.LearningRessouce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningRessouce == null)
            {
                return NotFound();
            }

            return View(learningRessouce);
        }

        // GET: LearningRessouces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LearningRessouces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StartDate,EndDate")] LearningRessouce learningRessouce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningRessouce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningRessouce);
        }

        // GET: LearningRessouces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LearningRessouce == null)
            {
                return NotFound();
            }

            var learningRessouce = await _context.LearningRessouce.FindAsync(id);
            if (learningRessouce == null)
            {
                return NotFound();
            }
            return View(learningRessouce);
        }

        // POST: LearningRessouces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate")] LearningRessouce learningRessouce)
        {
            if (id != learningRessouce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningRessouce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningRessouceExists(learningRessouce.Id))
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
            return View(learningRessouce);
        }

        // GET: LearningRessouces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LearningRessouce == null)
            {
                return NotFound();
            }

            var learningRessouce = await _context.LearningRessouce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningRessouce == null)
            {
                return NotFound();
            }

            return View(learningRessouce);
        }

        // POST: LearningRessouces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LearningRessouce == null)
            {
                return Problem("Entity set 'TestSkaalabContext.LearningRessouce'  is null.");
            }
            var learningRessouce = await _context.LearningRessouce.FindAsync(id);
            if (learningRessouce != null)
            {
                _context.LearningRessouce.Remove(learningRessouce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningRessouceExists(int id)
        {
          return (_context.LearningRessouce?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
