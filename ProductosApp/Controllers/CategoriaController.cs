﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosApp.Models;

public class CategoriaController(BDContext context) : Controller
{
    private readonly BDContext _context = context;

    // GET: Categoria
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categorias.ToListAsync());
    }

    // GET: Categoria/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(m => m.NoCategoria == id);
        if (categoria == null)
        {
            return NotFound();
        }

        return View(categoria);
    }

    // GET: Categoria/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categoria/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NoCategoria,Nombre,Descripcion")] Categoria categoria)
    {
        if (ModelState.IsValid)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(categoria);
    }

    // GET: Categoria/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    // POST: Categoria/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("NoCategoria,Nombre,Descripcion")] Categoria categoria)
    {
        if (id != categoria.NoCategoria)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(categoria);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(categoria.NoCategoria))
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
        return View(categoria);
    }

    // GET: Categoria/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(m => m.NoCategoria == id);
        if (categoria == null)
        {
            return NotFound();
        }

        return View(categoria);
    }

    // POST: Categoria/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoriaExists(int id)
    {
        return _context.Categorias.Any(e => e.NoCategoria == id);
    }
}
