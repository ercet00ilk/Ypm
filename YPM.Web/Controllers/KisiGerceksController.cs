using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using YPM.Veri.Kaynak;

namespace YPM.Web.Controllers
{
    public class KisiGerceksController : Controller
    {
        private readonly YpmSebil _context;

        public KisiGerceksController(YpmSebil context)
        {
            _context = context;
        }

        // GET: KisiGerceks
        public async Task<IActionResult> Index()
        {
            return View(await _context.KisiTbl.ToListAsync());
        }

        // GET: KisiGerceks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisiGercek = await _context.KisiTbl
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kisiGercek == null)
            {
                return NotFound();
            }

            return View(kisiGercek);
        }

        // GET: KisiGerceks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KisiGerceks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,EPosta,Sifre")] KisiGercek kisiGercek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisiGercek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisiGercek);
        }

        // GET: KisiGerceks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisiGercek = await _context.KisiTbl.SingleOrDefaultAsync(m => m.Id == id);
            if (kisiGercek == null)
            {
                return NotFound();
            }
            return View(kisiGercek);
        }

        // POST: KisiGerceks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,EPosta,Sifre")] KisiGercek kisiGercek)
        {
            if (id != kisiGercek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisiGercek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisiGercekExists(kisiGercek.Id))
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
            return View(kisiGercek);
        }

        // GET: KisiGerceks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisiGercek = await _context.KisiTbl
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kisiGercek == null)
            {
                return NotFound();
            }

            return View(kisiGercek);
        }

        // POST: KisiGerceks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kisiGercek = await _context.KisiTbl.SingleOrDefaultAsync(m => m.Id == id);
            _context.KisiTbl.Remove(kisiGercek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisiGercekExists(int id)
        {
            return _context.KisiTbl.Any(e => e.Id == id);
        }
    }
}
