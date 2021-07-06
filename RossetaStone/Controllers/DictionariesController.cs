using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RossetaStone.Data;
using RossetaStone.Models;
using static RossetaStone.Helper;

namespace RossetaStone.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictionariesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Dictionaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dictionary.ToListAsync());
        }


        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Dictionary());
            else
            {
                var dictionaryModel = await _context.Dictionary.FindAsync(id);
                if (dictionaryModel == null)
                {
                    return NotFound();
                }
                return View(dictionaryModel);
            }
        }


        // POST: Dictionaries/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,WordEng,WordRus")] Dictionary dictionary)
        {
            

            if (ModelState.IsValid)
            {//Insert
                if (id == 0)
                {
                    _context.Add(dictionary);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    try
                    {
                        _context.Update(dictionary);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DictionaryExists(dictionary.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Dictionary.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", dictionary) });
        }

        // POST: Dictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionary = await _context.Dictionary.FindAsync(id);
            _context.Dictionary.Remove(dictionary);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Dictionary.ToList()) });
        }

        private bool DictionaryExists(int id)
        {
            return _context.Dictionary.Any(e => e.Id == id);
        }
    }
}
