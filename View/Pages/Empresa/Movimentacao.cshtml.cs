using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistencia;

namespace View.Pages.Empresa
{
    public class MovimentacaoModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public MovimentacaoModel(Persistencia.Context context)
        {
            _context = context;
        }

        public IList<ProdutoMovimentacao> ProdutoMovimentacao { get; set; }
        public Modelo.Empresa Empresa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? idEmpresa)
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

            ProdutoMovimentacao = await _context.ProdutoMovimentacao
                .Include(p => p.IdEmpresaNavigation)
                .Include(p => p.IdProdutoNavigation)
                .Where(x => x.IdEmpresa == Empresa.Id)
                .ToListAsync();

            return Page();
        }
    }
}
