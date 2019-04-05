using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controle
{
    public class ProdutoMovimentacao : Geral<Modelo.ProdutoMovimentacao>, IGeral<Modelo.ProdutoMovimentacao>
    {
        public new Modelo.ProdutoMovimentacao GetById(int id)
        {
            return _dbContext.ProdutoMovimentacao.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Modelo.ProdutoMovimentacao> GetByIdAsync(int id)
        {
            return await _dbContext.ProdutoMovimentacao.FirstOrDefaultAsync(e => e.Id == id);
        }

        public List<Modelo.ProdutoMovimentacao> ManutencaoPorProdutoEEmpresa(Modelo.Produto produto, Modelo.Empresa empresa)
        {
            return _dbContext.ProdutoMovimentacao.Where(x => x.IdEmpresa == empresa.Id && x.IdProduto == produto.Id).ToList();
        }

        public List<Modelo.ProdutoMovimentacao> ManutencaoPorEmpresa(Modelo.Empresa empresa)
        {
            return _dbContext.ProdutoMovimentacao.Where(x => x.IdEmpresa == empresa.Id).ToList();
        }

        public List<Modelo.ProdutoMovimentacao> ManutencaoPorEmpresa(int idEmpresa)
        {
            return _dbContext.ProdutoMovimentacao.Where(x => x.IdEmpresa == idEmpresa).ToList();
        }

        public void Salvar(Modelo.ProdutoMovimentacao produtoEstoque)
        {
            if (produtoEstoque.Id == 0)
                Create(produtoEstoque);
            else Update(produtoEstoque);
        }
    }
}
