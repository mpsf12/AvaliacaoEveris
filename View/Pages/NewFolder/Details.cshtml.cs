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
    public class DetailsModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public DetailsModel(Persistencia.Context context)
        {
            _context = context;
        }

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
    }
}
