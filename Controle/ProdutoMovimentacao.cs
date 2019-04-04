using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle
{
    class ProdutoMovimentacao : Geral<Modelo.Empresa>, IGeral<Modelo.Empresa>
    {
        public new Modelo.ProdutoMovimentacao GetById(int id)
        {
            return _dbContext.ProdutoMovimentacao.FirstOrDefault(e => e.Id == id);
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
    }
}
