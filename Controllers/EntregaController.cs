using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using avd4.Data;
using avd4.Models;

namespace avd4.Controllers
{
    public class EntregaController : Controller
    {
        private readonly AppDbContext _context;

        public EntregaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Entrega
        public async Task<IActionResult> Index()
        {
            var entrega = await _context.Entregas
                .Include(e => e.Pedido.Cliente)
                .ToListAsync();
            return View(entrega);
        }

        // GET: Entrega/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas
                .Include(e => e.Pedido.Cliente)
                 .Include(e => e.Pedido.Produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

       
        // GET: Entrega/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }
            return View(entrega);
        }

        // POST: Entrega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DataHora")] Entrega entrega)
        {
            if (id != entrega.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaExists(entrega.id))
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
            return View(entrega);
        }

        // GET: Entrega/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas
                .FirstOrDefaultAsync(m => m.id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

        // POST: Entrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrega = await _context.Entregas.FindAsync(id);
            _context.Entregas.Remove(entrega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaExists(int id)
        {
            return _context.Entregas.Any(e => e.id == id);
        }
    }
}
