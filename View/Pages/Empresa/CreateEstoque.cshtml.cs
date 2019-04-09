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
    public class CreateEstoqueModel : PageModel
    {
        private readonly Persistencia.Context _context;

        public CreateEstoqueModel(Persistencia.Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? idEmpresa)
        {
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "NomeProduto");
            Empresa = await _context.Empresa.FirstOrDefaultAsync(x => x.Id == idEmpresa);
            return Page();
        }

        [BindProperty]
        public ProdutoEstoque ProdutoEstoque { get; set; }
        public static Modelo.Empresa Empresa { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var estoque = await _context.ProdutoEstoque.FirstOrDefaultAsync(x => x.IdProduto == ProdutoEstoque.IdProduto && x.IdEmpresa == Empresa.Id);
            if (estoque != null)
            {
                estoque.Estoque += ProdutoEstoque.Estoque;
                _context.Attach(estoque).State = EntityState.Modified;
                _context.ProdutoEstoque.Update(estoque);
            }
            else
            {
                _context.ProdutoEstoque.Add(ProdutoEstoque);
            }
            _context.ProdutoMovimentacao.Add(new ProdutoMovimentacao
            {
                Data = DateTime.Now,
                IdEmpresa = Empresa.Id,
                IdProduto = ProdutoEstoque.IdProduto,
                Movimentacao = ProdutoEstoque.Estoque
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}