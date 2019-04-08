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
    public class IndexModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public IndexModel(Persistencia.Context context)
        {
            _context = context;
        }

        public IList<ProdutoEstoque> ProdutoEstoque { get;set; }

        public async Task OnGetAsync()
        {
            ProdutoEstoque = await _context.ProdutoEstoque
                .Include(p => p.IdEmpresaNavigation)
                .Include(p => p.IdProdutoNavigation).ToListAsync();
        }
    }
}
