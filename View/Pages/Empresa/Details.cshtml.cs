﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public DetailsModel(Persistencia.Context context)
        {
            _context = context;
        }

        public Modelo.Empresa Empresa { get; set; }
        public IList<ProdutoEstoque> ProdutoEstoque { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empresa = await _context.Empresa.FirstOrDefaultAsync(m => m.Id == id);

            if (Empresa == null)
            {
                return NotFound();
            }

            ProdutoEstoque = await _context.ProdutoEstoque
                .Include(p => p.IdEmpresaNavigation)
                .Include(p => p.IdProdutoNavigation).Where(x => x.IdEmpresa == id).ToListAsync();

            if(ProdutoEstoque == null)
            {
                ProdutoEstoque = new List<ProdutoEstoque>();
            }

            return Page();
        }
    }
}
