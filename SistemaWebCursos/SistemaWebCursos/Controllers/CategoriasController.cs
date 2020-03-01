﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWebCursos.Data;
using SistemaWebCursos.Models;

namespace SistemaWebCursos.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly SistemaWebCursosContext _context;

        public CategoriasController(SistemaWebCursosContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index(string sortOrden)
        {
            // GET: Categorias por orden ascendente o desendente
            ViewData["NombreSortParm"] = String.IsNullOrEmpty(sortOrden) ? "nombre_desc" : "";
            ViewData["DescripcionSortParm"] = sortOrden == "descripcion_asc" ? "descripcion_desc" : "descripcion_asc";

            var categorias = from s in _context.Categoria select s;

            switch (sortOrden)
            {
                case "nombre_desc": categorias = categorias.OrderByDescending(s => s.Nombre); break;
                case "descripcion_desc": categorias = categorias.OrderByDescending(s => s.Descripcion); break;
                case "descripcion_asc": categorias = categorias.OrderByDescending(s => s.Descripcion); break;
                default: categorias = categorias.OrderByDescending(s => s.Nombre); break;
            }

            return View(await categorias.AsNoTracking().ToListAsync());
            //return View(await _context.Categoria.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        /** POST: Categorias/Create. Metodos especificos para registrar un dato de categorias
        * To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        * more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        **/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaID,Nombre,Descripcion,Estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        /** POST: Categorias/Edit/5, Metodos que realizan la edicion de un registro de categoria
        * To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        * more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        **/    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaID,Nombre,Descripcion,Estado")] Categoria categoria)
        {
            if (id != categoria.CategoriaID)
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
                    if (!CategoriaExists(categoria.CategoriaID))
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

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5, Metodo que realiza la eliminacion de un registro de categoria
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.CategoriaID == id);
        }
    }
}
