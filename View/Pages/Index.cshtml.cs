﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistencia;

namespace View.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public IndexModel(Persistencia.Context context)
        {
            _context = context;
        }

        public IList<ProdutoMovimentacao> ProdutoMovimentacao { get;set; }

        public async Task OnGetAsync()
        {
            ProdutoMovimentacao = await _context.ProdutoMovimentacao
                .Include(p => p.IdEmpresaNavigation)
                .Include(p => p.IdProdutoNavigation).ToListAsync();
        }
    }
}
