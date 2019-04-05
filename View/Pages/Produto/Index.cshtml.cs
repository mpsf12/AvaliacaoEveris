using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistencia;

namespace View.Pages.Produto
{
    public class IndexModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public IndexModel(Persistencia.Context context)
        {
            _context = context;
        }

        public IList<Modelo.Produto> Produto { get;set; }

        public async Task OnGetAsync()
        {
            Produto = await _context.Produto.ToListAsync();
        }
    }
}
