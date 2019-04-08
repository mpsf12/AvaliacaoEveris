using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo;
using Persistencia;

namespace View.Pages.NewFolder
{
    public class CreateModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public CreateModel(Persistencia.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
        ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "NomeProduto");
            return Page();
        }

        [BindProperty]
        public ProdutoEstoque ProdutoEstoque { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProdutoEstoque.Add(ProdutoEstoque);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}