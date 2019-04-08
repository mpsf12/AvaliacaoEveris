using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistencia;

namespace View.Pages.Empresa
{
    public class EditEstoqueModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public EditEstoqueModel(Persistencia.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdutoEstoque ProdutoEstoque { get; set; }

        [BindProperty]
        public Modelo.Empresa Empresa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? idEmpresa, int? id)
        {
            if (idEmpresa == null)
            {
                return NotFound();
            }

            Empresa = await _context.Empresa.FirstOrDefaultAsync(m => m.Id == idEmpresa);

            if (Empresa == null)
            {
                return NotFound();
            }

            if (id != null)
            {
                ProdutoEstoque = await _context.ProdutoEstoque
                    .Include(p => p.IdEmpresaNavigation)
                    .Include(p => p.IdProdutoNavigation).FirstOrDefaultAsync(m => m.Id == id);

                if (ProdutoEstoque == null)
                {
                    return NotFound();
                }
            }

            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "NomeProduto");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProdutoEstoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoEstoqueExists(ProdutoEstoque.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", "id="+Empresa.Id);
        }

        private bool ProdutoEstoqueExists(int id)
        {
            return _context.ProdutoEstoque.Any(e => e.Id == id);
        }
    }
}
