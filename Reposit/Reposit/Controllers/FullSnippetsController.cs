﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reposit.Data;
using Reposit.Models;
using Reposit.Models.Interfaces;

namespace Reposit.Controllers
{
    public class FullSnippetsController : Controller
    {
        private readonly IFullSnippets _context;

        public FullSnippetsController(IFullSnippets context)
        {
            _context = context;
        }

        // GET: FullSnippets
        public async Task<IActionResult> Index(int id)
        {
            List<FullSnippet> apiResults = await _context.GetSnippetsFromAPI();
            List<FullSnippet> webDb = await _context.GetSnippets();
            ViewModel output = new ViewModel();
            output.ApiSnippets = apiResults;
            output.WebDbSnippets = webDb;
            output.CategoryID = id;
            
            return View(output);
        }

        // GET: FullSnippets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FullSnippet fullSnippet = await _context.GetSnippet(id);

            if (fullSnippet == null)
            {
                return NotFound();
            }

            return View(fullSnippet);
        }

        // GET: FullSnippets/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.GetAllCategories(), "ID", "Title");
            return View();
        }

        // POST: FullSnippets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,CodeBody,Language,Notes,Author,CategoryID")] FullSnippet fullSnippet)
        {
            if (ModelState.IsValid)
            {
                await _context.AddSnippet(fullSnippet);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "FullSnippets", new { id = fullSnippet.ID });
            }
            return View(fullSnippet);
        }

        // GET: FullSnippets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FullSnippet fullSnippet = await _context.GetSnippet(id);
            if (fullSnippet == null)
            {
                return NotFound();
            }

            ViewData["CategoryID"] = new SelectList(_context.GetAllCategories(), "ID", "Title");
            return View(fullSnippet);
        }

        // POST: FullSnippets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,CodeBody,Language,Notes,Author,CategoryID")] FullSnippet fullSnippet, int categoryID)
        {
            if (id != fullSnippet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateSnippet(fullSnippet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FullSnippetExists(fullSnippet.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "Categories", new { id = categoryID });
            }

            return View(fullSnippet);
        }

        // GET: FullSnippets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fullSnippet = await _context.GetSnippet(id);

            if (fullSnippet == null)
            {
                return NotFound();
            }

            return View(fullSnippet);
        }

        // POST: FullSnippets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int categoryID)
        {
            await _context.DeleteSnippet(id);
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Categories", new { id = categoryID });
        }

        private bool FullSnippetExists(int id)
        {
            return _context.GetSnippet(id) != null;
        }
    }
}
