using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductosApp.Models;

public class ProductoController(BDContext context) : Controller
{
    private readonly BDContext _context = context;

    public async Task<IActionResult> Index()
    {
        
        ViewBag.Categorias = await _context.Categorias.ToListAsync();
        ViewBag.Productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();

        return View(new Producto());
    }


    // POST: Productos/CreateOrUpdate
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdate([Bind("NoProducto,NoCategoria,Nombre,Descripcion,Stock,Precio")] Producto producto)
    {
        Console.WriteLine("NoProducto", producto.NoProducto);

        if (producto.NoProducto == 0) // Crear
        {
            _context.Add(producto);
        }
        else // Actualizar
        {
            _context.Update(producto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    // GET: Producto/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(m => m.NoProducto == id);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // GET: Producto/Create
    public IActionResult Create()
    {
        ViewData["NoCategoria"] = new SelectList(_context.Categorias, "NoCategoria", "Nombre");
        return View();
    }

    // POST: Producto/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NoProducto,Nombre,Descripcion,Stock,Precio,NoCategoria")] Producto producto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["NoCategoria"] = new SelectList(_context.Categorias, "NoCategoria", "Nombre", producto.NoCategoria);
        return View(producto);
    }

    // GET: Producto/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var producto = await _context.Productos.FindAsync(id);
    //    if (producto == null)
    //    {
    //        return NotFound();
    //    }

    //    ViewData["NoCategoria"] = new SelectList(_context.Categorias, "NoCategoria", "Nombre", producto.NoCategoria);
    //    return View(producto);
    //}

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        var response = Json(new { producto });

        return response;
    }

    // POST: Producto/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind("NoProducto,Nombre,Descripcion,Stock,Precio,NoCategoria")] Producto producto)
    {
        if (producto.NoProducto <= 0)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            
        }

        try
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(producto.NoProducto))
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

    // GET: Producto/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(m => m.NoProducto == id);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: Producto/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductoExists(int id)
    {
        return _context.Productos.Any(e => e.NoProducto == id);
    }
}
