using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistencia;

namespace View.Pages.NewFolder
{
    public class DeleteModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public DeleteModel(Persistencia.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdutoEstoque ProdutoEstoque { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProdutoEstoque = await _context.ProdutoEstoque
                .Include(p => p.IdEmpresaNavigation)
                .Include(p => p.IdProdutoNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (ProdutoEstoque == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProdutoEstoque = await _context.ProdutoEstoque.FindAsync(id);

            if (ProdutoEstoque != null)
            {
                _context.ProdutoEstoque.Remove(ProdutoEstoque);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
